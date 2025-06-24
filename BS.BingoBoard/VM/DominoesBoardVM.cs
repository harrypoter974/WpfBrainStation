using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BingoBoard.VM
{
    public class DominoesBoardVM : BaseBingoBoardVM
    {
        public override string Name => "DominoesBoardVM";

        public override bool CheckAnswer(string answer)
        {
            return false;
        }

        public override bool CheckBoard(string answer)
        {
            return false;
        }

        public override void Clear()
        {
        }

        public override void ClearQuestion()
        {
        }

        public override void GameWin()
        {
        }

        public override bool GetIsFirst()
        {
            return false;
        }

        public override bool QuestionIsAnswer()
        {
            return false;
        }

        public override void RestartClear()
        {
        }

        public override void SetAnswer(string question)
        {
        }

        public override void SetBoard(List<GameObject> list)
        {
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetQuestion(string q)
        {
        }
    }
}
