using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Game
{
   public class ShapeGameBoardVM : BaseBingoBoardVM
    {
        public string TBShape { get; set; }
        public string ImageShape { get; set; }
        public override string Name => "";


        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Uid == answer;
        }
    
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override bool CheckBoard(string answer)
        {
            bool haveWin = false;
            if (IndexAnswer != -1)
            {
                if (LettersList[IndexAnswer].Uid == answer &&
                LettersList[IndexAnswer].Answer != "Red")
                {
                    LettersList[IndexAnswer].Answer = "Green";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                    if (GlobalVar.IAnsweredFirst)
                    {
                        GlobalVar.IAnsweredFirst = false;
                        AccruedPoints++;
                    }
                    AccruedPoints++;
                }
                else if (LettersList[IndexAnswer].Answer != "Green")
                {
                    LettersList[IndexAnswer].Answer = "Red";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                }
            }
            //IndexAnswer = -1;
            int winSum = IsBingo();
            if (winSum > 0)
            {
                for (int j = 0; j < winSum; j++)
                    SetSoldierPosition(true);
                haveWin = true;
            }
            return haveWin;
        }

        public override void Clear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Answer = LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                
                NotifyPropertyChanged("TBAnswer" + i);
            }
            ClearQuestion();
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            base.PlayWin();
        }

        public override void ClearQuestion()
        {
            TBShape =  ImageShape = string.Empty;
            NotifyPropertyChanged("ImageShape");
            NotifyPropertyChanged("TBShape");
            IndexAnswer = -1;
        }

        public override void SetAnswer(string shap)
        {
            TBShape = shap;
            NotifyPropertyChanged("TBShape");
        }

        public override void SetQuestion(string question)
        {
            GlobalVar.IAnsweredFirst = true;
            ImageShape = question;
            NotifyPropertyChanged("ImageShape");
        }

        public override void RestartClear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].Answer =string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void SetBoard(List<GameObject> list)
        {
            IndexAnswer = -1;
            AccruedPoints = 0;
            Clear();
            for (int i = 0; i < LettersList.Length; i++)
            {
                if (i < list.Count<GameObject>())
                {
                    LettersList[i].Uid  = list[i].Uid ;
                    LettersList[i].Question = list[i].Question;
                }
                else
                    LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
            ClearQuestion();
        }

        public override void SetNumLetterLimit(int v)
        {
            throw new NotImplementedException();
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }
    }
}
