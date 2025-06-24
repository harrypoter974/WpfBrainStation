using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ColorsLearnGroupVM : BaseStepVM, IPageVM
    {

        public ColorsLearnGroupVM()
        {
           
            ShowColor = new RelayCommand(DoShowColor);
            SwitchPage = new RelayCommand(DoSwitchPage);
        }
        void IPageVM.load() {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\ColorsGroup0.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        private void DoShowColor(object colorIndex)
        {
            Url = logic.PlayColor(PageInxex, colorIndex);
        }
        private void DoSwitchPage(object obj)
        {
            PageInxex = PageInxex == 0 ? 1 : 0;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\ColorsGroup" + PageInxex+".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        private void DoGoToExercise(object gropeIndex)
        {
            logic.setGrope(gropeIndex);
            GoToPage("ExerciseColorsVM");
        }
        public ICommand ShowColor { get; set; }
        public ICommand SwitchPage { get; set; }
        public ICommand GoToExercise { get; set; }
        private int PageInxex =0;
      
        IColorsManager logic = (IColorsManager)
   SupportHandlerManager.Base.GetManager("ColorsManager");

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
                return "ColorsLearnGroupVM";
            }
        }
    }
}
