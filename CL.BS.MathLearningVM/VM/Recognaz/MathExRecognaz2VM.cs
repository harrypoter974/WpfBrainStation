using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathExRecognaz2VM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "MathExRecognaz2VM";
        private string[] _replayText;
        public string TAnswer { get; set; }
        public ICommand Replay { get; set; }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\Recognaz\MessageBoll.png";
            }
            else
                messagePic = string.Empty;
            TAnswer = string.Empty;
            NotifyPropertyChanged("messagePic");
            NotifyPropertyChanged("TAnswer");
        }

        private MathExRecognaz2VM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            Replay = new RelayCommand(DoReplay);
        }

        private void DoReplay(object obj)
        {
            if (_replayText != null)
            {
                new Thread(new ThreadStart(() =>
                { PlayList(_replayText); })).Start();
            }
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
            //    new Thread(new ThreadStart(() =>
            //    {
            //        _replayText = _logic.SetQuestion();
            //        PlayList(_replayText);
            //    })).Start();
            //    TAnswer = string.Empty;
            //    for (int i = 0; i < _images.Length; i++)
            //    {
            //        _images[i].Text = string.Empty;
            //        NotifyPropertyChanged("Image" + i);
            //    }
            //    //   AnswerVisibility = "Visible";
            //}
            //else
            //{
            //    TAnswer = _logic.GetAnswer();
            //    int num = int.Parse(TAnswer);
            //    for (int i = 0; i < _images.Length; i++)
            //    {
            //        _images[i].Text = i < num ? System.AppDomain.CurrentDomain.BaseDirectory +
            //        @"Resources\BS.Items\kadur.png" : string.Empty;
            //        NotifyPropertyChanged("Image" + i);
            //    }

                //   AnswerVisibility = TAnswer.Length==1? "Hidden" : "Visible";
            }

            base.SwitchAnswerButton();
            //   NotifyPropertyChanged("AnswerVisibility");
            NotifyPropertyChanged("TAnswer");
        }
    }
}
