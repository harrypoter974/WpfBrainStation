using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MapVM : BaseLernPage, IPageVM
    {
        private IMapManager _logic = (IMapManager)
SupportHandlerManager.Base.GetManager("MapManager");
        private int _soldier = 0;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private SoldierObject[] _soldiers = new SoldierObject[4];
        public string Soldier0 { get { return _soldiers[0].Background; } set { _soldiers[0].Background = value; } }
        public string Soldier1 { get { return _soldiers[1].Background; } set { _soldiers[1].Background = value; } }
        public string Soldier2 { get { return _soldiers[2].Background; } set { _soldiers[2].Background = value; } }
        public string Soldier3 { get { return _soldiers[3].Background; } set { _soldiers[3].Background = value; } }
        public ICommand NextStep { get; set; }
        public string StepNum0 { get; set; }
        public string StepNum1 { get; set; }
        public override string Name =>nameof(MapVM) ;

        public MapVM()
        {
            NextStep = new RelayCommand(DoNextStep);
            for (int i = 0; i < _soldiers.Length; i++)
                _soldiers[i] = new SoldierObject();
        }

        private void DoNextStep(object obj)
        {         
            new Thread(new ThreadStart(() =>
            {
                int num0=0,num1=0;
                for (int i = 0; i < 10; i++)
                {
                    num0 = _ran.Next(1, 6); num1 = _ran.Next(1, 6);
                    StepNum0 = System.AppDomain.CurrentDomain.BaseDirectory +
                              @"Resources\Cube\cube" + num0 + ".png";
                    StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                           @"Resources\Cube\cube" + num1 + ".png";
                    NotifyPropertyChanged("StepNum0");
                    NotifyPropertyChanged("StepNum1");
                    Thread.Sleep(100);
                }

                NotifyPropertyChanged("StepNum0");
                NotifyPropertyChanged("StepNum1");
                _logic.SetStep(_soldier, num0+num1);
            SetSoldiers();
            _soldier = _soldier == 3 ? 0 : _soldier+1;
            })).Start();
        }
         
        void IPageVM.load()
        {
            base.Settings();
            StepNum1 = StepNum0 = System.AppDomain.CurrentDomain.BaseDirectory +
                                 @"Resources\Cube\cube6.png";
            NotifyPropertyChanged("StepNum0");
            NotifyPropertyChanged("StepNum1");
            _logic.Refresh();
            SetSoldiers();
        }

        private void SetSoldiers()
        {
            string[] Location = _logic.GetSoldiersLocation();
            for (int i = 0; i < _soldiers.Length; i++) {
                _soldiers[i].Background = Location[i];
                NotifyPropertyChanged("Soldier" + i);
            }
        }
    }
}
