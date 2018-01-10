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

        public frmEingabeAnforderungen()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new BE_Rechtslage_GefaehrdungsbeurteilungEntities();
            _context.Anforderungen.Include(b => b.Bezug).Include(b => b.Gesetze.Paragraphen).Load();
            _context.Gesetze.Load();
            _context.Paragraphen.Load();
            _context.Bezug.Load();

            this.anforderungenBindingSource.DataSource = _context.Anforderungen.Local.ToBindingList();
            var temp = _context.Anforderungen.Local.ToBindingList().Select(p => p.Gesetze.Paragraphen);
            this.paragraphenBindingSource1.DataSource = temp;
            this.setParagraphenPool();

            // OK:
            cboGesetz.DataSource = _context.Gesetze.Local.ToList();
            cboGesetz.DisplayMember = "Gesetz";
            cboGesetz.ValueMember = "ID";

            cboParagraph.DataSource = this.paragraphenBindingSource;
            cboParagraph.DisplayMember = "Paragraph";
            cboParagraph.ValueMember = "Paragraph";

            //cboTest.DataSource = this.anforderungenBindingSource;
            //cboTest.DisplayMember = "Gesetze.Paragraphen.Paragraph";
            //cboTest.ValueMember = "Gesetze.Paragraphen.Paragraph";


            


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
            //Anforderungen temp = (Anforderungen) this.bindingSource1.Current;
            //List<Paragraphen> tempPar = temp.Gesetze.Paragraphen.ToList();
            //string qryString = "SELECT Paragraph FROM Paragraphen WHERE GesetzID= " + temp.GesetzID.ToString();
            //int[] tempParAsInt = _context.Database.SqlQuery<int>(qryString).ToArray<int>();
            //var temp = ((Anforderungen)this.bindingSource1.Current).Gesetze.ParagraphenListe;
            var temp = ((Anforderungen)this.anforderungenBindingSource.Current).Bezug.Select( b => b.BezugText).ToArray();
            this.lstBezuege.Items.Clear();
            this.lstBezuege.Items.AddRange(temp);
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
        }

        private void anforderungenBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            this.setParagraphenPool();
        }

        /// <summary>
        /// Sets the Data Source of the Binding Source for Paragraphen according to the currently selected Gesetz
        /// </summary>
        private void setParagraphenPool()
        {
            this.paragraphenBindingSource.DataSource = _context.Paragraphen.Local.ToBindingList().Where(p => p.GesetzID == ((Anforderungen)this.anforderungenBindingSource.Current).GesetzID);
        }
    }
}
