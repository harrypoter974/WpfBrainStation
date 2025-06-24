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

namespace CL.BS.ShapesVM.VM.Angle
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AngleOpenVM : BaseStepVM, IPageVM
    {
        public AngleOpenVM()
        {
            PlayShape =new RelayCommand(DoPlayShape);
        }
        private void DoPlayShape(object obj)
        {
            PlayList(new string[] { @"Resources\Audio\He\Shapes\זווית.wav",
                @"Resources\Audio\He\Shapes\" + obj + ".wav" });
        }
        public ICommand PlayShape { get; set; }
        IAngleManager logic = (IAngleManager)
        SupportHandlerManager.Base.GetManager("AngleManager");
        public override string Name
        {
            get
            {
                return "AngleOpenVM";
            }
        }
    }
}
