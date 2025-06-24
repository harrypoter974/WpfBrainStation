using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
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
  public  class MathArray2VM : VMCommon.BaseLernPage,  IPageVM
    {
        public override string Name
        {
            get
            {
                return "MathArray2VM";
            }
        }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string imageTitel { get; set; }
        public ICommand GoToLern { get; set; }
        private IMathArray3Manager _logic = (IMathArray3Manager)
SupportHandlerManager.Base.GetManager("MathArray3Manager");

        void IPageVM.load()
        {
            base.Settings();
            imageTitel = Common.StaticVar.inline.ArrayDomain == 0 ? string.Empty 
                : System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\Recognaz\10to100.jpg";
            NotifyPropertyChanged(nameof( imageTitel));
            new Thread(new ThreadStart(() =>
            {
                PlayList(_logic.OpenMessage());
            })).Start();
        }

        public MathArray2VM()
        {
            GoToLern = new RelayCommand(DoGoToLern);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.438;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.343;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
        private void DoGoToLern(object obj)
        {
            if (!CanExit) 
                return;
            if (Common.StaticVar.inline.ArrayDomain == 0)
                DoGoToPage("MathRecognaz100BVM");
            else
                DoGoToPage("MathRecognaz100CVM");
        }
    }
}
