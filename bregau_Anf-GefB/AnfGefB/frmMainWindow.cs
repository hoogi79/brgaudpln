using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnfGefB
{
    public partial class frmMainWindow : Form
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void anforderungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEingabeAnforderungen mdiAnforderungen = new frmEingabeAnforderungen();
            mdiAnforderungen.MdiParent = this;
            mdiAnforderungen.Show();
        }
    }
}
