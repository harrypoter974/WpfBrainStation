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
    public class EnPrepositionsExerciseVM : BaseStepVM, IPageVM
    {
        public EnPrepositionsExerciseVM()
        {
            ShowAnimals = new RelayCommand(DoShowAnimals);
            SwichPage = new RelayCommand(DoSwichPage);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Languages\English\Prepositions\x1.jpg";

            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            base.SwitchAnswerButton();
        }
        private int index = 0;
        private void DoSwichPage(object index)
        {
            this.index = int.Parse(index.ToString());
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Languages\English\Prepositions\x" + index + ".jpg";
            NotifyPropertyChanged("BackgroundPic");

        }

        public void DoShowAnimals(object obj)
        {

        }
        private ICommand m_showAnimals;
        public ICommand ShowAnimals
        {
            get { return m_showAnimals; }
            set { m_showAnimals = value; }
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
                return "EnPrepositionsExerciseVM";
            }
        }
    }
}
