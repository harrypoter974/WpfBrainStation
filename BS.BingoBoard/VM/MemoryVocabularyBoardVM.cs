using CL.BS.Common;
using CL.BS.Database;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BingoBoard.VM
{
   public class MemoryVocabularyBoardVM: MemoryLetterBoard7VM
    {
        private string _question;
        public MemoryVocabularyBoardVM() : base()
        {
            TapAnswer = new CL.BS.VMCommon.RelayCommand(DoTapAnswer);
        }
        public override void SetQuestion(string question)
        {
            base.ClearAnswer();
            _question = question;
        }

        public override void SetAnswer(string question)
        {
          _question=  TBQuestion = string.Empty;
            NotifyPropertyChanged(nameof(TBQuestion) );
            _startpAnswerTime = DateTime.Now;
        }

        public override bool CheckBoard(string answer)
        {
            TBQuestion = _question;
            NotifyPropertyChanged(nameof(TBQuestion));
            string a = GeneralFunctions.GetLastWord(answer);
            bool NotAppeared = true;
            bool haveWin = false;
            int success = 4;
            for (int i = 0; i < _numLength; i++)
            {
                if (LettersList[i].Uid != null)
                {
                    if (GeneralFunctions.GetLastWord(LettersList[i].Uid)==a&& NotAppeared)
                    {
                        NotAppeared = false;
                        object num = i;
                        LettersList[i].Question = answer;
                        NotifyPropertyChanged("TB" + num);
                        if (IndexAnswer != -1)
                        {
                            if (GeneralFunctions.GetLastWord(LettersList[IndexAnswer].Uid)==a &&
                            LettersList[IndexAnswer].Answer != "Red")
                            {
                                LettersList[i].Answer = "Green";
                                NotifyPropertyChanged("TBAnswer" + i);
                                AccruedPoints++;
                                success = 1;
                            }
                            else if (LettersList[IndexAnswer].Answer != "Green")
                            {
                                LettersList[i].Answer = "Red";
                                NotifyPropertyChanged("TBAnswer" + i);
                                success = 3;
                            }
                        }
                        if (IsMemoryBingo(_numLetterLimit))
                        {
                            haveWin = true;
                            success =2;
                        }
                    }
                }
            }
            DatabaseManager.Inline.SaveActivity(GetUesrNum(), _startpAnswerTime, 
                DateTime.Now, GameName, "Memory", answer.Split('.')[0], Language, success);
            return haveWin;
        }
        private void DoTapAnswer(object obj)
        {//Get the child's answer and check if the square's empty.
            lock (this)
            {
                int ia = int.Parse(obj.ToString());
                if (StaticVar.isTimerRedRun && LettersList[ia].Answer == string.Empty &&
                    BackgroundList[ia].Background != "#FF41AD48" && Window.IsMouseRotation(Rotation))
                {
                    if (IndexAnswer != -1)
                    {
                        LettersList[IndexAnswer].Answer = string.Empty;
                        NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                    }
                    IndexAnswer = ia;
                    LettersList[IndexAnswer].Answer = "Purple";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                }
            }
        }
    }
}
