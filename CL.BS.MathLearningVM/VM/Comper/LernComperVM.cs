using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LernComperVM : BaseLernPage, IPageVM
    { 
        public override string Name => "LernComperVM";
        public string BackgroundPic { get; set; }
        public ICommand SetPage { get; set; }

        public LernComperVM() {
            SetPage = new RelayCommand(DoSetPage);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                  + @"Resources\Math\Comper\lernMessage.png";
                NotifyPropertyChanged(nameof(messagePic));
            }
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Math\Comper\Comper1.jpg";
            NotifyPropertyChanged((nameof(BackgroundPic)));
        }

        private void DoSetPage(object obj)
        {
            int i = int.Parse(obj.ToString());
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Math\Comper\Comper"+i+".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(new string[] {@"Resources\Audio\He\General\small.wav" ,
@"Resources\Audio\He\General\Equal.wav" , @"Resources\Audio\He\General\big.wav"  }[i]);})).Start();
    }
    }
}
