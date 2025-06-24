using CL.BS.Common;
using CL.BS.Database;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BS.BingoBoard.VM
{
    public class BingoVocabularyBoardVM : BaseBingoBoardVM
    {
        public override string Name => "";
        public string TBText0 { get { return LettersList[0].Uid; } set { LettersList[0].Uid = value; } }
        public string TBText1 { get { return LettersList[1].Uid; } set { LettersList[1].Uid = value; } }
        public string TBText2 { get { return LettersList[2].Uid; } set { LettersList[2].Uid = value; } }
        public string TBText3 { get { return LettersList[3].Uid; } set { LettersList[3].Uid = value; } }
        public string TBText4 { get { return LettersList[4].Uid; } set { LettersList[4].Uid = value; } }
        public string TBText5 { get { return LettersList[5].Uid; } set { LettersList[5].Uid = value; } }
        public string TBText6 { get { return LettersList[6].Uid; } set { LettersList[6].Uid = value; } }
        public string TBText7 { get { return LettersList[7].Uid; } set { LettersList[7].Uid = value; } }
        public string TBText8 { get { return LettersList[8].Uid; } set { LettersList[8].Uid = value; } }
        public int AnsFontSize { get; set; }
        public int QuestionFontSize { get; set; }
        public string AnswerPic { get; set; }
        private string Answer;
        public BingoVocabularyBoardVM()
        {
            AnsFontSize = 52;
            QuestionFontSize = 32;
            NotifyPropertyChanged(nameof(AnsFontSize) );
            NotifyPropertyChanged(nameof(QuestionFontSize));
        }

        public override void SetNumLetterLimit(int v)
        {//מאתכל את הרמת המשחק
          //  IsEasy = v == 0;
        }

        public override bool GetIsFirst()
        { return IndexAnswer!=-1; }

        public override bool CheckAnswer(string answer)
        {
            if (LettersList[IndexAnswer].Question == null)
                return true;
            return GeneralFunctions.GetLastWord(LettersList[IndexAnswer].Question)==GeneralFunctions.GetLastWord(answer);
        }
        public override bool CheckBoard(string answer)
        {
            AnswerPic = this.Answer;
            int success=4;
            NotifyPropertyChanged("AnswerPic");
            answer = GeneralFunctions.GetLastWord(answer);
            bool haveWin = false;
            for (int j = 0; j < LettersList.Length; j++)
            {
                if (IndexAnswer != -1)
                {
                    if (GeneralFunctions.GetLastWord(LettersList[IndexAnswer].Question) == answer &&
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
                        success = 1;
                    }
                    for (int i = 0; i < LettersList.Length; i++)
                    {//LettersList[i].Question.Contains(  answer) 
                        if (GeneralFunctions.GetLastWord(LettersList[i].Question) == answer && LettersList[i].Answer != "Green")
                        {
                            LettersList[i].Answer = "Red";
                            NotifyPropertyChanged("TBAnswer" + i);
                            success =3;
                        }
                    }
                }
            }
            int winSum = IsBingo();
           if (winSum > 0)
            {
                for (int j = 0; j < winSum; j++)
                    SetSoldierPosition(true);
                haveWin = true;
                success = 2;
            }  
            DatabaseManager.Inline.SaveActivity(GetUesrNum(), 
                _startpAnswerTime, DateTime.Now, GameName, "GBIN",
                answer.Split('.')[0],Language, success);
            return haveWin;
        }

        public override void Clear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
               LettersList[i].Uid =  LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                NotifyPropertyChanged("TBText" + i);
            }
            AnswerPic = string.Empty;
            NotifyPropertyChanged("AnswerPic");
        }

        public override void ClearQuestion()
        {
            AnswerPic = string.Empty;
            NotifyPropertyChanged("AnswerPic");
        }

        public override void SetAnswer(string answer)
        {
            base.ClearAnswer();            
        }

        public override void SetBoard(List<GameObject> list)
        {
            AccruedPoints = 0;
            IndexAnswer = -1;
            Clear();
            for (int i = 0; i < LettersList.Length; i++)
            {
                if (i < list.Count<GameObject>())
                {
                    LettersList[i].Question = list[i].Question;
                }
                else
                {
                    LettersList[i].Question = string.Empty;
                }
                NotifyPropertyChanged("TB" + i);


            }
            AnswerPic = string.Empty;
            NotifyPropertyChanged("AnswerPic");
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

        public override void RestartClear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void SetQuestion(string q)
        {
            GlobalVar.IAnsweredFirst = true;
            AnswerPic = q;
            NotifyPropertyChanged(nameof(AnswerPic));
            //if (bool.Parse(q))
            //{
            //    AnsFontSize = 52;
            //    QuestionFontSize = 32;
            //}
            //else
            //{

            //    AnsFontSize = 32;
            //    QuestionFontSize = 52;
            //}
            //NotifyPropertyChanged("AnsFontSize");
            //NotifyPropertyChanged("QuestionFontSize");
            _startpAnswerTime = DateTime.Now;
        }

        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
    }
}
