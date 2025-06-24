using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuInstructionsVM : BaseMenuVM, IPageVM
    {
        private bool _miceNotOpen = true;
        private string _codeTad = string.Empty;
        private const string CODE_TRUE = "1432";
        public ICommand Exhibition { get; set; }
        public ICommand TabCode { get; set; }
        public ICommand BootMice { get; set; }
        public override string Name
        {
            get
            {
                return "MenuInstructionsVM";
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        void IPageVM.disload()
        {
            if (!_miceNotOpen)
            {
                CL.BS.Common.MiceKiller.KillAllMices(false);
                keybd_event((byte)Keys.E, 0, 0, 0);
            }
            _miceNotOpen = true;
            _codeTad = string.Empty;
        }

        public MenuInstructionsVM()
        {
            BootMice = new RelayCommand(DoBootMice);
            TabCode = new RelayCommand(DoTabCode);
            Exhibition = new RelayCommand(DoExhibition);
           
        }

        private void DoExhibition(object obj)
        {
            if (_codeTad == CODE_TRUE)
                DoGoToPage("MenuPuzzlesVM");
        }

        private void DoTabCode(object obj)
        {
            _codeTad +=obj;
        }

        private void DoBootMice(object obj)
        {
            if (_miceNotOpen&& CODE_TRUE== _codeTad)
            {
                CL.BS.Common.MiceKiller.KillAllMices(true);
                var p = System.Diagnostics.Process.Start("Multiple Mice\\MultipleMice.exe"); 
                keybd_event((byte)Keys.E, 0, 0, 0);
                _miceNotOpen = false;
            }     
        }
    }
}
