using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class BaseMatchEngine
    {
        private string[] _commandText = new string[] { "move", "Add", "download" };
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private int _level;
        private int[,] _levelLimit = { { 9, 9, 9 }, { 19, 19, 38 }, { 19, 9, 19 }, { 19, 19, 99 } };

        internal string[][] GetQuestion(bool isLevel1 = true)
        {
            string[][] question = new string[3][];
            List<int> NumCommandList = new List<int>(  new int[] { 0,1,2,3,5,6,7,8,9});
               // new int[][] {
               // new int[] { 0, 2, 3, 5, 6, 9 }// new int[] { 0, 4, 6, 9 }
               //, new int[] { 0,1,  3, 5, 6, 9 }
               //,new int[] {6,7,8,9 } }[Ran.Next(3)]);
            char opertor1 = "+-x:"[0];//Ran.Next(4)//מנעתי את האפשרות של שאלות שהם לא חיבור
            int[] num = new int[4];
            switch (opertor1)
            {
                case '+':
                    if (isLevel1)
                    {
                        num[2] = NumCommandList[_ran.Next(NumCommandList.Count)];// Ran.Next(1, levelLimit[Level,0]);
                        num[0] = _ran.Next(num[2]);
                        num[1] = num[2] - num[0];
                    }
                    else
                    {
                        num[0] = NumCommandList[_ran.Next(NumCommandList.Count)];
                        num[1] = NumCommandList[_ran.Next(NumCommandList.Count)];
                        num[2] = _ran.Next(num[0] + num[1], 20);// num[0] + num[1] + num[3];
                        num[3] = num[2] - num[0] - num[1];
                        //num[0] = NumCommandList[Ran.Next(NumCommandList.Count)];
                        //num[1] = NumCommandList[Ran.Next(NumCommandList.Count)];
                        //num[3] = NumCommandList[Ran.Next(NumCommandList.Count)];
                        //num[2] = num[0] + num[1] + num[3];
                        //if (num[2] > 19)
                        //{
                        //    int delta = num[2] - 19;
                        //    num[2] = 19;
                        //    for (int i = 0; i < num.Length; i++)
                        //    {
                        //        if (i == 2)
                        //            continue;
                        //        if (num[i] - delta >= 0)
                        //            num[i] -= delta;
                        //    }
                        //}
                    }

                    break;
                case '-':
                    num[0] = _ran.Next(1, _levelLimit[_level, 0]);
                    num[2] = _ran.Next(num[0]);
                    num[1] = num[0] - num[2];
                    break;
                case 'x':
                    num[2] = _ran.Next(2, _levelLimit[_level, 0]);
                    num[0] = _ran.Next(1, num[2] / 2);
                    num[1] = num[2] / num[0];
                    num[2] = num[0] * num[1];
                    break;
                case ':':
                    num[0] = _ran.Next(2, _levelLimit[_level, 0]);
                    num[1] = _ran.Next(1, num[0] / 2);
                    num[2] = num[0] / num[1];
                    num[0] = num[2] * num[1];
                    break;
                default:
                    break;
            }
            int index;
            string command;
            question[1] = new string[] { num[0].ToString(), num[1].ToString(), num[2].ToString(), num[3].ToString() };
            List<int> NumIndex = new List<int>(new int[] { 0, 1, 2 });
            //do
            //{
            do
            {
                index = NumIndex[_ran.Next(NumIndex.Count - 1)];
                NumIndex.Remove(index);
            } while (!NumCommandList.Contains(num[index] % 10) && NumIndex.Count > 0);
           // int[] newNum =(int[]) num.Clone();
            int commandNum = switchNum(ref num[index]);
           command = _commandText[commandNum];
            string meseg = string.Format(".{0} {1} בשביל שהמשווה  תהיה נכונה "
              , command, true ? "גפרור" : "שני גפרורים");
            question[0] = new string[] { num[0].ToString(), num[1].ToString(), num[2].ToString(), num[3].ToString() };
           // question[1] = GetAllOptions(num, commandNum);
            question[2] = new string[] { command };
            return question;
        }

        private string[] GetAllOptions(int[] num, int command)
        {
           //int[] numList= new int[][] {
           //     new int[] { 0, 2, 3, 5, 6, 9 }
           //    , new int[] { 0,1,  3, 5, 6, 9 }
           //    ,new int[] {6,7,8,9 } }[command];
            Dictionary<int, int[]> numDic = new Dictionary<int, int[]>();
            switch (command)
            {
                case 0:
                    numDic.Add(0, new int[] {6,9 });
                    numDic.Add(2, new int[] {3 });
                    numDic.Add(3, new int[] {2,5 });
                    numDic.Add(5, new int[] {3 });
                    numDic.Add(6, new int[] { 0 });
                    numDic.Add(9, new int[] { 0 });
                    break;
                case 1:
                    numDic.Add(0, new int[] { 8 });
                    numDic.Add(1, new int[] { 7});
                    numDic.Add(3, new int[] { 9 });
                    numDic.Add(5, new int[] { 6 });
                    numDic.Add(6, new int[] { 8 });
                    numDic.Add(9, new int[] { 8 });
                    break;
                case 2:
                    numDic.Add(6, new int[] {5});
                    numDic.Add(7, new int[] {1 });
                    numDic.Add(8, new int[] { 0,9,6 });
                    numDic.Add(9, new int[] { 3 });
                    break;
                default:
                    break;
            }

            string[] NumText = new string[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                NumText[i] = num[i].ToString();
                int[] tnum;
                if (numDic.ContainsKey(num[i]))
                {
                    int[] numChack = numDic[num[i]];
                    foreach (int tn in numChack)
                    {
                        tnum = num;
                        tnum[i] = tn;
                        if (tnum.Length == 3 && tnum[2] == tnum[0] + tnum[1])
                        {
                            NumText[i] += "," + tnum[i];
                        }
                        else if (tnum[2] == tnum[0] + tnum[1] + tnum[3])
                        {
                            NumText[i] += "," + tnum[i];
                        }
                    }
                }
            }
            return NumText;
        }

        private int switchNum(ref int num)
        {
            int[] res = new int[2];
            res[0] = num % 10;
            int index;
            switch (res[0])
            {
                case 0://0 6 9
                    index = _ran.Next(3);// new int[] {Ran.Next(2),0,Ran.Next(3) }[Level];
                    res = new int[][]
                    {   new int[] { 6, 0 },
                        new int[] { 9, 0 },
                        new int[] { 8,2} }[index];
                    break;
                case 1:
                    res = new int[] { 7, 2 };
                    break;
                case 2:   //2 3 ::6

                    res = new int[] { 3, 0 };
                    break;
                case 3:  //3 5 2:9: 
                    index = _ran.Next(3);// new int[] { Ran.Next(2), 2, Ran.Next(3) }[Level];
                    res = new int[][] {
                        new int[] { 5, 0 },
                        new int[] { 2, 0 },
                        new int[] { 9, 2 } }[index];
                    break;
                //case 4:   //4 :9: 
                //    res =  new int[] { 9,2};
                //    break;
                case 5:   //5 3: :9 
                    index = _ran.Next(3);// new int[] {0, 0, Ran.Next(2) }[Level];
                    res = new int[][] {
                        new int[] { 9,2 },
                        new int[] { 3,0 },
                        new int[] { 6,2} }[index];
                    break;
                case 6:  //6 9 0:8:2
                    index = _ran.Next(4);// new int[] { Ran.Next(2), 2, Ran.Next(4) }[Level];
                    res = new int[][] {
                        new int[] { 9, 0 },
                        new int[] { 0, 0 },
                        new int[] { 5, 1 }  ,
                        new int[] { 8, 2 }}[index];
                    break;
                case 7:   //7 :: 1 
                    res = new int[] { 1,1 };
                    break;
                case 8:     //8 ::6 9 0  
                            // index = new int[] { 0, 0, Ran.Next(4) }[Level];
                    res = new int[][] {
                        new int[] {6, 1},
                        new int[] {9, 1},
                        new int[] {0, 1} }[_ran.Next(3)];
                    break;
                case 9:   //9 6 0  : 8 :3 5 
                    index = _ran.Next(5);//new int[] { Ran.Next(2), 2, Ran.Next(4) }[Level];
                    res = new int[][] {
                        new int[] {6, 0},
                        new int[] {0, 0 },
                        new int[] {5, 1 } ,
                        new int[] {3,1 }  ,
                        new int[] {8, 2 } }[index];
                    break;
                default:
                    break;
            }
            num = res[0] + num / 10 * 10;
            return res[1];
        }
    }
}
