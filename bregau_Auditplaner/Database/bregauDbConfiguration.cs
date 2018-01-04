using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Infrastructure.Interception;

namespace bregau_AuditplanerWPF.Database
{
    class bregauDbConfiguration : DbConfiguration
    {
        public bregauDbConfiguration()
        {
            SetDefaultConnectionFactory(new bregauDbConnectionFactory(Program.connectionString));
            //SetDatabaseInitializer<bregauDbContext>(new MigrateDatabaseToLatestVersion<bregauDbContext,Migrations.Configuration>());
#if DEBUG
            string path = System.IO.Path.GetTempPath() + "dblogger.txt";
            AddInterceptor(new DatabaseLogger(path,false));
#endif

        }
    }
}
