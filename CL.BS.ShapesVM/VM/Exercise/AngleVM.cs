using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AngleVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(AngleVM);
        private bool _indexPage = false;
        public string BackgroundPic { get; set; }
        public AngleVM()
        {         
            AnswerBut = new RelayCommand(DoSwich);
            DoSwich(0);
        }

        private void DoSwich(object obj)
        {
            _indexPage = !_indexPage;
            BackgroundPic = string.Format(@"{0}Resources\Shapes\Concepts\Angle{1}.jpg",
                System.AppDomain.CurrentDomain.BaseDirectory, _indexPage ? 0 : 1);
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
    }
}
