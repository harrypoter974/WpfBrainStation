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
    public class LineOpenVM : BaseStepVM, IPageVM
    {
        ILineManager logic = (ILineManager)
SupportHandlerManager.Base.GetManager("LineManager");
        public LineOpenVM()
        {
            PlayShape = new RelayCommand(DoPlayShape);
        }
        private void DoPlayShape(object obj)
        {
            if (obj.ToString().Split(' ').Length == 1)
            {
                PlayList(new string[] { @"Resources\Audio\He\Shapes\קו.wav",
                @"Resources\Audio\He\" + obj + ".wav" });
            }
            else
            {
                Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\" + obj + ".wav";
            }
        }

        public ICommand PlayShape { get; set; }
        public override string Name
        {
            get
            {
                return "LineOpenVM";
            }
        }
    }
}
