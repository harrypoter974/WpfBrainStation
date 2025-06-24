using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Common;
using CL.BS.GameManager.Engen;

namespace CL.BS.NotionsManager.Engine
{
    class GardenTriviaEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private List<triviaQuestion> _questionList;

        internal triviaQuestion GetTriviaQuestion()
        {
            triviaQuestion tq = null;
            if (_questionList.Count() == 0)
                NewGame();
            int i = _ran.Next(_questionList.Count());
            tq = _questionList[i];
            _questionList.RemoveAt(i);


            return tq;
        }

        internal void NewGame()
        {
            _questionList = new List<triviaQuestion>();
            if (StaticVar.GardenTriviaTopic.Count() == 0)
                StaticVar.GardenTriviaTopic = new List<int>(new int[] { 1, 2, 3, 4 });
            if (StaticVar.GardenTriviaTopic.Contains(1))
            {
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-0.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-1.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-2.png,0"
         }, "", @"Resources\Notions\Trivia\boll0.png", "אפס", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-0.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-2.png,0"
                 }, "", @"Resources\Notions\Trivia\boll1.png", "אחד", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\2-2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-0.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-1.png,180"
    }, "", @"Resources\Notions\Trivia\boll2.png", "שניים", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-2.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-4.png,180"
    }, "", @"Resources\Notions\Trivia\boll3.png", "שלוש", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-4.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\4-4.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-2.png,180"
    }, "", @"Resources\Notions\Trivia\boll4.png", "ארבע", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\2-3.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-4.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\2-2.png,0"
    }, "", @"Resources\Notions\Trivia\boll5.png", "חמש", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\2-3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-4.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-2.png,180"
    }, "", @"Resources\Notions\Trivia\boll6.png", "שש", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\2-5.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\2-3.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\4-4.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\0-6.png,0"
    }, "", @"Resources\Notions\Trivia\boll7.png", "שבע", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\4-4.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\5-5.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\1-6.png,180"
    }, "", @"Resources\Notions\Trivia\boll8.png", "שמונה", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-6.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-5.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\4-6.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\5-6.png,0"
    }, "", @"Resources\Notions\Trivia\boll9.png", "תשע", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\5-5.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\5-6.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\6-6.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\4-5.png,180"
    }, "", @"Resources\Notions\Trivia\boll10.png", "עשר", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\5-6.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\6-6.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\4-6.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\4-5.png,0"
    }, "", @"Resources\Notions\Trivia\boll11.png", "אחד עשרה", "?כמה כדורים יש במסגרת", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\6-6.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\5-6.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\5-5.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\3-6.png,180"
    }, "", @"Resources\Notions\Trivia\boll12.png", "שתיים עשרה", "?כמה כדורים יש במסגרת", 0, 1, ""));
            }
            if (StaticVar.GardenTriviaTopic.Contains(2))
            {
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\4\0.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\4\0.png,90",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\4\0.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\4\0.png,270"
    }, "", @"Resources\Notions\Trivia\Series\4\Q.png", "", "?מה התמונה הבאה", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\1\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\1\4.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\1\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\1\3.png,0"
    }, "", @"Resources\Notions\Trivia\Series\1\Q.png", "", "?מה התמונה הבאה", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\2\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\2\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\2\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\2\4.png,0"
    }, "", @"Resources\Notions\Trivia\Series\2\Q.png", "", "?מה התמונה הבאה", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\3\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\3\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\3\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\Series\3\4.png,0"
    }, "", @"Resources\Notions\Trivia\Series\3\Q.png", "", "?מה התמונה הבאה", 0, 1, ""));

                _questionList.Add(new triviaQuestion(new string[]  { "5,,0", "6,,0","4,,0", "7,,0"
    }, "", "", "5", "?מה המספר הבא", 0, 1, "2,3,4"));
                _questionList.Add(new triviaQuestion(new string[]  { "4,,0", "5,,0","6,,0", "3,,0"
    }, "", "", "4", "?מה המספר הבא", 0, 1, "7,6,5"));
                _questionList.Add(new triviaQuestion(new string[]  { "9,,0", "8,,0","10,,0", "2,,0"
    }, "", "", "9", "?מה המספר הבא", 0, 1, "3,5,7"));
                _questionList.Add(new triviaQuestion(new string[]  { "8,,0", "5,,0","7,,0", "9,,0"
    }, "", "", "8", "?מה המספר הבא", 0, 1, "2,4,6"));
                _questionList.Add(new triviaQuestion(new string[]  { "7,,0", "6,,0","4,,0", "8,,0"
    }, "", "", "7", "?מה המספר הבא", 0, 1, "1,3,5"));
                _questionList.Add(new triviaQuestion(new string[]  { "3,,0", "4,,0","6,,0", "8,,0"
    }, "", "", "3", "?מה המספר הבא", 0, 1, "9,7,5"));
                _questionList.Add(new triviaQuestion(new string[]  { "3,,0", "4,,0","6,,0", "7,,0"
    }, "", "", "3", "?מה המספר הבא", 0, 1, "5,3,5"));
                _questionList.Add(new triviaQuestion(new string[]  { "4,,0", "9,,0","5,,0", "7,,0"
    }, "", "", "4", "?מה המספר הבא", 0, 1, "8,4,8"));
                _questionList.Add(new triviaQuestion(new string[]  { "7,,0", "8,,0","3,,0", "9,,0"
    }, "", "", "7", "?מה המספר הבא", 0, 1, "4,5,6"));
                _questionList.Add(new triviaQuestion(new string[]  { "3,,0", "7,,0","8,,0", "5,,0"
    }, "", "", "3", "?מה המספר הבא", 0, 1, "6,5,4"));
                _questionList.Add(new triviaQuestion(new string[]  { "6,,0", "5,,0","8,,0", "4,,0"
    }, "", "", "6", "?מה המספר הבא", 0, 1, "9,8,7"));
                _questionList.Add(new triviaQuestion(new string[]  { "2,,0", "7,,0","3,,0", "5,,0"
    }, "", "", "2", "?מה המספר הבא", 0, 1, "8,6,4"));
                _questionList.Add(new triviaQuestion(new string[]  { "6,,0", "3,,0","7,,0", "8,,0"
    }, "", "", "6", "?מה המספר הבא", 0, 1, "1,5,2"));
                _questionList.Add(new triviaQuestion(new string[]  { "7,,0", "4,,0","5,,0", "8,,0"
    }, "", "", "7", "?מה המספר הבא", 0, 1, "2,6,3"));
            }
            if (StaticVar.GardenTriviaTopic.Contains(3))
            {
                #region Music
                _questionList.Add(new triviaQuestion(new string[]
                    {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\accordion.png,0",
                 ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\cello.png,0",
                  ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\drum.png,0",
                   ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
                    }, "Music\\accordion.wav", @"Resources\BS.Items\speaker.jpg", "אקורדיון", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]
              {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\guitar.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\harmonica.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\drum.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0"
              }, "Music\\guitar.wav", @"Resources\BS.Items\speaker.jpg", "גיטרה", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]
    {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\Flute.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\Violin.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\piano.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0"
    }, "Music\\Flute.wav", @"Resources\BS.Items\speaker.jpg", "חליל", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\Violin.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\piano.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
}, "Music\\trumpet.wav", @"Resources\BS.Items\speaker.jpg", "חצוצרה", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\Violin.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\harmonica.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\piano.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
}, "Music\\Violin.wav", @"Resources\BS.Items\speaker.jpg", "כנור", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\mandoline.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\harmonica.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\drum.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
}, "Music\\mandoline.wav", @"Resources\BS.Items\speaker.jpg", "מנדולינה", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\harmonica.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\drum.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\piano.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
}, "Music\\harmonica.wav", @"Resources\BS.Items\speaker.jpg", "מפוחית", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\harp.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\mandoline.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
}, "Music\\harp.wav", @"Resources\BS.Items\speaker.jpg", "נבל", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\piano.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\mandoline.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
}, "Music\\piano.wav", @"Resources\BS.Items\speaker.jpg", "פסנתר", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\cello.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\mandoline.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0"
}, "Music\\cello.wav", @"Resources\BS.Items\speaker.jpg", "צ'לו", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\xylophone.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\mandoline.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\cello.png,0"
}, "Music\\xylophone.wav", @"Resources\BS.Items\speaker.jpg", "קסילופון", "?של מה הקול המושמע", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]{
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\drum.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\trumpet.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\mandoline.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\MusicalLnstruments\cello.png,0"
}, "Music\\drum.wav", @"Resources\BS.Items\speaker.jpg", "תף", "?של מה הקול המושמע", 0, 1, ""));
                #endregion
            }
            if (StaticVar.GardenTriviaTopic.Contains(4))
            {
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\4\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\4\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\4\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\4\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\4\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\1\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\1\4.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\1\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\1\3.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\1\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\2\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\2\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\2\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\2\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\2\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\3\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\3\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\3\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\3\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\3\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\5\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\5\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\5\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\5\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\5\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\6\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\6\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\6\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\6\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\6\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\7\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\7\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\7\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\7\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\7\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\8\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\8\1.png,90",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\8\1.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\8\1.png,270"
    }, "", @"Resources\Notions\Trivia\FillShapes\8\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\9\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\9\1.png,90",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\9\1.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\9\1.png,270"
    }, "", @"Resources\Notions\Trivia\FillShapes\9\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\10\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\10\1.png,90",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\10\1.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\10\1.png,270"
    }, "", @"Resources\Notions\Trivia\FillShapes\10\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\11\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\11\1.png,90",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\11\1.png,180",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\11\1.png,270"
    }, "", @"Resources\Notions\Trivia\FillShapes\11\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\12\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\12\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\12\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\12\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\12\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\13\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\13\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\13\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\13\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\13\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\14\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\14\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\14\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\14\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\14\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\15\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\15\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\15\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\15\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\15\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\16\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\16\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\16\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\16\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\16\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\17\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\17\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\17\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\17\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\17\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\18\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\18\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\18\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\18\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\18\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\19\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\19\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\19\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\19\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\19\Q.png", "", "?מה החלק החסר", 0, 1, ""));
                _questionList.Add(new triviaQuestion(new string[]  {
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\20\1.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\20\2.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\20\3.png,0",
                ","+System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\Trivia\FillShapes\20\4.png,0"
    }, "", @"Resources\Notions\Trivia\FillShapes\20\Q.png", "", "?מה החלק החסר", 0, 1, ""));
            }
            _questionList = GeneralFunctions.ShuffleList<triviaQuestion>(_questionList);
        }
    }
}
