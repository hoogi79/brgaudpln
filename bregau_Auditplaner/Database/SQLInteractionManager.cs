using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace bregau_AuditplanerWPF.Database
{
    class SQLInteractionManager
    {
        private static SqlDataSourceEnumerator instances = null;

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

        /// <summary>
        /// Sucht nach Datenbanken auf dem angegebenen Server 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>Gibt eine Liste von String zurück die die Namen der Datenbanken enthält.</returns>
        public static List<string> FindDataBase(string connectionString)
        {
            List<string> retDBList = new List<string>();
            SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder(connectionString);
            sqsb.ConnectTimeout = 5;
            sqsb.Remove("Initial Catalog");

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

        /// <summary>
        /// Prüft ob auf die Datanbank des ConnetionStrings zugegriffen werden kann
        /// </summary>
        /// <param name="connectionString">ConnectionString zur Datenbank</param>
        /// <returns>Gibt <c>wahr</c> zurück, falls Zugriff möglich.</returns>
        public static bool checkCanConnect(string connectionString)
        {
            SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder(connectionString);
            sqsb.ConnectTimeout = 5;
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(sqsb.ConnectionString);
                sqlConn.Open();
                sqlConn.Close();
            }
            catch (Exception e)
            {
                sqlConn.Close();
                if (e.GetType() == typeof(SqlException))
                    if (((SqlException)e).Number == 4060 || ((SqlException)e).Number == 18456) // User has no access to CONECT (4060); User ID / Password Error (18456)
                        return false;
                throw (e);
            }
            return true;
        }

        /// <summary>
        /// Prüft ob die im ConnectionString angegebene Datenbank existiert.
        /// </summary>
        /// <param name="connectionString">Ein ConnectionString mit der zu prüfenden Datenbank (Intial Catalog)</param>
        /// <returns>Gibt wahr zurück falls Datenbank existiert.</returns>
        public static bool checkExists(string connectionString)
        {
            bool returnValue = false;
            SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder(connectionString);
            string dbName = sqsb.InitialCatalog;
            sqsb.Remove("Initial Catalog");
            SqlConnection sqlConn = null;

            try
            {
                sqlConn = new SqlConnection(sqsb.ConnectionString);
                sqlConn.Open();

                SqlCommand sqlCom = new SqlCommand(string.Format("SET LOCK_TIMEOUT 2000; SELECT * FROM sys.databases WHERE name = N'{0}'", dbName.Trim().Replace(" ", "")), sqlConn);
                sqlCom.CommandTimeout = 5;
                SqlDataReader sdr = sqlCom.ExecuteReader();
                returnValue = sdr.HasRows;
                sqlConn.Close();
                return returnValue;
            }
            catch (Exception e)
            {
                sqlConn.Close();
                if (e.GetType() == typeof(SqlException))
                    if (((SqlException)e).Number == 4060 || ((SqlException)e).Number == 18456) // User has no access to CONECT (4060); User ID / Password Error (18456)
                        return returnValue;
                throw (e);
            }
        }

        /// <summary>
        /// Prüft den Vollzugriff auf die Datenbank
        /// </summary>
        /// <param name="connectionString">ConnectioString zur Datenbank</param>
        /// <returns>Gibt <c>wahr</c> zurück, falls vollständiger SELECT + CRUD Zugriff erlaubt.</returns>
        public static bool checkFullAccessToDB(string connectionString)
        {
            AccessLevel access = AccessLevel.NONE;
            //SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder(connectionString);

            try
            {
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                SqlCommand sqlCom = new SqlCommand("SELECT * FROM fn_my_permissions(\'dbo\', \'SCHEMA\')", sqlConn);
                SqlDataReader sdr;
                sqlCom.CommandTimeout = 5;
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

        /// <summary>
        /// Testet ob die im ConnectionString angegebene Datenbank leer, also ohne Tabellen ist.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>Gibt <c>wahr</c> zurück, falls die Tabelle leer ist.</returns>
        public static bool checkIfDbIsEmpty(string connectionString)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                SqlCommand sqlCom = new SqlCommand("SELECT COUNT(name)FROM sysobjects WHERE xtype = 'U'", sqlConn);
                SqlDataReader sdr;
                sqlCom.CommandTimeout = 5;
                sdr = sqlCom.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    if ((int)sdr[0] > 0)
                        return false;
                }
                sqlConn.Close();
            }
            catch { throw; }
            return true;
        }

        /// <summary>
        /// Erzeugt eine Datenbank mit dem im ConnectionString angegebenen Namen. 
        /// Es darf kein Lock auf die model Systemdatenbank bestehen. Auf eine Freigabe wird max. 2 s gewartet.
        /// </summary>
        /// <param name="connectionString">Der ConnectionString</param>
        /// <returns>Gibt den Erfolg des Anlegens zurück</returns>
        /// <exception cref="">Wirft eine Ausnahme falls der Lock nicht aufgehoben werden kann</exception>
        public static bool createDatabase(string connectionString)
        {
            SqlConnectionStringBuilder sqsb = new SqlConnectionStringBuilder(connectionString);
            sqsb.ConnectTimeout = 5;
            string dbName = sqsb.InitialCatalog;
            sqsb.Remove("Initial Catalog");
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(sqsb.ConnectionString);
                sqlConn.Open();

                //string queryString = string.Format("SET LOCK_TIMEOUT 2000; CREATE DATABASE {0}", dbName.Trim().Replace(" ", ""));
                string queryString = string.Format("SET LOCK_TIMEOUT 2000; IF NOT EXISTS(Select * from sys.databases where name = N'{0}') CREATE DATABASE {0}", dbName.Trim().Replace(" ", ""));

                SqlCommand sqlCom = new SqlCommand(queryString, sqlConn);
                sqlCom.CommandTimeout = 7;
                sqlCom.ExecuteNonQuery();

                sqlConn.Close();

                // Wait for Database to be created and Schema Access is set-up. 
                int timeOut = 0;
                while (timeOut < 11) //!checkCanConnect(connectionString) && 
                {
                    System.Threading.Thread.Sleep(250);
                    timeOut++;
                }

                return (timeOut!=21);
            }
            catch (Exception e)
            {
                sqlConn.Close();
                if (e.GetType() == typeof(SqlException))
                    if (((SqlException)e).Number == 4060 || ((SqlException)e).Number == 18456) // User has no access to CONECT (4060); User ID / Password Error (18456)
                        return false;
                throw (e);
            }
        }

        public enum AccessLevel : byte { NONE=0, SELECT=1, INSERT=2, UPDATE=4, DELETE=8, FULL=15};
        
    }
}
