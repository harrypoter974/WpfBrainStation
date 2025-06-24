using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Engen
{
    public class triviaQuestion
    {
        public string[] Answer;
        public string Adio,EndAdio, Pic, FullAnswer, Question;
        public int Level, Num;

        public triviaQuestion(string[] answer, string adio, string pic, string fullAnswer, string question, int level, int num, string endAdio)
        {
            Answer = answer;
            Adio = adio;
            Pic = pic;
            FullAnswer = fullAnswer;
            Question = question;
            Level = level;
            Num = num;
            EndAdio = endAdio;
        }
    }
}
