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
    public class ConceptsMeasurementVM : BaseLernPage, IPageVM
    {
        private int _questionIndex = 0;
        private string[] _answersList = new string[] { "16", "12", "10" };
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public ICommand TypeNum { get; set; }
        public string QuestionImage { get ; set; }
        public string KeyboardVisibility { get; set; }
        public string NumText{ get; set; }
        public override string Name => "ConceptsMeasurementVM";

        public ConceptsMeasurementVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            TypeNum = new RelayCommand(DoTypeNum);
            KeyboardVisibility = "Collapsed";
            NotifyPropertyChanged("KeyboardVisibility");
        }

        void IPageVM.load()
        {
            base.Settings();
            QuestionImage = NumText = string.Empty;
            NotifyPropertyChanged("QuestionImage");
            NotifyPropertyChanged("NumText");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoTypeNum(object num)
        {
            string nl = num.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < NumText.Length - 1; i++)
                    ns += NumText[i];
                NumText = ns;
            }
            else if (NumText.Length < 2)
            {
                NumText += nl;
            }
            NotifyPropertyChanged("NumText" );
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                NumText = string.Empty;
                QuestionImage= System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Shapes\Concepts\‏‏MeasurementQuestion"+ _questionIndex + ".jpg";
                NotifyPropertyChanged("NumText" );
                NotifyPropertyChanged("QuestionImage");
            }
            else
            {
                if (NumText == _answersList[_questionIndex])
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
                _questionIndex = _questionIndex == 2 ? 0 : _questionIndex + 1;
            }
            base.SwitchAnswerButton();
        }
    }
}
