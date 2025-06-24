using CL.BS.Contract;
using CL.BS.VMCommon;
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
    public class HandEyeCoordinationGameVM2 : HandEyeCoordinationGameVM, IPageVM
    {
        public override string Name => nameof(HandEyeCoordinationGameVM2);
        public HandEyeCoordinationGameVM2()
        {
            LEVEL = 2;
           LevelBut0= LevelBut1 = string.Empty;
            LevelBut2 = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\Hard.png";
            NotifyPropertyChanged(nameof(LevelBut0));
            NotifyPropertyChanged(nameof(LevelBut1));
            NotifyPropertyChanged(nameof(LevelBut2));
        }
        protected override void Reset0()
        {//0.274 W 0.478 H  w  W0.14 H0.134
            Points[0].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.0661;// 0.196
            Points[0].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.0382;//
            NotifyPropertyChanged(nameof(Private0X));
            NotifyPropertyChanged(nameof(Private0Y));
        }
        protected override void Reset1()
        {//0.274 W 0.478 H
            Points[1].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.0184;//0.01
            Points[1].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.770;//0.239 - 15
            NotifyPropertyChanged(nameof(Private1X));
            NotifyPropertyChanged(nameof(Private1Y));
        }
        protected override void Reset2()
        {//0.274 W 0.478 H
            Points[2].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.481;// 0.265 - 15
            Points[2].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.1205;//0.239 - 15
            NotifyPropertyChanged(nameof(Private2X));
            NotifyPropertyChanged(nameof(Private2Y));
        }
        protected override void Reset3()
        {//0.274 W 0.478 H
            Points[3].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.4344;// 0.064
            Points[3].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.854;//  0.42
            NotifyPropertyChanged(nameof(Private3X));
            NotifyPropertyChanged(nameof(Private3Y));
        }
    }
}
