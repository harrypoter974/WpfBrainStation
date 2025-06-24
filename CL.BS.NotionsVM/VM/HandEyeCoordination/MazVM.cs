using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MazVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(MazVM) ;
        private int _questionIndex = 0;
        public string BackgroundPic { get; set; }

        public MazVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        void IPageVM.load()
        {
          //  PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
          //@"Resources\Audio\He\Title\Maz.wav");
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Maz\open.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _questionIndex = _questionIndex == 1 ? 0 : _questionIndex + 1;
                BackgroundPic=System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Maz\Q"+ _questionIndex +".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Maz\A" + _questionIndex + ".jpg";
            }
            NotifyPropertyChanged(nameof(BackgroundPic) );
            base.SwitchAnswerButton();
        }
    }
}
