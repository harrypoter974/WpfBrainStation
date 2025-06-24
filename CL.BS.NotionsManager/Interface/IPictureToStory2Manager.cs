using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IPictureToStory2Manager
    {
        List<LetterObject>[] SetPicList(int v);
        void ClearBord();
    }
}
