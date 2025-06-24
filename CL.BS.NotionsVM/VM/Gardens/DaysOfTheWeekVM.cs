using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class DaysOfTheWeekVM : BaseItemPage, IPageVM
    {
        public override string Name =>nameof(DaysOfTheWeekVM) ;
        private IDaysOfTheWeekManager _logic = (IDaysOfTheWeekManager)
SupportHandlerManager.Base.GetManager("DaysOfTheWeekManager");

        public DaysOfTheWeekVM()
        {
            ShowItem = new RelayCommand(DoShowDay);
        }

        void IPageVM.load()
        {
            ListWordVisible();
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, DateTime.Now,
                Name, "LERM", "", GetLanguage(), 0); ;
        }
        private void DoShowDay(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            new Thread(new ThreadStart(() =>
            {
                int day = int.Parse(obj.ToString());
                Items[day].ItemsVisible = Visibility.Hidden;
                NotifyPropertyChanged("Item" + day);
                for (int l = 0; l < 3; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        PlayUrl(_logic.PlayDay(day, l));
                        WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                    }
                }
            })).Start();
        }
    }
}
