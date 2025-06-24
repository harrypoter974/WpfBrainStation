using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Interface.Text
{
    public interface IEnTextOppositesManager
    {
        void SetIndex(object obj);
        string GetText(ref List<LetterObject>[] lineList, bool v);
        void SetLevel(object level);
    }
}
