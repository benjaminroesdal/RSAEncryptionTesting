using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using protoconsole;

namespace protoconsole
{
    public class RSAEncryption
    {
        static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);
        RSAParameters pbKey = csp.ExportParameters(false);


        public RSAParameters ToPbKey(string key)
        {
            var sr = new System.IO.StringReader(key);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            RSAParameters pubKey = (RSAParameters)xs.Deserialize(sr);
            csp.FromXmlString(key);
            return pubKey;
        }

        public byte[] EncryptData()
        {
            var plainText = Console.ReadLine();
            byte[] bytesplaintText = System.Text.Encoding.Unicode.GetBytes(plainText);
            byte[] bytesCypherText = csp.Encrypt(bytesplaintText, false);
            string cyphertext = Encoding.ASCII.GetString(bytesCypherText);
            Console.WriteLine(cyphertext);
            return bytesCypherText;
        }
    }
}
