using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class MathArray4Engine
    {
        private const int _fontBig = 60;
        private const int _fontSmall = 50;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private int _numStart, _level=1, _blankNumIndex;
        private List<LetterObject> _listAnswer ;

        internal string SetLevel(object level)
        {
            this._level = int.Parse(level.ToString());
            return  System.AppDomain.CurrentDomain.BaseDirectory 
                + @"Resources\Number\" + " ab"[this._level] + ".png";
        }
        internal List<LetterObject> GetAnswer()
        {
            return _listAnswer;
        }

       

        internal List<LetterObject> SetQuestion()
        {
          int[]  NumList = new int[5];
            int newNum;
            do
            {
                newNum = _ran.Next(1, 20);
            } while (newNum == _numStart);
            _numStart = newNum;
            int delta = _ran.Next(1,10);
          int addDelta=this._level==1?0:_ran.Next(1,5);
            NumList[0] = _numStart;

            for (int i = 0; i < NumList.Length-1; i++)
            {
                _numStart += delta;
                NumList[i + 1] = _numStart;
                delta += addDelta;
            }
           
                _blankNumIndex = _ran.Next(1, 5);
            List<LetterObject> list = new List<LetterObject>();
            _listAnswer = new List<LetterObject>();
            if (false)
            {
               LetterObject vo =new LetterObject()
               {Background= System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\BS.Items\greenBorderBut.png"
               , Uid= "Black",FontSize=_fontBig,
                   Width =80 * NumList[0].ToString().Length
               };
                list.Add(vo.Duplicate());
                vo.FontSize = _fontSmall;
                vo.Text = NumList[0].ToString();
                _listAnswer.Add(vo);
                for (int i = 0; i < 3; i++)
                {
                    vo = new LetterObject() { Text = NumList[i + 1] + ",", FontSize = _fontBig,
                        Uid = "White" ,Width= 80
                    };
                    list.Add(vo);
                    _listAnswer.Add(vo);
                }
                vo = new LetterObject() {
                    Background = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\BS.Items\greenBorderBut.png",
                    Uid = "Black", FontSize = _fontBig,
                    Width = 40* NumList[4].ToString().Length
                };
                list.Add(vo.Duplicate());
                vo.FontSize = _fontSmall;
                vo.Text = NumList[4].ToString();
                _listAnswer.Add(vo);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    LetterObject vo;
                    if (i == _blankNumIndex)
                    {
                        vo = new LetterObject()
                        {
                            Background = System.AppDomain.CurrentDomain.BaseDirectory +
                  @"Resources\BS.Items\greenBorderBut.png",
                            Uid = "Black",
                            FontSize = _fontBig,
                            Width =40* NumList[i].ToString().Length
                        };
                        list.Add(vo.Duplicate());
                        vo.FontSize = _fontSmall;
                        Result = NumList[i].ToString();
                        vo.Text = Common.GeneralFunctions.SplitText(Result, " ");                        
                        _listAnswer.Add(vo);
                    }
                    else
                    {
                        vo = new LetterObject() { Uid = "White", Text = NumList[i] + 
                     (  i==4?string.Empty:","), FontSize = _fontBig, Width= 80
                        };
                        list.Add(vo);
                        _listAnswer.Add(vo);
                    }                    
                }
            }
            return list;
        }

        internal int GetResult()
        {
           return int.Parse(Result);
        }

        internal string[] OpenMessage()
        {
            string[] message = new string[2];
            message[0] = Common.StaticVar.inline.PlayName();
            if (Common.StaticVar.inline.IsBoy)
                message[1] = @"Resources\Audio\He\Sentences\A12.wav";
            else
                message[1] = @"Resources\Audio\He\Sentences\A13.wav";
            return message;
            //return new string[] {
            //    Common.StaticVar.PlayName(),
            //   Common.StaticVar.IsBoy? @"Resources\Audio\He\General\הנח את.wav":
            //   @"Resources\Audio\He\General\הניחי.wav",
            //    Common.StaticVar.IsBoy?"":
            //  @"Resources\Audio\He\General\את...wav",
            //@"Resources\Audio\He\General\הכרטיסים.wav",
            //@"Resources\Audio\He\General\במקום.wav",
            //@"Resources\Audio\He\General\הנכון.wav" };
        }
        string Result;
    }
}
