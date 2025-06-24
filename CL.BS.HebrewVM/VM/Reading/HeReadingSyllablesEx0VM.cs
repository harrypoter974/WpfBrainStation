using BS.Items;
using CL.BS.Common;
using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace   CL.BS.HebrewVM.VM.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeReadingSyllablesEx0VM : BaseHeReadingSyllablesEx, IPageVM
    {
        public override string Name
        {
            get
            {
                return "HeReadingSyllablesEx0VM";
            }
        }
        public HeReadingSyllablesEx0VM()
        {
            Boards = new BoardSyllables0VM[BoardsLength];
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardSyllables0VM();    
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.379;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.30;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            AnswerBut = new RelayCommand(DoAnswerBut);
        }
        void IPageVM.load()
        {
            base.Settings();
            new Thread(new ThreadStart(() =>
            {
                PlayList(_logic.GetOpenSentens3());
            })).Start();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].BaseClear();
        }
        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string[] q = _logic.GetQuestion(true);
                new Thread(new ThreadStart(() =>
                { PlayUrl(q[3]); })).Start();
                PlayUrl = q[3];
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].SetBord(q[0],q[1],q[2]);
            }
            else
            {
                string a = _logic.GetAnswer();
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].ChackAnswer(a);

            }
            base.SwitchAnswerButton();
        }
    }
}
