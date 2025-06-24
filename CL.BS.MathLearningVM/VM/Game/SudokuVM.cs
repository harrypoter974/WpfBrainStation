using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class SudokuVM : VMCommon.BaseLernPage, IPageVM
    {
        private string[,] _bord;
        private BaseSudokuBord[] _Bord = new BaseSudokuBord[]
        { new SBord4x4VM(),new SBord4x4VM(),new SBord6x6VM(),new SBord6x6VM()};
        public string buttonCardOrWrite { get; set; }
        public string ShowAnswerBut { get; set; }
        public string NewGameBut { get; set; }
        public string IsGarden { get; set; }
        public ICommand SwitchCard { get; set; }
        public ICommand ShowAnswer { get; set; }
        public ICommand GHome { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public int ColumnR { get; set; }
        public int RowR { get; set; }
        public int ColumnSpanR { get; set; }
        public int RowSpanR { get; set; }
        public BaseSudokuBord SudokuBord { get; set; }
        public BaseSudokuBord SudokuBordR { get; set; }
        private bool _isCard = true;
        public override string Name
        {
            get
            {
                return nameof(SudokuVM) ;
            }
        }
        private ISudokuManager _logic = (ISudokuManager)
SupportHandlerManager.Base.GetManager("SudokuManager");

        void IPageVM.load()
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Audio\He\Title\Sudoku.wav");
            base.Settings();
            DoSetSize(Common.StaticVar.IsGarden ? "4x4" : "9x9");
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\Sudoku\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            IsGarden = Common.StaticVar.IsGarden ? "Visible" : "Collapsed";
        }

        public SudokuVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            ShowAnswer= new RelayCommand(DoShowAnswer);
            SwitchCard = new RelayCommand(DoSwitchCard);
            GHome = new RelayCommand(DoGoHome);
        }

        private void DoGoHome(object obj)
        {
            if (Common.StaticVar.IsGarden)
            {
                DoGoToPage( "MenuHeGeneralGameVM");
            }
            else
            {
                DoGoToPage("MenuGameVM");
            }
        }

        private void DoSwitchCard(object obj)
        {
            lock (this)
            {
                _isCard = !_isCard;
                _Bord[0].SwitchCardRoWrite(_isCard);
                _Bord[1].SwitchCardRoWrite(_isCard);
                buttonCardOrWrite = _isCard ? System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\writingButton.png" : string.Empty;
                NotifyPropertyChanged(nameof(buttonCardOrWrite) );
            }
        }

        private void DoSetSize(object obj)
        {
            string size = obj.ToString();
            if (size == "4x4")
            {
                SudokuBordR = _Bord[1];
                SudokuBord = _Bord[0];
                Column = 7;//Grid.ColumnSpan="1" Grid.Column="7"  Grid.Row="3" Grid.RowSpan="4"
                Row =3;
                ColumnSpan = 1;
                RowSpan = 4;//Grid.ColumnSpan="1" Grid.Column="3"  Grid.Row="6" Grid.RowSpan="1"
                ColumnR = 3;
                RowR = 6;
                ColumnSpanR = 1;
                RowSpanR = 1;
                _bord = new string[4, 4];
            }
            else
            {
                SudokuBordR = _Bord[2];
                SudokuBord = _Bord[3];
                Column = 6;
                Row = 1;
                ColumnSpan = 3;
                RowSpan = 8;
                ColumnR = 2;// Grid.ColumnSpan="3" Grid.Column="2"  Grid.Row="6" Grid.RowSpan="1"
                RowR =6;
                ColumnSpanR = 3;
                RowSpanR = 1;
                _bord = new string[6,6];
            }
            NotifyPropertyChanged(nameof(SudokuBord));
            NotifyPropertyChanged(nameof(SudokuBordR));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(ColumnSpan));
            NotifyPropertyChanged(nameof(RowSpan));
            NotifyPropertyChanged(nameof(ColumnR));
            NotifyPropertyChanged(nameof(RowR));
            NotifyPropertyChanged(nameof(ColumnSpanR));
            NotifyPropertyChanged(nameof(RowSpanR));
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoAnswerBut(object obj)
        {
            try
            {
                bool b = Common.StaticVar.IsGarden;

                _bord = _logic.SetQuestionBord(b,0);
                SudokuBord.SetBord(_bord, b ? 4 : 9);
                SudokuBordR.SetBord(_bord, b ? 4 : 9);
                ShowAnswerBut = string.Empty;
                NewGameBut = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\BS.Items\buttonNewGame.png";
                NotifyPropertyChanged(nameof(ShowAnswerBut));
                NotifyPropertyChanged(nameof(NewGameBut));
            }
            catch (Exception e)
            {
                Common.GlobalLog.Write(e.ToString());
            }
        }

        private void DoShowAnswer(object obj)
        {
            try
            {
                bool b = Common.StaticVar.IsGarden;
                string[,] bord = _logic.SetAnswerBord(b);
                if (bord == null)
                    return;
                SudokuBordR.SetBord(bord, b ? 4 : 9);
                NewGameBut = string.Empty;
                ShowAnswerBut = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\BS.Items\ShowAnswer.png";
                NotifyPropertyChanged(nameof(ShowAnswerBut));
                NotifyPropertyChanged(nameof(NewGameBut));
            }
            catch (Exception e)
            {
                Common.GlobalLog.Write(e.ToString());
            }
        }
    }
}
