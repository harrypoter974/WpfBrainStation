using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.JudaismVM.VM.Agenda
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AgendaVM : BaseMenuVM, IPageVM
    {        
        public override string Name => "AgendaVM";
        private string[] _playAgendaList = new string[]{ "I thank", "Washing hands", "צדקה", "morning", "",""};
        public string BackgroundPic { get; set; }
        public ICommand ChangeBrahot { get; set; }
        private bool _timerRun = false;

        public AgendaVM()
        {
            ChangeBrahot = new Common.RelayCommand(DoChangeBrahot);
        }

        private void DoChangeBrahot(object obj)
        {
            int i = int.Parse(Common.StaticVar.TransferVar.ToString());
            if(i ==3)
            {
                Common.StaticVar.TransferVar = 4;
                DoGoToPage("TwelveVersesVM");
                return;
            }
            Common.StaticVar.TransferVar = i == 5 ? 0 : (i + 1);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\JudaismImage\Agenda\a" + Common.StaticVar.TransferVar + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        void IPageVM.load()
        {
            _timerRun = false;
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(string.Format(@"{0}Resources\Audio\He\Judaism\{1}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory, _playAgendaList[int.Parse(Common.StaticVar.TransferVar.ToString())]));
                _timerRun = true;
                for (int i = 0; i < 100 && _timerRun; i++)
                    Thread.Sleep(150);
                DoGoToPage("MenuJudaismAgendaVM");
            })).Start();
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\JudaismImage\Agenda\a" + Common.StaticVar.TransferVar + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        void IPageVM.disload()
        {
            _timerRun = false;
        }
    }
}
