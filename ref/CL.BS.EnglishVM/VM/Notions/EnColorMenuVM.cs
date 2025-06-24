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
    public class EnColorMenuVM : BaseStepVM, IPageVM
    {
        IEnColorManager logic = (IEnColorManager)
SupportHandlerManager.Base.GetManager("EnColorManager");

        public EnColorMenuVM()
        {
            ShowGrope = new RelayCommand(DoShowGrope);
        }
        void IPageVM.load()
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Colors\Colors.wav";
        }
        public void DoShowGrope(object index)
        {
            logic.SetColorIndex(index);
            base.GoToPage("EnColorVM");
        }
        private ICommand m_showGrope;
        public ICommand ShowGrope
        {
            get { return m_showGrope; }
            set { m_showGrope = value; }
        }
        public override string Name
        {
            get
            {
                return "EnColorMenuVM";
            }
        }
    }
}
