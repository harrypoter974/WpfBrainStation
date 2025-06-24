using CL.BS.Contract;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EmotionsManager : IManager, IEmotionsManager
    {
        string IManager.ManagerName => "EmotionsManager";
        EmotionsEngine _logic = new EmotionsEngine();

        string IEmotionsManager.PlayEmotion(int emotion, int language)
        {
           return _logic.PlayEmotion(emotion, language);
        }
    }
}
