using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.JudaismVM.VM.Congratulations
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HolidaysVM : BaseMenuVM, IPageVM
    {
        private string[] _playHolidayList = new string[] {"Sabbath","Passover"
            ,"Lag B'Omer","Weeks","Tisha B'Av","New Year","Yom Kippur"
            ,"Sukot","Simchat Torah","Hanukkah","Tu Bishvat","Purim"  };

        public override string Name => "HolidaysVM";
        public string BackgroundPic { get; set; }
        private bool _timerRun = false;
        void IPageVM.load()
        {
            _timerRun = false;
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(string.Format(@"{0}Resources\Audio\He\Judaism\{1}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory, _playHolidayList[int.Parse( Common.StaticVar.TransferVar.ToString())]));
                _timerRun = true;
                for (int i = 0; i < 100 && _timerRun; i++)
                    Thread.Sleep(30);
                DoGoToPage("MenuHolidaysVM");
            })).Start();
            base.Settings();            
            BackgroundPic = String.Format(@"{0}Resources\JudaismImage\Holidays\h{1}.jpg",
                System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.TransferVar);
            NotifyPropertyChanged("BackgroundPic");
        }
        void IPageVM.disload()
        {
            _timerRun = false;
        }
    }
}
