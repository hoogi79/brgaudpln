using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bregau_AuditplanerWPF.Database
{
    class bregauDbConnectionFactory : IDbConnectionFactory
    {

        private string ConnectionString { get; set; }

        public bregauDbConnectionFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new System.Data.SqlClient.SqlConnection(this.ConnectionString);
        }
    }
}
