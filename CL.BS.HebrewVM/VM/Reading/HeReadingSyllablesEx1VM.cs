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

namespace CL.BS.HebrewVM.VM.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeReadingSyllablesEx1VM : BaseHeReadingSyllablesEx, IPageVM
    {
        public override string Name
        {
            get
            {
                return "HeReadingSyllablesEx1VM";
            }
        }

        public HeReadingSyllablesEx1VM()
        {
            Boards = new BoardSyllables1VM[BoardsLength];
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardSyllables1VM();
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.259;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.441;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            AnswerBut = new RelayCommand(DoAnswerBut);
          //  _logic.SetSeriesIndex(obj);
        }


        void IPageVM.load()
        {
            base.Settings();
            new Thread(new ThreadStart(() =>
            { 
            PlayList(_logic.GetOpenSentens());
            })).Start();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].BaseClear();
        }

        public void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string[] q = _logic.GetQuestion(false);
                new Thread(new ThreadStart(() =>
                {     PlayUrl(q[3]);})).Start();            
                 PlayUrl=q[3];
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
