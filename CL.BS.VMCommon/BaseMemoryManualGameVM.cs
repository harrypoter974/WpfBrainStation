using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public class BaseMemoryManualGameVM : BaseManualGame
    {   /// <summary>
        /// Not in use 
        /// BaseMemoryManualGameVM is in the game with 1 mouse.
        /// </summary>

        public override string Name => "";
        public ICommand SetLettersNum { get; set; }
        public string GameBackground { get; set; }
        public string NumLetterBut0 { get { return NumLetterBut[0].Background; } set { NumLetterBut[0].Background = value; } }
        public string NumLetterBut1 { get { return NumLetterBut[1].Background; } set { NumLetterBut[1].Background = value; } }
        public string NumLetterBut2 { get { return NumLetterBut[2].Background; } set { NumLetterBut[2].Background = value; } }
        protected SoldierObject[] NumLetterBut = new SoldierObject[3];
        protected string[] NumLetterLimit;
        protected int LimitIndex = 0;

        public BaseMemoryManualGameVM()
        {
            for (int i = 0; i < NumLetterBut.Length; i++)
                NumLetterBut[i] = new SoldierObject();
            SetLettersNum = new RelayCommand(DoSetLettersNum);
        }

        protected void DoSetLettersNum(object obj)
        {
            NumLetterBut[LimitIndex].Background = string.Empty;
            NotifyPropertyChanged("NumLetterBut" + LimitIndex);
            LimitIndex = int.Parse(obj.ToString());
            NumLetterBut[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\Number\" + NumLetterLimit[LimitIndex] + "b.png";
            NotifyPropertyChanged("NumLetterBut" + LimitIndex);
        }

        public int GetNumLetterLimit()
        {
            return int.Parse(NumLetterLimit[LimitIndex]);
        }
    }
}
