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
    public class HeReading3VM : BaseLernPage, IPageVM
    {
        public string BackgroundPic { get; set; }
        public ICommand PlayWord { get; set; }
        public ICommand SwitchPage { get; set; }
        public ICommand PlaySyllable { get; set; }
        private IHeReading3Manager _logic = (IHeReading3Manager)
SupportHandlerManager.Base.GetManager("HeReading3Manager");
        public override string Name
        {
            get
            {
                return "HeReading3VM";
            }
        }

        public HeReading3VM()
        {
            PlayWord = new RelayCommand(DoPlayWord);
            SwitchPage = new RelayCommand(DoSwitchPage);
            PlaySyllable = new RelayCommand(DoPlaySyllable);
        }

        void IPageVM.load()
        {
            base.Settings();
            SetBackground();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\ExerciseReading3\message.jpg";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }
        private void DoPlaySyllable(object syllable)
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Audio\He\" + _logic.GetSyllable(syllable) + ".wav");

        }
        private void DoSwitchPage(object index)
        {
            _logic.SetIndex(index);
            SetBackground();
        }

        private void DoPlayWord(object indexWord)
        {
            if (_logic.GetIndex() == 1)
            {
                if (indexWord.ToString() == "4")
                    indexWord = "2";
                else if (indexWord.ToString() == "2")
                    indexWord = "4";                
            }
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Audio\He\ComplexSyllable\" + _logic.getWord( indexWord,true) + ".wav");
        }

        private void SetBackground()
        {
            Common.StaticVar.TransferVar = _logic.GetIndex();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                          + @"Resources\Lang\He\ExerciseReading3\Reading" + _logic.GetIndex()+ ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
    }
}
