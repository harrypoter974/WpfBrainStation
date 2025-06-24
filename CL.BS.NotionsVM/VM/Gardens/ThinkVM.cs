using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ThinkVM : BaseLernPage, IPageVM
    {
        private string _indexPage = "2";
        public string BackgroundPic { get; set; }
        public ICommand SwitchPage { get; set; }
        public override string Name => nameof(ThinkVM);

        public ThinkVM()
        {
            SwitchPage = new RelayCommand(DoSwitchPage);
        }

        void IPageVM.load()
        {
            SetBackgroundPic();
        }

        private void DoSwitchPage(object obj)
        {
            _indexPage = obj.ToString();
            SetBackgroundPic();
        }

        private void SetBackgroundPic()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Think\" + Common.StaticVar.NotionsThinkGropeName + _indexPage + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
    }
}
