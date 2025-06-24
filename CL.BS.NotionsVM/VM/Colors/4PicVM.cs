using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class _4PicVM : BaseLernPage, IPageVM
    {
        public override string Name => "4PicVM";
        public ICommand showPic { get; set; }
        public ICommand PicSelected { get; set; }
        public ICommand selectPic { get; set; }
        public Pic4Bord Board0 { get { return _bords[0]; } set { _bords[0] = value; } }
        public Pic4Bord Board1 { get { return _bords[1]; } set { _bords[1] = value; } }
        public Pic4Bord Board2 { get { return _bords[2]; } set { _bords[2] = value; } }
        public Pic4Bord Board3 { get { return _bords[3]; } set { _bords[3] = value; } }
        private Pic4Bord[] _bords = new Pic4Bord[4];
        public string Pic0 { get { return _pics[0].Background; } set {_pics[0].Background = value; } }
        public string Pic1 { get { return _pics[1].Background; } set {_pics[1].Background = value; } }
        public string Pic2 { get { return _pics[2].Background; } set {_pics[2].Background = value; } }
        public string Pic3 { get { return _pics[3].Background; } set { _pics[3].Background = value; } }
        private SoldierObject[] _pics = new SoldierObject[4];
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string showPicBut { get; set; }
        private string _mode = "t";
        public _4PicVM()
        {
            for (int i = 0; i < _bords.Length; i++) {
                _bords[i] = new Pic4Bord();
                _pics[i] = new SoldierObject();
            }
            showPic = new  RelayCommand(DoShowPic);
            selectPic = new  RelayCommand(DoSelectPic);
            PicSelected = new  RelayCommand(DoPicSelected);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.372;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.414;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void DoPicSelected(object obj)
        {
            if (_mode == "s")
            {
                int i = int.Parse(obj.ToString());
                _pics[i].Background = _bords[i].GetPic();
                NotifyPropertyChanged("Pic" + i);
            }
        }

        private void DoSelectPic(object obj)
        {
            int i = int.Parse(obj.ToString());
            _bords[i].selectPic();
            _pics[i].Background = String.Empty;
            NotifyPropertyChanged("Pic" + i);
        }

        private void DoShowPic(object obj)
        {
            if (_mode == "t")
            {
                int i = int.Parse(obj.ToString());
                _bords[i].ShowPic();
            }
        }
        void IPageVM.load()
        {
            _mode = Common.StaticVar.TransferVar.ToString();
            base.Settings();
            showPicBut = _mode == "s" ? "#FF41AC48" : "Transparent";
            NotifyPropertyChanged(nameof(showPicBut));
            for (int i = 0; i < _pics.Length; i++)
            {
                _bords[i].selectPic();
                _bords[i].SetMode(_mode);
                _pics[i].Background = String.Empty;
                NotifyPropertyChanged("Pic" + i);
            }
        }
    }
}
