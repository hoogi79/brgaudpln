using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnfGefB
{
    class Anforderungen2TreeHelper
    {
        private static void AddChildNodes(TreeNode parent, IEnumerable<Anforderungen> anforderungenEnumeration)
        {
            TreeNode tn = null;
            foreach (Anforderungen a in anforderungenEnumeration.Where(a => a.UebergeordneteID == ((Anforderungen)parent.Tag).ID))
            {
                tn = CreateNode(a);
                AddChildNodes(tn, anforderungenEnumeration);
                parent.Nodes.Add(tn);
            }
        }

        private static TreeNode CreateNode(Anforderungen anf)
        {
            TreeNode tn = new TreeNode();
            tn.Text = "(" + anf.ID.ToString() + ") " + anf.Gesetze.Kurzform + " §" + anf.Paragraph.ToString();
            tn.Tag = anf;
            return tn;
        }

        public static void CreateTree (ref TreeView targetTree, IEnumerable<Anforderungen> anforderungenEnumeration)
        {
            TreeNode tn = null;
            foreach (Anforderungen a in anforderungenEnumeration.Where(a => a.UebergeordneteID == null || a.UebergeordneteID == 0))
            {
                tn = CreateNode(a);
                AddChildNodes(tn, anforderungenEnumeration);
                targetTree.Nodes.Add(tn);
            }
        }
    }
}
