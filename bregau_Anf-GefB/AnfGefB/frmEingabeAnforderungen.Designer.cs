namespace AnfGefB
{
    partial class frmEingabeAnforderungen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label anforderungenTextLabel;
            System.Windows.Forms.Label kurzformLabel;
            System.Windows.Forms.Label paragraphLabel;
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label paragraphLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEingabeAnforderungen));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboParagraph = new System.Windows.Forms.ComboBox();
            this.btnEditParagraph = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBezug = new System.Windows.Forms.TabPage();
            this.tabGFaktor = new System.Windows.Forms.TabPage();
            this.tabDaten = new System.Windows.Forms.TabPage();
            this.lblID = new System.Windows.Forms.Label();
            this.cboGesetz = new System.Windows.Forms.ComboBox();
            this.paragraphTextBox = new System.Windows.Forms.TextBox();
            this.anforderungenTextTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnPopulateTable = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gesetzeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.anforderungenDataGridView = new System.Windows.Forms.DataGridView();
            this.anforderungenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            anforderungenTextLabel = new System.Windows.Forms.Label();
            kurzformLabel = new System.Windows.Forms.Label();
            paragraphLabel = new System.Windows.Forms.Label();
            iDLabel = new System.Windows.Forms.Label();
            paragraphLabel1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gesetzeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anforderungenDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anforderungenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // anforderungenTextLabel
            // 
            anforderungenTextLabel.AutoSize = true;
            anforderungenTextLabel.Location = new System.Drawing.Point(12, 79);
            anforderungenTextLabel.Name = "anforderungenTextLabel";
            anforderungenTextLabel.Size = new System.Drawing.Size(83, 13);
            anforderungenTextLabel.TabIndex = 0;
            anforderungenTextLabel.Text = "Anforderungen :";
            // 
            // kurzformLabel
            // 
            kurzformLabel.AutoSize = true;
            kurzformLabel.Location = new System.Drawing.Point(11, 16);
            kurzformLabel.Name = "kurzformLabel";
            kurzformLabel.Size = new System.Drawing.Size(43, 13);
            kurzformLabel.TabIndex = 2;
            kurzformLabel.Text = "Gesetz:";
            // 
            // paragraphLabel
            // 
            paragraphLabel.AutoSize = true;
            paragraphLabel.Location = new System.Drawing.Point(395, 17);
            paragraphLabel.Name = "paragraphLabel";
            paragraphLabel.Size = new System.Drawing.Size(59, 13);
            paragraphLabel.TabIndex = 4;
            paragraphLabel.Text = "Paragraph:";
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(665, 17);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(21, 13);
            iDLabel.TabIndex = 6;
            iDLabel.Text = "ID:";
            // 
            // paragraphLabel1
            // 
            paragraphLabel1.AutoSize = true;
            paragraphLabel1.Location = new System.Drawing.Point(395, 51);
            paragraphLabel1.Name = "paragraphLabel1";
            paragraphLabel1.Size = new System.Drawing.Size(59, 13);
            paragraphLabel1.TabIndex = 13;
            paragraphLabel1.Text = "Paragraph:";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(849, 489);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.anforderungenDataGridView, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 677);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(paragraphLabel1);
            this.panel1.Controls.Add(this.cboParagraph);
            this.panel1.Controls.Add(this.btnEditParagraph);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.cboGesetz);
            this.panel1.Controls.Add(iDLabel);
            this.panel1.Controls.Add(paragraphLabel);
            this.panel1.Controls.Add(this.paragraphTextBox);
            this.panel1.Controls.Add(kurzformLabel);
            this.panel1.Controls.Add(anforderungenTextLabel);
            this.panel1.Controls.Add(this.anforderungenTextTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 603);
            this.panel1.TabIndex = 4;
            // 
            // cboParagraph
            // 
            this.cboParagraph.FormattingEnabled = true;
            this.cboParagraph.Location = new System.Drawing.Point(460, 48);
            this.cboParagraph.Name = "cboParagraph";
            this.cboParagraph.Size = new System.Drawing.Size(100, 21);
            this.cboParagraph.TabIndex = 14;
            // 
            // btnEditParagraph
            // 
            this.btnEditParagraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditParagraph.Image = global::AnfGefB.Properties.Resources.Document_16x;
            this.btnEditParagraph.Location = new System.Drawing.Point(566, 7);
            this.btnEditParagraph.Name = "btnEditParagraph";
            this.btnEditParagraph.Size = new System.Drawing.Size(33, 33);
            this.btnEditParagraph.TabIndex = 13;
            this.btnEditParagraph.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBezug);
            this.tabControl1.Controls.Add(this.tabGFaktor);
            this.tabControl1.Controls.Add(this.tabDaten);
            this.tabControl1.Location = new System.Drawing.Point(19, 170);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 182);
            this.tabControl1.TabIndex = 12;
            // 
            // tabBezug
            // 
            this.tabBezug.Location = new System.Drawing.Point(4, 22);
            this.tabBezug.Name = "tabBezug";
            this.tabBezug.Padding = new System.Windows.Forms.Padding(3);
            this.tabBezug.Size = new System.Drawing.Size(537, 156);
            this.tabBezug.TabIndex = 0;
            this.tabBezug.Text = "Gefährdungsbezug";
            this.tabBezug.UseVisualStyleBackColor = true;
            // 
            // tabGFaktor
            // 
            this.tabGFaktor.Location = new System.Drawing.Point(4, 22);
            this.tabGFaktor.Name = "tabGFaktor";
            this.tabGFaktor.Padding = new System.Windows.Forms.Padding(3);
            this.tabGFaktor.Size = new System.Drawing.Size(537, 156);
            this.tabGFaktor.TabIndex = 1;
            this.tabGFaktor.Text = "Gefährdungsfaktoren";
            this.tabGFaktor.UseVisualStyleBackColor = true;
            // 
            // tabDaten
            // 
            this.tabDaten.Location = new System.Drawing.Point(4, 22);
            this.tabDaten.Name = "tabDaten";
            this.tabDaten.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaten.Size = new System.Drawing.Size(537, 156);
            this.tabDaten.TabIndex = 2;
            this.tabDaten.Text = "Daten";
            this.tabDaten.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.Window;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anforderungenBindingSource, "ID", true));
            this.lblID.Location = new System.Drawing.Point(692, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(75, 20);
            this.lblID.TabIndex = 11;
            // 
            // cboGesetz
            // 
            this.cboGesetz.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.anforderungenBindingSource, "GesetzID", true));
            this.cboGesetz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGesetz.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboGesetz.FormattingEnabled = true;
            this.cboGesetz.Location = new System.Drawing.Point(69, 13);
            this.cboGesetz.Name = "cboGesetz";
            this.cboGesetz.Size = new System.Drawing.Size(286, 21);
            this.cboGesetz.TabIndex = 8;
            // 
            // paragraphTextBox
            // 
            this.paragraphTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anforderungenBindingSource, "Paragraph", true));
            this.paragraphTextBox.Location = new System.Drawing.Point(460, 14);
            this.paragraphTextBox.Name = "paragraphTextBox";
            this.paragraphTextBox.Size = new System.Drawing.Size(100, 20);
            this.paragraphTextBox.TabIndex = 5;
            // 
            // anforderungenTextTextBox
            // 
            this.anforderungenTextTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anforderungenBindingSource, "AnforderungenText", true));
            this.anforderungenTextTextBox.Location = new System.Drawing.Point(15, 95);
            this.anforderungenTextTextBox.Multiline = true;
            this.anforderungenTextTextBox.Name = "anforderungenTextTextBox";
            this.anforderungenTextTextBox.Size = new System.Drawing.Size(545, 57);
            this.anforderungenTextTextBox.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLoadData);
            this.flowLayoutPanel1.Controls.Add(this.btnPopulateTable);
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(920, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Enabled = false;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadData.Location = new System.Drawing.Point(3, 3);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(113, 33);
            this.btnLoadData.TabIndex = 8;
            this.btnLoadData.Text = "Load data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnPopulateTable
            // 
            this.btnPopulateTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopulateTable.Location = new System.Drawing.Point(122, 3);
            this.btnPopulateTable.Name = "btnPopulateTable";
            this.btnPopulateTable.Size = new System.Drawing.Size(113, 33);
            this.btnPopulateTable.TabIndex = 4;
            this.btnPopulateTable.Text = "Info about ";
            this.btnPopulateTable.UseVisualStyleBackColor = true;
            this.btnPopulateTable.Click += new System.EventHandler(this.btnPopulateTable_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::AnfGefB.Properties.Resources.Close_12x;
            this.btnClose.Location = new System.Drawing.Point(241, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(144)))));
            this.flowLayoutPanel2.Controls.Add(this.lblHeading);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(920, 39);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(3, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(179, 33);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Anforderungen";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 702);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(926, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(926, 677);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(926, 702);
            this.toolStripContainer1.TabIndex = 8;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.bindingNavigator1);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.anforderungenBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(264, 25);
            this.bindingNavigator1.TabIndex = 0;
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Neu hinzufügen";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(44, 22);
            this.bindingNavigatorCountItem.Text = "von {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente.";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Löschen";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Erste verschieben";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Vorherige verschieben";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Aktuelle Position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Nächste verschieben";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Letzte verschieben";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // anforderungenDataGridView
            // 
            this.anforderungenDataGridView.AutoGenerateColumns = false;
            this.anforderungenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.anforderungenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.anforderungenDataGridView.DataSource = this.anforderungenBindingSource;
            this.anforderungenDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anforderungenDataGridView.Location = new System.Drawing.Point(3, 702);
            this.anforderungenDataGridView.Name = "anforderungenDataGridView";
            this.anforderungenDataGridView.Size = new System.Drawing.Size(920, 198);
            this.anforderungenDataGridView.TabIndex = 14;
            // 
            // anforderungenBindingSource
            // 
            this.anforderungenBindingSource.DataSource = typeof(AnfGefB.Anforderungen);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "GesetzID";
            this.dataGridViewTextBoxColumn2.HeaderText = "GesetzID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Paragraph";
            this.dataGridViewTextBoxColumn3.HeaderText = "Paragraph";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UebergeordneteID";
            this.dataGridViewTextBoxColumn4.HeaderText = "UebergeordneteID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AnforderungenText";
            this.dataGridViewTextBoxColumn5.HeaderText = "AnforderungenText";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Besondere_Fachkunde";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Besondere_Fachkunde";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Daten";
            this.dataGridViewTextBoxColumn6.HeaderText = "Daten";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Gesetze";
            this.dataGridViewTextBoxColumn7.HeaderText = "Gesetze";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Bezug";
            this.dataGridViewTextBoxColumn8.HeaderText = "Bezug";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Gefährdungsfaktoren";
            this.dataGridViewTextBoxColumn9.HeaderText = "Gefährdungsfaktoren";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // frmEingabeAnforderungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 724);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmEingabeAnforderungen";
            this.Text = "frmEingabeAnforderungen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gesetzeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anforderungenDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anforderungenBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnPopulateTable;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.TextBox paragraphTextBox;
        private System.Windows.Forms.TextBox anforderungenTextTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gesetzIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paragraphDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uebergeordneteIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anforderungenTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn besondereFachkundeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datenDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource gesetzeBindingSource;
        private System.Windows.Forms.ComboBox cboGesetz;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBezug;
        private System.Windows.Forms.TabPage tabGFaktor;
        private System.Windows.Forms.TabPage tabDaten;
        private System.Windows.Forms.Button btnEditParagraph;
        private System.Windows.Forms.ComboBox cboParagraph;
        private System.Windows.Forms.BindingSource anforderungenBindingSource;
        private System.Windows.Forms.DataGridView anforderungenDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}