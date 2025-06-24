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

namespace   CL.BS.HebrewVM.VM.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeReadingEx2To4VM : BaseLernPage, IPageVM
    {
        public override string Name => "HeReadingEx2To4VM";
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        protected string PlayUrl;
        public ICommand RePlay { get; set; }
        public BoardHeReadingExVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BoardHeReadingExVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BoardHeReadingExVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BoardHeReadingExVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        protected BoardHeReadingExVM[] Boards =new BoardHeReadingExVM[4];

        private IHeReadingExTo4Manager _logic = (IHeReadingExTo4Manager)
SupportHandlerManager.Base.GetManager("HeReadingExTo4Manager");
      
        public HeReadingEx2To4VM()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardHeReadingExVM();   
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.433;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.438;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));

            AnswerBut = new RelayCommand(DoAnswerBut);

            RePlay = new RelayCommand(DoRePlay);
        } 
     private  string[] a;
        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string[] q = _logic.GetQuestion(0);
              a  = _logic.GetAnswer();
                int pageIndex = int.Parse(q[0]);
                int wordLength = int.Parse(q[2]);
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].SetBoard(pageIndex, q[1], wordLength);
                PlayUrl = q[3];
                DoRePlay(0);
            }
            else
            {
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].CheckBord(a );
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
                Boards[i].Clear(6);
            base.Settings();
        }
    }
}
