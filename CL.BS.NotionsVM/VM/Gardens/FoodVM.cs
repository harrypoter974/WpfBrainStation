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

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class FoodVM : BaseItemPage, IPageVM
    {
        public override string Name =>nameof(FoodVM) ;
        private IFoodManager _logic = (IFoodManager)
SupportHandlerManager.Base.GetManager("FoodManager");
        public FoodVM()
        {
            ShowItem = new RelayCommand(DoShowShape);
        }

        void IPageVM.load()
        {
            ListWordVisible();
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, DateTime.Now,
 Name, "LERM", "", GetLanguage(), 0);
        }

        private void DoShowShape(object obj)
        {
            lock (this)
            {
                if (Common.StaticVar.PlayMode)
                    return;
                new Thread(new ThreadStart(() =>
                {
                    int shape = int.Parse(obj.ToString());
                    Items[shape].ItemsVisible = Visibility.Hidden;
                    NotifyPropertyChanged("Item" + shape);
                    for (int l = 0; l < 3; l++)
                    {
                        if (LanguageBut[l].Background.Contains("AnimalStitle"))
                        {
                            PlayUrl(_logic.PlayFood(shape, l));
                            WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                        }
                    }
                })).Start();
            }
        }
    }
}
