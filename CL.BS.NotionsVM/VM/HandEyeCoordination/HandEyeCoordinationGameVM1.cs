using CL.BS.Common;
using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HandEyeCoordinationGameVM1 : HandEyeCoordinationGameVM, IPageVM
    {
        public override string Name => nameof(HandEyeCoordinationGameVM1);
        public HandEyeCoordinationGameVM1()
        {
            LEVEL = 1;
            LevelBut1 = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\Medium.png";
            LevelBut0 = LevelBut2 = string.Empty;
            NotifyPropertyChanged(nameof(LevelBut0));
            NotifyPropertyChanged(nameof(LevelBut1));
            NotifyPropertyChanged(nameof(LevelBut2));
        }
    }
}
