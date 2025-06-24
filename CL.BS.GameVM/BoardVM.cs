using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardVM : BaseLernPage, IPageVM
    {
        public override string Name =>nameof(BoardVM );
        private int _indexPic = 0;
        public ICommand SwitchBack { get; set; }
        public string BackgroundPic { get; set; }

        public BoardVM()
        {
            SwitchBack = new RelayCommand(DoSwitchBack);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Game\Board\Board18.jpg";
            NotifyPropertyChanged("BackgroundPic");
            Common.StaticVar.BoardName = "m";
        }

        private void DoSwitchBack(object obj)
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                      @"Resources\Game\Board\Board" + _indexPic + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            switch (Common.StaticVar.BoardName)
            {
                case "chess": _indexPic =  _indexPic == 8 ? 6 : _indexPic + 1; break;
                case "billiards": _indexPic = 5; break;
                case "Dominoes": _indexPic = _indexPic==2? 0: _indexPic+1; break;
                case "Consumer": _indexPic = _indexPic == 11 ?9 : _indexPic + 1;  break;
                case "Geography": _indexPic = _indexPic == 14 ?12 : _indexPic + 1;  break;
                case "m": _indexPic = _indexPic == 22 ?18 : _indexPic + 1;  break;
                default:
                    break;
            }
        }

        void IPageVM.load()
        {
            base.Settings();
            switch (Common.StaticVar.BoardName)
            {
                case "chess": _indexPic = 6; break;
                case "billiards": _indexPic = 5; break;
                case "Dominoes": _indexPic = 0; break;
                case "Consumer": _indexPic = 9; break;
                case "Geography": _indexPic = 12; break;
                case "m": _indexPic = 18; break;
                default:
                    break;
            }
            DoSwitchBack(0);
        }
    }
}
