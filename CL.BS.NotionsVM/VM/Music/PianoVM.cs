using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Music
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PianoVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(PianoVM);
        private string[] _ScaleList = new string[] { "do", "re", "mi", "fa", "sol", "la", "ti", "do2" };
        private int _pianoIndex = 0;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public Piano_bordVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public Piano_bordVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public Piano_bordVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public Piano_bordVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        private Piano_bordVM[] Boards=new Piano_bordVM[4];
        public ICommand switchForPractice { get; set; }
        public ICommand RePlay { get; set; }
        public ICommand changeVolume { get; set; }
        public string ToLarneButton { get; set; }
        public string IsLarne { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public PianoVM()
        {
            for (int i = 0; i <Boards.Length ; i++)
                Boards[i]=new Piano_bordVM();
            changeVolume= new RelayCommand(DoChangeVolume);
            switchForPractice = new RelayCommand(DoSwitchForPractice);
            AnswerBut = new RelayCommand(DoAnswerBut);
            RePlay = new RelayCommand(DoRePlay);
            ToLarneButton = string.Empty; 
            IsLarne = "Visible";
            NotifyPropertyChanged(nameof(IsLarne));
            NotifyPropertyChanged(nameof(ToLarneButton));
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.494;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.369;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void DoChangeVolume(object obj)
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].setVolume( Volume);
        }

        private void DoSwitchForPractice(object obj)
        {
            ToLarneButton = ToLarneButton == string.Empty? String.Format(@"{0}Resources\BS.Items\ToLarneButton.jpg",
                System.AppDomain.CurrentDomain.BaseDirectory) : string.Empty;
            NotifyPropertyChanged(nameof(ToLarneButton));
            bool b = ToLarneButton == string.Empty;
            IsLarne =b? "Visible" : "Collapsed";
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].IsExercise(!b);
            NotifyPropertyChanged(nameof(IsLarne));
        }

        private void DoRePlay(object obj)
        {
            Common.StaticVar.PlayMode = false;
            PlayUrl(String.Format(@"{0}Resources\Audio\Music\{1}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory, _ScaleList[_pianoIndex]));
        }

        private void DoAnswerBut(object obj)
        {
            if ( ToLarneButton == string.Empty)
                return;
            if (base.IsQuestionMode)
            {
                _pianoIndex = _ran.Next(_ScaleList.Length);
                DoRePlay(0);
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].Clear();
            }
            else
            {
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].CheckQuestion(_pianoIndex);
            }
            base.SwitchAnswerButton();
        }
    }
}
