using CL.BS.Model;
using CL.BS.VMCommon;
using CL.BS.Contract;

namespace CL.BS.GameVM
{
    public class Puzzle25BoardVM  : BaseLernPage//, IPageVM
    {
        public override string Name => "Puzzle25BoardVM";
        private const string _colorRect = "White";// "#FFD1D3D4";
        public string Bull00 { get { return _cards[0, 0].Background; } set { _cards[0, 0].Background = value; } }
        public string Bull01 { get { return _cards[0, 1].Background; } set { _cards[0, 1].Background = value; } }
        public string Bull02 { get { return _cards[0, 2].Background; } set { _cards[0, 2].Background = value; } }
        public string Bull03 { get { return _cards[0, 3].Background; } set { _cards[0, 3].Background = value; } }
        public string Bull04 { get { return _cards[0, 4].Background; } set { _cards[0, 4].Background = value; } }

        public string Bull10 { get { return _cards[1, 0].Background; } set { _cards[1, 0].Background = value; } }
        public string Bull11 { get { return _cards[1, 1].Background; } set { _cards[1, 1].Background = value; } }
        public string Bull12 { get { return _cards[1, 2].Background; } set { _cards[1, 2].Background = value; } }
        public string Bull13 { get { return _cards[1, 3].Background; } set { _cards[1, 3].Background = value; } }
        public string Bull14 { get { return _cards[1, 4].Background; } set { _cards[1, 4].Background = value; } }

        public string Bull20 { get { return _cards[2, 0].Background; } set { _cards[2, 0].Background = value; } }
        public string Bull21 { get { return _cards[2, 1].Background; } set { _cards[2, 1].Background = value; } }
        public string Bull22 { get { return _cards[2, 2].Background; } set { _cards[2, 2].Background = value; } }
        public string Bull23 { get { return _cards[2, 3].Background; } set { _cards[2, 3].Background = value; } }
        public string Bull24 { get { return _cards[2, 4].Background; } set { _cards[2, 4].Background = value; } }

        public string Bull30 { get { return _cards[3, 0].Background; } set { _cards[3, 0].Background = value; } }
        public string Bull31 { get { return _cards[3, 1].Background; } set { _cards[3, 1].Background = value; } }
        public string Bull32 { get { return _cards[3, 2].Background; } set { _cards[3, 2].Background = value; } }
        public string Bull33 { get { return _cards[3, 3].Background; } set { _cards[3, 3].Background = value; } }
        public string Bull34 { get { return _cards[3, 4].Background; } set { _cards[3, 4].Background = value; } }

        public string Bull40 { get { return _cards[4, 0].Background; } set { _cards[4, 0].Background = value; } }
        public string Bull41 { get { return _cards[4, 1].Background; } set { _cards[4, 1].Background = value; } }
        public string Bull42 { get { return _cards[4, 2].Background; } set { _cards[4, 2].Background = value; } }
        public string Bull43 { get { return _cards[4, 3].Background; } set { _cards[4, 3].Background = value; } }
        public string Bull44 { get { return _cards[4, 4].Background; } set { _cards[4, 4].Background = value; } }
        private ItemObject[,] _cards = new ItemObject[5, 5];
        public string IsVisibility { get; set; }
        public string BackgroundCard { get; set; }
        public Puzzle25BoardVM(char color)
        {
            for (int i = 0; i < _cards.GetLength(0); i++)
            {
                for (int j = 0; j < _cards.GetLength(1); j++)
                {
                    _cards[i, j] = new ItemObject();
                    _cards[i, j].Background = _colorRect;
                    NotifyPropertyChanged("Bull" + i + j);
                }
            } 

            BackgroundCard =  System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Game\UCPuzzle25\" + color + "card.png";
            NotifyPropertyChanged("BackgroundCard");
        }

        internal void SetCard(int [,] card)
        {
            for (int x = 0; x < card.GetLength(0); x++)
            {
                for (int y = 0; y < card.GetLength(1); y++)
                {
                    _cards[x, y].Background = card[x, y] == 0 ? _colorRect : "";
                    NotifyPropertyChanged("Bull" + x+ y);
                }
            }
        }

        internal void SetVisibility(bool isVisibility)
        {
            IsVisibility = isVisibility ? "Visible" : "Hidden";
            NotifyPropertyChanged("IsVisibility");
        }
    }
}
