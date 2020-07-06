using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace TempSocketServer
{
    public class Deserializer
    {

        //public byte[] Decode(byte[] packet)
        //{
        //    var i = packet.Length - 1;
        //    while (packet[i] == 0)
        //    {
        //        --i;
        //    }
        //    var temp = new byte[i + 1];
        //    Array.Copy(packet, temp, i + 1);
        //    return temp;
        //}


        public Object DeSerialize(byte[] array)
        {
            int objecttype = BitConverter.ToInt32(array, 0);
            int objectarraylenght = BitConverter.ToInt32(array, 4);
            byte[] objectarray = new byte[objectarraylenght];
            switch (objecttype)
            {
                case 1:
                    string bytestring = Encoding.UTF8.GetString(array,8,objectarraylenght);
                    string name = bytestring.Split('\0')[0];
                    string developer = bytestring.Split('\0')[1];
                    int releaseYear = Int32.Parse(bytestring.Split('\0')[2]);
                    Dish dish = new Dish
                    {
                        Name = name,
                        Developer = developer,
                        ReleaseYear = releaseYear
                    };
                    return dish;
                case 2:
                    break;
                default:
                    break;
            }

            return null;
        }
    }
}
