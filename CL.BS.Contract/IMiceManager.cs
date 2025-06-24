using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Contract
{
    public interface IMiceManager
    {
        void Close();
        void OnClosing();
        void NewMouseSplitter();
        void Run();
        void Dispose();
        bool IsMouseRotation(string Rotation="A");
        bool IswindowNull();
        bool IsMouse();
        string GetMouseRotation();
    }
}
