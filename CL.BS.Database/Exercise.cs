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
    public class Exercise
    {

        public string   TableID    { get; set; }
        public int ApplicationVersion { get; set; }//
        public int      scoolID       { get; set; }//
        public int      Class             { get; set; }//
        public string   User            { get; set; }
        public char     Edge             { get; set; }
        public DateTime StartTime     { get; set; }
        public DateTime EndTime       { get; set; }
        public string    Type           { get; set; }
        public string    Activity      { get; set; }
        public string    Task          { get; set; }
        public string    SubTask       { get; set; }
        public int     Success         { get; set; }

        internal string[] GetCol()
        {
            return new string[] {
            TableID
,"|"+ApplicationVersion.ToString()
,"|"+scoolID.ToString()
,"|"+Class.ToString()
,"|"+User
,"|"+Edge.ToString()
,"|"+StartTime.ToString()
,"|"+EndTime.ToString()
,"|"+ Type
,"|"+ Activity
,"|"+ Task
,"|"+ SubTask
,"|"+Success.ToString()}; 
        }
    }
}
