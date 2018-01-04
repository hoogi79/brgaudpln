using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bregau_AuditplanerWPF.Database.Auth
{
    class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string EMail { get; set; }
        public string PasswordHash { get; set; }
        public List<Group> Groups { get; set; }
        public bool Enabled { get; set; } = true;
    }

    class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
