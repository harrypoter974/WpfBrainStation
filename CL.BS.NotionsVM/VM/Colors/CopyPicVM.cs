using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
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
    public class CopyPicVM : BaseLernPage, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(CopyPicVM) ;
            }
        }
        private string[,] _picList = new string[,] {
            {"Train","Truck", "Shep", "Motorcycle" },
            { "Fish", "Crocodilia", "Horse", "Rabbit" } ,
           { "Farm", "Windmill", "Palace", "Home" } };
        private int _groupIndex = 0;
        private IColorsManager _logic = (IColorsManager)
    SupportHandlerManager.Base.GetManager("ColorsManager");
        public string BackgroundPic { get; set; }
        public ICommand GoToExercise { get; set; }
        public ICommand GoToGroup { get; set; }
        public ICommand SwitchPic { get; set; }
        public ICommand ShowPic { get; set; }
        public ICommand NextGroup { get; set; }
        public string PicBord { get; set; }
        public CopyPicVM()
        {

            SwitchPic = new RelayCommand(DoSwitchPic);
            ShowPic = new RelayCommand(DoShowPic);
            GoToGroup = new RelayCommand(DoGoToGroup);
            GoToExercise = new RelayCommand(DoGoToExercise);
            NextGroup = new RelayCommand(DoNextGroup);
        }

        void IPageVM.load()
        {
            //   PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            //@"Resources\Audio\He\Title\CopyPic.wav");
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Notions\Colors\Pic\open.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));

            messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }


        private void DoNextGroup(object obj)
        {
            if (obj.ToString() == "1" && _groupIndex < 2)
            {
                _groupIndex++;
            }
            else if (obj.ToString() == "-1" && _groupIndex > 0)
            {
                _groupIndex--;
            }
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Colors\Pic\Copy" + _picList[_groupIndex, 0] + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic) );
        }

        private void DoGoToGroup(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.setGrope(obj);
            DoGoToPage(nameof(ColorsLearnGroupVM) );
        }

        private void DoSwitchPic(object pic)
        {
            if (Common.StaticVar.PlayMode)
                return;
            int ip = int.Parse(pic.ToString());
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory+
             @"Resources\Notions\Colors\Pic\Copy" + _picList[_groupIndex, ip] + ".jpg";
            NotifyPropertyChanged(nameof( BackgroundPic));
            PicBord = string.Empty;
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Colors\Pic\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged( nameof (messagePic));
        }

        private void DoShowPic(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            PicBord = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\Pic\Board.jpg";
            NotifyPropertyChanged( nameof(PicBord));
        }

        private void DoGoToExercise(object gropeIndex)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.setGrope(gropeIndex);
            DoGoToPage(nameof( ExerciseGroupColorsVM));
        }
    }
}
