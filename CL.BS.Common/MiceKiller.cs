using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.Common
{
    public class MiceKiller
    {
        /// stop all the mice exset for one
        private const string _textFill = @"C:\bs\killMice.txt";

        public static void KillAllMices(bool killMice)
        {
            try
            {
                if (System.IO.File.Exists(_textFill))
                    return;
                string[] text = System.IO.File.ReadAllText(_textFill).Split('\r');
                int miceIndex = int.Parse(text[text.Length - 1].Replace("\\n", string.Empty).Trim());
                CL.BS.Common.GlobalLog.Write("MiceKiller ReadAllText :" + DateTime.Now);
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if (miceIndex == i)
                        continue;
                    string[] s = text[i].Replace("\\n", string.Empty).Trim().Split(' ');
                    Guid mouseGuid = new Guid(s[1]);
                   // נתיב מופע התקן
                       DeviceHelper.SetDeviceEnabled(mouseGuid, s[0], killMice); // true disables the device, false enables it
                    //System.Diagnostics.Process.Start("CAkillMice.exe", text[i].Replace("\\n", string.Empty).Trim()+' '+killMice.ToString());
                }

                CL.BS.Common.GlobalLog.Write("MiceKiller sacses (-:" + DateTime.Now);
            }
            catch (Exception e)
            {
                GlobalLog.Write("Exception ReadAllText : " + e);
            }
        }

        public static void SetMainMices(object number)
        {
            try
            {
               // int num = int.Parse(number.ToString());
                string text = System.IO.File.ReadAllText(_textFill);
                //if (text.Split('\r').Length - 1 < num)
                //    num = text.Length - 1;
                string[] lines = text.Split('\r');
                int miceIndex = int.Parse(lines[lines.Length - 1].Replace("\\n", string.Empty).Trim());
                string s = string.Empty;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == lines.Length - 1)
                        s += "" + number;
                    else
                        s += lines[i] + "\r\n";
                }
                System.IO.File.WriteAllText(_textFill, s);
            }
            catch (Exception e)
            {
                GlobalLog.Write(e.ToString());
            }
        }

    }
}