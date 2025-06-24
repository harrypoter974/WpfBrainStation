using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen.Text
{
    class EnTextBuilderEngen
    {
        internal static List<LetterObject> GetListText(string text,bool isAnswer)
        {
            List<LetterObject>listText = new List<LetterObject>();
            bool isText = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\'')
                {
                    isText = !isText;
                    i++;
                    if (i == text.Length)
                        break;
                }
                LetterObject vo = new LetterObject() {Text=text[i].ToString() };
                if (isText)
                {
                   vo.Uid = "Black";
                }
                else
                {
                    if (!isAnswer)
                        vo.Text = string.Empty;
                    vo.Uid = "Orange";
                    vo.Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\BS.Items\WhiteBoard.jpg";
                }
                listText.Add(vo);
            }
            return listText;
        }
    }
}
