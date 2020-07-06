using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TempSocketServer
{
    public class RsaEncryption
    {
        static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);
        RSAParameters pvKey = csp.ExportParameters(true);
        RSAParameters pbKey = csp.ExportParameters(false);



        public byte[] ReturnPbKey()
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(System.IO.File.ReadAllText(@"C:\Users\benj6414\source\repos\TempSocketServer\TempSocketServer\Keypair.txt"));
            byte[] finalarray = new byte[bytearray.Length];
            bytearray.CopyTo(finalarray, 0);
            return finalarray;
        }

        public string pbKeyString()
        {
            var sw = new System.IO.StringWriter();
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, pbKey);
            string pbKeyString = sw.ToString();
            System.IO.File.WriteAllText(@"C:\Users\benj6414\source\repos\TempSocketServer\TempSocketServer\Keypair.txt", pbKeyString);
            return pbKeyString;
        }

        public RSAParameters ToPbKey()
        {
            string tempstring = System.IO.File.ReadAllText(@"C:\Users\benj6414\source\repos\TempSocketServer\TempSocketServer\Keypair.txt");
            var sr = new System.IO.StringReader(tempstring);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            RSAParameters pubKey = (RSAParameters)xs.Deserialize(sr);
            csp.FromXmlString(tempstring);
            return pubKey;
        }

        public string pvKeyString()
        {
            var sw = new System.IO.StringWriter();
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, pvKey);
            string pvKeyString = sw.ToString();
            System.IO.File.WriteAllText(@"C:\Users\benj6414\source\repos\TempSocketServer\TempSocketServer\PrivateKey.txt", pvKeyString);
            return pvKeyString;
        }

        public RSAParameters ToPvKey()
        {
            string tempstring = System.IO.File.ReadAllText(@"C:\Users\benj6414\source\repos\TempSocketServer\TempSocketServer\PrivateKey.txt");
            var sr = new System.IO.StringReader(tempstring);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            RSAParameters pvKey = (RSAParameters)xs.Deserialize(sr);
            csp.FromXmlString(tempstring);
            return pvKey;
        }

        //public byte[] EncryptData()
        //{
        //    csp = new RSACryptoServiceProvider();
        //    csp.ImportParameters(ToPbKey());

        //    var plainText = "morten vestergaard";
        //    byte[] bytesplaintText = System.Text.Encoding.Unicode.GetBytes(plainText);
        //    byte[] bytesCypherText = csp.Encrypt(bytesplaintText, false);
        //    return bytesCypherText;
        //}

        public string DecryptData(byte[] encryptedData)
        {
            csp.ImportParameters(pvKey);
            string cyphertext = Encoding.ASCII.GetString(encryptedData);
            Console.WriteLine(cyphertext);
            byte[] bytesPlainText = csp.Decrypt(encryptedData, false);
            string plaintext = System.Text.Encoding.Unicode.GetString(bytesPlainText);
            return plaintext;
        }




	}
}
