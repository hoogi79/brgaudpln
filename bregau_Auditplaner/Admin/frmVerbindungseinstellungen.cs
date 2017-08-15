using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bregau_Auditplaner.Admin
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
        /// Gibt an ob nach dem Klicken auf OK ein FileSelect Dialog aufgerufen und der Verbindungsstring verschlüssel gespeichert werden soll.
        /// </summary>
        public bool DoSaveAs { get; set; } = true;

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

        public frmVerbindungseinstellungen()
        {
            InitializeComponent();
        }

        private void frmVerbindungseinstellungen_Load(object sender, EventArgs e)
        {
            // Read: VerbindungString und Deserialize per Hand via XML
            string encryptedVerbindungString = bregau_Auditplaner.Properties.Settings.Default.Verbindung;
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
                        cmbSQLServer.Items.Add(connectionStringBuilder.DataSource);
                        cmbSQLServer.SelectedIndex = 0;

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

        private void btnDBAbfragen_Click(object sender, EventArgs e)
        {
            cmbDataBase.Items.Clear();
            List<string> databases;
            try
            {
                databases = Tools.Database.SQLInteractionManager.FindDataBase(cmbSQLServer.Text, txtLogin.Text, txtPassword.Text);
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
                serverList = Tools.Database.SQLInteractionManager.FindSQLServers();
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
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            connectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = cmbSQLServer.Text;
            connectionStringBuilder.InitialCatalog = cmbDataBase.Text;
            connectionStringBuilder.UserID = txtLogin.Text;
            connectionStringBuilder.Password = txtPassword.Text;
            connectionStringBuilder.IntegratedSecurity = false;

            /* check if specified user has SELECT, INSERT, UPDATE and DELETE (herein aka FULL access)
             * if not, give error message and return
            */
            if (Tools.Database.SQLInteractionManager.checkFullAccessToDB(connectionStringBuilder.ConnectionString) == false)
            {
                errorProvider1.SetError(lblError, "Kein Vollzugriff auf diese Datenbank!");
                return;
            }
            else
                btnSaveAs.DialogResult = DialogResult.OK;
           
            if (aesCrypt == null)
                aesCrypt = new Tools.Encryption.AESEncrypter();

            byte[] encryptedConnectionString = aesCrypt.EncryptAES(Encoding.UTF8.GetBytes(connectionStringBuilder.ConnectionString));
            
            Tools.Encryption.AESDataSet encryptedConnectionData = new Tools.Encryption.AESDataSet();
            encryptedConnectionData = aesCrypt.GetAESDataSet(encryptedConnectionString);
            string serializedECD = Tools.Encryption.AESDataSet.SerializeXml(encryptedConnectionData);

            //bregau_Auditplaner.Properties.Settings.Default.Verbindung = encryptedConnectionData;
            //bregau_Auditplaner.Properties.Settings.Default.VerbindungString = serializedECD;
            //bregau_Auditplaner.Properties.Settings.Default.Save();

            if (this.DoSaveAs)
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


    }
}
