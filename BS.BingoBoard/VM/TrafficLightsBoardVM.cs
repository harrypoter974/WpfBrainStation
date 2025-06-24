using CL.BS.Model;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace BS.BingoBoard.VM
{
    public class TrafficLightsBoardVM: INotifyPropertyChanged
    {
        public string TBSoldier0 { get { return SoldierList[0].Background; } set { SoldierList[0].Background = value; } }
        public string TBSoldier1 { get { return SoldierList[1].Background; } set { SoldierList[1].Background = value; } }
        public string TBSoldier2 { get { return SoldierList[2].Background; } set { SoldierList[2].Background = value; } }
        public string TBSoldier3 { get { return SoldierList[3].Background; } set { SoldierList[3].Background = value; } }
        public string TBSoldier4 { get { return SoldierList[4].Background; } set { SoldierList[4].Background = value; } }
        protected SoldierObject[] SoldierList = new SoldierObject[5];
        public string BackgroundBoard { get; set; } 
        public string BaseWinBlink { get; set; }
        private int NumFoStep = 4, Index = 0, SoldierPosition=0;
        private string Rotation;
         public TrafficLightsBoardVM(int index, int numFoStep,string rotation)
        {
            this.Index = index;
            this.NumFoStep = numFoStep;
            this.Rotation = rotation;
            BackgroundBoard = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Board\LightsRed" + NumFoStep + ".png";
            NotifyPropertyChanged("BackgroundBoard");
            for (int i = 0; i < SoldierList.Length; i++)
                SoldierList[i] = new SoldierObject();
            BaseWinBlink = "Hidden";
            NotifyPropertyChanged("BaseWinBlink");
        }

        public void SetBoardPic(int CarentIndex)
        {
            BackgroundBoard = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Board\Lights"+(CarentIndex==Index? "Green" : "Red") + NumFoStep + ".png";
            NotifyPropertyChanged("BackgroundBoard");
        }

        public bool SetSoldierPosition(bool ToUper)
        {//He bring's the soldier up if he win's the game and in the new square he starts a new game.
            SoldierPosition = !ToUper ? 0 :
           SoldierList.Length - 1 == SoldierPosition ? NumFoStep - 1 : SoldierPosition + 1;
            for (int i = 0; i < NumFoStep; i++)
            {
                if (i == SoldierPosition)
                {
                    SoldierList[i].Background =
                    System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Pion\" + Rotation + ".png";
                }
                else
                {
                    SoldierList[i].Background = string.Empty;
                }
                NotifyPropertyChanged("TBSoldier" + i);
            }
            return SoldierPosition == NumFoStep;
        }

        public  void GameWin()
        {
            SoldierList[NumFoStep].Background =
                   System.AppDomain.CurrentDomain.BaseDirectory +
                  @"Resources\Pion\" + Rotation + ".png";

            NotifyPropertyChanged("TBSoldier" + (NumFoStep));
            BaseWinBlink = "Visible";
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(2000 );
            BaseWinBlink = "Hidden";
            NotifyPropertyChanged("BaseWinBlink");
            SoldierList[NumFoStep].Background =string.Empty;
            NotifyPropertyChanged("TBSoldier" + (NumFoStep));
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;


        protected void NotifyPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged(int propertyValue)
        {
            VerifyPropertyName(propertyValue);
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyValue.ToString()));
        }


        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(int propertyValue)
        {
            if (TypeDescriptor.GetProperties(this)[propertyValue] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyValue);
        }
        #endregion
    }
}
