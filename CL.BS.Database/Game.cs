using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CL.BS.Database
{
    [DataContract]
    public class Game
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int GameCode { get; set; }
        public string GameName { get; set; }
    }
}
