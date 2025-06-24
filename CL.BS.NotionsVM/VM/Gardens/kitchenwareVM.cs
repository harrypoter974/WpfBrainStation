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
    public class kitchenwareVM : BaseItemPage, IPageVM
    {
        private IkitchenwareManager _logic = (IkitchenwareManager)
SupportHandlerManager.Base.GetManager("kitchenwareManager");
        public override string Name =>nameof(kitchenwareVM) ;
        public kitchenwareVM() {
            ShowItem = new RelayCommand(DoShowkitchenware);
        }

        void IPageVM.load()
        {
            ListWordVisible();
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, DateTime.Now, 
                Name, "LERM", "", GetLanguage(),0);
        }
        private void DoShowkitchenware(object obj)
        {
            lock (this)
            {
                if (Common.StaticVar.PlayMode)
                    return;
                new Thread(new ThreadStart(() =>
                {
                    int kitchenware = int.Parse(obj.ToString());
                    Items[kitchenware].ItemsVisible = Visibility.Hidden;
                    NotifyPropertyChanged("Item" + kitchenware);
                    for (int l = 0; l < 3; l++)
                    {
                        if (LanguageBut[l].Background.Contains("AnimalStitle"))
                        {
                            PlayUrl(_logic.Playkitchenware(kitchenware, l));
                            WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                        }
                    }
                })).Start();
            }
        }
    }
}
