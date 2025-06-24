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
    public class HandEyeCoordinationGameVM0 : HandEyeCoordinationGameVM, IPageVM
    {
        public override string Name =>nameof(HandEyeCoordinationGameVM0) ;
        public HandEyeCoordinationGameVM0()
        {
            LEVEL = 0;
            LevelBut2 = LevelBut1 = string.Empty;
            LevelBut0 = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\Easy.png";
            NotifyPropertyChanged(nameof(LevelBut0));
            NotifyPropertyChanged(nameof(LevelBut1));
            NotifyPropertyChanged(nameof(LevelBut2));
        }
    }
}
