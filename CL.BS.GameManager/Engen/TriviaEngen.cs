using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace CL.BS.GameManager.Engen
{
    class TriviaEngen
    {
        private List<triviaQuestion> _questionList;
        private Random _ran = new Random(DateTime.Now.Millisecond);

        internal triviaQuestion GetTriviaQuestion()
        {
            triviaQuestion tq=null;
            if (_questionList.Count() == 0)
                NewGame();
            if ( _questionList.Count()>0)
            {
                int i = _ran.Next( _questionList.Count());
                tq = _questionList[i];
                _questionList.RemoveAt(i);
            }
            return tq;
        }
        internal void NewGame()
        {
            _questionList = new List<triviaQuestion>();
            StreamReader streamReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory+ 
                (Common.StaticVar.IsGarden ? @"Resources\Game\triva\Congratulations.xls" : @"Resources\Game\triva\triva.xls"), System.Text.Encoding.UTF8);
            string[] xlRange = streamReader.ReadToEnd().Split('\n');

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i =0; i < xlRange.Length; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(xlRange[i]))
                        continue;
                    string[] Cells = xlRange[i].Split(',');
                    _questionList.Add(new triviaQuestion(new string[] {Cells[ 5], Cells[6], Cells[ 7], Cells[ 8] }
    ,  Cells[2],Cells[ 3],Cells[9], Cells[4], 0, 0, ""));

                }
                catch (Exception) { }
            }
        }
    }
}
