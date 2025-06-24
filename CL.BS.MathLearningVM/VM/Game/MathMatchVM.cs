using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMatchVM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(MathMatchVM);
            }
        }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string TBTitle { get; set; }
        public BoardMathMatchVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BoardMathMatchVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BoardMathMatchVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BoardMathMatchVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        private BoardMathMatchVM[] Boards = new BoardMathMatchVM[4];
        public Visibility RectBut { get; set; }
        public MathMatchVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.494;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.42;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
        void IPageVM.load()
        {
            base.Settings();
            string l = Common.StaticVar.MatchLevel.ToString();
            TBTitle = string.Format(@"{0}Resources\Math\Match\heading{1}.jpg", 
                System.AppDomain.CurrentDomain.BaseDirectory, l);
            NotifyPropertyChanged(nameof(TBTitle));
            if (l == "1" || l == "2")
            {
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i] = new BoardMathMatchVM();
                    Boards[i].DoSetLevel(l);
                }
                RectBut = Visibility.Collapsed;
            }
            else
            {
                BoardMathMatchVM b = new BoardMathMatchVM();
                Common.StaticVar.MatchLevel = l = l == "3" ? "1" : "2";
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i] = b;
                    Boards[i].DoSetLevel(l);
                }
                RectBut = Visibility.Visible; 
            }
            NotifyPropertyChanged(nameof(RectBut));
        }
    }
}
