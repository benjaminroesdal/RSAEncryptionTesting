using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace protoconsole
{
    public class AESEnctryption
    {
        SymmetricAlgorithm crypt = Aes.Create();

        public void EncryptData()
        {
            AesManaged aes = new AesManaged();
            aes.GenerateKey();
            aes.GenerateIV();
            Console.WriteLine(Encoding.ASCII.GetString(aes.Key));
        }
    }
}
