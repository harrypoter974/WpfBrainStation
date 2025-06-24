using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Game;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathMemoryNumManager : IManager, IMathMemoryNumManager
    {
        string IManager.ManagerName => "MathMemoryNumManager";
        private MathMemoryNumEngine _logic = new MathMemoryNumEngine();

        bool IMemoryManager.EndGame(bool T)
        {
            return _logic.EndGame();
        }

        List<GameObject>[] IMemoryManager.GetNewGame(int v)
        {
            return _logic.NewGame(v);
        }

        string IMemoryManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        string[] IMathMemoryNumManager.Get_Question()
        {
            return _logic.Get_Question();
        }

        void IMathMemoryNumManager.SetLimit(int limit)
        {
            _logic.SetLimit(limit);
        }

        void IMathMemoryNumManager.SwitchLanguage(string language)
        {
            BingoNumEngine._language=language;
        }
    }
}
