using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Common
{
    public class RestoresMice
    {
        private static string RestoresFile = @"C:\bs\Mice Positions.xml";
        private static string SaveFile =
Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Multiple Mice\\Mice Positions.xml";
        public static void restoresMice()
        {
            if (!File.Exists(RestoresFile))
                return;
            string[] file = System.IO.File.ReadAllText(RestoresFile).Split('\n');
            if (file.Length != 6)
                return;
            try
            {
                File.Copy(RestoresFile, SaveFile, true);
            }
            catch (IOException iox)
            {

            }
        }
        public static void SaveMice()
        {
            if (!File.Exists(SaveFile))
                return;
            string[] file = System.IO.File.ReadAllText(SaveFile).Split('\n');
            if (file.Length != 6)
                return;
            try
            {
                File.Copy(SaveFile, RestoresFile, true);
            }
            catch (IOException iox)
            {

            }
        }
    }
}
