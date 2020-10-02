using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ADADLS_Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pl = new List<string>();
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

            SearchResultCollection results;
            DirectoryEntry objADAM;  // Directory object.
            DirectorySearcher objADAMSearcher;
            string strObject;        // DN of object to bind to.
            string strPath;          // Bind path.
            string strPort;          // Optional TCP port.
            string strServer;        // DNS Name of the computer with the
                                     // AD LDS installation
            string strUser;
            string strPassword;

            // In this example, the AD LDS installation is on a local computer
            strServer = "bregau2k12.bregau.local";

            // TCP Port to use
            strPort = "389";

            // Distinguished name of the object.
            strObject = "CN=AppPartition,DC=bregau,DC=local";

            // Construct the binding string.
            strPath = "LDAP://";
            if (strServer.Equals("") || strServer.Equals(String.Empty))
            {
                Console.WriteLine("Error: Invalid hostname specified.");
                return;
            }
            else
            {
                strPath = String.Concat(strPath, strServer);
            }

            if (!strPort.Equals("") && !strPort.Equals(String.Empty))
            {
                strPath = String.Concat(strPath, ":", strPort);
            }

            if (!strObject.Equals("") && !strObject.Equals(String.Empty))
            {
                strPath = String.Concat(strPath, "/", strObject);
            }

            Console.WriteLine("Bind to: {0}", strPath);

            strUser = "CN=test,CN=AppPartition,DC=bregau,DC=local";
            strPassword = "testtesttest2020";

            // Get the specified object.
            try
            {
                objADAM = new DirectoryEntry(strPath,  strUser, strPassword, AuthenticationTypes.None);
                objADAM.RefreshCache();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Bind failed.");
                Console.WriteLine("         {0}.", e.Message);
                System.Console.ReadKey();
                return;
            }

            // Output object attributes.
            Console.WriteLine("Success: Bind succeeded.");
            Console.WriteLine("Name:    {0}", objADAM.Name);
            Console.WriteLine("Path:    {0}", objADAM.Path);

            objADAMSearcher = new DirectorySearcher(objADAM);
            results = objADAMSearcher.FindAll();

            foreach (SearchResult sr in results)
            {
                // Using the index zero (0) is required!
                if (sr.Properties.Contains("Name"))
                    Console.WriteLine(sr.Properties["name"][0].ToString());
            }

            System.Console.ReadKey();
        
        }
    }
}
