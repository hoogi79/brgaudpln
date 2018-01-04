using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bregau_AuditplanerWPF.Admin
{
    public partial class frmVerbindungseinstellungen : Form
    {
        private string[] serverList;
        private Tools.Encryption.AESEncrypter aesCrypt = null;
        private System.Data.SqlClient.SqlConnectionStringBuilder connectionStringBuilder = null;

        private bool validServer = false;
        private bool validLogin = false;
        private bool validPassword = false; 
        private bool validDataBase = false;

        /// <summary>
        /// Gibt die in diesem Formular erzeugte Verbindungszeichenfolge zurück (Klartext) (Nach Dialog.OK)
        /// </summary>
        public string ConnectionString  { get; private set;}

        /// <summary>
        /// Ermöglicht das Speichern des verschlüsselten ConnectionStrings in eine Datei um sie von dort manuell als Ressource für die Benutzer vorzugeben
        /// </summary>
        public bool SaveToDisk { get; set; } = false;

        /// <summary>
        /// Erlaubt das Erstellen von neuen Datenbanken
        /// </summary>
        public bool AllowCreate { get; set; } = false;

        public System.Data.Entity.DbContext DbContext { get; private set; } = null;

        /// <summary>
        /// Überprüft die Eingaben der einzelnen Felder und gibt Steuerelement frei 
        /// </summary>
        private void ValidateSettings()
        {
            // Zustand der Felder prüfen. Die inhaltliche Gültigkeit der Werte wird (sollte) im Steuerelement Validating geprüft (werden).
            validServer = (cmbSQLServer.Text.Length > 0);
            validLogin = (txtLogin.Text.Length > 0);
            validPassword = (txtPassword.Text.Length > 0);
            validDataBase = (cmbDataBase.Text.Length > 0);

            bool validAll = validServer && validLogin && validPassword && validDataBase;

            // GUI entsprechend steuern
            btnSaveAs.Enabled = validAll;
            btnDBAbfragen.Enabled = (validServer && validLogin && validPassword);

            // Fehleranzeige zurücksetzen
            errorProvider1.Clear();
        }

        /// <summary>
        /// Lädt die Standard Verbindungszeichenfolge und füllt damit die Steuerelemente
        /// <param name="TryFromSettings">Gibt an, dass versucht werden soll einen Verbdinungsstring aus der Config Datei als Vorgabe zu laden.</param>
        /// </summary>
        private void LoadDefaultFrom(bool TryFromSettings = false)
        {
            string encryptedVerbindungString = null;
            if (TryFromSettings)
            {
                encryptedVerbindungString = bregau_AuditplanerWPF.Properties.Settings.Default.VerbindungString;
            }
            else
            {
                try
                {
                    encryptedVerbindungString = bregau_AuditplanerWPF.Properties.Resources.ResourceManager.GetString("Verbindung");
                }
                catch
                {
                    ValidateSettings();
                    return;
                }
            }
          
            Tools.Encryption.AESDataSet encryptedConnectionData;
            try
            {
                encryptedConnectionData = Tools.Encryption.AESDataSet.DeserializeXml(encryptedVerbindungString);
            }
            catch (Exception ex)
            {
                Program.mainLogger.AppendMessage(DateTime.Now, ex.Message, Tools.Logger.LogLevel.Error);
                ValidateSettings();
                return;
            }

            if (encryptedConnectionData != null)
            {
                aesCrypt = new Tools.Encryption.AESEncrypter(encryptedConnectionData.Key, encryptedConnectionData.IV);
                string decryptedConnectionString = Encoding.UTF8.GetString(aesCrypt.DecryptAES(encryptedConnectionData.Message));
                if (decryptedConnectionString?.Length > 0)
                {
                    try
                    {
                        connectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(decryptedConnectionString);
                        cmbSQLServer.Items.Clear();
                        cmbSQLServer.Items.Add(connectionStringBuilder.DataSource);
                        cmbSQLServer.SelectedIndex = 0;

                        cmbDataBase.Items.Clear();
                        cmbDataBase.Items.Add(connectionStringBuilder.InitialCatalog);
                        cmbDataBase.SelectedIndex = 0;

                        txtLogin.Text = connectionStringBuilder.UserID;
                        txtPassword.Text = connectionStringBuilder.Password;

                    }
                    catch (Exception ex)
                    {
                        Program.mainLogger.AppendMessage(DateTime.Now, ex.Message, Tools.Logger.LogLevel.Error);
                    }
                }
            }
            ValidateSettings();
        }

        public frmVerbindungseinstellungen(System.Data.Entity.DbContext dBContext, bool AdminMode = false)
        {
            if (DbContext == null)
                throw (new ArgumentNullException());
            InitializeComponent();
            this.DbContext = dBContext;
            this.SaveToDisk = AdminMode;
            this.AllowCreate = AdminMode;
            this.Text = AdminMode ? "Verbindungszeichenfolge erstellen" : " Eine Datenbank auswählen";
            btnReset.Visible = !AdminMode;  // Reset nur im Nicht-Admin-Modus anzeigen
        }


        private void frmVerbindungseinstellungen_Load(object sender, EventArgs e)
        {
            // Read: VerbindungString und Deserialize per Hand via XML
            this.LoadDefaultFrom(!this.SaveToDisk);
        }

        private void btnDBAbfragen_Click(object sender, EventArgs e)
        {
            cmbDataBase.Items.Clear();
            List<string> databases;
            System.Data.SqlClient.SqlConnectionStringBuilder sqsb = new System.Data.SqlClient.SqlConnectionStringBuilder();

            sqsb.DataSource = cmbSQLServer.Text;
            sqsb.UserID = txtLogin.Text;
            sqsb.Password = txtPassword.Text;
            sqsb.IntegratedSecurity = false;
            
            try
            {
                databases = Database.SQLInteractionManager.FindDataBase(sqsb.ConnectionString);
            } catch (Exception ex)
            {
                Program.mainLogger.AppendMessage(DateTime.Now, ex.Message, Tools.Logger.LogLevel.Error);
                return;
            }

            if (databases?.Count > 0)
            {
                cmbDataBase.Items.AddRange(databases.ToArray());
                cmbDataBase.SelectedIndex = 0;
            }
        }

        private void btnServerSuchen_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                // In eigenem Thread (backgroundWorker1) nach SQL Datenbanken suchen...
                btnServerSuchen.Visible = false;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (serverList?.Length > 0)
            {
                cmbSQLServer.Items.Clear();
                cmbSQLServer.Items.AddRange(serverList);
                if (cmbSQLServer.SelectedIndex == -1)
                    cmbSQLServer.SelectedIndex = 0;
            }
            btnServerSuchen.Visible = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                serverList = Database.SQLInteractionManager.FindSQLServers();
            } catch (Exception) {}
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            this.Close();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            bool isNewDataBase = false;

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            connectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = cmbSQLServer.Text;
            connectionStringBuilder.InitialCatalog = cmbDataBase.Text;
            connectionStringBuilder.UserID = txtLogin.Text;
            connectionStringBuilder.Password = txtPassword.Text;
            connectionStringBuilder.IntegratedSecurity = false;

            

            /* First check if database exists (or user has no right to "CONNECT"). */
            if (cmbDataBase.FindString(cmbDataBase.Text) == -1)
                if (!Database.SQLInteractionManager.checkExists(connectionStringBuilder.ConnectionString))
                {
                    if (this.AllowCreate)
                    {
                        DialogResult dr = System.Windows.Forms.MessageBox.Show("Datenbank erzeugen?", "Datenbank existiert nicht.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            Database.SQLInteractionManager.createDatabase(connectionStringBuilder.ConnectionString);
                            isNewDataBase = true;
                        }
                            
                        else
                            return;
                    }
                    else
                    {
                        errorProvider1.SetError(lblError, "Datenbank nicht gefunden");
                        btnSaveAs.DialogResult = DialogResult.None;
                        return;
                    }
                }
                           
            /* check if specified user has SELECT, INSERT, UPDATE and DELETE (herein aka FULL access)
             * if not, give error message and return
            */
            if (Database.SQLInteractionManager.checkFullAccessToDB(connectionStringBuilder.ConnectionString) == false)
            {
                errorProvider1.SetError(lblError, "Kein Vollzugriff auf diese Datenbank!");
                Console.WriteLine("Kein Vollzugriff auf diese Datenbank!");
                btnSaveAs.DialogResult = DialogResult.None;
                return;
            }
            else
            {
#if DEBUG
                Console.WriteLine("Hat vollen Zugriff. Setze DialogResult auf OK");
#endif
                btnSaveAs.DialogResult = DialogResult.OK;
            }

            // If database is not newly created, check if empty (and warn) 
            if (!isNewDataBase && Database.SQLInteractionManager.checkIfDbIsEmpty(connectionStringBuilder.ConnectionString))
            {
                DialogResult dr = System.Windows.Forms.MessageBox.Show
                    (
                        "Datenbank leer. Verwenden dieser Datenbank wird einen neuen Datenstand erzeugen",
                        "Datenbank ohne Daten.",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question
                        );
                if (dr == DialogResult.Cancel)
                    return;
            }

            if (aesCrypt == null)
                aesCrypt = new Tools.Encryption.AESEncrypter();

            byte[] encryptedConnectionString = aesCrypt.EncryptAES(Encoding.UTF8.GetBytes(connectionStringBuilder.ConnectionString));
            
            Tools.Encryption.AESDataSet encryptedConnectionData = aesCrypt.GetAESDataSet(encryptedConnectionString);
            string serializedECD = Tools.Encryption.AESDataSet.SerializeXml(encryptedConnectionData);

            Console.WriteLine(this.SaveToDisk.ToString());
            if (this.SaveToDisk)
            {
                saveFileDialog1.Title = "Bitte Speicherort auswählen";
                saveFileDialog1.Filter = "Text Dateien|*.txt|Alle Dateien|*.*";
                DialogResult dr = this.saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK && !String.IsNullOrWhiteSpace(saveFileDialog1.FileName))
                {
                    try
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                        {
                            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                            sw.Write(serializedECD);
                            sw.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Program.mainLogger.AppendMessage(DateTime.Now, ex.Message, Tools.Logger.LogLevel.Error);
                    }

                }
            }

            bregau_AuditplanerWPF.Properties.Settings.Default.VerbindungString = serializedECD;
            bregau_AuditplanerWPF.Properties.Settings.Default.Save();

            this.ConnectionString = connectionStringBuilder.ConnectionString;

        }

        private void txtLogin_Validating(object sender, CancelEventArgs e)
        {
            this.validLogin = (!String.IsNullOrWhiteSpace(txtLogin.Text));
            ValidateSettings();
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            this.validPassword = (!String.IsNullOrWhiteSpace(txtPassword.Text));
            ValidateSettings();
        }

        private void cmbSQLServer_Validating(object sender, CancelEventArgs e)
        {
            this.validServer = (!String.IsNullOrWhiteSpace(cmbSQLServer.Text));
            ValidateSettings();
        }

        private void cmbSQLServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.validServer = (cmbSQLServer.SelectedIndex != -1);
            this.cmbDataBase.Items.Clear();
            this.cmbDataBase.Text = "";
            this.validDataBase = false;
            ValidateSettings();
        }

        private void cmbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.validDataBase = (cmbDataBase.SelectedIndex != -1);
            ValidateSettings();
        }

        private void cmbDataBase_Validating(object sender, CancelEventArgs e)
        {
            this.validDataBase = !String.IsNullOrWhiteSpace(cmbDataBase.Text);
            ValidateSettings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadDefaultFrom();
        }
    }
}
