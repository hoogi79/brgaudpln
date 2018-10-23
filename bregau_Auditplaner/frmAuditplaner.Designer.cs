namespace bregau_AuditplanerWPF
{
    partial class frmAuditplaner
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnuStripMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verbindenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erzeugeLogMeldungWARNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setzteProgressAuf1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aESEncryptTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stsStripMain = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mnuStripMain.SuspendLayout();
            this.stsStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStripMain
            // 
            this.mnuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.administrationToolStripMenuItem});
            this.mnuStripMain.Location = new System.Drawing.Point(0, 0);
            this.mnuStripMain.Name = "mnuStripMain";
            this.mnuStripMain.Size = new System.Drawing.Size(774, 24);
            this.mnuStripMain.TabIndex = 1;
            this.mnuStripMain.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verbindenToolStripMenuItem,
            this.öffnenToolStripMenuItem,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // verbindenToolStripMenuItem
            // 
            this.verbindenToolStripMenuItem.Enabled = false;
            this.verbindenToolStripMenuItem.Name = "verbindenToolStripMenuItem";
            this.verbindenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verbindenToolStripMenuItem.Text = "Verbinden";
            this.verbindenToolStripMenuItem.Click += new System.EventHandler(this.verbindenToolStripMenuItem_Click);
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datenbankToolStripMenuItem,
            this.dateiToolStripMenuItem1});
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            // 
            // datenbankToolStripMenuItem
            // 
            this.datenbankToolStripMenuItem.Name = "datenbankToolStripMenuItem";
            this.datenbankToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.datenbankToolStripMenuItem.Text = "Datenbank";
            this.datenbankToolStripMenuItem.Click += new System.EventHandler(this.datenbankToolStripMenuItem_Click);
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.Enabled = false;
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.dateiToolStripMenuItem1.Text = "Datei";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erzeugeLogMeldungWARNToolStripMenuItem,
            this.setzteProgressAuf1ToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // erzeugeLogMeldungWARNToolStripMenuItem
            // 
            this.erzeugeLogMeldungWARNToolStripMenuItem.Name = "erzeugeLogMeldungWARNToolStripMenuItem";
            this.erzeugeLogMeldungWARNToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.erzeugeLogMeldungWARNToolStripMenuItem.Text = "Erzeuge Log-Meldung [WARN]";
            this.erzeugeLogMeldungWARNToolStripMenuItem.Click += new System.EventHandler(this.erzeugeLogMeldungWARNToolStripMenuItem_Click);
            // 
            // setzteProgressAuf1ToolStripMenuItem
            // 
            this.setzteProgressAuf1ToolStripMenuItem.CheckOnClick = true;
            this.setzteProgressAuf1ToolStripMenuItem.Name = "setzteProgressAuf1ToolStripMenuItem";
            this.setzteProgressAuf1ToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.setzteProgressAuf1ToolStripMenuItem.Text = "Setzte Progress auf -1";
            this.setzteProgressAuf1ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.setzteProgressAuf1ToolStripMenuItem_CheckStateChanged);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.aESEncryptTesterToolStripMenuItem,
            this.datenbankToolStripMenuItem1});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.administrationToolStripMenuItem.Text = "Installation";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(302, 6);
            // 
            // aESEncryptTesterToolStripMenuItem
            // 
            this.aESEncryptTesterToolStripMenuItem.Name = "aESEncryptTesterToolStripMenuItem";
            this.aESEncryptTesterToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.aESEncryptTesterToolStripMenuItem.Text = "Standard Verbindungszeichenfolge erstellen";
            this.aESEncryptTesterToolStripMenuItem.Click += new System.EventHandler(this.aESEncryptTesterToolStripMenuItem_Click);
            // 
            // datenbankToolStripMenuItem1
            // 
            this.datenbankToolStripMenuItem1.Name = "datenbankToolStripMenuItem1";
            this.datenbankToolStripMenuItem1.Size = new System.Drawing.Size(305, 22);
            this.datenbankToolStripMenuItem1.Text = "Datenbank";
            this.datenbankToolStripMenuItem1.Click += new System.EventHandler(this.datenbankToolStripMenuItem1_Click);
            // 
            // stsStripMain
            // 
            this.stsStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.stsStripMain.Location = new System.Drawing.Point(0, 451);
            this.stsStripMain.Name = "stsStripMain";
            this.stsStripMain.Size = new System.Drawing.Size(774, 22);
            this.stsStripMain.TabIndex = 2;
            this.stsStripMain.Text = "statusStrip1";
            this.stsStripMain.DoubleClick += new System.EventHandler(this.stsStripMain_DoubleClick);
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(400, 17);
            this.toolStripStatusLabel1.Text = "Willkommen zum bregau-Audiplaner";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(774, 25);
            this.toolStripMain.TabIndex = 4;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // frmAuditplaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 473);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.stsStripMain);
            this.Controls.Add(this.mnuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuStripMain;
            this.Name = "frmAuditplaner";
            this.Text = "bregau Auditplaner alpha";
            this.Load += new System.EventHandler(this.frmAuditplaner_Load);
            this.mnuStripMain.ResumeLayout(false);
            this.mnuStripMain.PerformLayout();
            this.stsStripMain.ResumeLayout(false);
            this.stsStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuStripMain;
        private System.Windows.Forms.StatusStrip stsStripMain;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erzeugeLogMeldungWARNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setzteProgressAuf1ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verbindenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aESEncryptTesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datenbankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem datenbankToolStripMenuItem1;
    }
}

