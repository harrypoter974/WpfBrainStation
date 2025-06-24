using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class KnowLetterVM : BaseStepVM, IPageVM
    {
        public KnowLetterVM()
        {
            SwichPage = new RelayCommand(DoSwichPage);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Languages\Hebrew\Letters\lernא.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        private string m_BackgroundPic;
        public string BackgroundPic
        {
            get { return m_BackgroundPic; }
            set { m_BackgroundPic = value; }
        }
        private void DoSwichPage(object index)
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Languages\Hebrew\Letters\lern" + index + ".jpg";
            NotifyPropertyChanged("BackgroundPic");

        }
        private ICommand m_swichPage;
        public ICommand SwichPage
        {
            get { return m_swichPage; }
            set { m_swichPage = value; }
        }

        public override string Name
        {
            get
            {
                return "KnowLetterVM";
            }
        }
    }
}
