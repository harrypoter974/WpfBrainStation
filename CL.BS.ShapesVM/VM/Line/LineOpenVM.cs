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

namespace CL.BS.ShapesVM.VM.Line
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LineOpenVM : BaseLernPage, IPageVM
    {

        public ICommand PlayShape { get; set; }
        private ILineManager _logic = (ILineManager)
SupportHandlerManager.Base.GetManager("LineManager");
        public override string Name
        {
            get
            {
                return "LineOpenVM";
            }
        }

        public LineOpenVM()
        {
            PlayShape = new RelayCommand(DoPlayShape);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
            messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Shapes\Line\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoPlayShape(object obj)
        {
            if (obj.ToString().Split(' ').Length == 1)
            {
                PlayList(new string[] { @"Resources\Audio\He\Shapes\line.wav",
                @"Resources\Audio\He\" + obj + ".wav" });
            }
            else
            {
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\" + obj + ".wav");
            }
        }
    }
}
