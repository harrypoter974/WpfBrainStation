using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Reading;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeReading2VM : BaseLernPage, IPageVM
    {
        private string[] _words = new string[] {
            "note","tablespoon", "Turtle", "bag",  "basket",
            "falcon", "garden","bull" , "Fish",  "Mountain"  };
        public ICommand PlayWord { get; set; }
        private IHeReading2Manager _logic = (IHeReading2Manager)
SupportHandlerManager.Base.GetManager("HeReading2Manager");
        public override string Name
        {
            get
            {
                return "HeReading2VM";
            }
        }

        public HeReading2VM()
        {
            PlayWord = new RelayCommand(DoPlayWord);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\ExerciseReading3\message.jpg";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof( messagePic));
        }

        private void DoPlayWord(object word)
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Audio\He\OneSyllable\" +
                 _words[int.Parse(word.ToString())] + ".wav");
        }
    }
}
