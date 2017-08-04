using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace bregau_Auditplaner.Tools.Database
{
    class SQLInteractionManager
    {
        private static SqlDataSourceEnumerator instances = null;

        // New comment

        /// <summary>
        /// Sucht nach SQL Server Instanzen
        /// </summary>
        /// <returns>Gibt eine Liste von SQLServer Strings zurück die den Servernamen und die Instanz beinhalten</returns>
        public static string[] FindSQLServers()
        {
            instances = SqlDataSourceEnumerator.Instance;
            DataTable dtSources = instances.GetDataSources();
            List<string> retList = new List<string>();

            foreach (DataRow dr in dtSources.Rows)
                retList.Add(dr["ServerName"].ToString() + "\\" + dr["InstanceName"].ToString());
            return retList.ToArray();
        }

        public static List<string> FindDataBase(string Server, string Login, string Password)
        {
            List<string> retDBList = new List<string>();
            SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder();
            sqsb.Password = Password;
            sqsb.UserID = Login;
            sqsb.DataSource = Server;
            sqsb.IntegratedSecurity = false;

            DataTable tblDatabases;
            try
            {
                SqlConnection sqlConn = new SqlConnection(sqsb.ConnectionString);
                sqlConn.Open();
                tblDatabases = sqlConn.GetSchema("Databases");
                sqlConn.Close();
            } catch (Exception e)
            {
                throw (e);
            }
            
            foreach (DataRow row in tblDatabases.Rows)
            {
                retDBList.Add(row["database_name"].ToString());
            }
            return retDBList;
        }

        
    }
}
