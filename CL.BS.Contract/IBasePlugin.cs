using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.Contract
{
    public interface IBasePlugin
    {
        IPageVM ViewModel { get; }
        ResourceDictionary View { get; }
    }
}
