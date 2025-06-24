using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General.Prepositions
{
  public  class BoardPrepositionsVM : BaseLernPage, IPageVM
    {
        public override string Name => throw new NotImplementedException();
        protected IMiceManager MiceLogic;
        public ICommand TapAnswer { get; set; }
        public string AnswerIndex, MiceName="A";
        public BoardPrepositionsVM()
        {
            TapAnswer = new RelayCommand(DoTapAnswer);
        }
        private void DoTapAnswer(object obj)
        {
            if (MiceLogic.GetType() == typeof(VMCommon.Mice.TouchManager) ||
                MiceLogic.GetMouseRotation() == MiceName)
            {
                AnswerIndex = obj.ToString();
            }
        }

        internal void SetMiceName(string miceName)
        {
            this.MiceName = miceName;
        }

        internal void SetMice(IMiceManager miceLogic)
        {
            this.MiceLogic = miceLogic;
        }
    }
}
