using CL.BS.Model;
using CL.BS.VMCommon;
using System.Threading;

namespace BS.BingoBoard.VM
{
    public class SortBoardVM : BasePageVM
    {
        public int Point = 0;
        private string _rotation;
        private int _soldierPosition = 0;
        public string BaseWinBlink { get; set; }
        public string QuestionPic { get; set; }
        public bool InPlay { get; set; }
        public string TBSoldier0 { get { return SoldierList[0].Background; } set { SoldierList[0].Background = value; } }
        public string TBSoldier1 { get { return SoldierList[1].Background; } set { SoldierList[1].Background = value; } }
        public string TBSoldier2 { get { return SoldierList[2].Background; } set { SoldierList[2].Background = value; } }
        public string TBSoldier3 { get { return SoldierList[3].Background; } set { SoldierList[3].Background = value; } }
        public string TBSoldier4 { get { return SoldierList[4].Background; } set { SoldierList[4].Background = value; } }
        protected SoldierObject[] SoldierList = new SoldierObject[5];
        public override string Name => "SortBoardVM";

        public SortBoardVM(string rotation)
        {
            this._rotation = rotation;
            for (int i = 0; i < SoldierList.Length; i++)
                SoldierList[i] = new SoldierObject();
            BaseWinBlink = "Hidden";
            NotifyPropertyChanged("BaseWinBlink");
            InPlay = true;
        }

        public void SetQuestion(string pic)
        {
            QuestionPic = pic;
            NotifyPropertyChanged("QuestionPic");
        }

   
        public void SetSoldierPosition(bool ToUper)
        {
            _soldierPosition = !ToUper ? 0 :
           SoldierList.Length - 1 == _soldierPosition ? SoldierList.Length - 1 : _soldierPosition + 1;
            for (int i = 0; i < SoldierList.Length; i++)
            {
                if (i == _soldierPosition)
                {
                    SoldierList[i].Background =
                    System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Pion\" + _rotation + ".png";
                }
                else
                {
                    SoldierList[i].Background = string.Empty;
                }
                NotifyPropertyChanged("TBSoldier" + i);
            }
        }

        public bool Is5Position()
        {
            bool b = _soldierPosition == 4;
            if (b)
            {
                BaseWinBlink = "Visible";
                NotifyPropertyChanged(nameof(BaseWinBlink));
                Thread.Sleep(1500);
                BaseWinBlink = "Hidden";
                NotifyPropertyChanged(nameof(BaseWinBlink));
            }
            return b;
        }

        public void StoopBlink()
        {
            BaseWinBlink = "Hidden";
            NotifyPropertyChanged(nameof(BaseWinBlink));
        }
    }
}
