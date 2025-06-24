using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CL.BS.Database
{
    public class User
    {
        public string    UserType   { get; set; }
        public string   _User       { get; set; }
        public bool     Gender      { get; set; }
        public string   Teacher     { get; set; }
        public DateTime Birthday    { get; set; }
        public string   Limitations { get; set; }
        public string    Voice      { get; set; }
        public string    Image      { get; set; }
        public string    Name       { get; set; }

    }
}
