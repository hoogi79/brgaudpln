using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bregau_AuditplanerWPF
{
    static class Program
    {
        public static Tools.Logger.multiLogManager mainLogger;
        //public static System.Data.SqlClient.SqlConnection dataBaseConnection = null;
        public static string connectionString = null;


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            Program.connectionString = "Data Source = DHOOG-NB\\SQLEXPRESS; Initial Catalog = bregau_Auditplaner.Database.bregauDbContext; Integrated Security = False; User ID = sa; Password = da22gvz";
#endif
            Application.Run(new frmAuditplaner());
        }
    }
}
