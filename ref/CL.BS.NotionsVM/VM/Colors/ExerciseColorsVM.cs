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
    public class ExerciseColorsVM : BaseStepVM, IPageVM
    {
        public ExerciseColorsVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\Pic\Home.jpg";
            NotifyPropertyChanged("BackgroundPic");
            SwitchPic = new RelayCommand(DoSwitchPic);
            ShowPic = new RelayCommand(DoShowPic);
        }
        private void DoSwitchPic(object pic)
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\Pic\"+pic+".jpg";
            NotifyPropertyChanged("BackgroundPic");
            PicBord = string.Empty;
            NotifyPropertyChanged("PicBord");
        }
        private void DoShowPic(object obj)
        {
            PicBord = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\Pic\Board.jpg";
            NotifyPropertyChanged("PicBord");
        }

        public ICommand  SwitchPic{ get; set; }
        public ICommand ShowPic {get;set; }
        public string PicBord { get; set; }
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
                return "ExerciseColorsVM";
            }
        }
    }
}
