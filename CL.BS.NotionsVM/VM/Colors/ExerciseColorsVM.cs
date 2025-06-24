using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ExerciseColorsVM : BaseLernPage, IPageVM
    {   
        private string[,] _picList = new string[,] { 
            {"Train","Truck", "Shep", "Motorcycle" },
            { "Fish", "Crocodilia", "Horse", "Rabbit" } , 
           { "Farm", "Windmill", "Palace", "Home" } };
        private int _groupIndex = 0;
        private IColorsManager _logic = (IColorsManager)
    SupportHandlerManager.Base.GetManager("ColorsManager");
        public string BackgroundPic{get;set; }
    //    private bool _isCopy = false;
        public ICommand GoToExercise { get; set; }
        public ICommand GoToGroup { get; set; }
        public ICommand  SwitchPic{ get; set; }
        public ICommand NextGroup { get;set; }
        public ICommand ShowPic {get;set; }
        //public string PicBord { get; set; }
        public override string Name
        {
            get
            {
                return nameof(ExerciseColorsVM) ;
            }
        }

        public ExerciseColorsVM()
        {
            NextGroup = new RelayCommand(DoNextGroup);
            SwitchPic = new RelayCommand(DoSwitchPic);
            ShowPic = new RelayCommand(DoShowPic);
            GoToGroup = new RelayCommand(DoGoToGroup);
            GoToExercise = new RelayCommand(DoGoToExercise);
            AnswerBut = new RelayCommand(DoAnswerBut);
            ExitBut = new RelayCommand(DOExitBut);
        }

        private void DoAnswerBut(object obj)
        {
            base.SwitchAnswerButton();
        }
        protected void DOExitBut(object obj)
        {
            CanExit = !CanExit;
            ExitButBackground = string.Format(@"{0}Resources\BS.Items\stop{1}Icon.png",
  System.AppDomain.CurrentDomain.BaseDirectory, CanExit ? "Green" : "Red");
            NotifyPropertyChanged(nameof(ExitButBackground));
            new Thread(new ThreadStart(() =>
            {for (int i = 0; i < 1000&&CanExit; i++)
                {
                    Thread.Sleep(10);
                }
                if (CanExit)
                    DOExitBut(0);
            })).Start();
        }

        void IPageVM.load()
        {
         //   PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
         //@"Resources\Audio\He\Title\ExerciseColors.wav");
            base.Settings();          
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Notions\Colors\Pic\open.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic) );
         
            messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic) );
        }


        private void DoNextGroup(object obj)
        {
            if (!CanExit)
                return;
            if (obj.ToString() == "1" && _groupIndex < 2)
            {
                _groupIndex++;
            }
            else if (obj.ToString() == "-1" && _groupIndex > 0)
            {
                _groupIndex--;
            }

            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Colors\Pic\open" + _groupIndex + ".jpg";
            messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        private void DoGoToGroup(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.setGrope(obj);
            DoGoToPage(nameof(ColorsLearnGroupVM));
        }

        private void DoSwitchPic(object pic)
        {  
            if (Common.StaticVar.PlayMode||!CanExit)
                return;
            int ip = int.Parse(pic.ToString());
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                +@"Resources\Notions\Colors\Pic\"+_picList[_groupIndex,ip] + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Colors\Pic\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }

        private void DoShowPic(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\Pic\Board"+ _groupIndex + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        private void DoGoToExercise(object gropeIndex)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.setGrope(gropeIndex);
            DoGoToPage(nameof(ExerciseGroupColorsVM));
        }
    }
}
