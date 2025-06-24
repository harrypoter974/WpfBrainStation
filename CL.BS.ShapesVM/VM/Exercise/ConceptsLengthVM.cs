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
    public class ConceptsLengthVM : BaseLernPage, IPageVM
    {
        private int _index = 0;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string[] _answersList = new string[] { "22", "12" };
        public string TBAnswer { get; set; }
        public string KeyboardVisibility { get; set; }
        public ICommand TypeNum { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name => "ConceptsLengthVM";

        public ConceptsLengthVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        
            KeyboardVisibility = "Collapsed";
            NotifyPropertyChanged("KeyboardVisibility");
            TypeNum = new RelayCommand(DoTypeNum);
            TBAnswer = string.Empty;
        }

        void IPageVM.load()
        {
            base.Settings();
            TBAnswer = string.Empty;
            NotifyPropertyChanged("TBAnswer");
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Shapes\Concepts\LengthOpen.jpg";
            NotifyPropertyChanged("BackgroundPic");
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
            else if (TBAnswer.Length < 2)
            {
                TBAnswer += nl;
            }
            NotifyPropertyChanged("TBAnswer");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\Shapes\Concepts\Length" + _index + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                TBAnswer =  string.Empty;
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
                _index = _index == 0 ? 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}
