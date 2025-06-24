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
    public class ShadowGameManager : IShadowGameManager, IManager
    {
        string IManager.ManagerName => "ShadowGameManager";
        ShadowGameEngine _login = new ShadowGameEngine();
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

        void IShadowGameManager.Reset()
        {
            _login.Reset();
        }

        string IShadowGameManager.PlayShadow(string question)
        {
           return _login.PlayShadow(question);
        }

        void IShadowGameManager.SwitchLanguage(string v)
        {
            _login.SwitchLanguage(v);
        }
    }
}
