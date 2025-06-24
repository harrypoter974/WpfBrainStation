using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Exercise
{
    class EngineFunctions
    {
       // public int[] Limit = { 2, 99, 999, 9999 };
        private Dictionary<char, Action> _opertor;
        private int _limitIndex;
        protected Random _ran = new Random(DateTime.Now.Millisecond);
        public EngineFunctions()
        {
            _opertor = new Dictionary<char, Action>();
            _opertor.Add('+', new Add());
            _opertor.Add('-', new Sub());
            _opertor.Add(':', new Split());
            _opertor.Add('x', new Multipl());
        }
        internal void SetLevel(int v)
        {
            _limitIndex = v;    
        }
        internal int[] SetQuestion(char[] Operator, bool HaveBrackets)
        {
            int i;
            int[] Num;
            bool trueMath;
            Num = new int[] { -1, -1, -1, -1 };
            if ((Operator[0] == '-' && Operator[1] == ':')
             || (Operator[0] == '+' && Operator[1] == ':')
             || (Operator[0] == '-' && Operator[1] == 'x')
             || (Operator[0] == '+' && Operator[1] == 'x'))
            {
                HaveBrackets = true;
            }
            if (HaveBrackets)
            {
                i = _opertor[Operator[1]].Act(ref Num[1], ref Num[2], 0);
                Num[3] = _opertor[Operator[0]].Act(ref Num[0], ref i, _limitIndex);
            }
            else
            {
                i = _opertor[Operator[0]].Act(ref Num[0], ref Num[1], 0);
                Num[3] = _opertor[Operator[1]].Act(ref i, ref Num[2], _limitIndex);
            }
            for (int j = 0; j < Num.Length; j++)
                if (Num[j] == -1)
                    Num[j] = 1;
            return Num;
        }

        private  int Act(int num1,char Operator, int num2)
        {
            switch (Operator)
            {
                case '+': return num1 + num2;
                case '-':return num1 - num2;
                case 'x': return num1 * num2;
                case ':':
                    if (num2 == 0)
                        return -1;
                    return num1 / num2;
                default:
                    return -1;
            }
        }

        public abstract class Action
        {
            protected Random Run = new Random(DateTime.Now.Millisecond);
            protected int[] Limite = new int[] { 2, 99, 999, 9999 };
            public abstract int Act(ref int num1, ref int num2, int limitIndex);
            protected int getSplitNum(int num)
            {
                List<int> l = new List<int>();
                if (num == 0)
                    return 1;
                for (int i = num; i > 0; i--)
                    if (num % i == 0)
                        l.Add(i);
                return l[Run.Next(l.Count)];
            }

            protected int GetMultiplNum(int num, int limitIndex)
            {
                List<int> l = new List<int>();
                int n = num == 0 ? 10 : num;
                l.Add(1);
                for (int i = 2; n * i <= Limite[limitIndex+1]; i++)
                    l.Add(i);
                return l[Run.Next(l.Count)];
            }
        }

        public class Add : Action
        {
            public override int Act(ref int num1, ref int num2, int limitIndex)
            {
                int res=0;
                if (num1 == -1 && num2 == -1)
                {
                    num1 = Run.Next(Limite[limitIndex], Limite[limitIndex + 1]/2);
                    num2 = Run.Next(Limite[limitIndex], Limite[limitIndex + 1]/2);
                    res = num2 + num1;
                }
                else if (num1 == -1)
                {
                    res = Run.Next(num2, Limite[limitIndex + 1] < num2 ? 2 * num2 : Limite[limitIndex + 1]);
                    num1 = res - num2;
                }
                else if (num2 == -1)
                {
                    res = Run.Next(num1, Limite[limitIndex + 1] < num1 ? 2 * num1 : Limite[limitIndex + 1]);
                    num2 = res - num1;
                }
                return res;
            }
        }

        public class Sub : Action
        {
            public override int Act(ref int num1, ref int num2, int limitIndex)
            {
                int res;
                if (num1 == -1 && num2 == -1)
                {
                    res = Run.Next(2, Limite[limitIndex + 1] - 1);
                    num1 = Run.Next(res, Limite[limitIndex + 1]);
                    num2 = num1 - res;
                }
                if (num1 == -1)
                {
                    num1 = Run.Next(num2 + 1, Limite[limitIndex + 1]< num2 + 1? 2*num2 + 1:Limite[limitIndex + 1]);
                }
                else if (num2 == -1)
                {
                    num2 = Run.Next(num1);
                }
                res = num1 - num2;
                return res;
            }
        }

        public class Split : Action
        {
            public override int Act(ref int num1, ref int num2, int limitIndex)
            {
                int res;
                if (num1 == -1 && num2 == -1)
                {
                    res = Run.Next(Limite[limitIndex], Limite[limitIndex + 1] /10);
                    num2 = GetMultiplNum(res, limitIndex);
                    num1 = res* num2;
                }
                else
                {
                    if (num1 == -1)
                        num1 = GetMultiplNum(num2, limitIndex);
                    else if (num2 == -1)
                        num2 = getSplitNum(num1);
                    res = num1 / num2;
                }
                return res;
            }
        }

        public class Multipl : Action
        {
            public override int Act(ref int num1, ref int num2, int limitIndex)
            {
                int res;
                if (num1 == -1 && num2 == -1)
                {
                    num1 = Run.Next(Limite[limitIndex ] , Limite[limitIndex + 1]/10);
                    res = Run.Next(num1*2, Limite[limitIndex + 1]);
                    num2 = res / num1;
                }
                else if (num1 == -1)
                {
                    num1 = GetMultiplNum(num2, limitIndex);
                }
                else if (num2 == -1)
                {
                    num2 = GetMultiplNum(num1, limitIndex);
                }
                res = num1 * num2;
                return res;
            }
        }
    }
}
