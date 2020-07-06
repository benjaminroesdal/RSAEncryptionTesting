using Google.Protobuf;
using ProtoBuf;
using System;
using System.Text;
using System.Net.Sockets;

namespace protoconsole
{
    class Program
    {
        public static byte[] bytes = new byte[1024];
        /// <summary>
        /// Takes an object and a EDishType, turns every value of the object into a byte array of strings. 
        /// The final byte array contains first 4 bytes = EDishtpye, 4 next bits = length of object array, rest of bits = object values
        /// </summary>
        /// <param name="myObj">An object matching a type in EDishType</param>
        /// <param name="type">What type of dish is it, (different types in the enum)</param>
        /// <returns>A byte array containing first 4 bits = EDishType, next 4 = length of object values in array, rest of bytes = object values</returns>
        static byte[] Serialize(Object myObj, EDishType type)
        {
            byte[] dishtypes = new byte[0];
            byte[] arraylength = new byte[0];
            byte[] finalobjectarray = new byte[0];
            switch (type)
            {
                case EDishType.Dish:
                    dishtypes = BitConverter.GetBytes(1);
                    byte[] tempdishname = Encoding.UTF8.GetBytes(((Dish)myObj).Name + char.MinValue);
                    byte[] tempdev = Encoding.UTF8.GetBytes(((Dish)myObj).Developer + char.MinValue);
                    byte[] tempyear = Encoding.UTF8.GetBytes(((Dish)myObj).ReleaseYear.ToString() + char.MinValue);
                    byte[] finalobjarray = new byte[tempdishname.Length + tempdev.Length + tempyear.Length];
                    tempdishname.CopyTo(finalobjarray, 0);
                    tempdev.CopyTo(finalobjarray, tempdishname.Length);
                    tempyear.CopyTo(finalobjarray, tempdishname.Length + tempdev.Length);
                    finalobjectarray = finalobjarray;
                    break;
                case EDishType.PremiumDish:
                    dishtypes = BitConverter.GetBytes(2);
                    break;
                default:
                    break;
            }
            arraylength = BitConverter.GetBytes(finalobjectarray.Length);
            byte[] finalarray = new byte[dishtypes.Length + arraylength.Length + finalobjectarray.Length];
            dishtypes.CopyTo(finalarray, 0);
            arraylength.CopyTo(finalarray, dishtypes.Length);
            finalobjectarray.CopyTo(finalarray, dishtypes.Length + arraylength.Length);
            return finalarray;
        }

        //public static string byteKeyToString(byte[] array)
        //{
        //    int BitConverter.ToInt32(array, 0);
        //    for (int i = 0; i < length; i++)
        //    {

        //    }
        //}

        /// <summary>
        /// Connection function for connecting to the socket server
        /// </summary>
        /// <param name="host">Hostname</param>
        /// <param name="port">port</param>
        /// <param name="array">The array that will be send to the socket server</param>
        public static void Connect3(string host, int port, byte[] array)
        {
            AESEnctryption aESEnctryption = new AESEnctryption();
            aESEnctryption.EncryptData();
            RSAEncryption rSAEncryption = new RSAEncryption();
            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}",
                host);
            s.Connect(host, port);
            Console.WriteLine("Connection established");
            s.Send(array);
            s.Receive(bytes);
            string bytestring = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            rSAEncryption.ToPbKey(bytestring);
            byte[] encarray = rSAEncryption.EncryptData();
            s.Send(encarray);

            Console.WriteLine(bytestring);
            Console.WriteLine("Connection established");
        }

        static void Main(string[] args)
        {
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[1];
            //Console.WriteLine(ipAddress);

            Dish dish = new Dish()
            {
                Name = "Bolognese",
                Developer = "Italien",
                ReleaseYear = 2019
            };

            Connect3("192.168.0.13", 11000, Serialize(dish, EDishType.Dish));
            
            Console.ReadLine();
        }
    }
}
