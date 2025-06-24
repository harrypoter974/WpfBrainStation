using CL.BS.Contract;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.VMCommon.Mice
{
  public  class MiceManager: IMiceManager
    {
        public MiceManager()
        {
        }

        void IMiceManager.NewMouseSplitter()
        {
            _window = new MouseSplitter(); 
        }

       internal MouseSplitter GetWindow()
        {
            return _window;
        }

        bool IMiceManager.IsMouseRotation(string Rotation)
        {
            if (_window != null)
                if (_window.currentMouse != null)
                    if (_window.currentMouse.Rotation.ToString() == Rotation)
                        return true;
            return false;
        }

        void IMiceManager.Run()
        {
            _logicMice.Run();
        }

        void IMiceManager.Dispose()
        {
            _logicMice.Dispose();
        }

        void IMiceManager.Close()
        {
            _window.Close();
        }

        void IMiceManager.OnClosing()
        {
            _window.OnClosing();
        }

        bool IMiceManager.IswindowNull()
        {
            return _window==null;
        }

        bool IMiceManager.IsMouse()
        {
            return true;
        }

        string IMiceManager.GetMouseRotation()
        {
           return _window.currentMouse.Rotation.ToString();
        }

        private static LowLevelHook _logicMice = new LowLevelHook();
        private MouseSplitter _window;
    }
}
