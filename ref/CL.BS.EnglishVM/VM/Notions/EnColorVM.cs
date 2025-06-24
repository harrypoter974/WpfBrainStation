using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Notions;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnColorVM : BaseStepVM, IPageVM
    {
        IEnColorManager logic = (IEnColorManager)
SupportHandlerManager.Base.GetManager("EnColorManager");
        public EnColorVM()
        {
            ShowColor = new RelayCommand(DoShowColor);
            SwitchColor = new RelayCommand(DoSwitchColor);
        }

        void IPageVM.load() {
            BackgroundPic= System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Languages\English\Color\Color" + logic.GetColorIndex() + ".jpg";
        }

        public void DoShowColor(object obj)
        {            
            Url = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Audio\En\Colors\" + logic.GetColorWord( obj) + ".wav";
        }
        public void DoSwitchColor(object obj)
        {           
            logic.SetColorIndex(obj);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Languages\English\Color\Color" + obj + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        //private ICommand m_switchColor;
        //public ICommand SwitchColor
        //{
        //    get { return m_}
        //}
        public ICommand SwitchColor { get; set; }
        private ICommand m_showColor;
        public ICommand ShowColor
        {
            get { return m_showColor; }
            set { m_showColor = value; }
        }

        private string m_BackgroundPic;
        public string BackgroundPic
        {
            get { return m_BackgroundPic; }
            set { m_BackgroundPic = value; }
        }

        public override string Name
        {
            get
            {
                return "EnColorVM";
            }
        }
    }
}
