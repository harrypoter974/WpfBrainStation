using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MenuVM.GeneralGame
{
    public class BaseMenuHeGeneralVM : BaseMenuVM
    {
        public override string Name => "BaseMenuHeGeneralVM";
        public ICommand GoToShadow { get; set; }
        public ICommand GoToMemory { get; set; }
        public ICommand GoToBingo { get; set; }
        private string Topic;
        public BaseMenuHeGeneralVM(string topic) 
        {
            this.Topic = topic;
            GoToBingo = new RelayCommand(DoGoToBingo);
            GoToMemory = new RelayCommand(DoGoToMemory);
            GoToShadow = new RelayCommand(DoGoToShadow);
        }
   

        private void DoGoToBingo(object obj)
        {
            Common.StaticVar.BingoGroup = this.Topic;
            DoGoToPage("AnimalsBingoVM");
        }

        private void DoGoToMemory(object obj)
        {
            Common.StaticVar.BingoGroup = this.Topic;
            DoGoToPage("AnimalsMemoryVM");
        }

        private void DoGoToShadow(object obj)
        {
            Common.StaticVar.BingoGroup = this.Topic;
            DoGoToPage("ShadowGameVM");
        }
    }
}
