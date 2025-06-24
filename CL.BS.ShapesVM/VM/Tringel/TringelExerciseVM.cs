using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Tringel
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TringelExerciseVM : BaseShapesVM, IPageVM
    {
        public ICommand ChangLevel { get; set; }
        public string BackgroundPic  { get ;set; }
        private ITringelManager _logic = (ITringelManager)
SupportHandlerManager.Base.GetManager("TringelManager");
        private int _tringelIndex = 0;
        private bool _isLevel1 = true;
        public override string Name
        {
            get
            {
                return "TringelExerciseVM";
            }
        }

        public TringelExerciseVM() {
      
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangLevel = new RelayCommand(DoChangLevel);
        }

        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Tringel\open1.jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (Common.StaticVar.inline.IsBoy)
            {
                messagePic = string.Empty;
                NotifyPropertyChanged("messagePic");
            }
        }

        private void DoChangLevel(object level)
        {
            if (Common.StaticVar.PlayMode)
                return;
            BackgroundShapes = "Transparent";
            NotifyPropertyChanged("BackgroundShapes");
            _isLevel1 = !_isLevel1;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Tringel\Tringel" + (_isLevel1 ? 'A' : 'B') + "Q" + _tringelIndex + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }
      
        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            BackgroundShapes = "Transparent";
            NotifyPropertyChanged("BackgroundShapes");
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Tringel\Tringel" + (_isLevel1 ? 'A' : 'B') + "Q" + _tringelIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                new Thread(new ThreadStart(() =>
                { 
                PlayList(_logic.GetPlayList('a', _tringelIndex));
                })).Start();
                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Shapes\Tringel\m" + _tringelIndex + ".png";
                    NotifyPropertyChanged("messagePic");
                }
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Tringel\Tringel" + (_isLevel1 ? 'A' : 'B') + "A" + _tringelIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                _tringelIndex = _tringelIndex < 2 ? _tringelIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}

