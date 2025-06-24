using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Recognaz
{
    public abstract class OpenMathRecognaz : BaseLernPage
    {
        public string LevelBut1 { get; set; }
        public ICommand OpenPage { get; set; }

        public OpenMathRecognaz()
        {
            OpenPage = new RelayCommand(DoOpenPage);
            LevelBut1 = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Math\Num\Learn1.png";
            NotifyPropertyChanged("LevelBut1");
        }

        private void DoOpenPage(object obj)
        {
           // _isOpen = false;
        }
    }
}
