using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Game
{
    public interface ISudokuManager
    {
        void GenerateGame(bool is4x4);
        string[,] SetAnswerBord(bool is4x4);
        string[,] SetQuestionBord(bool is4x4,int level);
        bool CheckBoard(LetterObject[,] letterObject,int y,int x);
    }
}
