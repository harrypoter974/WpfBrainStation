using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MusicalLnstrumentsExerciseVM : BaseItemPage, IPageVM
    {

        private string[,] _musicals = new string[,] {
              {"xylophone","guitar", "harmonica", "mandoline" }
            , { "Flute", "harp", "accordion", "trumpet" },
              { "cello", "drum", "Violin", "piano" } };
        private string _reMusic = string.Empty;
        private int _pageIndex = 0, SpeakerIndex=0;
        public string BackgroundPic { get; set; }
        public ICommand Play { get; set; }
        public ICommand RePlay { get; set; }
        public string Speaker0 { get { return Speakers[0].Background; } set { Speakers[0].Background = value; } }
        public string Speaker1 { get { return Speakers[1].Background; } set { Speakers[1].Background = value; } }
        public string Speaker2 { get { return Speakers[2].Background; } set { Speakers[2].Background = value; } }
        public string Speaker3 { get { return Speakers[3].Background; } set { Speakers[3].Background = value; } }
        protected LetterObject[] Speakers = new LetterObject[4];
        public override string Name =>nameof(MusicalLnstrumentsExerciseVM) ;

        public MusicalLnstrumentsExerciseVM()
        {
            Play = new RelayCommand(DoPlay);
            RePlay = new RelayCommand(DoRePlay);
            AnswerBut = new RelayCommand(DoAnswerBut);
            for (int i = 0; i < Speakers.Length; i++)
                Speakers[i] = new LetterObject();
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\MusicalLnstruments\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            _pageIndex = 0;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MusicalLnstruments\open.jpg";
            NotifyPropertyChanged("BackgroundPic");
            Common.StaticVar.PlayMode = false;
            IsQuestionMode = true;
            BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GShowTask.png";
            NotifyPropertyChanged(nameof(BackgroundAnswerButton) );
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _pageIndex = _pageIndex == 2 ? 0 : _pageIndex + 1;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MusicalLnstruments\Q" + _pageIndex + ".jpg";
            
            }
            else
            {
                UrlPlay = string.Empty;
                Common.StaticVar.PlayMode = false;
                Speakers[SpeakerIndex].Background = string.Empty;
                NotifyPropertyChanged("Speaker" + SpeakerIndex);

                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MusicalLnstruments\A" + _pageIndex + ".jpg";
            }
            NotifyPropertyChanged(nameof(BackgroundPic));
            IsQuestionMode = !IsQuestionMode;
            if (IsQuestionMode)
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GShowTask.png";
            else
                BackgroundAnswerButton=System.AppDomain.CurrentDomain.BaseDirectory+@"Resources\BS.Items\BShowSolution.png";
            NotifyPropertyChanged(nameof(BackgroundAnswerButton) );
        }

        private void DoRePlay(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            PlayUrl(_reMusic);
            SpeakerPlay();
        }

        private void DoPlay(object obj)
        {
            if (base.IsQuestionMode)
                return;
            Common.StaticVar.PlayMode = false;
            Speakers[SpeakerIndex].Background = string.Empty;
            NotifyPropertyChanged("Speaker" + SpeakerIndex);
            SpeakerIndex = int.Parse(obj.ToString());
            _reMusic = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Audio\He\Music\" + _musicals[_pageIndex, SpeakerIndex].Replace("\u0095", string.Empty) + ".wav";
            PlayUrl(_reMusic);
            SpeakerPlay();
        }

        private void SpeakerPlay()
        {
            new Thread(new ThreadStart(() =>
            {
                int sp = 0;
                while (Common.StaticVar.PlayMode)
                {
                    Speakers[SpeakerIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\MusicalLnstruments\speaker" + sp + ".png";
                    NotifyPropertyChanged("Speaker" + SpeakerIndex);
                    sp = sp == 2 ? 0 : sp + 1;
                    Thread.Sleep(400);
                }
                Speakers[SpeakerIndex].Background = string.Empty;
                NotifyPropertyChanged("Speaker" + SpeakerIndex);
            })).Start();
        }
    }
}
