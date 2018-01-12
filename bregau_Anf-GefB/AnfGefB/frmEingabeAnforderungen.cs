using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace AnfGefB
{
    public partial class frmEingabeAnforderungen : Form
    {
        BE_Rechtslage_GefaehrdungsbeurteilungEntities _context;
        Anforderungen currentAnforderung = null;

        public frmEingabeAnforderungen()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new BE_Rechtslage_GefaehrdungsbeurteilungEntities();

            var lstAnforderungen = _context.Anforderungen.Include(b => b.Bezug).Include(g => g.Gefährdungsfaktoren).Include(g => g.Gesetze.Paragraphen).ToList();
           
            _context.Gesetze.Load();
            //_context.Paragraphen.Load();
            _context.Bezug.Load();
            _context.GefährdungsfaktorenKategorien.Include(g => g.Gefährdungsfaktoren).Load();

            this.anforderungenBindingSource.DataSource = lstAnforderungen;
            bsTest = new BindingSource(this.anforderungenBindingSource, "Gesetze");
            bsTest2 = new BindingSource(this.bsTest, "Paragraphen");

            //this.setParagraphenPool();

            //// OK:
            cboGesetz.DataSource = _context.Gesetze.Local.ToList();
            cboGesetz.DisplayMember = "Gesetz";
            cboGesetz.ValueMember = "ID";

            cboParagraph.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.anforderungenBindingSource, "Paragraph", true));
            cboParagraph.DisplayMember = "Paragraph";
            cboParagraph.ValueMember = "Paragraph";
            cboParagraph.DataSource = this.bsTest2;

            cboBAUAKategorien.DataSource = _context.GefährdungsfaktorenKategorien.Local.ToList();

            // OK, old Version, more overhead, needs manual update of DataSource in anforderungenBindingSource_CurrentChanged Event wie setParagraphenPool:
            //cboParagraph.DataSource = this.paragraphenBindingSource;
            //cboParagraph.DisplayMember = "Paragraph";
            //cboParagraph.ValueMember = "Paragraph";

            // Works nearly as expected. Can be adopted to needs
            //lstParagraph.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.anforderungenBindingSource, "Paragraph", true));
            //lstParagraph.DisplayMember = "Paragraph";
            //lstParagraph.ValueMember = "Paragraph";
            //lstParagraph.DataSource = this.bsTest2;

            lstBezuege.DisplayMember = "Bezug.BezugText";
            lstBezuege.ValueMember = "Bezug.ID";
            lstBezuege.DataSource = this.anforderungenBindingSource;

            lstFaktoren.DisplayMember = "Gefährdungsfaktoren.KategorieNummerGefährdungsfaktor";
            lstFaktoren.ValueMember = "Gefährdungsfaktoren.ID";
            lstFaktoren.DataSource = this.anforderungenBindingSource;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPopulateTable_Click(object sender, EventArgs e)
        {
            foreach (Anforderungen a in _context.Anforderungen.Local.Where(a => a.UebergeordneteID == null || a.UebergeordneteID == 0))
            {
                TreeNode tn = new TreeNode();
                tn.Text = a.ID.ToString();
                tn.Tag = a.ID;
                AddChildNodes(tn);
                treeAnforderungen.Nodes.Add(tn);
            }
        }

        private TreeNode AddChildNodes(TreeNode parent)
        {
            foreach (Anforderungen a in _context.Anforderungen.Local.Where(a => a.UebergeordneteID == (int)parent.Tag))
            {
                TreeNode tn = new TreeNode();
                tn.Text = a.ID.ToString();
                tn.Tag = a.ID;
                AddChildNodes(tn);
                parent.Nodes.Add(tn);
            }
            return parent;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
        }

        private void anforderungenBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            this.currentAnforderung = (Anforderungen)anforderungenBindingSource.Current;
            //this.setParagraphenPool();
            this.setBezuegePool();
            this.setFaktorenPool();
        }

        /// <summary>
        /// Sets the Data Source of the Binding Source for Paragraphen according to the currently selected Gesetz
        /// </summary>
        private void setParagraphenPool()
        {
            this.paragraphenBindingSource.DataSource = _context.Paragraphen.Local.ToBindingList().Where(p => p.GesetzID == ((Anforderungen)this.anforderungenBindingSource.Current).GesetzID);
        }

        private void setBezuegePool()
        {
            int[] intBezuege = currentAnforderung.Bezug.Select(b => b.ID).ToArray();
            this.lstBezuegePool.DataSource = _context.Bezug.Local.Where(b => !intBezuege.Contains(b.ID)).ToList();
        }

        private void setFaktorenPool()
        {
            if (this.cboBAUAKategorien.SelectedIndex != -1)
            {
                int[] intFaktoren = currentAnforderung.Gefährdungsfaktoren.Select(g => g.ID).ToArray();
                this.lstFaktorenPool.DataSource = _context.Gefährdungsfaktoren.Local.Where(k => k.Kategorie == ((int)this.cboBAUAKategorien.SelectedValue)).Where(n => !intFaktoren.Contains(n.ID)).ToList();
            }
        }

        private void btnAddBezug_Click(object sender, EventArgs e)
        {
            if (lstBezuegePool.SelectedIndex != -1)
            {
                currentAnforderung.Bezug.Add((Bezug)lstBezuegePool.SelectedItem);
                this.setBezuegePool();
            }
        }

        private void btnRemoveBezug_Click(object sender, EventArgs e)
        {
            if (lstBezuege.SelectedIndex != -1)
            {
                currentAnforderung.Bezug.Remove((Bezug)lstBezuege.SelectedItem);
                this.setBezuegePool();
            }
        }

        private void cboBAUAKategorien_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setFaktorenPool();
        }

        private void btnFaktorAdd_Click(object sender, EventArgs e)
        {
            if (lstFaktorenPool.SelectedIndex != -1)
            {
                currentAnforderung.Gefährdungsfaktoren.Add((Gefährdungsfaktoren)lstFaktorenPool.SelectedItem);
                this.setFaktorenPool();
            }
        }

        private void btnFaktorRemove_Click(object sender, EventArgs e)
        {
            if (lstFaktoren.SelectedIndex != -1)
            {
                currentAnforderung.Gefährdungsfaktoren.Remove((Gefährdungsfaktoren)lstFaktoren.SelectedItem);
                this.setFaktorenPool();
            }
        }
    }
}
