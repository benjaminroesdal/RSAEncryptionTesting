using System;
using System.Net;
using System.Net.Sockets;
using Google.Protobuf;

namespace TempSocketServer
{
    public class SynchronousSocketListener
    {
        // Incoming data from the client.  
        public static string data = null;

        public static void StartListening()
        {
            RsaEncryption rsaEncryption = new RsaEncryption();
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the
            // host running the application.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    rsaEncryption.pbKeyString();
                    rsaEncryption.pvKeyString();
                    rsaEncryption.ToPbKey();
                    rsaEncryption.ToPvKey();
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        handler.Receive(bytes);

                        if (1 + 1 == 2)
                        {
                            break;
                        }
                    }
                    // Show the data on the console. 

                    // Echo the data back to the client.  
                    handler.Send(rsaEncryption.ReturnPbKey());
                    int bytesrec = handler.Receive(bytes);
                    byte[] tempbytearray = new byte[bytesrec];
                    for (int i = 0; i < bytesrec; i++)
                    {
                        tempbytearray[i] = bytes[i];
                    }
                    Console.WriteLine(rsaEncryption.DecryptData(tempbytearray));
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}
