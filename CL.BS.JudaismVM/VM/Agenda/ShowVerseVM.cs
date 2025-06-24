using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.JudaismVM.VM.Agenda
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ShowVerseVM : BaseMenuVM, IPageVM
    {//        
        public override string Name => "ShowVerseVM";
        private string[] _playVerseList = new string[] { "","","","","",""
            ,"","Torah commanded us Moses","","","",""};
        public string BackgroundPic { get; set; }
        private bool _timerRun = false;
        void IPageVM.load()
        {
            _timerRun = false;
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\JudaismImage\Verse\v" + Common.StaticVar.TransferVar + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(string.Format(@"{0}Resources\Audio\He\Judaism\{1}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory, _playVerseList[int.Parse(Common.StaticVar.TransferVar.ToString())]));
                _timerRun = true;
                for (int i = 0; i < 100 && _timerRun; i++)
                    Thread.Sleep(30);
                DoGoToPage("TwelveVersesVM");
            })).Start();
        }
        void IPageVM.disload()
        {
            _timerRun = false;
        }
    }
}
