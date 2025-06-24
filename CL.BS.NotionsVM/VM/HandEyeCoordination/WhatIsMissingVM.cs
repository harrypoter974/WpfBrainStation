using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WhatIsMissingVM : BaseLernPage, IPageVM
    {
        public override string Name =>nameof(WhatIsMissingVM) ;
        public string BackgroundPic { get; set; }
        private int _pageIndex = 0;

        public WhatIsMissingVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\WhatIsMissing\open.jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\WhatIsMissing\Q"+ _pageIndex + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\WhatIsMissing\A" + _pageIndex + ".jpg";
                _pageIndex = _pageIndex == 2 ? 0 : _pageIndex + 1;
            }
            NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }
    }
}
