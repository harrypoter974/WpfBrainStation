using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeReadingSyllablesVM : BaseLernPage, IPageVM
    {
        public string Label0 { get { return LetterList[0].Background; } set { LetterList[0].Background = value; } }
        public string Label1 { get { return LetterList[1].Background; } set { LetterList[1].Background = value; } }
        public string Label2 { get { return LetterList[2].Background; } set { LetterList[2].Background = value; } }
        public string Label3 { get { return LetterList[3].Background; } set { LetterList[3].Background = value; } }
        public string Label4 { get { return LetterList[4].Background; } set { LetterList[4].Background = value; } }
        public string Label5 { get { return LetterList[5].Background; } set { LetterList[5].Background = value; } }
        public string Label6 { get { return LetterList[6].Background; } set { LetterList[6].Background = value; } }
        public string Label7 { get { return LetterList[7].Background; } set { LetterList[7].Background = value; } }
        public string Label8 { get { return LetterList[8].Background; } set { LetterList[8].Background = value; } }
        public string Label9 { get { return LetterList[9].Background; } set { LetterList[9].Background = value; } }
        public string Label10 { get { return LetterList[10].Background; } set { LetterList[10].Background = value; } }
        public string Label11 { get { return LetterList[11].Background; } set { LetterList[11].Background = value; } }
        public string Label12 { get { return LetterList[12].Background; } set { LetterList[12].Background = value; } }
        public string Label13 { get { return LetterList[13].Background; } set { LetterList[13].Background = value; } }
        public string Label14 { get { return LetterList[14].Background; } set { LetterList[14].Background = value; } }
        public string Label15 { get { return LetterList[15].Background; } set { LetterList[15].Background = value; } }
        public string Label16 { get { return LetterList[16].Background; } set { LetterList[16].Background = value; } }
        public string Label17 { get { return LetterList[17].Background; } set { LetterList[17].Background = value; } }
        public string Label18 { get { return LetterList[18].Background; } set { LetterList[18].Background = value; } }
        public string Label19 { get { return LetterList[19].Background; } set { LetterList[19].Background = value; } }
        public string Label20 { get { return LetterList[20].Background; } set { LetterList[20].Background = value; } }
        public string Label21 { get { return LetterList[21].Background; } set { LetterList[21].Background = value; } }
        public string Label22 { get { return LetterList[22].Background; } set { LetterList[22].Background = value; } }
        public string Label23 { get { return LetterList[23].Background; } set { LetterList[23].Background = value; } }
        public string Label24 { get { return LetterList[24].Background; } set { LetterList[24].Background = value; } }
        public string Label25 { get { return LetterList[25].Background; } set { LetterList[25].Background = value; } }
        protected LetterObject[] LetterList = new LetterObject[26];
        public string BackgroundPic { get; set; }
        public ICommand PleyLetter { get; set; }
        public ICommand SwitchNikod { get; set; }
        public ICommand PlayAllLetter { get; set; }
        public ICommand StopPlayAllLetter { get; set; }
        public string PlayAllNumBut { get; set; }
        public string StopPlayAllNumBut { get; set; }
        private bool _playRun = false;
        private int _nikodIndex = 0, LeterIndex = 0;
        private int[] _aodioNikodIndex = { 0, 1, 1, 2, 2, 3, 4, 4, 5, 5 };
        private string[] _nikodAudio = new string[]
        {"Kamatz","Patach", "Tzere", "Segol", "Hiriq", "Holam", "full_Holam", "Kubutz", "shuruk" };
        public override string Name
        {
            get
            {
                return "HeReadingSyllablesVM";
            }
        }

        public HeReadingSyllablesVM()
        {
            SwitchNikod = new RelayCommand(DoSwitchNikod);
            PleyLetter = new RelayCommand(DoPleyLetter);
            PlayAllLetter = new RelayCommand(DoPlayAllLetter);
            StopPlayAllLetter = new RelayCommand(DoStopPlayAllLetter);
            for (int i = 0; i < LetterList.Length; i++)
                LetterList[i] = new LetterObject();
        }

        private void DoStopPlayAllLetter(object obj)
        {
            _playRun = false;
            PlayAllNumBut = string.Empty;
            StopPlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\PlayLetter.png";
            NotifyPropertyChanged("PlayAllNumBut");
            NotifyPropertyChanged("StopPlayAllNumBut");
        }

        void IPageVM.disload()
        {
            DoStopPlayAllLetter(0);
        }

        private void DoPlayAllLetter(object obj)
        {
            _playRun = true;
            if (Common.StaticVar.PlayMode)
                return;
            LetterList[LeterIndex].Background = string.Empty;
            NotifyPropertyChanged("Label" + LeterIndex);
            PlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Lang\PlayLetters.png";
            StopPlayAllNumBut = string.Empty;
            NotifyPropertyChanged("PlayAllNumBut");
            NotifyPropertyChanged("StopPlayAllNumBut");
            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < Common.StaticVar.HeLetersList.Length && _playRun; i++)
                {
                    if (_playRun)
                    {
                        LetterList[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Lang\He\Niqqud\" + Common.StaticVar.HeLetersList[i]+ _nikodIndex + ".jpg";
                        NotifyPropertyChanged("Label" + i);
                        if (_nikodIndex == 0)
                          UrlPlay=System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Letters\" + Common.StaticVar.HeLetersList[i].ToString().Trim() + ".wav";
                        else
                            UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Letters\" + Common.StaticVar.HeLetersList[i] + (_aodioNikodIndex[_nikodIndex]) + ".wav";
                          WhitTime(1500, ref _playRun);
                        LetterList[i].Background = string.Empty;
                        NotifyPropertyChanged("Label" + (i));                      
                    }
                }
                PlayAllNumBut = string.Empty;
                StopPlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Lang\PlayLetter.png";
                NotifyPropertyChanged("PlayAllNumBut");
                NotifyPropertyChanged("StopPlayAllNumBut");
            })).Start();
        }

        private void DoPleyLetter(object letter)
        {
            LetterList[LeterIndex].Background =string.Empty;
            NotifyPropertyChanged("Label" + LeterIndex);
            LeterIndex = Common.StaticVar.GetIndexHeLetersList(letter);
            LetterList[LeterIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Lang\He\Niqqud\" + letter + _nikodIndex + ".jpg";
            NotifyPropertyChanged("Label" + LeterIndex);
            if (_nikodIndex == 0)
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Letters\" + letter.ToString().Trim() + ".wav");
            else
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Letters\" + letter + (_aodioNikodIndex[_nikodIndex]) + ".wav");

        }

        private void DoSwitchNikod(object index)
        {
            _nikodIndex = int.Parse(index.ToString());
            SetBackground();
        }
   
        void IPageVM.load()
        {
            base.Settings();
            _nikodIndex = 0;
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Niqqud\SyllablesMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            SetBackground();
        }

        private void SetBackground()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                          + @"Resources\Lang\He\Niqqud\reading"+ _nikodIndex+".jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (_nikodIndex > 0) {
                new Thread(new ThreadStart(() =>
                {
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Letters\"
+ _nikodAudio[_nikodIndex - 1] + ".wav");
                })).Start();            
            }
        }
    }
}
