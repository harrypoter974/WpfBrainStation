using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class GardenMemoryVM : BaseLernPage, IPageVM
    {
        private int _levelIndex = 0;
        private int _picIndex = 0;
        public ICommand NextPic { get; set; }
        public ICommand SetPic { get; set; }
        public ICommand SetLevel { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name => nameof(GardenMemoryVM);

        public GardenMemoryVM()
        {

            SetPic = new RelayCommand(DoSetPic);
            SetLevel = new RelayCommand(DoSetLevel);
            NextPic = new RelayCommand(DoNextPic);
        }

        void IPageVM.load()
        {

            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Audio\He\Title\GardenMemory.wav");
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\Animals\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Notions\GardenMemory\open.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void DoNextPic(object obj)
        {
            _picIndex = _picIndex == 2 ? 0 : _picIndex + 1;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\GardenMemory\sh" + _levelIndex + _picIndex + ".jpg";        
        NotifyPropertyChanged("BackgroundPic");
    }

        private void DoSetLevel(object obj)
        {
            _levelIndex = int.Parse(obj.ToString());
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Notions\GardenMemory\p" + _levelIndex +  ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void DoSetPic(object obj)
        {
            if (obj.ToString() != "p") {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
       @"Resources\Notions\GardenMemory\" + obj + _levelIndex + _picIndex + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Notions\GardenMemory\" + obj + _levelIndex +  ".jpg";
            }
            NotifyPropertyChanged("BackgroundPic");
        }
    }
}
