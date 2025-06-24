using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.GameManager.Manager;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System.Collections.Generic;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class QuartetsVM : BaseCardGame, IPageVM
    {
        public override string Name => "QuartetsVM";
        protected int PlayerSelected = -1;
        protected bool HaveGroup = false;
        private IQuartets_manager _logic;

      
        public QuartetsVM()
        {
            _logic = (IQuartets_manager)  SupportHandlerManager.Base.GetManager("QuartetsManager");
            for (int i = 0; i < Boards.Length; i++) {                  
                Boards[i] = new QuartetsBoardVM();
                Boards[i].SetPlayerNum(i);
            }

            SelectCard = new RelayCommand(DoSelectCard);
            NewGame = new RelayCommand(DoNewGame);
        }

        private void DoNewGame(object obj)
        {
           List<string>[] l = _logic.NewGame("Vehicles", 4);
            for (int i = 0; i < 4; i++) {
                List<GameObject> lgo = new List<GameObject>();
                for (int j = 0; j < l[i].Count; j++)
                {
                    lgo.Add(new GameObject() { Answer = l[i][j] });
                }
                Boards[i].SetBoard(lgo);
            }
            NextPlayer();
        }
        private void DoSelectCard(object obj)
        {
            if (CL.BS.Common.StaticVar.TransferVar == null)
            {
                if (PlayerSelected != -1)
                    if (!Boards[PlayerSelected].CheckBoard(((QuartetsBoardVM)Boards[PlayerIndex]).GetCardGroup()))
                        NextPlayer();
                    else
                        HaveGroup = true;

                return;
            }
            int i =int.Parse(CL.BS.Common.StaticVar.TransferVar.ToString());
            CL.BS.Common.StaticVar.TransferVar = null;
            if (i < 4)
            {
                PlayerSelected = i;
                string p = ((QuartetsBoardVM)Boards[PlayerIndex]).GetCardGroup();
                if (!Boards[PlayerSelected].CheckBoard(p))
                    NextPlayer();
                else {
                    Boards[PlayerIndex].SetQuestion(p);
                    HaveGroup = true; 
                }
            }
            else
            {
                if (PlayerSelected == -1 || !HaveGroup)
                    return;
                string card = ((QuartetsBoardVM)Boards[PlayerSelected]).CheckCard(((QuartetsBoardVM)Boards[PlayerIndex]).GetRequiredCard());
                if (string.IsNullOrEmpty(card))
                    NextPlayer();
                else { 
                    Boards[PlayerIndex].AddCard(card);
                    Boards[PlayerIndex].SetQuestion(((QuartetsBoardVM)Boards[PlayerIndex]).GetCardGroup());

                }
            }
        }

        private void NextPlayer()
        {
            Boards[PlayerIndex].RestartClear();
            Boards[PlayerIndex].AddCard(_logic.GetCard());
            PlayerIndex = PlayerIndex == 3 ? 0 : PlayerIndex + 1;
            PlayerSelected = -1;
            HaveGroup = false;
            Boards[PlayerIndex].ClearQuestion();
        }

        void IPageVM.load()
        {
            base.Settings();
            DSetPlayer(-1);
        }
    }
}
