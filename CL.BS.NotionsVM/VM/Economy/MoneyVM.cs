using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Economy
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MoneyVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(MoneyVM);
        public string BackgroundPic { get; set; }
        public ICommand PlayMoney { get; set; }
        public MoneyVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                           + @"Resources\Notions\Economy\money0.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            AnswerBut = new RelayCommand(DoSwitchPage);
            PlayMoney = new RelayCommand(DoPlayMoney);
        }

        private void DoPlayMoney(object obj)
        {
            if (BackgroundPic.Contains("money0.jpg"))
            {
                string[] p = obj.ToString().Split(',');
                PlayList(new string[] {
string.Format(@"Resources\Audio\He\Economy\{0}.wav",(p[0]=="0"?"Currency of":"bill of")) ,
string.Format(@"Resources\Audio\He\Economy\{0}.wav",p[1]) });
            }
        }

        private void DoSwitchPage(object obj)
        {
            bool b = BackgroundPic.Contains("money0.jpg");
            BackgroundPic =String.Format(@"{0}Resources\Notions\Economy\money{1}.jpg",
                System.AppDomain.CurrentDomain.BaseDirectory,b?1:0 ) ;
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
    }
}
