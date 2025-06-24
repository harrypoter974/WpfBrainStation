using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class MathMemoryNumEngine
    {
        private int _lengthNum = 6, _numIndex = 0;
        private const int _cardLength = 8;
        private string[] _numQuestionList;

        internal List<GameObject>[] NewGame(int length)
        {
            _numIndex =0;
            _lengthNum = length;
            string[][] bordLetters = BingoNumEngine.GetNumbers(_lengthNum);
            _numQuestionList = bordLetters[0];
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 1; i < bordLetters.Length; i++)
            {
                bord[i - 1] = new List<GameObject>();
                int cardIndex = 0;
                for (int j = 0; j < _cardLength; j++)
                {
                    GameObject vo = new GameObject();
                    if ((_cardLength - length) / 2  <=j && j -1< _cardLength -
                        (_cardLength - length) / 2 && cardIndex < length)
                    {
                        vo.Uid = vo.Question = bordLetters[i][cardIndex].ToString();
                        cardIndex++;
                    }
                    else
                        vo.Answer = "#FF41AD48";
                    bord[i - 1].Add(vo);
                }
            }
            return bord;
        }
        internal bool EndGame()
        {
            if (_numIndex == -1)
                return true;
            return _numIndex >= _lengthNum;//-1
        }

        internal void SetNumbersLength(int num)
        {
            _lengthNum = num;
        }
        internal string GetQuestion()
        {
            return _numQuestionList[_numIndex++].ToString();
        }
        internal string[] Get_Question()
        {
            int num = int.Parse(_numQuestionList[_numIndex].ToString());
            if (BingoNumEngine._language == "He")
            {

                if (num == 0)
                {
                    return new string[]{ System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Audio\He\Num\0.wav"};
                }
                else if (num == 2)
                {
                    return new string[]{
                        System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Audio\He\Num\two.wav"};
                }
                else if ((num > 10 && num < 32) || num % 10 == 0)
                {
                    return new string[]{  System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\He\Num\" +num+ ".wav" };
                }
                else if (num > 31)
                {
                    return new string[]{ @"Resources\Audio\He\Num\" + (num -num%10) + ".wav" ,
                         @"Resources\Audio\He\General\and.wav",
                        string.Format( @"Resources\Audio\He\Num\{0}.wav" , num%10==2?"two":"n"+ num%10)
                    };
                }
                else
                {
                    return new string[]{  System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\He\Num\n" + num + ".wav" };
                }
            }
            else// 
            {
                if (num < 32 || num % 10 == 0)
                    return new string[]{  string.Format(@"{0}Resources\Audio\{1}\Numbers\{2}.wav",
                        System.AppDomain.CurrentDomain.BaseDirectory, BingoNumEngine._language, num) };
                else if (BingoNumEngine._language == "En")
                {
                    return new string[]{ @"Resources\Audio\En\Numbers\" + (num -num%10) + ".wav" ,
                        string.Format( @"Resources\Audio\En\Numbers\{0}.wav" , num%10)
                    };
                }
                else
                {
                    return new string[]{ @"Resources\Audio\Ar\Numbers\" + num%10+ ".wav" ,
                         @"Resources\Audio\En\Vowels\We.wav",
                        string.Format( @"Resources\Audio\Ar\Numbers\{0}.wav" , (num -num%10) )
                    };
                }
            }
        }

        internal int SetNumbersLength()
        {
            return _lengthNum;
        }

        internal void SetLimit(int limit)
        {
            BingoNumEngine._limit=limit;
        }
    }
}
