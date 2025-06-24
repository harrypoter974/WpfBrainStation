using CL.BS.Contract;
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
    public class MathRecognaz100AVM : VM.Recognaz.OpenMathRecognaz, IPageVM
    {
        public string ButLevel1 { get; set; }
        public ICommand PlayNum { get; set; }
        public override string Name => "MathRecognaz100AVM";

        void IPageVM.load()
        {
            base.Settings();
            messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\Num\" + (Common.StaticVar.inline.IsBoy? "BoyMessage" : "Grilmessage") + ".png";
            NotifyPropertyChanged("messagePic");
        }

        public MathRecognaz100AVM()
        {
            PlayNum = new RelayCommand(DoPlayNum);
        }

        private void DoPlayNum(object Num)
        {
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Audio\He\Num\" + Num + ".wav");
                if (Num.ToString() == "10")
                    UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory +
                                 @"Resources\Audio\He\Num\n" + Num + ".wav";
            })).Start();
        }
    }
}
