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

namespace CL.BS.ShapesVM.VM.Tringel
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TringelOpenVM : BaseLernPage, IPageVM
    {
        private ITringelManager _logic = (ITringelManager)
SupportHandlerManager.Base.GetManager("TringelManager");
        public ICommand PlayShape { get; set; }
        public override string Name
        {
            get
            {
                return "TringelOpenVM";
            }
        }

                public TringelOpenVM()
        {
            PlayShape = new RelayCommand(DoPlayShape);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\Shapes\Tringel\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoPlayShape(object obj)
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory 
                + @"Resources\Audio\He\Sentences\" + obj + ".wav");
        }
    }
}

