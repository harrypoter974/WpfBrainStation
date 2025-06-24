using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Exercise
{
    class MathVariableEngine
    {
        // private static string[] Thing = { "iparon", "kadur" };,"balon", "perah", "uga"
        private string[] _objectPic = new string[3]
   { System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\iparon.png",
         System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\kadur.png",
          System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\balon.png"  };
      
        private int[] _answer = new int[3];
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private const int _limite = 9;
        private const int WIDTH = 19;

        internal string Switch1Or2(int var)
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Math\Exercise\var" + var + ".png";
        }

  

        internal int[] GetAnswer()
        {
            return _answer ;
        }

        internal List<LetterObject>[] getQuestion(int var)
        {
            List<LetterObject>[] Num =new  List<LetterObject>[var];
            for (int i = 0; i < var; i++)
                Num[i] = new List<LetterObject>();
            char op1 = "+-x:"[_ran.Next(3)];
            int[] bottomNum = new int[3];
            switch (op1)
            {
                case '+':
                    bottomNum[0] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = _ran.Next(1, _limite / 2);
                    bottomNum[2] = bottomNum[0] + bottomNum[1];
                    break;
                case '-':
                    bottomNum[2] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = _ran.Next(1, _limite / 2);
                    bottomNum[0] = bottomNum[2] + bottomNum[1];
                    break;
                case 'x':
                    bottomNum[0] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = GetMultiplNum(bottomNum[0]);
                    bottomNum[2] = bottomNum[0] * bottomNum[1];
                    break;
                case ':':
                    bottomNum[2] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = GetMultiplNum(bottomNum[2]);
                    bottomNum[0] = bottomNum[2] * bottomNum[1];
                    break;
            }
            Num[0]=new List<LetterObject>();
            Num[0].Add(new LetterObject { Text = bottomNum[0].ToString(), Width = WIDTH * bottomNum[0].ToString().Length });
            Num[0].Add(new LetterObject { Text =op1.ToString(), Width = WIDTH });
            Num[0].Add(new LetterObject { Text =bottomNum[1].ToString(), Width = WIDTH * bottomNum[1].ToString().Length });
            Num[0].Add(new LetterObject { Text ="=", Width = WIDTH });
            Num[0].Add(new LetterObject { Text =bottomNum[2].ToString(), Width = WIDTH * bottomNum[2].ToString().Length });
            int varIndex = _ran.Next(2);
            int var1 = bottomNum[varIndex];
            _answer[0] = bottomNum[varIndex];
           Num[0] [varIndex * 2].Background= _objectPic[0];
           Num[0] [varIndex * 2].Text=String.Empty;
            if (var >= 2)
            {
                Num[1] = new List<LetterObject>();
                char op2 = "+-x:"[_ran.Next(3)];

                int varIndex1;
                if (op2 == '+' || op2 == '-')
                    varIndex1 = _ran.Next(2);
                else if (op2 == 'x')
                    varIndex1 = _ran.Next(1);
                else
                    varIndex1 = _ran.Next(1, 2);
                int varIndex2;
                do
                {
                    varIndex2 = _ran.Next(2);
                } while (varIndex1 == varIndex2);
                int[] UpNum = new int[3];
                switch (op2)
                {
                    case '+':
                        if (varIndex1 == 2)
                        {
                            UpNum[2] = var1;
                            UpNum[0] = _ran.Next(1, var1);
                            UpNum[1] = UpNum[2] - UpNum[0];
                        }
                        else
                        {
                            UpNum[varIndex1] = var1;
                            if (varIndex1 != 0)
                                UpNum[0] = _ran.Next(1, _limite / 2);
                            if (varIndex1 != 1)
                                UpNum[1] = _ran.Next(1, _limite / 2);
                            UpNum[2] = UpNum[0] + UpNum[1];
                        }
                        break;
                    case '-':
                        if (varIndex1 == 0)
                        {
                            UpNum[0] = var1;
                            UpNum[2] = _ran.Next(1, var1);
                            UpNum[1] = UpNum[0] - UpNum[2];
                        }
                        else
                        {
                            UpNum[varIndex1] = var1;
                            if (varIndex1 != 2)
                                UpNum[2] = _ran.Next(1, _limite / 2);
                            if (varIndex1 != 1)
                                UpNum[1] = _ran.Next(1, _limite / 2);
                            UpNum[0] = UpNum[2] + UpNum[1];
                        }
                        break;
                    case 'x':
                        UpNum[varIndex1] = var1;
                        if (varIndex1 != 0)
                            UpNum[0] = _ran.Next(1, _limite / 2);
                        if (varIndex1 != 1)
                            UpNum[1] = _ran.Next(1, _limite / 2);
                        UpNum[2] = UpNum[0] * UpNum[1];
                        break;
                    case ':':
                        UpNum[varIndex1] = var1;
                        if (varIndex1 != 2)
                            UpNum[2] = _ran.Next(1, _limite / 2);
                        if (varIndex1 != 1)
                            UpNum[1] = _ran.Next(1, _limite / 2);
                        UpNum[0] = UpNum[2] * UpNum[1];
                        break;
                }
               Num[1].Add(new LetterObject { Text = UpNum[0].ToString() ,Width=WIDTH* UpNum[0].ToString().Length });
               Num[1].Add(new LetterObject { Text = op2.ToString(), Width = WIDTH });
               Num[1].Add(new LetterObject { Text = UpNum[1].ToString(), Width = WIDTH * UpNum[1].ToString().Length });
               Num[1].Add(new LetterObject { Text = "=", Width = WIDTH });
                for (int i = 0; i < UpNum.Length; i++)
                {
                    if (var1.ToString() == Num[1][i].Text) {
                        Num[1][ i].Background= _objectPic[0];
                        Num[1][i ].Text =String.Empty;
                    }
                }
                _answer[1] = UpNum[2];
               Num[1].Add(new LetterObject { Background = _objectPic[1], Width = WIDTH });
            }
            if (var == 3)
            {
                Num[2] = new List<LetterObject>();
                char op3 = "+-"[_ran.Next(2)];
                int[] locatin = new int[3];
                switch (op3)
                {
                    case '-':
                        locatin = _answer[0] > _answer[1] ? new int[] { 0, 1, 2 } : new int[] { 1, 0, 2 };
                        _answer[2] = _answer[locatin[0]] - _answer[locatin[1]];
                        break;
                    case '+':
                        locatin = new int[] { 0, 1, 2 };
                        _answer[2] = _answer[locatin[0]] + _answer[locatin[1]];
                        break;
                    default:
                        break;
                }
                Num[2].Add(new LetterObject { Background = _objectPic[locatin[0]], Width = WIDTH });
                Num[2].Add(new LetterObject { Text = op3.ToString(), Width = WIDTH });
                Num[2].Add(new LetterObject { Background = _objectPic[locatin[1]], Width = WIDTH });
                Num[2].Add(new LetterObject { Text = "=", Width = WIDTH });
                Num[2].Add(new LetterObject { Background = _objectPic[locatin[2]], Width = WIDTH });
            }
            return Num;
        }

        internal string[] GetQuestion(int var)
        {
            string[] Num = new string[var * 5];
            char op1 = "+-x:"[_ran.Next(3)];
            int[] bottomNum = new int[3];
            switch (op1)
            {
                case '+':
                    bottomNum[0] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = _ran.Next(1, _limite / 2);
                    bottomNum[2] = bottomNum[0] + bottomNum[1];
                    break;
                case '-':
                    bottomNum[2] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = _ran.Next(1, _limite / 2);
                    bottomNum[0] = bottomNum[2] + bottomNum[1];
                    break;
                case 'x':
                    bottomNum[0] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = GetMultiplNum(bottomNum[0]);
                    bottomNum[2] = bottomNum[0] * bottomNum[1];
                    break;
                case ':':
                    bottomNum[2] = _ran.Next(1, _limite / 2);
                    bottomNum[1] = GetMultiplNum(bottomNum[2]);
                    bottomNum[0] = bottomNum[2] * bottomNum[1];
                    break;
            }
            Num[0] = bottomNum[0].ToString();
            Num[1] = op1.ToString();
            Num[2] = bottomNum[1].ToString();
            Num[3] = "=";
            Num[4] = bottomNum[2].ToString();
            int varIndex = _ran.Next(2);
            int var1 = bottomNum[varIndex];
            _answer[0] = bottomNum[varIndex];
            Num[varIndex*2] = _objectPic[0];
            if (var >= 2)
            {
                char op2 = "+-x:"[_ran.Next(3)];
                Num[8] = op2.ToString();
             
                int varIndex1;
                if (op2 == '+' || op2 == '-')
                    varIndex1 = _ran.Next(2);
                else if (op2 == 'x')
                    varIndex1 = _ran.Next(1);
                else
                    varIndex1 = _ran.Next(1, 2);
                int varIndex2;
                do
                {
                    varIndex2 = _ran.Next(2);
                } while (varIndex1 == varIndex2);
                int[] UpNum = new int[3];
                switch (op2)
                {
                    case '+':
                        if (varIndex1 == 2)
                        {
                            UpNum[2] = var1;
                            UpNum[0] = _ran.Next(1, var1);
                            UpNum[1] = UpNum[2] - UpNum[0];
                        }
                        else
                        {
                            UpNum[varIndex1] = var1;
                            if (varIndex1 != 0)
                                UpNum[0] = _ran.Next(1, _limite / 2);
                            if (varIndex1 != 1)
                                UpNum[1] = _ran.Next(1, _limite / 2);
                            UpNum[2] = UpNum[0] + UpNum[1];
                        }
                        break;
                    case '-':
                        if (varIndex1 == 0)
                        {
                            UpNum[0] = var1;
                            UpNum[2] = _ran.Next(1, var1);
                            UpNum[1] = UpNum[0] - UpNum[2];
                        }
                        else
                        {
                            UpNum[varIndex1] = var1;
                            if (varIndex1 != 2)
                                UpNum[2] = _ran.Next(1, _limite / 2);
                            if (varIndex1 != 1)
                                UpNum[1] = _ran.Next(1, _limite / 2);
                            UpNum[0] = UpNum[2] + UpNum[1];
                        }
                        break;
                    case 'x':
                        UpNum[varIndex1] = var1;
                        if (varIndex1 != 0)
                            UpNum[0] = _ran.Next(1, _limite / 2);
                        if (varIndex1 != 1)
                            UpNum[1] = _ran.Next(1, _limite / 2);
                        UpNum[2] = UpNum[0] * UpNum[1];
                        break;
                    case ':':
                        UpNum[varIndex1] = var1;
                        if (varIndex1 != 2)
                            UpNum[2] = _ran.Next(1, _limite / 2);
                        if (varIndex1 != 1)
                            UpNum[1] = _ran.Next(1, _limite / 2);
                        UpNum[0] = UpNum[2] * UpNum[1];
                        break;
                }
                Num[5] = UpNum[0].ToString();
                Num[6] = op2.ToString();
                Num[7] = UpNum[1].ToString();
                Num[8] = "=";
                for (int i = 0; i < UpNum.Length; i++)
                {
                    if (var1==UpNum[i])
                        Num[5+i*2]= _objectPic[0];
                }
                _answer[1] = UpNum[2];
                Num[9] = _objectPic[1];
            }
            if (var == 3)
            {
                char op3 = "+-"[_ran.Next(2)];
                int[] locatin = new int[3];
                switch (op3)
                {
                    case '-':
                        locatin = _answer[0] > _answer[1] ? new int[] {0,1,2 } : new int[] {1,0,2 };
                        _answer[2] = _answer[locatin[0]] - _answer[locatin[1]];
                        break;
                    case '+':
                        locatin =new int[] { 0, 1, 2 };
                        _answer[2] = _answer[locatin[0]] + _answer[locatin[1]];
                        break;
                    default:
                        break;
                }
                Num[10] = _objectPic[locatin[0]];
                Num[11] = op3.ToString();
                Num[12] = _objectPic[locatin[1]];
                Num[13] = "=";
                Num[14] = _objectPic[locatin[2]];
            }
            return Num;
        }

        protected int GetMultiplNum(int num)
        {
            List<int> l = new List<int>();
            int n = num == 0 ? 10 : num;
            l.Add(1);
            for (int i = 1; n * i <= _limite; i++)
                l.Add(i);
            return l[_ran.Next(l.Count)];
        }
    }
}
