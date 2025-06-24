using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Game;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.Model;
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
    public class SudokuManager : IManager,ISudokuManager
    {
        string IManager.ManagerName => "SudokuManager";
        private SudokuEngine _logic = new SudokuEngine();

        void ISudokuManager.GenerateGame(bool is4x4)
        {
            _logic.GenerateGame( is4x4);
        }

        string[,] ISudokuManager.SetAnswerBord(bool is4x4)
        {
         return _logic.SetAnswerBord( is4x4);
        }

        string[,] ISudokuManager.SetQuestionBord(bool is4x4, int level)
        {
           return _logic.SetQuestionBord(is4x4,  level);
        }

        bool ISudokuManager.CheckBoard(LetterObject[,] letterObject,int y,int x)
        {
          return _logic.CheckBoard(letterObject,y,x);
        }
    }
}
