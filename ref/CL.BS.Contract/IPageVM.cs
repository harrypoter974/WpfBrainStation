using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Contract
{
    public interface IPageVM
    {
        string Name { get; }
        Action<IPageVM, string> GoToAction {set; }
        void load();
        void disload();
    }
}