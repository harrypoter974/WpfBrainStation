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

namespace CL.BS.ShapesVM.VM.Circles
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class CirclesOpenVM : BaseStepVM, IPageVM
    {
        ICirclesManager logic = (ICirclesManager)
          SupportHandlerManager.Base.GetManager("CirclesManager");
        public CirclesOpenVM()
        {
            PlayShape = new RelayCommand(DoPlayShape);
        }
        private void DoPlayShape(object obj)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Shapes\" + obj + ".wav";
        }
        public ICommand PlayShape { get; set; }
        public override string Name
        {
            get
            {
                return "CirclesOpenVM";
            }
        }
    }
}
