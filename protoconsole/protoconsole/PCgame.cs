using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace protoconsole
{
    [ProtoContract]
    public class PCgame
    {
        [ProtoMember(1)]
        public string name { get; set; }
        [ProtoMember(2)]
        public string developer { get; set; }
        [ProtoMember(3)]
        public int release_year { get; set; }

        public void SerializeNow()
        {
            game spil = new game
            {
                Name = "CoD",
                Developer = "Infinity ward",
                ReleaseYear = 2019
            };
            
        }
    }
}
