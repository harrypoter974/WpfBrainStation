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
    public abstract class BaseCardBoardVM : BasePageVM
    {
        protected int CardSelected;
        public List<LetterObject> LstCards { get; set; }
        public ICommand TapAnswer { get; set; }

        public string TB0 { get { return LettersList[0].Question; } set { LettersList[0].Question = value; } }
        public string TB1 { get { return LettersList[1].Question; } set { LettersList[1].Question = value; } }
        public string TB2 { get { return LettersList[2].Question; } set { LettersList[2].Question = value; } }
        public string TB3 { get { return LettersList[3].Question; } set { LettersList[3].Question = value; } }
        public string TB4 { get { return LettersList[4].Question; } set { LettersList[4].Question = value; } }
        public string TB5 { get { return LettersList[5].Question; } set { LettersList[5].Question = value; } }
        public Visibility BB0 { get { return LettersList[0].BlinkCell; } set { LettersList[0].BlinkCell = value; } }
        public Visibility BB1 { get { return LettersList[1].BlinkCell; } set { LettersList[1].BlinkCell = value; } }
        public Visibility BB2 { get { return LettersList[2].BlinkCell; } set { LettersList[2].BlinkCell = value; } }
        public Visibility BB3 { get { return LettersList[3].BlinkCell; } set { LettersList[3].BlinkCell = value; } }
        public Visibility BB4 { get { return LettersList[4].BlinkCell; } set { LettersList[4].BlinkCell = value; } }
        public Visibility BB5 { get { return LettersList[5].BlinkCell; } set { LettersList[5].BlinkCell = value; } }
        protected GameObject[] LettersList = new GameObject[6];
        public ICommand SelectCard { get; set; }
        public BaseCardBoardVM()
        {
            for (int i = 0; i < LettersList.Length; i++)
                LettersList[i] = new GameObject();

            SelectCard = new RelayCommand(DoSelectCard);
        }

        private void DoSelectCard(object obj)
        {
            LetterObject lo = (LetterObject)obj;
            TB0 = lo.Background;
            NotifyPropertyChanged("TB0");
        }
        public abstract void SetBoard(List<GameObject> list);
        public abstract void ClearQuestion();
        public abstract void SetQuestion(string q);
        public abstract void SetPlayerNum(int playerNum);
        public abstract  void AddCard(string card);
        public abstract void Clear();
        public abstract void RestartClear();
        public abstract string GetRequiredCard();
        public abstract bool CheckBoard(string answer);
        public  int GetPlayerSelected()
        {
            return CardSelected;
        }
        protected bool LstCardsContains(string p)
        {
            for (int i = 0; i < LstCards.Count(); i++)
            {
                if (LstCards[i].Background == p)
                    return false;

            }
            return true;
        }
        public string GetSelectedCard()
        {
            return TB0;
        }

    }
}
