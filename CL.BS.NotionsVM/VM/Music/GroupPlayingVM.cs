using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Music
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class GroupPlayingVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(GroupPlayingVM); 
        public PlayingBingoVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public PlayingBingoVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public PlayingBingoVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public PlayingBingoVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        private PlayingBingoVM[] Boards = new PlayingBingoVM[4];
        public ICommand changeVolume { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public GroupPlayingVM()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new PlayingBingoVM();
            changeVolume = new RelayCommand(DoChangeVolume);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.498;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.262;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
        private void DoChangeVolume(object obj)
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].setVolume(Volume);
        }
    }
}
