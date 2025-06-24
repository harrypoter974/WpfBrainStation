using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Notions;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuEnGeneralVM : BaseMenuVM,  IPageVM
    {
        private object _page;
        public ICommand OpenGeneralPage { get; set; }
        public override string Name
        {
            get
            {
                return "MenuEnGeneralVM";
            }
        }

        public MenuEnGeneralVM()
        {
            OpenGeneralPage = new RelayCommand(DoOpenGeneralPage);
            StopPlay = new RelayCommand(DoStopPlay);
            Pages = new string[] { "EnPrepositionsMenu", "EnOppositesMenuVM"
,"EnColorVM","EnAnimalsVM","EnCalendarVM","EnDaysOfTheWeekVM"
,"EnNumbersVM","EnClockVM","EnFamilyVM" };
        }

        private void DoStopPlay(object obj)
        {
            DoGoToPage(_page);
            DoGoToPage(_page);
        }

        private void DoOpenGeneralPage(object obj)
        {
            switch (obj.ToString())
            {
                case "EnFamilyVM":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
          @"Resources\Audio\En\Family\Family.wav");
                    break;
                case "EnClockVM":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory 
                        + @"Resources\Audio\En\Clock\Clock.wav");
                    break;
                case "EnNumbersVM":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Audio\En\Numbers\Numbers.wav");
                    break;
                case "EnDaysOfTheWeekVM":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Audio\En\DayOfTheWeek\DayOfTheWeek.wav");
                    break;
                case "EnCalendarVM":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Audio\En\Seasons\Seasons.wav");
                    break;
                case "EnAnimalsVM":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\En\Animals\Animals.wav");
                    break;
                case "EnColorVM":
                    IEnColorManager logic = (IEnColorManager)
            SupportHandlerManager.Base.GetManager("EnColorManager");
                    logic.SetColorIndex(0);
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\En\Colors\Colors.wav");
                    break;
                case "EnOppositesMenuVM":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Audio\En\Opposites\Opposites.wav");
                    break;
                case "EnPrepositionsMenu":
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Audio\En\Prepositions\Prepositions.wav");
                    break;
                default:
                    break;
            }
            _page= obj;

        }
    }
}
