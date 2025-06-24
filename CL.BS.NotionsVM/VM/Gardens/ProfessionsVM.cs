using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System.Threading;
using System.Windows;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ProfessionsVM : BaseItemPage, IPageVM
    {
        private IProfessionsManager _logic = (IProfessionsManager)
 SupportHandlerManager.Base.GetManager("ProfessionsManager");
        public override string Name =>nameof(ProfessionsVM) ;

        public ProfessionsVM()
        {
            ShowItem = new RelayCommand(DoShowShape);
        }

        void IPageVM.load()
        {
            ListWordVisible();
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, System.DateTime.Now,
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
                            PlayUrl(_logic.PlayProfession(shape, l));
                            WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                            WhitTime(500, ref Common.StaticVar.PlayMode);
                        }
                    }
                })).Start();
            }
        }
    }
}
