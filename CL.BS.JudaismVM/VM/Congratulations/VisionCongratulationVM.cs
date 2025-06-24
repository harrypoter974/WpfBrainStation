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
    public  class VisionCongratulationVM : BaseMenuVM, IPageVM
    {
        private string[,] _playCongratulationList = new string[,] {{"Lightning",""}
 ,{"Thunder","Ream Barakah"} ,{"Rainbow","" } };
        public override string Name => "VisionCongratulationVM";
        public string BackgroundPic { get; set; }
        public string LightningVisibility { get; set; }
        public ICommand ChangeBrahot { get; set; }
        private int _indexPage = 0;
        private bool _timerRun = false;
        public VisionCongratulationVM()
        {
            ChangeBrahot = new Common.RelayCommand(DoChangeBrahot);
        }

        private void DoChangeBrahot(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            new Thread(new ThreadStart(() =>
            {
                string n = obj.ToString();
                _indexPage = int.Parse(n);
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\JudaismImage\Brahot\Vision\v" + n + ".jpg";
                LightningVisibility = n == "0" ? "Visible" : "Hidden";
                NotifyPropertyChanged("BackgroundPic");
                NotifyPropertyChanged("LightningVisibility");
                if(LightningVisibility == "Visible")
                {
                    _timerRun = true;
                    for (int i = 0; i < 100 && _timerRun; i++)
                        Thread.Sleep(10);
                }
                string[] pl = new string[2];
                for (int i = 0; i < pl.Length; i++)
                { //System.AppDomain.CurrentDomain.BaseDirectory,
                    pl[i] = string.Format(@"Resources\Audio\He\Judaism\{0}.wav",
                         _playCongratulationList[_indexPage, i]);
                }
                PlayList(pl);
                _timerRun = true;
                for (int i = 0; i < 100 && _timerRun; i++)
                    Thread.Sleep(20);
                LightningVisibility = "Hidden";
                NotifyPropertyChanged("LightningVisibility");
            })).Start();
        }
        void IPageVM.load()
        {
            _timerRun = false;
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\JudaismImage\Brahot\Vision\open.jpg";
            LightningVisibility = "Hidden";
            NotifyPropertyChanged("BackgroundPic");
            NotifyPropertyChanged("LightningVisibility");
        }
        void IPageVM.disload()
        {
            _timerRun = false;
        }
    }
}
