using smartHealthApp.Common.Properties;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace smartHealthApp.Common
{
    public class CommonMethods
    {
        
        public static class EncryptDecryptKey
        {
            public readonly static string Key = "MAKV2SPBNI99212";
            public readonly static string PHIKey = "~!@#$%^*HeaLthC@re$smaRtData~!@!!!=";
        }
        public static string Encrypt(string clearText)
        {
            string encryptionKey = EncryptDecryptKey.Key; 
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            using (Aes aes = Aes.Create())
            {
                // Use Rfc2898DeriveBytes to generate the Key and IV
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())          // Here, MemoryStream to hold the encrypted bytes
                {
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))     //  CryptoStream to perform the encryption
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                    }
                    clearText = Convert.ToBase64String(ms.ToArray()); // Convert the encrypted bytes to a base64 string
                }
            }
            return clearText;
        }

        /// <summary>
        /// Decrypts the encrypted data.
        /// </summary>
        /// <param name="cipherText">The encrypted text to be decrypted.</param>
        /// <returns>The decrypted plain text.</returns>
        public static string Decrypt(string cipherText)
        {
            string encryptionKey = EncryptDecryptKey.Key;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public static void SaveToXmlFile<T>(T obj, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, obj);
            }
        }
        public static object ReadFile(object obj)
        {
            XmlDocument doc = new XmlDocument();
            string baseDirectory = Path.GetPathRoot(Environment.SystemDirectory);
            string folderPath = Path.Combine(Path.Combine(baseDirectory, DefaultSettings.SettingFileFolder), DefaultSettings.SettingSubFolder);
            string fileName = Path.Combine(folderPath, DefaultSettings.SettingFileName);

            //file exists
            if (File.Exists(fileName))
            {
                doc.Load(fileName);
                string xmlcontents = doc.InnerXml;
                XmlSerializer oXmlSerializer = new XmlSerializer(obj.GetType());
                //The StringReader will be the stream holder for the existing XML file 
                obj = oXmlSerializer.Deserialize(new StringReader(xmlcontents));
                //initially deserialized, the data is represented by an object without a defined type 
                return obj;
            }
            return null;
        }


    }
}
