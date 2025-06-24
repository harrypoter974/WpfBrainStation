using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CL.BS.Common;

namespace UserInformationManager.Engine
{
    class MenuNameEngine
    {
        private Thickness _thick = new Thickness(5);

        public MenuNameEngine()
        {
     
        }

        internal List<string> GetName(object letter)
        {
            List<string> ls = new List<string>();
            string[] nameList;
            if (letter.ToString() == "nickname")
            {
                nameList = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory +
                "Resources\\Audio\\He\\Name\\" + StaticVar.SelectBoy+ "\\Nickname");
                for (int i = 0; i < nameList.Length; i++)
                {
                    string[] name = nameList[i].Split('\\');
                    ls.Add(name[name.Length - 1].Split('.')[0] );
                   
                }
            }
            else
            {
                nameList = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory +
                     "Resources\\Audio\\He\\Name\\" + StaticVar.SelectBoy);//(StaticVar.SelectBoy == "Boy" ? "Boy" : "Girl")
                for (int i = 0; i < nameList.Length; i++)
                {
                    string[] name = nameList[i].Split('\\');
                    if (name[name.Length - 1].Split('.')[0][0] == letter.ToString()[0])
                        ls.Add( name[name.Length - 1].Split('.')[0]   );                   
                }
            }
            return ls;
        }
    }
}
