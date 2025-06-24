using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class ShapeGameEngine
    {
      private const  int _shapeLength=9;
      private const int _lengthCard = 7;
      private int _shapeIndex =-1, _shapeNum=3;
      private List<string> _shapeList;
      private List<string> _questionList;
      private bool _isPic=false,_isMemory; 
      private string[] _shape = new string[]
        {"straight line","dashed line","curved line"
         ,"Open broken line","Closed broken line"
         ,"Obtuse angle","right angle" ,"sharp angle"
            ,"Equilateral triangle" ,"right triangle"
            ,"scalene triangle" ,"isosceles triangle"
            ,"Square","parallelogram","trapeze"
            ,"quad","rhombus","rectangle"
        ,"ellipse","circle","box","cube"
        ,"cone","Galilee","Hexagonal pyramid","ball","Square pyramid","Triangular pyramid"};
        private string[][] _shapePlay = new string[][] {
     new string[]   { @"Resources\Audio\He\Shapes\line.wav", @"Resources\Audio\He\Shapes\Straight.wav" },
     new string[]   { @"Resources\Audio\He\Shapes\line.wav", @"Resources\Audio\He\General\dashed.wav" },
     new string[]   { @"Resources\Audio\He\Shapes\line.wav", @"Resources\Audio\He\General\crooked.wav" }  ,
     new string[]   {@"Resources\Audio\He\Shapes\Open broken line.wav"},
     new string[]   { @"Resources\Audio\He\Shapes\Closed broken line.wav" } ,
     new string[]   { @"Resources\Audio\He\Shapes\angle.wav",  @"Resources\Audio\He\Shapes\obtuse.wav"},
     new string[]   { @"Resources\Audio\He\Shapes\angle.wav", @"Resources\Audio\He\Shapes\straight_.wav" } ,
     new string[]   { @"Resources\Audio\He\Shapes\angle.wav", @"Resources\Audio\He\Shapes\sharp.wav" },
     new string[]   {@"Resources\Audio\He\Sentences\B10.wav"   },
     new string[]   { @"Resources\Audio\He\Sentences\B9.wav" } ,
     new string[]   {@"Resources\Audio\He\Sentences\B12.wav"   },
     new string[]   {@"Resources\Audio\He\Sentences\B11.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\Square.wav"   },
     new string[]   {@"Resources\Audio\He\Shapes\parallelogram.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\Trapezoid.wav"   },
     new string[]   {@"Resources\Audio\He\Shapes\Square3.wav"   },
     new string[]   {@"Resources\Audio\He\Shapes\Diamond.wav"   },
     new string[]   {@"Resources\Audio\He\Shapes\rectangle.wav"   },
     new string[]   {@"Resources\Audio\He\Shapes\Oval.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\a circle.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\Box.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\cube.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\cone.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\Cylinder.wav" },
     new string[]   {@"Resources\Audio\He\Shapes\Hexagonal pyramid.wav"},
     new string[]   { @"Resources\Audio\He\Shapes\Sphere.wav" } ,
     new string[]   {@"Resources\Audio\He\Shapes\Square pyramid.wav" },
     new string[]   { @"Resources\Audio\He\Shapes\Triangular pyramid.wav" } };

        internal List<GameObject>[] NewGame(int num)
        {
            _isMemory = true;
            _shapeNum = num;
            _shapeIndex = 0;
            _shapeList = GeneralFunctions.ShuffleList<string>(new List<string>(_shape));
            List<GameObject>[] shapeList = new List<GameObject>[4];
            List<GameObject> list = new List<GameObject>();
            _questionList = new List<string>();
            for (int i = 0; i < _shapeNum; i++)
            {
                string shape =  System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Shapes\Game\" + _shapeList[0] + (_isPic ? ".png" : ".jpg");
                list.Add(new GameObject { Uid =shape, Question = shape });// _shapeList[0]
                _questionList.Add(_shapeList[0]);
                _shapeList.RemoveAt(0);
            }
            for (int i = 0; i < shapeList.Length; i++)
            {
                List<GameObject> alist = GeneralFunctions.ShuffleList<GameObject>(list);
                shapeList[i] = new List<GameObject>();
                int animalsIndex = 0;
                for (int j = 0; j < _lengthCard; j++)
                {
                    GameObject vo = new GameObject();
                    if ((_lengthCard - _shapeNum) / 2 - 1 < j && j < _lengthCard - (_lengthCard - _shapeNum) / 2
                        && animalsIndex < _shapeNum)
                    {
                        vo.Uid = alist[animalsIndex].Uid;
                        vo.Question = alist[animalsIndex].Question;
                        animalsIndex++;
                    }
                    else
                        vo.Answer = "#FF41AD48";
                    shapeList[i].Add(vo);
                }
            }
            return shapeList;
        }
     
        internal string[][] GetManagerQuestion()
        {
            string[][] answer = new string[3][];
            answer[0]= new string[] {  System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Shapes\Game\" + _questionList[_shapeIndex] + (_isPic ? ".jpg" : ".png")};
            int i = GetShepIndex(_questionList[_shapeIndex]);
            answer[1] = new string[]{ _shapePlay[i][0],
         _shapePlay[i].Length>1? _shapePlay[i][1]:string.Empty};
            answer[2] = new string[] {  System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Shapes\Game\" + _questionList[_shapeIndex] + (_isPic ? ".png":".jpg"  )};
            _shapeIndex++;
            return answer;
        }
        internal bool EndGame()
        {
            if (_shapeIndex == -1)
                return true;
            return _shapeIndex >=(_isMemory? _shapeNum : _shapeLength);
        }

        internal string GetQuestion()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Shapes\Game\" + _shapeList[_shapeIndex] +( _isPic? ".jpg" : ".png");
        }

        internal string[][] GetAnswer()
        {
            string[][] answer = new string[2][];
            int i = GetShepIndex(_shapeList[_shapeIndex]);
            answer[0] =new string []{ _shapePlay[i][0],
         _shapePlay[i].Length>1? _shapePlay[i][1]:string.Empty};
            answer[1] = new string[] { _shapeList[_shapeIndex] };
            _shapeIndex++;
            return answer;
        }

        internal List<GameObject>[] NewGame()
        {
            _isMemory = false;   
            _shapeIndex = 0;
            List<GameObject>[] bord = new List<GameObject>[5];
            _shapeList = GeneralFunctions.ShuffleList<string>(new List<string>(_shape));
            bord[4] = new List<GameObject>();
            for (int i = 0; i < _shapeLength; i++)
            {
                bord[4].Add(new GameObject
                {
                    Question = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Shapes\Game\" + _shapeList[i] + (_isPic ? ".png"  :".jpg") ,
                    Uid = _shapeList[i]
                });
            }
            for (int i = 0; i <4; i++)
            {
                // bord[i] = new List<ViewObject>();
                bord[i] = GeneralFunctions.ShuffleList<GameObject>(bord[4]);
            }
            return bord;
        }
        internal void SwichMode(bool isPic)
        {
            _isPic= isPic;  
        }

        private int GetShepIndex(string shape)
        {
            for (int i = 0; i < _shape.Length; i++)
                if (shape == _shape[i])
                    return i;
            return -1;
        }
    }
}
