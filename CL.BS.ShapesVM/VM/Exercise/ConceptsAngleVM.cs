using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ConceptsAngleVM : BaseLernPage, IPageVM
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        private string[] _answersList = new string[] { "140", "110" , "40", "70"};
        public string BackgroundPic { get; set; }
        public string TBAnswer { get; set; }
        public string KeyboardVisibility { get; set; }
        public ICommand TypeNum { get; set; }
        public override string Name => "ConceptsAngleVM";

        public ConceptsAngleVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            KeyboardVisibility = "Collapsed";
            NotifyPropertyChanged("KeyboardVisibility");
            TypeNum = new RelayCommand(DoTypeNum);
            TBAnswer = string.Empty;//MAngle3   
            DoAnswerBut(0);
        }

        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Shapes\Concepts\MAngle.jpg";
            NotifyPropertyChanged("BackgroundPic");
            TBAnswer = string.Empty;
            NotifyPropertyChanged("TBAnswer");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoTypeNum(object num)
        {
            string nl = num.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < TBAnswer.Length - 1; i++)
                    ns += TBAnswer[i];
                TBAnswer = ns;
            }
            else if (TBAnswer.Length < 3)
            {
                TBAnswer += nl;           
            }
            NotifyPropertyChanged("TBAnswer");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _index = _logic.GetIndex(4);
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\Shapes\Concepts\MAngle" + _index + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                TBAnswer = string.Empty;
                NotifyPropertyChanged("TBAnswer");
            }
            else
            {
                if (TBAnswer == _answersList[_index])
                {
                    new Thread(new ThreadStart(() =>
                    {
                        PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                            @"Resources\Audio\He\Good\Win" + _ran.Next(8) + ".wav" });
                    })).Start();
                }
                else
                {
                    new Thread(new ThreadStart(() =>
                    {
                        PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                        @"Resources\Audio\He\Bad\Error" + _ran.Next(3) + ".wav" });
                    })).Start();
                }
            }
            base.SwitchAnswerButton();
        }
    }
}
#region MyRegion
//private void DoAnswerBut(object obj)
//{
//    if (base.IsQuestionMode)
//    {
//        angle = Ran.Next(36) * 5;
//        double a = ((double)angle / 180.0) * Math.PI;
//        X2 = Math.Cos(a) * LineLength;
//        Y2 = -Math.Sin(a) * LineLength;
//        NotifyPropertyChanged("X2");
//        NotifyPropertyChanged("Y2");
//        TBAngle = string.Empty;
//    }
//    else
//    {
//        TBAngle = angle + "º";
//        new Thread(new ThreadStart(() =>
//        {
//            if (TBAngle == angle.ToString())
//            {
//                PlayList(new string[] { Common.StaticVar.PlayName(),
//                            @"Resources\Audio\He\Good\Win" + Ran.Next(8) + ".wav" });
//            }
//            else
//            {
//                PlayList(new string[] { Common.StaticVar.PlayName(),
//                        @"Resources\Audio\He\Bad\Error" + Ran.Next(3) + ".wav" });
//            }
//        })).Start();
//    }
//    NotifyPropertyChanged("TBAngle");
//    base.SwitchAnswerButton();
//}
//private int angle;
#endregion