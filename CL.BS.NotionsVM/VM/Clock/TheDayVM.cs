using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TheDayVM : BaseItemPage, IPageVM
    {
        public override string Name => nameof(TheDayVM);
        string[] _lan = new string[] { "He\\time", "En\\TheDay", "Ar\\time" };

        public TheDayVM()
        {
          ShowItem = new RelayCommand(DoPlayDayPart);
        }

        void IPageVM.load()
        {
            ListWordVisible();
            if (!Common.StaticVar.inline.IsBoy)
                messagePic = "Visible";
            else
                messagePic = "Hidden";
            NotifyPropertyChanged(nameof(messagePic));
        }
        void IPageVM.disload()
        {
         Database.DatabaseManager.Inline.SaveActivity(4,_startTime,
             DateTime.Now, Name, "LERM", "", GetLanguage(),0);
        }
        private void DoPlayDayPart(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            new Thread(new ThreadStart(() =>
            {
                for (int l = 0; l < LanguageBut.Length; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        PlayUrl(string.Format(@"{0}Resources\Audio\{1}\{2}.wav",
   System.AppDomain.CurrentDomain.BaseDirectory, _lan[l], obj));
                        WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                    }
                }
            })).Start();
 
        }
    }
}
