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
    public class EnAnimalsVM : BaseStepVM, IPageVM
    {
       
        public EnAnimalsVM()
        {
           
            SwichPage = new RelayCommand(DoSwichPage);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Languages\English\Animals\Animals0.jpg";
            NotifyPropertyChanged("BackgroundPic");
            ShowAnimals = new RelayCommand(DoShowAnimals);
        }
        void IPageVM.load()
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Animals\Animals.wav";
        }

        public void DoShowAnimals(object obj)
        {
            string enimal = obj.ToString().Split(':')[index];
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Animals\" + enimal + ".wav";

        }
        private ICommand m_showAnimals;
        public ICommand ShowAnimals
        {
            get { return m_showAnimals; }
            set { m_showAnimals = value; }
        }
 private int index = 0;
        private void DoSwichPage(object index)
        {
            this.index = int.Parse(index.ToString());
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Languages\English\Animals\Animals" + index + ".jpg";
            NotifyPropertyChanged("BackgroundPic");

        }

        private ICommand m_swichPage;
        public ICommand SwichPage
        {
            get { return m_swichPage; }
            set { m_swichPage = value; }
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
                return "EnAnimalsVM";
            }
        }
    }
}

