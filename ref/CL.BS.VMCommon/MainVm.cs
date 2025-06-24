
using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.VMCommon
{
    public class MainVm : INotifyPropertyChanged
    {
        public MainVm()
        {
            _pageManger = new SportHandler();
            InitCurStep();
        }

        public void InitCurStep()
        {
            CurStep = _pageManger.GetGame(SportHandler.HOME_PAGE);
            // ;objectType
            // CurStep.Tick += CurStep_PropertyChanged;
            BaseStepVM bs = (BaseStepVM)CurStep;
            bs.GoHome = ChangedPage;
            //CurStep.GoToAction = ChangedPage;
        }

        private void ChangedPage(IPageVM page, string name= "MenuOpenVM")
        {
            CurStep.disload();
            CurStep = _pageManger.GetGame(name);
            CurStep.load();
            BaseStepVM bs = (BaseStepVM)CurStep;
            bs.GoHome = ChangedPage;
            //CurStep.GoToAction = ChangedPage;
            NotifyPropertyChanged("CurStep");
        }
        private SportHandler _pageManger;

        private IPageVM _curStep;
        public IPageVM CurStep
        {
            set
            {
                if (value != null)
                {
                    _curStep = value;
                    NotifyPropertyChanged("CurStep");
                }
            }
            get { return _curStep; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string Obj)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Obj));
            }
        }
    }
}
