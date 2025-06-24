using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Print
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PrintVM : BaseLernPage, IPageVM
    {
        private string _selectPrint;
        private int _picIndex = 0;
        public ICommand SelectPic { get; set; }
        public ICommand NextPic  { get; set; }
        public ICommand ShowPic { get; set; }
        public string BackgroundPic { get; set; }
        public string PicBackground { get; set; }
        public string MessagePic { get; set; }
        public override string Name => "PrintVM";

        public PrintVM()
        {
            ShowPic = new RelayCommand(DoShowPic);
            SelectPic = new RelayCommand(DoSelectPic);
            NextPic = new RelayCommand(DoNextPic  );
        }

        void IPageVM.load()
        {
            //PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            //@"Resources\Audio\He\Title\Print.wav");

            PicBackground = "Transparent" ;
            NotifyPropertyChanged("PicBackground");
            _selectPrint = string.Empty;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Print\Open.jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (!Common.StaticVar.inline.IsBoy)
            {//
                MessagePic= System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Print\message.png";
            NotifyPropertyChanged("MessagePic");
            }
        }

        private void DoShowPic(object obj)
        {

            PicBackground = PicBackground == "White" ? "Transparent" : "White";
            NotifyPropertyChanged("PicBackground");
        }

        private void DoSelectPic(object obj)
        {
            _selectPrint = obj.ToString();
            _picIndex = 0;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Print\"+_selectPrint+_picIndex+".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void DoNextPic(object obj)
        {
            if(_selectPrint != string.Empty)
            {
                if (_picIndex >= 4)
                    _picIndex = 0;
                else
                    _picIndex++;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Print\" + _selectPrint + _picIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
              
            }
        }
    }
}
