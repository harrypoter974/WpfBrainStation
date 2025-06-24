using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class FamilyVM : BaseItemPage, IPageVM
    {
        private string[] _word = new string[] { "Daughter", "Grandfather",
            "Mother", "Father", "Grandmother", "Son" };
        string[] _lan = new string[] { "He", "En", "Ar" };
        public override string Name =>nameof(FamilyVM);

        public FamilyVM()
        {
            ShowItem = new RelayCommand(DoShowPerson);
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

        private void DoShowPerson(object obj)
        {
            lock (this)
            {
                if (Common.StaticVar.PlayMode)
                    return;
                new Thread(new ThreadStart(() =>
                {
                    int person = int.Parse(obj.ToString());
                    for (int l = 0; l < 3; l++)
                    {
                        if (LanguageBut[l].Background.Contains("AnimalStitle"))
                        {
                            PlayUrl(string.Format(@"{0}Resources\Audio\{1}\Family\{2}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory, _lan[l], _word[person]));
                            WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                        }
                    }
                })).Start();
            }
        }
    }
}
