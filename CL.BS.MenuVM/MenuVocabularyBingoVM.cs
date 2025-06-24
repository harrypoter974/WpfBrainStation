using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuVocabularyBingoVM : BaseMenuVM, IPageVM
    {
        public ICommand GoToShadow { get; set; }
        public ICommand GoToMemory { get; set; }
        public ICommand GoToBingo { get; set; }
        public override string Name
        {
            get
            {
                return "MenuVocabularyBingoVM";
            }
        }

        public MenuVocabularyBingoVM()
        {
            GoToBingo = new RelayCommand(DoGoToBingo);
            GoToMemory= new RelayCommand(DoGoToMemory);
            GoToShadow = new RelayCommand(DoGoToShadow);
        }
        void IPageVM.load()
        {
            base.Settings();
            Common.MiceKiller.KillAllMices(true);
        }

        private void DoGoToBingo(object obj)
        {
            Common.StaticVar.BingoGroup =obj.ToString();
            DoGoToPage("AnimalsBingoVM");
        }

        private void DoGoToMemory(object obj)
        {
            Common.StaticVar.BingoGroup = obj.ToString();
            DoGoToPage("AnimalsMemoryVM");
        }

        private void DoGoToShadow(object obj)
        {
            Common.StaticVar.ShadowGroup = obj.ToString();
            DoGoToPage("ShadowExerciseVM");
        }
    }
}
