using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Common
{
    public class GlobalLog
    {
        private static readonly string _fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
            + "\\BrainStationLog.txt";

        public static void Write(string line)
        {
            string text = string.Empty;
            try
            {
            
                StringReader reader = new StringReader(_fileName);
                text += System.IO.File.ReadAllText(_fileName);

                using (StreamWriter file =
               new StreamWriter(_fileName))
                {
                    file.Write(text);
                    file.WriteLine(line);
                }
            }
            catch (Exception)
            {
            }
        }
  }
}
