using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class CopyDrawingsVM : BaseLernPage, IPageVM
    {
        public override string Name =>nameof(CopyDrawingsVM);

        public string BackgroundOpen { get; set; }
        public Visibility BackgroundVisibility { get; set; }
        public CopyDrawingsVM()
        { 
            AnswerBut = new RelayCommand(StopeGame);
        }
        private void StopeGame(object obj)
        {
            BackgroundVisibility = System.Windows.Visibility.Collapsed;
            NotifyPropertyChanged(nameof(BackgroundVisibility));
        }

        void IPageVM.load()
        {
            BackgroundOpen = string.Format(@"{0}Resources\Notions\CopyDrawings\open.jpg",
                System.AppDomain.CurrentDomain.BaseDirectory);
            BackgroundVisibility = System.Windows.Visibility.Visible;
            NotifyPropertyChanged(nameof(BackgroundVisibility));
            NotifyPropertyChanged(nameof(BackgroundOpen));
            base.Settings();
        }
    }
}
