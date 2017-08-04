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
            sqsb.ConnectTimeout = 5;

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

        public static bool checkFullAccessToDB(string connectionString)
        {
            SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder(connectionString);
            sqsb.ConnectTimeout = 5;

            try
            {
                SqlConnection sqlConn = new SqlConnection(sqsb.ConnectionString);
                sqlConn.Open();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM fn_my_permissions(\'dbo\', \'SCHEMA\')",sqlConn);
                SqlDataReader sdr;
                sdr = sqlCom.ExecuteReader();
                if (sdr.HasRows)
                {
                    DataTable schemaTable = sdr.GetSchemaTable();
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        foreach (DataColumn column in schemaTable.Columns)
                        {
                            Console.WriteLine(String.Format("{0} = {1}",
                               column.ColumnName, row[column]));
                        }
                    }
                }
                sqlConn.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            return true;
        }

        
    }
}
