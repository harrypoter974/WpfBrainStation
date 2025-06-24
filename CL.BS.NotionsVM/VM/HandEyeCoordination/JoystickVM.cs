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
    public class JoystickVM :  BasePageVM
    {
        public override string Name =>nameof(JoystickVM);
        public ICommand MouseMove { get; set; }
        public int Column;
        public int Row;
        private const int YCenter = 4, XCenter = 4; 
        public JoystickVM()
        {
            MouseMove = new RelayCommand(DoMouseMove);
            RestartJoystick();
        }
        public void RestartJoystick()
        {
            DoMouseMove("0_0");
        }
        private void DoMouseMove(object obj)
        {
            string[]n=obj.ToString().Split('_');
            Row = YCenter+int.Parse(n[0]);
            Column = XCenter + int.Parse(n[1]);
        }
        internal int[] GetPosition()
        {
            return new int[] {Column-XCenter,Row-YCenter};
        }
    }
}
