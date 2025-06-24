using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
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
    public class AnimalsManager : IManager, IAnimalsManager
    {
        private AnimalsEngine _logic = new AnimalsEngine();
        string IManager.ManagerName => "AnimalsManager";


        void IBingoManager.DoChangeMode(bool b)
        {
            _logic.DoChangeMode(b);
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        bool Contract.IMemoryManager.EndGame(bool ToFill)
        {
            return _logic.EndMemoryGame();            
        }

        bool IAnimalsManager.EndMemoryGame()
        {
            return _logic.EndMemoryGame();
        }

        string IAnimalsManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        List<GameObject>[] Contract.IMemoryManager.GetNewGame(int v)
        {
            return _logic.GetNewGameMemory(v);
        }

        string Contract.IMemoryManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        string IAnimalsManager.GetQuestionMemory()
        {
            return _logic.GetQuestionMemory();
        }


        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.GetNewGameBingo();
        }

        string IAnimalsManager.PlayAnimals(int language, int picIndex, int animals)
        {
            return _logic.PlayAnimals( language, picIndex, animals);
        }

        string IAnimalsManager.PlayItem()
        {
             return _logic.GetQuestionPlay();
        }

        void IAnimalsManager.ResetMemoryList()
        {
            _logic.ResetMemoryList();
        }

        void IAnimalsManager.SwitchLanguage(object lan)
        {
            _logic.SwitchLanguage(lan);
        }
    }
}
