using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using bregau_AuditplanerWPF.Database.Auth;
using System.Data.Common;

namespace bregau_AuditplanerWPF.Database
{
    class bregauDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        public bregauDbContext (string connectionString) : base(connectionString)
        { }

        public bregauDbContext() : base() { }

        ///// <summary>
        ///// Diese Funktion wird beim Erstellen des Modells aufgerufen. 
        ///// Hier weird mittels fluent API in die automatische Koniguration der 
        ///// zu erstellenden Datenbank eingegriffen. (Alternativ zu [Data Annotations] in den Klassen selbst.
        ///// </summary>
        ///// <param name="modelBuilder"></param>
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Group>().ToTable("Groups", "auth"); // Gruppen in Tabelle Groups und ins Schema auth
        //    modelBuilder.Entity<User>().ToTable("Users", "auth");

        //}
    }
}
