using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Shape
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ShapeOpenVM : BaseLernPage, IPageVM
    {
        private IShapeManager _logic = (IShapeManager)
SupportHandlerManager.Base.GetManager("ShapeManager");
        public ICommand PlayShape { get; set; }
        public override string Name
        {
            get
            {
                return "ShapeOpenVM";
            }
        }

        public ShapeOpenVM()
        {
            PlayShape = new RelayCommand(DoPlayShape);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy) {
            messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Shape\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoPlayShape(object obj)
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + 
                @"Resources\Audio\He\Shapes\" + obj + ".wav"); 
        }
    }
}
