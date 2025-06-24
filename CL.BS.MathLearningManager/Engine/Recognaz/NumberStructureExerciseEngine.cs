using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class NumberStructureExerciseEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string _group = "10", _tbNum1=string.Empty;
        private int _resolt=0;

        internal string GetBackground()
        {
            return @"Resources\Math\NumberStructure\Exercise" + _group + ".jpg"; ;
        }

        internal void SetGroup(object obj)
        {
           _group=obj.ToString();
        }

        internal void disload()
        {
            _group = "10";
        }

        internal string[] SetQuestion()
        {
            string[] q = new string[3];
            int n1, n2;
            do
            {
                n1 = _ran.Next(1, _group == "100" ? 490 : 40);
                n2 = _ran.Next(1, _group == "100" ? 490 : 40);
            } while (n1.ToString() == _tbNum1);
                _resolt = n1 + n2;
            if (_group == "1")
            {
                q[0] = (n1/10)+"."+(n1%10);
                q[1] = (n2 / 10) + "." + (n2 % 10);
            }
            else
            {
                q[0] = n1.ToString();
                if (_group == "100")
                    q[2] = n2.ToString();
                else
                    q[1] = n2.ToString();
            }
            return q;
        }

        internal bool IsGroup100()
        {
           return _group=="100";
        }

        internal string[] GetResolt()
        {
            string[] res = new string[4];
            switch (_group)
            {
                case "1":
                    res[0] = (_resolt / 10).ToString();
                    res[1] = (_resolt % 10).ToString();
                    break;
                case "10":
                   res[2] = _resolt / 10 == 0 ? string.Empty : (_resolt / 10).ToString();
                    res[3] = (_resolt % 10).ToString();
                    break;
                case "100":
                    res[1] = _resolt / 100 == 0 ? string.Empty : (_resolt / 100).ToString();
                    res[2] = ((_resolt % 100) / 10).ToString();
                    res[3] = ((_resolt % 100) % 10).ToString();
                    break;
                default:
                    break;
            }
            return res;
        }
    }
}
