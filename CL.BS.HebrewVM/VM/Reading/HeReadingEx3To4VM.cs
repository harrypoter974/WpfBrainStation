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
    public class HeReadingEx3To4VM : BaseLernPage, IPageVM
    {
        public override string Name => "HeReadingEx3To4VM";
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public double PicHeight { get; set; }
        public double PicWidth { get; set; }
        protected string PlayUrl;
        public string PicWord { get; set; }
        public string ButSwitchSituation { get; set; }
        public ICommand RePlay { get; set; }
        public ICommand SwitchSituation { get; set; }
        public BoardHeReadingExVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BoardHeReadingExVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BoardHeReadingExVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BoardHeReadingExVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        protected BoardHeReadingExVM[] Boards = new BoardHeReadingExVM[4];
        private IHeReadingExTo4Manager _logic = (IHeReadingExTo4Manager)
SupportHandlerManager.Base.GetManager("HeReadingExTo4Manager");
        public HeReadingEx3To4VM()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardHeReadingExVM();
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.432;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.26;
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged(nameof(BoardHeight));
            PicWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.099;
            PicHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.18;
            NotifyPropertyChanged(nameof(PicWidth) );
            NotifyPropertyChanged(nameof(PicHeight));

            AnswerBut = new RelayCommand(DoAnswerBut);

            RePlay = new RelayCommand(DoRePlay);
            SwitchSituation = new RelayCommand(DoSwitchSituation);

        }

        private void DoSwitchSituation(object obj)
        {
           if( ButSwitchSituation == String.Empty)
            {
                ButSwitchSituation = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\ExerciseReading3\buttonBLUE.png"; 
            }
            else
            {
                ButSwitchSituation = String.Empty;
            }

            NotifyPropertyChanged(nameof(ButSwitchSituation));
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                int index = ButSwitchSituation == String.Empty?int.Parse( Common.StaticVar.TransferVar.ToString())+1:6;
                string[] q = _logic.GetQuestion(index);
                int pageIndex = int.Parse(q[0]);
                int wordLength = int.Parse(q[2]);
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].SetBoard(pageIndex,q[1],wordLength);
                PicWord = q[1];
                NotifyPropertyChanged(nameof(PicWord)); 
                PlayUrl(q[3]);
                PlayUrl = q[3];
            }
            else
            {
                string[] a = _logic.GetAnswer();
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].CheckBord(a);
                PlayUrl = String.Empty;
            }
            base.SwitchAnswerButton();
        }

        private void DoRePlay(object obj)
        {
            PlayUrl(PlayUrl);
        }
        void IPageVM.load()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].Clear(0);
            base.Settings();
            ButSwitchSituation = String.Empty;
          NotifyPropertyChanged(nameof(ButSwitchSituation));    
        }
    }
}
