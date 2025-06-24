using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class UnusualVM : BaseLernPage, IPageVM
    {
        private int _picIndex = 0;
        public ICommand OpenBut { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name => nameof(UnusualVM);

        public UnusualVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            OpenBut = new RelayCommand(DoOpenBut);
        }

        void IPageVM.load()
        {
         //   PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
         //@"Resources\Audio\He\Title\Unusual.wav");
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Unusual\open.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic) );
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoOpenBut(object obj)
        {
            if (BackgroundPic.Contains(@"Resources\Notions\Unusual\open.jpg"))
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\Notions\Unusual\Q" + _picIndex + ".jpg";
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Unusual\Q" + _picIndex + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Unusual\A"+ _picIndex + ".jpg";
                _picIndex = _picIndex == 4 ? 0 : _picIndex + 1;
            }
            NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }
    }
}
