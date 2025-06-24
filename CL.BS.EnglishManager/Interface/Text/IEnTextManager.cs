using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Interface.Text
{
    public interface IEnTextManager
    {
        void SetFill(string textFile);
        void GetText(ref List<LetterObject>[] lineList, bool v);
    }
}
