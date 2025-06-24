using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.VMCommon.Mice
{
  public  class TouchManager : IMiceManager
    {
        public TouchManager()
        {
        }

        void IMiceManager.Close()
        {
        }

        void IMiceManager.Dispose()
        {
        }

        string IMiceManager.GetMouseRotation()
        {
            return "A";
        }

        bool IMiceManager.IsMouse()
        {
           return false;
        }

        bool IMiceManager.IsMouseRotation(string Rotation)
        {
            return true;
        }

        bool IMiceManager.IswindowNull()
        {
           return true;
        }

        void IMiceManager.NewMouseSplitter()
        {
        }

        void IMiceManager.OnClosing()
        {
        }

        void IMiceManager.Run()
        {
        }
    }
}
