using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Navigation;

namespace CL.BS.NotionsVM.VM.Music
{
    public class SimonBoardVM : BaseBingoBoardVM
    {
        public override string Name => "";
        private string[] ScaleList = new string[]
        {  "do"  ,"re","mi" ,"fa" ,"sol","la" ,"ti","do2" };
        private int _answerIndex = -1;
        private bool _isWin = false,_perWin=true; 
        public double SpeedRatio { get; set; }
        private int[] _soundList = new int[20];
        public SimonBoardVM()
        {
            TapAnswer = new RelayCommand(DoTapAnswer);
        }

        private void DoTapAnswer(object obj)
        {
            string tm = obj.ToString();
            int m = int.Parse(tm);
            if (LettersList[7].Question == "Visible")
            {
                new Thread(new ThreadStart(() =>
                {
                    LettersList[m].Question = String.Format(
@"{0}Resources\Notions\Music\SimonBut{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, m);
                    NotifyPropertyChanged("TB" + m);
                    Thread.Sleep(900);
                    LettersList[m].Question = String.Empty;
                    NotifyPropertyChanged("TB" + m);
                })).Start();
                Common.StaticVar.PlayMode = false;
                PlayUrl(String.Format(@"{0}Resources\Audio\Music\{1}{2}.wav"
, System.AppDomain.CurrentDomain.BaseDirectory, ScaleList[m], SpeedRatio==1.0?string.Empty: "Short"));

                if (_soundList[ _answerIndex] == m)
                {
                    _answerIndex++;
                    if (_soundList[_answerIndex] == -1)
                    {
                        _isWin = true;
                        Common.StaticVar.isTimerRedRun = false;
                    }
                }
                else
                {
                    _isWin = Common.StaticVar.isTimerRedRun = false;
                }
            }
        }

        internal void SetSpeed(double level)
        { // Error XDG0062 אין אפשרות להמיר אובייקט מסוג 'System.Windows.Data.Binding' לסוג 'System.Double'.BS.NotionsView  C:\Brain_Station\WpfBrainStationBrachoot\BS.NotionsView\Music C:\Brain_Station\WpfBrainStationBrachoot\BS.NotionsView\Music\UCSimonBoard.xaml 102
            SpeedRatio = level;
           // NotifyPropertyChanged(nameof(SpeedRatio));
        }

        public override bool CheckAnswer(string answer)
        {
            if (answer=="1")
            {
                return LettersList[6].Question.Contains("SimonBroken");
            }
            else if(answer=="2")    
                return _perWin;
            return true;   
        }

        public override bool CheckBoard(string answer)
        {
            LettersList[7].Question = "Collapsed";
            NotifyPropertyChanged(nameof(TB7));
            return _isWin;
        }

        public override void Clear()
        {
            _answerIndex = -1;
               _perWin = true;
            for (int i = 0; i < 8; i++)
            {
                _soundList[i] = -1;
                LettersList[i].Question = String.Empty;
                NotifyPropertyChanged("TB" + i);
            }
            LettersList[7].Question = "Collapsed";
            NotifyPropertyChanged(nameof(TB7));
        }

        public override void ClearQuestion()
        {
            LettersList[7].Question = "Visible";
            NotifyPropertyChanged(nameof(TB7));
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime / 3 * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            base.PlayWin();
        }

        public override bool GetIsFirst()
        {
            return false;
        }

        public override bool QuestionIsAnswer()
        {
            return LettersList[6].Question.Contains("SimonBroken");
        }

        public override void RestartClear()
        {
        }

        public override void SetAnswer(string question)
        {

            LettersList[6].Question = "SimonBroken";
            for (int i = _answerIndex; i < 8; i++)
            {
                if (_soundList[i] == -1)
                {
                    break;
                }
                else
                {
                    int t = _soundList[i];
                    LettersList[t].Question = String.Format(
                   @"{0}Resources\Notions\Music\SimonBroken{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, t);
                    NotifyPropertyChanged("TB" + t);
                    Thread.Sleep(200);
                }
            }
        }

        public override void SetBoard(List<GameObject> list)
        {
            _perWin = !_isWin;
            _isWin = false;
            new Thread(new ThreadStart(() =>
            {
                //if (_answerIndex>0)
                //    _perWin= LettersList[6].Question.Contains("SimonBroken");
                _answerIndex = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    int t = list[i].Width;
                    _soundList[i] = t;
                    PlayUrl(String.Format(
      @"{0}Resources\Audio\Music\{1}{2}.wav", System.AppDomain.CurrentDomain.BaseDirectory,
      ScaleList[t], SpeedRatio == 1.0 ? string.Empty : "Short"));
                    LettersList[t].Question = String.Format(
      @"{0}Resources\Notions\Music\SimonBut{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, t);
                    NotifyPropertyChanged("TB" + t);
                    //  WhitAntilPlayStop();
                    Thread.Sleep(700);
                    LettersList[t].Question = String.Empty;
                    NotifyPropertyChanged("TB" + t);
                    Thread.Sleep(700);
                }
                _soundList[list.Count] = -1;
            })).Start();
        }

        public override void SetNumLetterLimit(int v)
        {
            Volume = v;
            NotifyPropertyChanged(nameof(Volume));
        }
        internal void setVolume(double v)
        {
            Volume = v;
            NotifyPropertyChanged(nameof(Volume));
        }
        public override void SetQuestion(string q)
        {
        }
    }
}
