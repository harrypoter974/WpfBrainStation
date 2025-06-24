using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class NumberStructureLernVM : BaseLernPage, IPageVM
    {
        public ICommand GoToExercise { get; set; }
        public ICommand SwitchGroup { get; set; }
        public ICommand SwitchNum { get; set; }
        public string BackgroundPic { get; set; }
        private INumberStructureLernManager _logic = (INumberStructureLernManager)
SupportHandlerManager.Base.GetManager("NumberStructureLernManager");
        public override string Name => "NumberStructureLernVM";

        void IPageVM.disload()
        {
            _logic.disload();
        }

        void IPageVM.load()
        {
            UrlPlay = string.Empty;
            _logic.SetGroup(1);
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\NumberStructure\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            SetBackground();
            new Thread(new ThreadStart(() =>
            {
                PlayList(new string[] {Common.StaticVar.inline.PlayName(),
(Common.StaticVar.inline.IsBoy ?@"Resources\Audio\He\Sentences\A19.wav":@"Resources\Audio\He\Sentences\A20.wav") });
            })).Start();
        }

        public NumberStructureLernVM()
        {
            SwitchGroup =new  RelayCommand(DoSwitchGroup);
            SwitchNum = new RelayCommand(DoSwitchNum);
            GoToExercise = new RelayCommand(DoGoToExercise);
        }

        private void DoGoToExercise(object obj)
        {
            DoGoToPage("NumberStructureExerciseVM");
        }

        private void DoSwitchGroup(object obj)
        {
            _logic.SetGroup(obj);
            SetBackground();
        }

        private void DoSwitchNum(object obj)
        {
            _logic.SetNum(obj);
            SetBackground();
        }
        
        private void SetBackground()
        {
                BackgroundPic =
                    System.AppDomain.CurrentDomain.BaseDirectory
                    + _logic.GetBackground();
                NotifyPropertyChanged("BackgroundPic");
           
        }
    }
}
