using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Text;
using CL.BS.EnglishManager.Interface.Text;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnWriteLetterManager : IEnWriteLetterManager,IManager
    {
        private string _letter = "a";
        string IManager.ManagerName => "EnWriteLetterManager";
        private WritingEnNameEngen _logic = new WritingEnNameEngen();

        string IEnWriteLetterManager.GetLetter()
        {
            return _letter;
        }

        void IEnWriteLetterManager.SetLetter(object letter)
        {
           _letter=letter.ToString();
        }

        List<ItemObject> IEnWriteLetterManager.WriteName(string tBFirstName)
        {
            return _logic.WriteName( tBFirstName);
        }

        bool IEnWriteLetterManager.SetLetter(ref string back, char letter, int j,bool isBig)
        {
           return _logic.SetLetter(ref  back,  letter,  j,isBig);
        }

        int IEnWriteLetterManager.EndLetter()
        {
            return _logic.EndLetter(_letter);
        }
    }
}
