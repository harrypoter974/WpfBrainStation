using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMemoryNumLanVM: MathMemoryNumVM, IPageVM
    {
        public override string Name =>nameof(MathMemoryNumLanVM);
        public ICommand SwitchLanguage { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public MathMemoryNumLanVM() : base()
        {

            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
        }

        private void DoSwitchLanguage(object obj)
        {
            int l = int.Parse(obj.ToString());
            Common.StaticVar.LanguageIndex = l;
            string[] lan = new string[] { "He", "En", "Ar" };
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (l == i)
                {
                    LanguageBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
                }
                else
                    LanguageBut[i].Background = string.Empty;
                NotifyPropertyChanged("LanguageBut" + i);
          base._language = lan[l];
            }

           ((IMathMemoryNumManager)Logic).SwitchLanguage(base._language);
        }
    }
}
