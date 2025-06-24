using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    public class Pic4Bord : BasePageVM
    {
        public override string Name =>nameof(Pic4Bord) ;
        public ICommand SelectPic { get; set; }
        public string BackgroundPic { get; set; }
        public string transparencyPic { get; set; }
        public string smallPic { get; set; }
        public string ButMode { get; set; }
        private string _mode = "t";
        private string _pic = "select.jpg";
        public Pic4Bord()
        {
            SelectPic = new RelayCommand(DoSelectPic);
        }

        private void SetPic()
        {
            if (_mode == "s")
            {
                BackgroundPic = string.Format(@"{0}Resources\Notions\Colors\Pic\Board.jpg"
, System.AppDomain.CurrentDomain.BaseDirectory);
            }
            else
            {
                BackgroundPic = string.Format(@"{0}\Resources\Notions\Colors\Image\{1}{2}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, _mode, _pic);

            }
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        private void DoSelectPic(object obj)
        {
            if (BackgroundPic.Contains("select.jpg"))
            {
                _pic = obj.ToString();
                SetPic();
                ButMode = "Visible";
                NotifyPropertyChanged(nameof(ButMode));
                transparencyPic = string.Format(@"{0}\Resources\Notions\Colors\Image\t{1}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, _pic);
                NotifyPropertyChanged(nameof(transparencyPic));
                smallPic = string.Format(@"{0}\Resources\Notions\Colors\Image\s{1}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, _pic);
                NotifyPropertyChanged(nameof(smallPic));
            }
        }

        internal void ShowPic()
        {
            BackgroundPic = string.Format(@"{0}Resources\Notions\Colors\Pic\Board.jpg", 
                System.AppDomain.CurrentDomain.BaseDirectory) ;
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        internal void selectPic()
        {
            ButMode = "Collapsed";
            NotifyPropertyChanged(nameof(ButMode));
            BackgroundPic = string.Format(@"{0}\Resources\Notions\Colors\Image\select.jpg"
, System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        internal void SetMode(string o)
        {
            _pic = "select.jpg";
            _mode = o;
        }

        internal string GetPic()
        {
            return string.Format(@"{0}\Resources\Notions\Colors\Image\{1}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, _pic); ;
        }
    }
}
