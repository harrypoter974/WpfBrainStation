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

namespace CL.BS.NotionsVM.VM.Animals
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AnimalsLernVM : BaseStepVM, IPageVM
    {
        IAnimalsManager logic = (IAnimalsManager)
          SupportHandlerManager.Base.GetManager("AnimalsManager");
        public AnimalsLernVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Notions\Animals\Animals"+ PicIndex+".jpg";
            NotifyPropertyChanged("BackgroundPic");
            ChangBackground = new RelayCommand(DoChangBackground);
            ShowAnimals = new RelayCommand(DoShowAnimals);
        }
        private void DoChangBackground(object odj)
        {
            PicIndex = PicIndex == 0 ? 1 : 0;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Notions\Animals\Animals" + PicIndex + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        private void DoShowAnimals(object animals)
        {
           Url= System.AppDomain.CurrentDomain.BaseDirectory +
   logic.PlayAnimals(PicIndex,animals) ;
        }
        public override string Name
        {
            get
            {
                return "AnimalsLernVM";
            }
        }
        private int PicIndex = 0;
        public string BackgroundPic { get; set; }
        public ICommand ChangBackground { get; set; }
        public ICommand ShowAnimals { get; set; }
    }
}
