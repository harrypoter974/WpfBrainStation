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
    public class ToolsVM : BaseItemPage, IPageVM
    {
        private IToolsManager _logic = (IToolsManager)
SupportHandlerManager.Base.GetManager("ToolsManager");
        public override string Name => nameof(ToolsVM);

        public ToolsVM()
        {
            ShowItem = new RelayCommand(DoShowItem);
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
        private void DoShowItem(object obj)
        {
            lock (this)
            {
                if (Common.StaticVar.PlayMode)
                    return;
                new Thread(new ThreadStart(() =>
                {
                    int item = int.Parse(obj.ToString());
                    Items[item].ItemsVisible = Visibility.Hidden;
                    NotifyPropertyChanged("Item" + item);
                    for (int l = 0; l < 3; l++)
                    {
                        if (LanguageBut[l].Background.Contains("AnimalStitle"))
                        {
                            PlayUrl(_logic.PlayTool(item, l));
                            WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                        }
                    }
                })).Start();
            }
        }
    }
}
