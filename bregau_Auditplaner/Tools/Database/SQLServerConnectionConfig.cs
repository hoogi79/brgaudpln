using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bregau_Auditplaner.Tools.Database
{
    /// <summary>
    /// Kapselt Informationen zur Anbindung an den Datenbankserver.
    /// </summary>
    [Serializable]
    class SQLServerConnectionConfig
    {
        public Tools.Encryption.AESDataSet Login { get; set; }
        public Tools.Encryption.AESDataSet Password { get; set; }
        public String Server { get; set; }
        public String DatabaseName { get; set; }

        public string GetConnectionString()
        {
            throw (new NotImplementedException());
        }

        public static string Serialize(SQLServerConnectionConfig sscc)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                formatter.Serialize(ms, sscc);
                ms.Position = 0;
                System.IO.StreamReader sr = new System.IO.StreamReader(ms);
                return sr.ReadToEnd();
            }
        }

        public static SQLServerConnectionConfig Deserialize(string serializedClass)
        {
            if (serializedClass?.Length != 0)
                try
                {
                    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(ms);
                        sw.Write(serializedClass);
                        sw.Flush();
                        ms.Position = 0;
                        SQLServerConnectionConfig sscc = (SQLServerConnectionConfig)formatter.Deserialize(ms);
                        return sscc;
                    }
                }
                catch (Exception e) { throw; }
            else
                throw new ArgumentException("Length of serialized class can not be zero.");
        } 
    }
}
