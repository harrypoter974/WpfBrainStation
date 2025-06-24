using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class Sudoku4PlayerVM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name =>nameof(Sudoku4PlayerVM) ;
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public BaseSudukuBoardVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BaseSudukuBoardVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BaseSudukuBoardVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BaseSudukuBoardVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        private BaseSudukuBoardVM[] Boards=new SudukuBoard4x4VM[4]; private int _level = 0;
        public string Level0 { get { return _LevelBut[0].Background; } set { _LevelBut[0].Background = value; } }
        public string Level1 { get { return _LevelBut[1].Background; } set { _LevelBut[1].Background = value; } }
        public string Level2 { get { return _LevelBut[2].Background; } set { _LevelBut[2].Background = value; } }
        private SoldierObject[] _LevelBut = new SoldierObject[3];
        public Sudoku4PlayerVM()
        {
            for (int i = 0; i < _LevelBut.Length; i++)
                _LevelBut[i] = new SoldierObject();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i]=new SudukuBoard4x4VM("ABCD"[i]);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.352;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight *0.482 ;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(SetLevel);
            MouseMove = new RelayCommand(DpMouseDone);
        }

        private void DpMouseDone(object obj)
        {
            Boards[3].DoMouseDown(obj);
        }

        private void SetLevel(object obj)
        {
            _LevelBut[_level].Background = String.Empty;
            NotifyPropertyChanged("Level" + _level);
            _level = int.Parse(obj.ToString());
            _LevelBut[_level].Background = String.Format(@"{0}Resources\BS.Items\{1}.png",
 System.AppDomain.CurrentDomain.BaseDirectory, new String[] { "Easy", "Medium", "Hard" }[_level]);
            NotifyPropertyChanged("Level" + _level);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetLevel(int.Parse(obj.ToString()));
        }
        void IPageVM.load()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].RestartBoard();
            base.Settings();
            UrlPlay = String.Empty;
        }
    }
}
