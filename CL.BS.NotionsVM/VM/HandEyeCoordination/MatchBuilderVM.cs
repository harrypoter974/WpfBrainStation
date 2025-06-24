using CL.BS.Contract;
using CL.BS.VMCommon;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MatchBuilderVM : BaseLernPage, IPageVM
    {
        private int _numIndex = 0;
        private bool isFerst = false;
        public string OpenPageVisibility { get; set; }
        public ICommand OpenPage { get; set; }
        public ICommand SetNum { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name => nameof(MatchBuilderVM);

        public MatchBuilderVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetNum = new RelayCommand(DoSetNum);
            OpenPage = new RelayCommand(DoOpenPage);
        }

        void IPageVM.load()
        {
          //  PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
          //@"Resources\Audio\He\Title\MatchBuilder.wav");
            base.Settings();
            OpenPageVisibility = "Visible";
            NotifyPropertyChanged("OpenPageVisibility");
               BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MatchBuilder\open.jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            isFerst = true;
            messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoOpenPage(object obj)
        {
            OpenPageVisibility = "Collapsed";
            NotifyPropertyChanged("OpenPageVisibility");
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MatchBuilder\open1.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void DoSetNum(object obj)
        {
            if (isFerst)
            {
                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                       @"Resources\Notions\MatchBuilder\message.png";
                }
                else
                    messagePic = string.Empty;
                NotifyPropertyChanged("messagePic");
                isFerst = false;
            }
            _numIndex = int.Parse(obj.ToString());
            if (base.IsQuestionMode)
                base.SwitchAnswerButton();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MatchBuilder\Q" + _numIndex + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MatchBuilder\Q" + _numIndex + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\MatchBuilder\A" + _numIndex + ".jpg";
            }
            NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }
    }
}
