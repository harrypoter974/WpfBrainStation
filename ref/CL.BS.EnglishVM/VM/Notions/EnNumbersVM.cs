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
    public class EnNumbersVM : BaseStepVM, IPageVM
    {
        private bool SmallerThan11 = true;
        public EnNumbersVM()
        {
            ShowNum = new RelayCommand(DoShowNum);
            SwichGroup = new RelayCommand(DoSwichGroup);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Languages\English\Numbers\open1.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        void IPageVM.load()
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Numbers\Numbers.wav";
        }
        private void DoSwichGroup(object group)
        {
            SmallerThan11 = !SmallerThan11;
             BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Languages\English\Numbers\open"+(SmallerThan11?1:10)+".jpg";
            NotifyPropertyChanged("BackgroundPic");

        }

        public void DoShowNum(object index)
        {
            string[]Num = index.ToString().Split(',');
            string num = (SmallerThan11 ? Num[1] : Num[0]);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Languages\English\Numbers\"+num + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Numbers\" + num + ".wav";
        }
        private ICommand m_showNum;
        public ICommand ShowNum
        {
            get { return m_showNum; }
            set { m_showNum = value; }
        }
        private ICommand m_swichGroup;
        public ICommand SwichGroup
        {
            get { return m_swichGroup; }
            set { m_swichGroup = value; }
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
                return "EnNumbersVM";
            }
        }
    }
}
