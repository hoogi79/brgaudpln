using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace UI.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestClass tc = new TestClass();
            //tc.PropertyChanged += (e, s) => { System.Console.WriteLine(tc.SomeProperty); };
            //System.Console.WriteLine("Set to \"Hello World\"");
            //tc.SomeProperty = "Hello World";
            //System.Console.WriteLine("Set again to \"Hello World\"");
            //tc.SomeProperty = "Hello World";
            //System.Console.WriteLine("Set to \"New World\"");
            //tc.SomeProperty = "New World";
            //System.Console.ReadKey();

            List<string> pl = new List<string>();
            //pl.Add("Dirk");
            //pl.Add("Henrike");
            //pl.Add("Helge");
            //pl.Add("Guido");

            ////pl.ForEach(delegate(string name) { Console.WriteLine(name); });
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, "server2008.bregau.local");
            bool isValid = pc.ValidateCredentials("TT", "testtoast19");
            if (isValid)
            {
                UserPrincipal uc = new UserPrincipal(pc);
                uc.Enabled = true;
                PrincipalSearcher ps = new PrincipalSearcher(uc);
                foreach (var result in ps.FindAll())
                {
                    DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                    String LastName = de.Properties["sn"].Value?.ToString() ?? "{no entry}";
                    String FirstName = de.Properties["givenName"].Value?.ToString() ?? "{no entry}";
                    String accountName = de.Properties["userPrincipalName"].Value?.ToString() ?? "no principal";
                    pl.Add(accountName + " => " + FirstName + " " + LastName);
                }
            }
            pl.ForEach((name) => Console.WriteLine(name));
            System.Console.ReadKey();


        }
    }

    class TestClass : INotifyPropertyChanged
    {
        public string SomeProperty { get; set; }
        //private string _someProperty;
        //public string SomeProperty {
        //    get { return _someProperty; }
        //    set
        //    {
        //        if (value == _someProperty)
        //            return;
        //        _someProperty = value;
        //        OnProperyChanged();
        //    }
        //}

        //public virtual void OnProperyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
