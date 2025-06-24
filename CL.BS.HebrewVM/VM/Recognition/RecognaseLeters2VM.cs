using BS.Items.Properties;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class RecognaseLeters2VM : RecognaseLeters, IPageVM
    { 
        public override string Name
        {
            get
            {
                return nameof(RecognaseLeters2VM);
            }
        }
        public double KeyboardWidth { get; set; }
        public double KeyboardHeight { get; set; }
        public string OpenMenuBut { get; set; }
        public ICommand RePlay { get; set; }
        public ICommand OpenMenu { get; set; }
        public BoardRecognaseLetersVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BoardRecognaseLetersVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BoardRecognaseLetersVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BoardRecognaseLetersVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        public BoardRecognaseLetersVM[] Boards = new BoardRecognaseLetersVM[4];
        private string _playUrl;
        private string _Letter;
        private List<string> _Letters = new List<string>();
        private WinHeSettingsLetters _win;
        public RecognaseLeters2VM()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardRecognaseLetersVM();
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
            OpenMenuBut = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\BS.Items\ChooseLetters.jpg";
            NotifyPropertyChanged("OpenMenuBut");
            _win =  new WinHeSettingsLetters("");
            _win.Closed += Win_Closed;
            _win.ShowDialog();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            OpenMenuBut = string.Empty;
            NotifyPropertyChanged("OpenMenuBut");
            _Letters = new List<string>();
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
                _playUrl = string.Format(@"{0}Resources\Audio\He\Letters\{1}.wav",
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
          List<  string> l = Common.StaticVar.inline._HeLetterList;
            if (l.Count < 5)
                l = new List<string>( Common.StaticVar.HeLeters);
            //l = Common.StaticVar.inline._IsBigEnLetter ? l.ToUpper() : l.ToLower();
            for (int i = 0; i < l.Count; i++)
            {
                _Letters.Add(l[i]);
            }
            _Letters = Common.GeneralFunctions.ShuffleList<string>(_Letters);
        }

    }
}
