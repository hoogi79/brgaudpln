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
                sqsb.InitialCatalog = row["database_name"].ToString();
                if (checkCanConnect(sqsb.ConnectionString))
                    retDBList.Add(row["database_name"].ToString());
            }
            return retDBList;
        }

        public static bool checkCanConnect(string connectionString)
        {
            SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder(connectionString);
            sqsb.ConnectTimeout = 5;
            try
            {
                SqlConnection sqlConn = new SqlConnection(sqsb.ConnectionString);
                sqlConn.Open();
                sqlConn.Close();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(SqlException))
                    if (((SqlException)e).Number == 4060 || ((SqlException)e).Number == 18456) // User has no access to CONECT (4060); User ID / Password Error (18456)
                        return false;
                throw (e);
            }
            return true;
        }

        public static bool checkFullAccessToDB(string connectionString)
        {
            AccessLevel access = AccessLevel.NONE;
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
                    String permissionString;
                    while (sdr.Read()&&access!=AccessLevel.FULL)
                    {
                        permissionString = sdr.GetString(2);
                        if (String.Equals(permissionString, "SELECT"))
                            access = (access | AccessLevel.SELECT);
                        if (String.Equals(permissionString, "INSERT"))
                            access = (access | AccessLevel.INSERT);
                        if (String.Equals(permissionString, "UPDATE"))
                            access = (access | AccessLevel.UPDATE);
                        if (String.Equals(permissionString, "DELETE"))
                            access = (access | AccessLevel.DELETE);
                    }
                }
                sqlConn.Close();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(SqlException))
                    if (((SqlException)e).Number == 4060||((SqlException)e).Number==18456) // User has no access to CONECT (4060); User ID / Password Error (18456)
                        return false;
                    throw (e);
            }
            return (access==AccessLevel.FULL);
        }

        public enum AccessLevel : byte { NONE=0, SELECT=1, INSERT=2, UPDATE=4, DELETE=8, FULL=15};
        
    }
}
