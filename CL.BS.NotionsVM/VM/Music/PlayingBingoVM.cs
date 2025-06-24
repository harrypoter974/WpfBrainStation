using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Music
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PlayingBingoVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(PlayingBingoVM);

        //public double BoardHeight { get; set; }
        //public double BoardWidth { get; set; }
        public PlayingBingoVM()
        {
            AnswerBut = new RelayCommand(DoPlaying);
            //BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.498;
            //BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.262;
            //NotifyPropertyChanged(nameof(BoardWidth));
            //NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void DoPlaying(object obj)
        {
            Common.StaticVar.PlayMode = false;
            PlayUrl(String.Format(@"{0}Resources\Audio\Music\{1}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory, obj));
        }
        internal void setVolume(double v)
        {
            Volume = v;
            NotifyPropertyChanged(nameof(Volume));
        }
    }
}
