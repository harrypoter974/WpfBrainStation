using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM
{
   public abstract  class BaseShapesVM : VMCommon.BaseLernPage
    {
        public ICommand ShowShapes { get; set; }
        public string BackgroundShapes { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }

        public BaseShapesVM()
        {
            ShowShapes = new RelayCommand(DoShowShapes);
        }

        private void DoShowShapes(object obj)
        {//BaseShapesVM
            BackgroundShapes = "White";
            NotifyPropertyChanged("BackgroundShapes");
        }
    }
}
