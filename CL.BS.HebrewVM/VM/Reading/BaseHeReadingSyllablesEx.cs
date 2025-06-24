using BS.Items;
using CL.BS.HebrewManager.Interface.Recognition;
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
    public class BaseHeReadingSyllablesEx : BaseLernPage
    {
        protected IHeReadingSyllablesExManager _logic = (IHeReadingSyllablesExManager)
 SupportHandlerManager.Base.GetManager("HeReadingSyllablesExManager");
        protected string PlayUrl;
        protected Random _ran = new Random(DateTime.Now.Millisecond);
        public ICommand RePlay { get; set; }
        public ICommand OpenMenu { get; set; }
        public BaseBoardSyllablesVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BaseBoardSyllablesVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BaseBoardSyllablesVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BaseBoardSyllablesVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        protected BaseBoardSyllablesVM[] Boards;
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        protected const int BoardsLength = 4;
        public override string Name
        {
            get
            {
                return string.Empty;
            }
        }

        public BaseHeReadingSyllablesEx()
        {
            RePlay = new RelayCommand(DoRePlay);
            OpenMenu = new RelayCommand(DoOpenMenu);
        }

        private void DoOpenMenu(object obj)
        {
            new WinHeVowels().ShowDialog();
            //WinHeVowels win = new WinHeVowels();
            //win.Closed += Win_Closed;
            //win.ShowDialog();
        }

        //private void Win_Closed(object sender, EventArgs e)
        //{
        //}


        private void DoRePlay(object obj)
        {
            PlayUrl(PlayUrl);
        }
      
    }
}
