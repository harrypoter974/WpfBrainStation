using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Engen
{
    class Puzzle25Engen
    {
        private Dictionary<int, int> _groupDic = new Dictionary<int, int>();
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private List<int[,]>[] _cards;

        internal Puzzle25Engen()
        {
            _groupDic.Add( 0,1);
            _groupDic.Add( 1,2);
            _groupDic.Add( 2,3);
            _groupDic.Add( 3,6);
            _cards = new List<int[,]>[6];
            #region Card 0
            _cards[0] = new List<int[,]>() {
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 1, 0 },
                             { 0, 1,1, 1, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 1,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 1,1, 1, 0 },
                             { 0, 1,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 1, 1 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 1, 1,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 1,1, 1, 0 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 1, 1 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 0, 1,1, 1, 0 } } };
            #endregion
            #region Card 1
            _cards[1] = new List<int[,]>() {
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 1, 1,1, 1, 0 } },
                new int[,] { { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 1,1, 1, 1 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 } },
                new int[,] { { 1, 1,1, 1, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,1, 1, 1 } } };
            #endregion
            #region Card 2
            _cards[2] = new List<int[,]>() {
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,1, 1, 0 },
                             { 0, 0,0, 1, 1 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 1, 1,0, 0, 0 },
                             { 1, 0,0, 0, 0 } },
                new int[,] { { 1, 1,0, 0, 0 },
                             { 0, 1,1, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 1 },
                             { 0, 0,0, 1, 1 },
                             { 0, 0,0, 1,0 },
                             { 0, 0,0, 0,0 },
                             { 0, 0,0, 0, 0 } },

                new int[,] { { 1, 0,0, 0, 0 },
                             { 1, 1,0, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 1, 1 },
                             { 0, 0,1, 1, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,0, 1, 1 },
                             { 0, 0,0, 0, 1 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,1, 0, 0 },
                             {1, 1,0, 0, 0 } } };
            #endregion
            #region Card 3
            _cards[3] = new List<int[,]>() {
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 1,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 0, 1,1, 1, 0 },
                             { 0, 0,0, 0,0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 1, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,1, 1, 0  },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 0 } },

                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,0, 1, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,1, 1, 0 },
                             { 1, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 1,0, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,1, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 1 },
                             { 0, 1,1, 1, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } } };
            #endregion
            #region Card 4
            _cards[4] = new List<int[,]>() {
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,1, 1, 1 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 1,0, 0, 0 },
                             { 1, 0,0, 0, 0 } },
                new int[,] { { 1, 1,1, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 1 },
                             { 0, 0,0, 1, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 1, 0,0, 0, 0 },
                             { 1, 1,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,1, 1, 1 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 1, 1 },
                             { 0, 0,0, 0, 1 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 1, 1,1, 0, 0 } } };
            #endregion
            #region Card 5
            _cards[5] = new List<int[,]>() {
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,1, 1, 1 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 1, 1,1, 0, 0 },
                             { 1, 0,0, 0, 0 } },
                new int[,] { { 1, 1,1, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 1 },
                             { 0, 0,1, 1, 1 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 1, 0,0, 0, 0 },
                             { 1, 1,1, 0, 0 },
                             { 1, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,1, 1, 1 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,0, 1, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 1 },
                             { 0, 0,1, 1, 1 },
                             { 0, 0,0, 0, 1 } },
                new int[,] { { 0, 0,0, 0, 0 },
                             { 0, 0,0, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 0, 1,0, 0, 0 },
                             { 1, 1,1, 0, 0 } } };
            #endregion
        }

        internal List<int[,]> GetCards(int cardsNum)
        {
            cardsNum = _groupDic[cardsNum];int 
                cardIndex = 0;
            List<int[,]> cards = new List<int[,]>();
            switch (cardsNum) {
                case 1:
                cards.Add(
                new int[,] { { 1, 1,1, 1, 1 },
                             { 1, 1,1, 1, 1 },
                             { 1, 1,1, 1, 1 },
                             { 1, 1,1, 1, 1 },
                             { 1, 1,1, 1, 1 }  });
                return cards;
                case 6:
                List<int>location=    Common.GeneralFunctions.ShuffleList<int>(new List<int> { 0, 1, 2, 3, 4, 5 });
                for (int i = 0; i < cardsNum; i++)
                    cards.Add(_cards[location[i]][_ran.Next(_cards[0].Count())]);
                    break;
                case 3:
                   List< int>cardsList = GetCardsList();
                    for (int i = 0; i < cardsNum; i++)
                    {
                        bool NotfindCard = true;
                        int[,]c = new int[5,5];
                        while (NotfindCard)
                        {
                        cardIndex = i * 2;
                            int[] card1 =new int [2]{cardsList[cardIndex++], _ran.Next(8)};
                            int[] card2 = new int[2]{cardsList[cardIndex++], _ran.Next(8) };
                            bool CircleNotCircle = true;
                            for (int x = 0; x < 5&& CircleNotCircle; x++)
                            {
                                for (int y = 0; y < 5&& CircleNotCircle; y++)
                                {
                                    if (_cards[card1[0]][ card1[1]][x,y] == 1)
                                        CircleNotCircle = _cards[card1[0]][card1[1]][x, y] != _cards[card2[0]][card2[1]][x, y];
                                    if (CircleNotCircle)
                                    {
                                        if (_cards[card2[0]][card2[1]][x, y] == 1)
                                        {
                                            CircleNotCircle = _cards[card1[0]][card1[1]][x, y] != _cards[card2[0]][card2[1]][x, y];
                                        }
                                    }
                                }
                            }
                            if (CircleNotCircle)
                            {
                                NotfindCard = false;
                                for (int x = 0; x < 5 && CircleNotCircle; x++)
                                {
                                    for (int y = 0; y < 5 && CircleNotCircle; y++)
                                    {
                                        if(_cards[card2[0]][card2[1]][x, y]==1||_cards[card1[0]][card1[1]][x, y]==1)
                                            c[x,y] = 1;
                                        else
                                            c[x, y] = 0;
                                    }
                                }
                            }
                        }                   
                        cards.Add(c);
                    }
                    break;
                case 2:
                    List<int> cards_list = GetCardsList();
                    for (int i = 0; i < cardsNum; i++)
                    {
                        bool NotfindCard = true;
                        int[,] c = new int[5, 5];
                        while (NotfindCard)
                        {
                        cardIndex = i * 3;
                            int[] card1 = new int[2] {cards_list[cardIndex++], _ran.Next(8) };
                            int[] card2 = new int[2] {cards_list[cardIndex++], _ran.Next(8) };
                            int[] card3 = new int[2] {cards_list[cardIndex++], _ran.Next(8) };
                         
                            bool CircleNotCircle = true;
                            for (int x = 0; x < 5 && CircleNotCircle; x++)
                            {
                                for (int y = 0; y < 5 && CircleNotCircle; y++)
                                {
                                    if (_cards[card1[0]][card1[1]][x, y] == 1) { 
                                        CircleNotCircle = _cards[card1[0]][card1[1]][x, y] != _cards[card2[0]][card2[1]][x, y]&&
                                            _cards[card1[0]][card1[1]][x, y] != _cards[card3[0]][card3[1]][x, y];
                                    }
                                    if (CircleNotCircle)
                                    {
                                        if (_cards[card2[0]][card2[1]][x, y] == 1)
                                        {
                                            CircleNotCircle = _cards[card1[0]][card1[1]][x, y] != _cards[card2[0]][card2[1]][x, y] &&
                                                _cards[card2[0]][card2[1]][x, y] != _cards[card3[0]][card3[1]][x, y];
                                        }
                                    }
                                    if (CircleNotCircle)
                                    {
                                        if (_cards[card3[0]][card3[1]][x, y] == 1)
                                        {
                                            CircleNotCircle = _cards[card3[0]][card3[1]][x, y] != _cards[card2[0]][card2[1]][x, y] &&
                                                _cards[card1[0]][card1[1]][x, y] != _cards[card3[0]][card3[1]][x, y];
                                        }
                                    }
                                }
                            }
                            if (CircleNotCircle)
                            {
                                NotfindCard = false;
                                for (int x = 0; x < 5 && CircleNotCircle; x++)
                                {
                                    for (int y = 0; y < 5 && CircleNotCircle; y++)
                                    {
                                        if (_cards[card1[0]][card1[1]][x, y] == 1 
                                         || _cards[card2[0]][card2[1]][x, y] == 1 
                                         || _cards[card3[0]][card3[1]][x, y] == 1)
                                            c[x, y] = 1;
                                        else
                                            c[x, y] = 0;
                                    }
                                }
                            }
                        }
                        cards.Add(c);
                    }
                    break;


            }
           
            return cards;
        }

        private List<int> GetCardsList()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5 };
            List<int> cardList = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                int n = list[_ran.Next(list.Count())];
                list.Remove(n);
                cardList.Add(n);
            }
            return cardList;
        }
    }
}
