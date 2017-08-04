using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace bregau_Auditplaner.Tools.Encryption
{
    /// <summary>
    /// AES Encryption Beispiel aus .NET Hilfe von MS (https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=netframework-4.7)
    /// </summary>
    class AESEncrypter
    {
        string p_codeword = string.Empty;
        byte[] p_keyEnc;
        byte[] p_IVEnc;

        public AESEncrypter(string codeword)
        {
            using (Aes aesAl = Aes.Create())
                this.Setup(codeword, AESEncrypter.EncryptSimple(codeword, aesAl.Key), AESEncrypter.EncryptSimple(codeword, aesAl.IV));
        }

        public AESEncrypter() : this("bregau2017")
        { }

        public AESEncrypter(string codeword, byte[] EncryptedKey, byte[] EncryptedIV)
        {
            this.Setup(codeword, EncryptedKey, EncryptedIV);
        }

        public AESEncrypter(byte[] EncryptedKey, byte[] EncryptedIV)
        {
            this.Setup("bregau2017", EncryptedKey, EncryptedIV);
        }

        /// <summary>
        /// Initialisiert die Encrypter Klasse
        /// </summary>
        /// <param name="codeword">Password für EncryptSimple (UTF8)</param>
        /// <param name="EncryptedKey">mit EncryptSimple verschlüsselter AES Key</param>
        /// <param name="EncryptedIV">mit EncryptSimple verschlüsselter AES Initial Vector</param>
        private void Setup(string codeword, byte[] EncryptedKey, byte[] EncryptedIV)
        {
            this.p_codeword = codeword ?? "";
            this.p_keyEnc = EncryptedKey;
            this.p_IVEnc = EncryptedIV;
        }

        /// <summary>
        /// Erzeugt eine billig verschlüsselte Nachricht
        /// </summary>
        /// <param name="codeword">Das Kennwort</param>
        /// <param name="message">Die Nachricht in Klartext</param>
        /// <returns></returns>
        static public byte[] EncryptSimple (string codeword, byte[] message)
        {
            byte[] codewordBytes = Encoding.UTF8.GetBytes(codeword);
            byte[] workBytes = new byte[message.Length];

            for (int i=0; i < message.Length; i++)
            {
                workBytes[i] = (byte) (message[i] ^ codewordBytes[i%codewordBytes.Length]);
            }

            return Encoding.UTF8.GetBytes(System.Convert.ToBase64String(workBytes));
            //return workBytes;
        }

        /// <summary>
        /// Entschlüsselt eine Nachricht die mit EncryptSimple verschlüsselt wurde.
        /// </summary>
        /// <param name="codeword">Das Kennwort</param>
        /// <param name="message">Die verschlüsselte Nachricht</param>
        /// <returns></returns>
        static public byte[] DecryptSimple (string codeword, byte[]message)
        {
            byte[] workBytes = System.Convert.FromBase64String(Encoding.UTF8.GetString(message));
            byte[] codewordBytes = Encoding.UTF8.GetBytes(codeword);
            byte[] returnBytes = new byte[workBytes.Length];

            for (int i = 0; i < workBytes.Length; i++)
            {
                returnBytes[i] = (byte)(workBytes[i] ^ codewordBytes[i % codewordBytes.Length]);
            }

            return returnBytes;
        }

        /// <summary>
        /// Verschlüsselt eine Nachricht per AES
        /// </summary>
        /// <param name="message">Die zu verschlüsselnde Nachricht</param>
        /// <returns>Die verschlüsselte Nachricht</returns>
        public byte[] EncryptAES(byte[] message)
        {
            return AESEncrypter.EncryptStringToBytes_Aes(Encoding.UTF8.GetString(message), DecryptSimple(this.p_codeword, this.p_keyEnc), DecryptSimple(this.p_codeword, this.p_IVEnc));
        }

        /// <summary>
        /// Entschlüsselt eine Nachricht per AES
        /// </summary>
        /// <param name="message">Die AES-verschlüsselte Nachricht</param>
        /// <returns>Die Nachricht in Klartext</returns>
        public byte[] DecryptAES(byte[] message)
        {
            return Encoding.UTF8.GetBytes(AESEncrypter.DecryptStringFromBytes_Aes(message, DecryptSimple(this.p_codeword, this.p_keyEnc), DecryptSimple(this.p_codeword, this.p_IVEnc)));
        }

        public AESDataSet GetAESDataSet(byte[] message)
        {
            return new AESDataSet { Key = this.p_keyEnc, IV = this.p_IVEnc, Message = message };
        }

        /// <summary>
        /// Verschlüsselt einen String
        /// </summary>
        /// <param name="plainText">Original string</param>
        /// <param name="Key">AES Key</param>
        /// <param name="IV">AES Initialisierungsvektor</param>
        /// <returns>Verschlüsseltes Byte Array</returns>
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        /// <summary>
        /// Entschlüsselt ein Byte-Array und erzeugt einen String
        /// </summary>
        /// <param name="cipherText">Verschlüselte Nachricht</param>
        /// <param name="Key">AES Key</param>
        /// <param name="IV">AES Initialisierungsvektor</param>
        /// <returns>Entschlüsselter String</returns>
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
    }

    [Serializable]
    public class AESDataSet
    {
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
        public byte[] Message { get; set; }

        public static string Serialize(AESDataSet ads)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                formatter.Serialize(ms, ads);
                ms.Position = 0;
                System.IO.StreamReader sr = new System.IO.StreamReader(ms);
                return sr.ReadToEnd();
            }
        }

        public static string SerializeXml(AESDataSet ads)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(AESDataSet));
            string xml = "";

            using (StringWriter sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, ads);
                    xml = sww.ToString(); // Your XML
                }
            }
            return xml;
        }

        public static AESDataSet Deserialize(string serializedClass)
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
                        AESDataSet ads = (AESDataSet)formatter.Deserialize(ms);
                        return ads;
                    }
                }
                catch (Exception) { throw; }
            else
                throw new ArgumentException("Length of serialized class can not be zero.");
        }

        public static AESDataSet DeserializeXml(string serializedClass)
        {
            if (serializedClass?.Length != 0)
                try
                {
                    XmlSerializer xsSubmit = new XmlSerializer(typeof(AESDataSet));
                    using (StringReader sr = new StringReader(serializedClass))
                    {
                        using (XmlReader reader = XmlReader.Create(sr))
                        {
                            if (xsSubmit.CanDeserialize(reader))
                                return xsSubmit.Deserialize(reader) as AESDataSet;
                            else
                                return null;
                        }
                    }
                }
                catch (Exception) { throw; }
            else
                throw new ArgumentException("Length of serialized class can not be zero.");
        }


    }

}
