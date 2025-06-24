using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseCardGame : BaseLernPage
    {
        protected int PlayerIndex = 0;
        protected int PlayerNum = 1;
        public ICommand SelectCard { get; set; }
        public ICommand NewGame { get; set; }
        public ICommand SetPlayer { get; set; }
        public string PlayerBut1 { get { return PlayerBut[0].Background; } set { PlayerBut[0].Background = value; } }
        public string PlayerBut2 { get { return PlayerBut[1].Background; } set { PlayerBut[1].Background = value; } }
        public string PlayerBut3 { get { return PlayerBut[2].Background; } set { PlayerBut[2].Background = value; } }
        public Visibility BoardVisibility1 { get { return PlayerBut[0].LineVisible; } set { PlayerBut[0].LineVisible = value; } }
        public Visibility BoardVisibility2 { get { return PlayerBut[1].LineVisible; } set { PlayerBut[1].LineVisible = value; } }
        public Visibility BoardVisibility3 { get { return PlayerBut[2].LineVisible; } set { PlayerBut[2].LineVisible = value; } }

        public BaseCardBoardVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BaseCardBoardVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BaseCardBoardVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BaseCardBoardVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        protected BaseCardBoardVM[] Boards = new BaseCardBoardVM[4];//SelectCard

        protected ItemObject[] PlayerBut = new ItemObject[3];
        public BaseCardGame()
        {
            for (int i = 0; i < PlayerBut.Length; i++)
                PlayerBut[i] = new ItemObject() { LineVisible = Visibility.Visible };

            SetPlayer = new RelayCommand(DSetPlayer);
        }

        protected void DSetPlayer(object obj)
        {
            PlayerBut[PlayerNum].Background = string.Empty;
            NotifyPropertyChanged("PlayerBut" + (PlayerNum + 1));
            int pi = int.Parse(obj.ToString());
            if (pi == -1)
            {
                PlayerBut[2].Background = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\Number\4b.png";
                NotifyPropertyChanged("PlayerBut3");
                PlayerNum = 2;
            }
            else
            {
                PlayerBut[pi].Background = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\Number\" + (pi + 2) + "b.png";
                NotifyPropertyChanged("PlayerBut" + (pi + 1));
                PlayerNum = pi;
            }

            switch (pi)
            {
                case -1:
                    PlayerBut[0].LineVisible =
                    PlayerBut[1].LineVisible =
                    PlayerBut[2].LineVisible = Visibility.Visible;
                    break;
                case 0:
                    PlayerBut[0].LineVisible = Visibility.Hidden;
                    PlayerBut[1].LineVisible = Visibility.Hidden;
                    PlayerBut[2].LineVisible = Visibility.Visible;
                    break;
                case 1:
                    PlayerBut[0].LineVisible = Visibility.Visible;
                    PlayerBut[1].LineVisible = Visibility.Hidden;
                    PlayerBut[2].LineVisible = Visibility.Visible;
                    break;
                case 2:
                    PlayerBut[0].LineVisible =
                    PlayerBut[1].LineVisible =
                    PlayerBut[2].LineVisible = Visibility.Visible;
                    break;
                default:
                    break;
            }
            for (int i = 1; i < 4; i++)
                NotifyPropertyChanged("BoardVisibility" + (i));

        }

    }
}
