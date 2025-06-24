using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
  public  interface IEmotionsGameManager : IBingoManager
    {
        string PlayEmotions(string url,int language);
    }
}
