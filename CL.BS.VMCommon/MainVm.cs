
using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public class MainVm : INotifyPropertyChanged
    {
        /// <summary>
        /// Like its name this class contain's all the VM classes 
        ///  responsible for switching pages
        /// and is responsible for control on the main window from the VM.
        /// </summary>

        private GameHandler _pageManger;
        private Stack<string> _prePageName = new Stack<string>();
        private IPageVM _curStep;
        public ICommand GoBack { get; set; }
        public event EventHandler CloseWin;
        public event EventHandler StraightWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainVm()
        {
            
             _pageManger = GameHandler.GetIntense();
            CL.BS.Common.GlobalLog.Write("Close WindowBase" + DateTime.Now);
            GoBack = new RelayCommand(DoGoBack);
        }

        private void DoGoBack(object obj)
        {//not in use 
            if (_prePageName.Count() == 0)
                return;
            CurStep.disload();
            CurStep = _pageManger.GetGame(_prePageName.Pop());
            CurStep.load();
            if (CurStep is BasePageVM)
            {
                BasePageVM bs = (BasePageVM)CurStep;
                bs.GoHome = ChangedPage;
            }
            NotifyPropertyChanged("CurStep");
        }

        public void InitCurStep()
        {//Set open page in the opening page.
            CurStep = _pageManger.GetGame(GameHandler.HOME_PAGE);
            BasePageVM bs = (BasePageVM)CurStep;
            CL.BS.Common.GlobalLog.Write("Open WindowBase" + DateTime.Now);
            _pageManger.WreteClassCaunt();
            bs.GoHome = ChangedPage;
            CL.BS.Common.GlobalLog.Write("sacsess WindowBase" + DateTime.Now);
        }

        private void ChangedPage(IPageVM page, string name = "MenuOpenVM")
        {//Go to another page
            if (Common.StaticVar.inline.LimitingPages.Contains(name))
                return;
            if ("Error" == name)
                MessageBox.Show("סליחה החלון בבניה", "חלון בבניה", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if ("Restart" == name)
            {
                //System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "WpfBrainStation.exe");
                CloseWin(null, null);
            }
            else if ("RefreshWin" == name) 
                StraightWindow(null, null);
            CurStep.disload();
            if (!string.IsNullOrEmpty(Common.StaticVar.PageKyeName))
                if(CurStep.Name.Contains("Menu"))
                    if ((!name.Contains("Menu") )&& name != Common.StaticVar.PageKyeName)
                        return;
            if (name != CurStep.Name)
                _prePageName.Push(CurStep.Name);
            CurStep = _pageManger.GetGame(name);
            CurStep.load();
            if (CurStep is BasePageVM)
            {
                BasePageVM bs = (BasePageVM)CurStep;
                bs.GoHome = ChangedPage;
            }
            NotifyPropertyChanged("CurStep");
            //if (CurStep is BaseAutoGameVM)
            //    ((BaseAutoGameVM)(CurStep)).MoveCursor();
        }

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

        protected void NotifyPropertyChanged(string Obj)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Obj));
            }
        }     
    }
}
