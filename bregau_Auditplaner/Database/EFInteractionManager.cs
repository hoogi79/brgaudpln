using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;

namespace bregau_AuditplanerWPF.Database
{
    class EFInteractionManager
    {
        public static bool checkIfExists(Type dbContexType)
        {
            if (dbContexType.IsSubclassOf(typeof(DbContext)))
            {
                DbContext tempDbContext = (DbContext)dbContexType.GetConstructor(new Type[0]).Invoke(new Object[0]);
                bool retBool = tempDbContext.Database.Exists();
                tempDbContext.Dispose();
                return retBool;
            }
            else
                throw (new Exception("Kein DbContext als Parameter."));
        }

        //public static bool checkForPendingMigrations(Type dbContexType)
        //{

        //    if (dbContexType.IsSubclassOf(typeof(DbContext)))
        //    {
        //        DbContext tempDbContext = (DbContext)dbContexType.GetConstructor(new Type[0]).Invoke(new Object[0]);
        //        Migrations.Configuration cfg = new Migrations.Configuration();

        //        cfg.TargetDatabase = new DbConnectionInfo(tempDbContext.Database.Connection.ConnectionString,  "System.Data.SqlClient");
        //        DbMigrator dbMigrator = new DbMigrator(cfg);
        //        tempDbContext.Dispose();

        //        if (dbMigrator.GetPendingMigrations().Any())
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    else
        //        throw (new Exception("Kein DbContext als Parameter."));
        //}

        public static bool checkIfCompatible(Type dbContexType, string connectionString = null)
        {
            if (dbContexType.IsSubclassOf(typeof(DbContext)))
            {
                DbContext tempDbContext = null;

                if (!String.IsNullOrEmpty(connectionString))
                    tempDbContext = (DbContext)dbContexType.GetConstructor(new Type[0]).Invoke(new Object[0]);
                else
                    tempDbContext = (DbContext)dbContexType.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { connectionString });

                bool retValue = tempDbContext.Database.CompatibleWithModel(false);
                tempDbContext.Dispose();
                return retValue;
            }
            else
                throw (new Exception("Kein DbContext als Parameter."));
        }

    }
}
