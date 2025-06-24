using CL.BS.Contract;
using CL.BS.VMCommon;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EmotionsExerciseVM : BaseLernPage, IPageVM
    {
        private string[,] _emotions = new string[,] {
            {"hope","Love", "Satisfaction", "enthusiasm", "disappointment", "despair", "indifference", "Hate" },
            {"Pride","anger", "Peacefulness", "happiness", "Sadness", "shame", "calm", "anxiety"  } };
        private int _pageIndex = 0;
        public ICommand ShowEmotion { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name =>nameof(EmotionsExerciseVM);

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
                messagePic = "Visible";
            else
                messagePic = "Hidden";
            NotifyPropertyChanged(nameof(messagePic ));

            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Notions\Emotions\open.jpg";

            NotifyPropertyChanged( nameof( BackgroundPic));
            Common.StaticVar.PlayMode = false;
        }

        public EmotionsExerciseVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            ShowEmotion = new RelayCommand(DoShowEmotion);
        }

        private void DoShowEmotion(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            int emotion = int.Parse(obj.ToString());
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Audio\He\Emotions\" + _emotions[_pageIndex, emotion] + ".wav");
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                _pageIndex = _pageIndex == 0 ? 1 : 0;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Emotions\QEmotions" + _pageIndex + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Notions\Emotions\AEmotions" + _pageIndex + ".jpg";
            }
            NotifyPropertyChanged(nameof(BackgroundPic) );
            base.SwitchAnswerButton();
        }
    }
}
