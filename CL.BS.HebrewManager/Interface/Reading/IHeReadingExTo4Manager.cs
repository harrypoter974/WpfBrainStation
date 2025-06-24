using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Reading
{
    public interface IHeReadingExTo4Manager
    {
        string[] GetQuestion(int index);
        string[] GetAnswer();
    }
}
