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
    public class AngleOpenVM : BaseLernPage, IPageVM
    {
        public ICommand PlayShape { get; set; }
        private IAngleManager _logic = (IAngleManager)
        SupportHandlerManager.Base.GetManager("AngleManager");
        public override string Name
        {
            get
            {
                return "AngleOpenVM";
            }
        }

        public AngleOpenVM()
        {
            PlayShape =new RelayCommand(DoPlayShape);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
            messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Shapes\Angle\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoPlayShape(object obj)
        {
            PlayList(new string[] { @"Resources\Audio\He\Shapes\angle.wav",
                @"Resources\Audio\He\Shapes\" + obj + ".wav" });
        }
    }
}
