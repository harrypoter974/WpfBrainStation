using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM
{
    public class BaseBoardShape : BaseLernPage
    {
        public override string Name =>"";
        public string BackgroundPic { get; set; }
        public ICommand ShowShapes { get; set; }
        public ICommand TypeNum { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string HappySmily { get; set; }
        public BaseBoardShape()
        {

        }
    }
}
