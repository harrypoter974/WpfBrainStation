using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.JudaismVM.VM.Congratulations
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class FoodCongratulationVM : BaseLernPage, IPageVM
    {
        private string[] _playFoodList = new string[] {"foods","vine"
 ,"the issuer","the fruit of the tree" ,"the fruit of the earth","that all"  };
        public override string Name => "FoodCongratulationVM";
        public string BackgroundPic { get; set; }
        public ICommand ChangeBrahot { get; set; }
        private bool _timerRun = false;

        public FoodCongratulationVM()
        {
            ChangeBrahot= new Common.RelayCommand(DoChangeBrahot);
        }

        private void DoChangeBrahot(object obj)
        {
            if (_timerRun)
                return;
            new Thread(new ThreadStart(() =>
            {
                _timerRun = true;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\JudaismImage\Brahot\FoodC\f" + obj + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
                string n = obj.ToString();
                if (n != "open")
                {
                    PlayUrl(string.Format(@"{0}Resources\Audio\He\Judaism\{1}.wav",
                    System.AppDomain.CurrentDomain.BaseDirectory, _playFoodList[int.Parse(n)]));
                }
                for (int i = 0; i < 100 && _timerRun; i++)
                    Thread.Sleep(80);
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\JudaismImage\Brahot\FoodC\open.jpg";
                NotifyPropertyChanged("BackgroundPic");
                _timerRun = false;
            })).Start();
        }

        void IPageVM.load()
        {
            _timerRun = false;
            base.Settings();
            DoChangeBrahot( Common.StaticVar.TransferVar);
        }
        void IPageVM.disload()
        {
            _timerRun = false;
        }
    }
}
