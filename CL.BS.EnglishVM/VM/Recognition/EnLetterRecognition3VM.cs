using BS.Items;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public  class EnLetterRecognition3VM : BaseLernPage,  IPageVM
    {
        public double KeyboardWidth { get; set; }
        public double KeyboardHeight { get; set; }
        public string OpenMenuBut { get; set; }
        public ICommand RePlay { get; set; }
        public ICommand OpenMenu { get; set; }
        public BoardEnLetterRecognitionVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BoardEnLetterRecognitionVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BoardEnLetterRecognitionVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BoardEnLetterRecognitionVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        public BoardEnLetterRecognitionVM[] Boards = new BoardEnLetterRecognitionVM[4];
        private string _playUrl;
        private string _Letter;
        private List<char> _Letters = new List<char>();
        private WinEnSettingsLetters _win;
        public override string Name
        {
            get
            {
                return nameof(EnLetterRecognition3VM);
            }
        }

        public EnLetterRecognition3VM()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i]=new BoardEnLetterRecognitionVM();
            AnswerBut = new RelayCommand(DoAnswerBut);
            RePlay = new RelayCommand(DoRePlay);
            OpenMenu = new RelayCommand(DoOpenMenu);
            KeyboardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.364;
            KeyboardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.434;
            NotifyPropertyChanged(nameof(KeyboardWidth));
            NotifyPropertyChanged(nameof(KeyboardHeight));
            FillLetters();
        }

        private void DoOpenMenu(object obj)
        {
            _win = new WinEnSettingsLetters();
            _win.Closed += Win_Closed;
            _win.ShowDialog();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            _Letters = new List<char>();
            FillLetters();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetBackground();
        }

        private void DoRePlay(object obj)
        {
            PlayUrl(_playUrl);
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                if (_Letters.Count() == 0)
                    FillLetters();
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].Clear();
                _Letter = _Letters[0].ToString();
                _Letters.RemoveAt(0);
                _playUrl = string.Format(@"{0}Resources\Audio\En\Letters\{1}.wav", 
                    System.AppDomain.CurrentDomain.BaseDirectory, _Letter);
                PlayUrl(_playUrl);
            }
            else
            {
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].CheckAnswer(_Letter);
            }
            base.SwitchAnswerButton();
        }
        private void FillLetters()
        {
            string l = Common.StaticVar.inline._EnLetterList.Length > 4 ? 
                Common.StaticVar.inline._EnLetterList : "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            l = Common.StaticVar.inline._IsBigEnLetter ? l.ToUpper() : l.ToLower();
            for (int i = 0; i <l.Length ; i++)
            {
                _Letters.Add(l[i]); 
            }
            _Letters= Common.GeneralFunctions.ShuffleList<char>(_Letters);
        }

        void IPageVM.load()
        {
            base.Settings();
            _startTime=DateTime.Now;
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4, _startTime, DateTime.Now,
           Name, "LERM", "", "E", 0);
        }
    }
}
