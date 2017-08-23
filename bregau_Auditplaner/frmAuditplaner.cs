using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bregau_Auditplaner
{
    public partial class frmAuditplaner : Form
    {
        public frmAuditplaner()
        {
            InitializeComponent();
        }

        private void frmAuditplaner_Load(object sender, EventArgs e)
        {
            // Logger aktivieren
            Program.mainLogger = new Tools.Logger.multiLogManager();
            Program.mainLogger.Add(new Tools.Logger.simpleLoggerForm() { LogLevel = Tools.Logger.LogLevel.Info });
            Program.mainLogger.Add(new Tools.Logger.progressLogger(this.toolStripStatusLabel1, this.toolStripProgressBar1, 10000));
            
        }

        #region Einträge Debug Menu ...
        private void erzeugeLogMeldungWARNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.mainLogger.AppendMessage(DateTime.Now, "Debugging Testnachricht", Tools.Logger.LogLevel.Warn);
        }

        private void setzteProgressAuf1ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.setzteProgressAuf1ToolStripMenuItem.CheckState == CheckState.Checked)
                Program.mainLogger.Progress = -1;
            else
                Program.mainLogger.Progress = 0;
        }

        #endregion

        private void stsStripMain_DoubleClick(object sender, EventArgs e)
        {
            Program.mainLogger.Show(this);
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sicherungen und beenden einer Verbindung, speicheren der Konfiguration einbauen ...
            this.Close();
        }


        /// <summary>
        /// (MenuItem_Click) Eine Verbindung zur Datenbank aufbauen und den Benutzer anmelden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verbindenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Prüfen ob bereits eigene Konfigurationsdateien angelegt wurden, in denen der Datenbankserver und weitere
            * Einstellungen die für den Start und die Anmeldung notwendig sind angegeben sind.
            * Dazu wird geprüft, ob in der Config-Datei der Wert UserConfigActivated auf wahr gesetzt wurde
           */
            //if (Properties.Settings.Default.DBServer==String.Empty || Properties.Settings.Default.Database==String.Empty)
            //{
            //    // Fenster mit Verbindungseinstellungen öffnen
            //    Admin.frmVerbindungseinstellungen verbindungseinstellungenForm = new Admin.frmVerbindungseinstellungen();
            //    //verbindungseinstellungenForm.MdiParent = this;
            //    DialogResult dr = verbindungseinstellungenForm.ShowDialog();
            //}
            //else
            //{
            //    // Verbidndung zum DB-Server testen und aufbauen.
            //}
        }

        private void aESEncryptTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.frmVerbindungseinstellungen formConnectionSetup = new Admin.frmVerbindungseinstellungen(AdminMode: true);
            formConnectionSetup.AllowCreate = true;
            formConnectionSetup.SaveToDisk = false;
            DialogResult dr =  formConnectionSetup.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Program.connectionString = formConnectionSetup.ConnectionString;
            }
            
        }

        private void datenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.frmVerbindungseinstellungen formConnectionSetup = new Admin.frmVerbindungseinstellungen(false);
        }

        private void datenbankToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           if (Program.connectionString != null)
            {
                Database.bregauDbContext bregauDbContext = new Database.bregauDbContext();
               
                bregauDbContext.Users.Add(new Database.Auth.User { Login = "Slytherin", Name = "Theo", FamilyName = "Test", PasswordHash="000" });
                bregauDbContext.SaveChanges();
            }
        }
    }
}
