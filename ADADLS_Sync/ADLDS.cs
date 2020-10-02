using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace ADADLS_Sync
{
    class ADLDS
    {
        private DirectoryEntry pObjADAM;

        public ADLDS (string strServerFQDN, int intPort, string strTopObjectDN, string strUserDN, string strPassword)
        {
            this.Server = strServerFQDN;
            this.Port = intPort;
            this.Object = strTopObjectDN;
            this.User = strUserDN;
            this.Password = strPassword;

         
            // Get the specified object.
            try
            {
                pObjADAM = new DirectoryEntry(this.GetConnectionPath(), this.User, this.Password, AuthenticationTypes.None);
                pObjADAM.RefreshCache();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Bind failed.");
                Console.WriteLine("         {0}.", e.Message);
                System.Console.ReadKey();
                return;
            }

            Console.WriteLine("Bind to: {0}", strPath);
        }

        private string pServer;

        public string Server
        {
            get { return pServer; }
            private set {
                if (value.Equals("") || value.Equals(String.Empty))
                    throw new ArgumentNullException("Server", "Error: Invalid hostname specified.");
                pServer = value; }
        }

        /// <summary>
        /// Port des Servers
        /// </summary>
        public int? Port { get; private set; } = 389;

        /// <summary>
        /// Distinguished name of the root Object
        /// </summary>
        public string Object { get; private set; }

        /// <summary>
        /// User of LDS used for binding
        /// </summary>
        public string User { get; private set; }
        
        /// <summary>
        /// Password for binding user
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Construct the binding string.
        /// </summary>
        /// <returns></returns>
        private string GetConnectionPath()
        {
            string strPath = "LDAP://";
            
            strPath = String.Concat(strPath, this.Server);
            if (this.Port != null)
                strPath = String.Concat(strPath, ":", this.Port.ToString());

            if (!this.Object.Equals("") && !this.Object.Equals(String.Empty))
                strPath = String.Concat(strPath, "/", this.Object);
            return strPath;
        }




    }

}
