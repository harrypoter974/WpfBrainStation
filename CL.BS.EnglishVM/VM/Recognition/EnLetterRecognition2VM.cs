using BS.Items;
using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.EnglishManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnLetterRecognition2VM : BaseLernPage, IPageVM
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string OpenMenuBut { get; set; }
        public string LetterPic { get; set; }
        public ICommand OpenMenu { get; set; }
        public override string Name
        {
            get
            {
                return nameof(EnLetterRecognition2VM);
            }
        }
        IEnLetterRecognitionManager _logic = (IEnLetterRecognitionManager)
SupportHandlerManager.Base.GetManager("EnLetterRecognitionManager");

        public EnLetterRecognition2VM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            OpenMenu = new RelayCommand(DoOpenMenu);
        }

        private void DoOpenMenu(object obj)
        {
          WinEnSettingsLetters win= new WinEnSettingsLetters();
            OpenMenuBut = System.AppDomain.CurrentDomain.BaseDirectory
                  + @"Resources\BS.Items\ChooseLetters.jpg";
            NotifyPropertyChanged(nameof(OpenMenuBut));
            win.Closed += Win_Closed;
            win.ShowDialog();
            _logic.ClearList();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            OpenMenuBut = string.Empty;
            NotifyPropertyChanged(nameof(OpenMenuBut));
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Niqqud\message1.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            _startTime=DateTime.Now;
        }
        void IPageVM.disload()
        {
            DatabaseManager.Inline.SaveActivity(4, _startTime, DateTime.Now,
           Name, "LERM", "", "E", 0);
        }
        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string[] q = _logic.SetQuestion();
                LetterPic= System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Recognition\Image\" + q[0] + ".jpg";
                new Thread(new ThreadStart(() =>
                { PlayUrl(q[1]); })).Start();
               
                NotifyPropertyChanged(nameof(LetterPic));
                Text1 =  Text2 = string.Empty;
            }
            else
            {
                Text1 = _logic.GetLetter();
                Text2 = _logic.GetLetter().ToLower();
            }
            base.SwitchAnswerButton();
                NotifyPropertyChanged(nameof(Text1));
                NotifyPropertyChanged(nameof(Text2));
        }
    }
}
