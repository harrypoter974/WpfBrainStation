using BS.Items;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    public class MathComplexVM : BaseLernPage
    {
        public BoardExercise1VM[] Boards = new BoardExercise1VM[4]; 
        public BoardExercise1VM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BoardExercise1VM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BoardExercise1VM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BoardExercise1VM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        public ICommand Return { get; set; }  
     
        public override string Name => "MathComplexVM";
        protected IMathComplexManager _logic;

        public string TBTitle { get; set; }
        public string ImageMenuVisibility { get; set; }

        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public MathComplexVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.456;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.472;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
    }
}
