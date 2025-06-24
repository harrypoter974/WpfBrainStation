using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Reading
{
    public interface IHeReading3Manager
    {
        string getWord( object indexWord, bool IsLearn);
        void ClireVar();
        void SetIndex(object index);
        int GetIndex();
        string GetSyllable(object syllable);
        int GetPageIndex();
    }
}
