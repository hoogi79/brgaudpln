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
        private List<Anforderungen> AnforderungenSource = null;

        public frmEingabeAnforderungen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BE_Rechtslage_GefaehrdungsbeurteilungEntities context = new BE_Rechtslage_GefaehrdungsbeurteilungEntities();
            var fstAnforderung = context.Anforderungen.Find(209);
            if (fstAnforderung != null)
                textBox1.Text = fstAnforderung.ID.ToString() + ": " + fstAnforderung.AnforderungenText;
        }

        private void btnPopulateTable_Click(object sender, EventArgs e)
        {
            using (BE_Rechtslage_GefaehrdungsbeurteilungEntities context = new BE_Rechtslage_GefaehrdungsbeurteilungEntities())
            {
                this.AnforderungenSource= context.Anforderungen.Include(s => s.Gesetze).Include(s => s.Bezug).Include(s => s.Gefährdungsfaktoren).ToList();
                dataGridView1.DataSource = this.AnforderungenSource;
            }


        }
    }
}
