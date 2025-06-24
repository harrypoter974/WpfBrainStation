using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Writing
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class WritingLettersManager : IManager,IWritingLettersManager
    {
        string IManager.ManagerName => "WritingLettersManager";
        private string _letter="";

        string IWritingLettersManager.GetLetter()
        {
            return _letter;
        }

        void IWritingLettersManager.SetLetter(object letter)
        {
            _letter = letter.ToString();
        }

        string IWritingLettersManager.SwitchFontButton()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\BS.Items\Button" +
            (Common.StaticVar.inline.IsCard ? "Card" : "Writing") + ".png";
        }

        string IWritingLettersManager.SwitchFontOpenPage()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\He\Writing\UCWritingLetters" +
             (Common.StaticVar.inline.IsCard ? 1 : 2) + ".jpg"; 
        }

        void IWritingLettersManager.SwitchFont()
        {
           Common.StaticVar.inline.IsCard = !Common.StaticVar.inline.IsCard;
        }

        List<LetterObject> IWritingLettersManager.WriteName(string tBLastName)
        {
            List<LetterObject> list = new List<LetterObject>();
            for (int i =tBLastName.Length-1; i>=0; i--)
            {
                list.Add(new LetterObject
                {
                    Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\He\Writing\" + tBLastName[i] + (Common.StaticVar.inline.IsCard ? "\\0.png" : "\\0.jpg")
                ,
                    Uid = "50 50 910 340"
                });
            }
            return list;
        }

        bool IWritingLettersManager.SetLetter(ref string back, char letter, int j)
        {
            back = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Lang\He\Writing\" + letter + "\\" + j +(Common.StaticVar.inline.IsCard ? ".png" : ".jpg");
            return !File.Exists(back);
        }
    }
}
