using CL.BS.Contract;
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
  public class EnFamilyVM : BaseStepVM, IPageVM
    {
        public EnFamilyVM()
        {
            ShowPerson = new RelayCommand(DoPlayPerson);
        }
        void IPageVM.load()
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Family\Family.wav";
        }
        public void DoPlayPerson(object obj)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Family\" + obj + ".wav";
        }
        private ICommand m_playPerson;

        public ICommand ShowPerson
        {
            get { return m_playPerson; }
            set { m_playPerson = value; }
        }
        public override string Name
        {
            get
            {
                return "EnFamilyVM";
            }
        }
    }
}
