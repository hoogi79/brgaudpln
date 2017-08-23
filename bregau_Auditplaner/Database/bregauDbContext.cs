using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using bregau_Auditplaner.Database.Auth;
using System.Data.Common;

namespace bregau_Auditplaner.Database
{
    class bregauDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        //public bregauContext (DbConnection connection) : base(connection, false)
        //{ }
    }
}
