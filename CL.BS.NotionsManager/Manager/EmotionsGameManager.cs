using CL.BS.Contract;
using CL.BS.Model;
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
    public class EmotionsGameManager : IEmotionsGameManager, IManager
    {
        string IManager.ManagerName => "EmotionsGameManager";
        EmotionsEngine _login = new EmotionsEngine();
        void IBingoManager.DoChangeMode(bool b)
        {
            _login.DoChangeMode(b);
        }

        bool IBingoManager.EndGame()
        {
            return _login.EndGame();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _login.GetNewGame();
        }

        string IEmotionsGameManager.PlayEmotions(string url, int language)
        {
            return _login.PlayEmotions(url,language);
        }
    }
}
