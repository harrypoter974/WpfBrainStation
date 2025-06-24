using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BS.BingoBoard.VM
{
    public class QuartetsBoardVM : BaseCardBoardVM
    {
        public override string Name => "QuartetsBoardVM";
        string _subject = "Vehicles";
        private string MyCaler;
        private string RequiredCard;
        public QuartetsBoardVM()
        {
            TapAnswer = new RelayCommand(DoTapAnswer);
        }

        private void DoTapAnswer(object obj)
        {
            CL.BS.Common.StaticVar.TransferVar = obj;
            int i = int.Parse(obj.ToString());
            if (i < 4)
                CardSelected = i;
            else
            {
                RequiredCard = LettersList[i-3].Question;
            }
        }
        public override bool CheckBoard(string answer)
        {
            for (int i = 0; i < LstCards.Count(); i++)
            {
                string[] p = LstCards[i].Background.Split('\\');
                if (answer[0] == p[p.Length - 1][0])
                    return true;
            }
            return false;
        }

        public override void Clear()
        {
            LstCards = new List<LetterObject>();
            NotifyPropertyChanged("LstCards");
        }

        public override void ClearQuestion()
        {
            LettersList[5].Question = "LawnGreen";
            NotifyPropertyChanged("TB5" );
            for (int i = 1; i < 5; i++)
            {
                LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }   
        }

        public override void RestartClear()
        {
            LettersList[5].Question = MyCaler;
            NotifyPropertyChanged("TB5");
            for (int i = 1; i < 5; i++)
            {
                LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void AddCard(string card)
        {
            LstCards.Add(new LetterObject() { Background = card });
            LstCards = new List<LetterObject>(LstCards);
            NotifyPropertyChanged("LstCards");
        }

        public override void SetBoard(List<GameObject> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                LettersList[i].Question = list[i].Answer;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void SetPlayerNum(int playerNum)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == playerNum)
                {
                    LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                    MyCaler=new string[] { "#FF36A7E9", "#FFBF0027", "#FFF2E61C", "#FF135525" }[i];
                    TB5 = MyCaler;
                    NotifyPropertyChanged("TB5");
                }
                else
                {
                    LettersList[i].BlinkCell = System.Windows.Visibility.Visible;
                }
               
                NotifyPropertyChanged("BB" + i);
            }
        }

        public override void SetQuestion(string q)
        {
            for (int i = 1; i < 5; i++)
            {
                string p = string.Format(@"{0}Resources\Game\Quartets\{1}\{2}{3}.png", System.AppDomain.CurrentDomain.BaseDirectory,_subject,q, "ABCD"[i-1]);
                if (LstCardsContains(p ))
                {
                    LettersList[i].Question = p;
                    NotifyPropertyChanged("TB" + i);
                }
            }
        }

        public string GetCardGroup()
        {
            if (string.IsNullOrEmpty(TB0))
                    return string.Empty;
            string[] p = TB0.Split('\\');
            return p[p.Length-1][0].ToString();
        }

     
        public override string GetRequiredCard()
        {
            return RequiredCard;
        }
        public string CheckCard(string card)
        {
            for (int i = 0; i < LstCards.Count(); i++)
            {
                if (LstCards[i].Background == card)
                {
                    LstCards.RemoveAt(i);

                    LstCards = new List<LetterObject>(LstCards);
                    NotifyPropertyChanged("LstCards");
                    return card;
                }
            }
            return string.Empty;
        }
    }
}
