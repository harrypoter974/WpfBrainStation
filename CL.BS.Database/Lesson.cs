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
    public class Lesson
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public int Student0Code { get; set; }

        public int Student1Code { get; set; }
        public int Student2Code { get; set; }
        public int Student3Code { get; set; }
        public int ClassCode { get; set; }
        public int LessonCode { get; set; }
    }
}
