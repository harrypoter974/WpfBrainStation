using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BingoBoard.VM
{
    public class CollectBoardVM : BaseBingoBoardVM
    {
        public override string Name => "CollectBoardVM";
        public List<GameObject> myList { get; set; }
        public string QuestionText { get; set; }
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }
        public string TBArrow5 { get { return _items[5].Background; } set { _items[5].Background = value; } }
        private SoldierObject[] _items = new SoldierObject[6];
        private int _arrowPosition;
        public CollectBoardVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
            myList = new List<GameObject>();
        }


        public override bool CheckAnswer(string answer)
        {
            return answer == QuestionText;
        }
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override bool CheckBoard(string answer)
        {
            IndexAnswer = 0;
            List<GameObject> l = new List<GameObject>();
            for (int i = 0; i < myList.Count(); i++)
                l.Add(myList[i]);
            GameObject ngo = new GameObject() { Question = answer };
            if (!CL.BS.Common.GeneralFunctions.Contains(l, ngo)) {
                l.Add(ngo);
                SetSoldierPosition();
            }
            myList = l;
            NotifyPropertyChanged("myList");
            return _arrowPosition==5;
        }

        public override void Clear()
        {
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            myList = new List<GameObject>();
            NotifyPropertyChanged("myList");
            ClearQuestion();
        }

        public override void ClearQuestion()
        { 
            QuestionText = string.Empty;
            NotifyPropertyChanged("QuestionText");
        }

        public override void GameWin()
        {
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }

        public override void RestartClear()
        {
            Clear();
        }

        public override void SetAnswer(string question)
        {
            QuestionText = question;
            NotifyPropertyChanged("QuestionText");
        }

        public override void SetBoard(List<GameObject> list)
        {
        }

        public override void SetNumLetterLimit(int v)
        {
            throw new NotImplementedException();
        }

        public override void SetQuestion(string q)
        {
            IndexAnswer = -1;
            QuestionText = q;
            NotifyPropertyChanged("QuestionText");
        }
        private bool SetSoldierPosition()
        {
            if (_arrowPosition == 5)
                return true;
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return _arrowPosition == 5;
        }
    }
}
