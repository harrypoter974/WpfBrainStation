using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PuzzleVM : BaseLernPage, IPageVM
    {
        public override string Name => "PuzzleVM";
        protected int GroupIndex;
        private Dictionary<string, int> _groupDic = new Dictionary<string, int>();
        public string GroupBut0 { get { return _groups[0].Background; } set { _groups[0].Background = value; } }
        public string GroupBut1 { get { return _groups[1].Background; } set { _groups[1].Background = value; } }
        public string GroupBut2 { get { return _groups[2].Background; } set { _groups[2].Background = value; } }
        public string GroupBut3 { get { return _groups[3].Background; } set { _groups[3].Background = value; } }
        private ItemObject[] _groups = new ItemObject[4];
        public Puzzle25BoardVM Card0 { get { return _cards[0]; } set { _cards[0] = value; } }
        public Puzzle25BoardVM Card1 { get { return _cards[1]; } set { _cards[1] = value; } }
        public Puzzle25BoardVM Card2 { get { return _cards[2]; } set { _cards[2] = value; } }
        private Puzzle25BoardVM[] _cards = new Puzzle25BoardVM[3];
        private IPuzzle25Manager _logic = (IPuzzle25Manager)
SupportHandlerManager.Base.GetManager("Puzzle25Manager");
        public ICommand _GoHome { get; set; }
        public ICommand NewGame { get; set; }
        public ICommand SetGroup { get; set; }
       
        public PuzzleVM()
        {
            for (int i = 0; i < _groups.Length; i++)
                _groups[i] = new ItemObject();
            for (int i = 0; i < _cards.Length; i++)
                _cards[i] = new Puzzle25BoardVM('B');
            NewGame = new RelayCommand(DoNewGame);
            _GoHome = new RelayCommand(DoGoHome);
        }

        private void DoGoHome(object obj)
        {
            if (Common.StaticVar.IsGarden)
                DoGoToPage("MenuHeGeneralGameVM");
            else
                DoGoToPage("MenuGameVM");
        }

        private void DoNewGame(object obj)
        {
            new Thread(new ThreadStart(() =>
            {
                List<int[,]> cards = _logic.GetCard(GroupIndex);

                for (int i = 0; i < _cards.Length; i++)
                {
                    if (i < cards.Count())
                    {
                        _cards[i].SetCard(cards[i]);
                    }
                    _cards[i].SetVisibility(i < cards.Count());
                    NotifyPropertyChanged("Card" + i);
                }
            })).Start();
        }
    }
}
