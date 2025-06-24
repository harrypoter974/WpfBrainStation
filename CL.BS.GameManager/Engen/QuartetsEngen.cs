using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Engen
{
    internal class QuartetsEngen
    {
        List<string> CardList;
        List<string>[] CardPlayers;
        internal List<string>[] NewGame(string subject,int numbPlayers)
        {
            CardList = new List<string>();
            for (int i = 0; i < 40; i++)
            {
                CardList.Add(string.Format(@"{0}Resources\Game\Quartets\{1}\{2}{3}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, subject ,i/4,"ABCD"[i%4]));  
            }
            CardList= Common.GeneralFunctions.ShuffleList<string>(CardList);
            CardPlayers =  new List<string>[numbPlayers];
            for (int i = 0; i < numbPlayers; i++)
            {
                CardPlayers[i] = new List<string>();
                for (int j = 0; j < 4; j++)
                {
                    CardPlayers[i].Add(CardList[0]);
                    CardList.RemoveAt(0);
                }
            }
            return CardPlayers; 
        }

        internal string GetCard()
        {
            string go=CardList[0];
            CardList.RemoveAt(0);
            return go; ;
        }
    }
}
