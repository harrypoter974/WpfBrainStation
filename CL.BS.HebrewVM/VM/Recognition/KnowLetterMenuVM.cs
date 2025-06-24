using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class KnowLetterMenuVM : BaseLernPage, IPageVM
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
        public string Label26 { get { return LetterList[26].Background; } set { LetterList[26].Background = value; } }
        protected LetterObject[] LetterList = new LetterObject[27];
        private string[] _heLeters = new string[] { "alef","Bet", "Gimel", "Dalet", "He", "Waw", "Zayin", "Heth", "Teth", "Yodh"
        ,"Kaph","KaphFinal","Lamedh","Mem","MemFinal","Nun","NunFinal","Samekh","Ayin","Pe","PeFinal","Tsade","TsadeFinal","Qoph","Resh","Shin","Taw"};
        private bool _playRun = false;
        private int _labelIndex = 0;
        public string BackgroundPic { get; set; }
        public string PlayAllNumBut { get; set; }
        public string StopPlayAllNumBut { get; set; }
        public string NamePic { get; set; }
        public ICommand SetBackground { get; set; }
        public ICommand PlayLetter { get; set; }
        public ICommand PlayAllLetter { get; set; }
        public ICommand StopPlayAllLetter { get; set; }
        IKnowLetterManager logic = (IKnowLetterManager)
SupportHandlerManager.Base.GetManager("KnowLetterManager");
        public override string Name
        {
            get
            {
                return "KnowLetterMenuVM";
            }
        }

        public KnowLetterMenuVM()
        {
            PlayLetter = new RelayCommand(DoPleyLetter);
            SetBackground = new RelayCommand(DoSetBackground);
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

        private void DoPlayAllLetter(object obj)
        {
            if (Common.StaticVar.PlayMode|| _playRun)
                return;
            _playRun = true;
            LetterList[_labelIndex].Background = string.Empty;
            NotifyPropertyChanged("Label" + _labelIndex);
            PlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Lang\PlayLetters.png";
            StopPlayAllNumBut = string.Empty;
            NotifyPropertyChanged("PlayAllNumBut");
            NotifyPropertyChanged("StopPlayAllNumBut");
            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < _heLeters.Length && _playRun; i++)
                {

                    LetterList[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
       @"Resources\Lang\He\Letters\" + (Common.StaticVar.inline.IsCard ? 'H' : 'R') + _heLeters[i] + ".jpg";
                    NotifyPropertyChanged("Label" + i);
                    UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory +
       @"Resources\Audio\He\Letters\" + _heLeters[i] + ".wav";
                    if (_playRun)
                    {
                        WhitTime(2100, ref _playRun);
                        LetterList[i].Background = string.Empty;
                        NotifyPropertyChanged("Label" + (i));
                    }
                }
                PlayAllNumBut = string.Empty;
                StopPlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Lang\PlayLetter.png";
                NotifyPropertyChanged("PlayAllNumBut");
                NotifyPropertyChanged("StopPlayAllNumBut");
                _playRun = false;
            })).Start();
        }
       
        void IPageVM.load()
        {
            base.Settings();
            if (Common.StaticVar.inline.IsBoy)
            {
                NamePic =System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Writing\WriteNameBoy.png" ;
                messagePic = string.Empty;
            }
            else  { messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Letters\messageLetter.png";
                NamePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Writing\WriteNameGirl.png";
               
            }
            NotifyPropertyChanged("messagePic");
            NotifyPropertyChanged("NamePic");
            DoSetBackground("Reporter");
            _playRun = false;
        }

        void IPageVM.disload()
        {
            DoStopPlayAllLetter(0);
        }

        private void DoPleyLetter(object obj)
        {
            if (_playRun)
                return;
            LetterList[_labelIndex].Background = string.Empty;
            NotifyPropertyChanged("Label" + _labelIndex);
            logic.SetLetter(obj);
            UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Audio\He\Letters\" + obj + ".wav";
            string num = obj.ToString();
            for (int i = 0; i < _heLeters.Length; i++)
            {
                if (_heLeters[i] == num)
                    _labelIndex = i;
            }
            LetterList[_labelIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Lang\He\Letters\" + (Common.StaticVar.inline.IsCard ? 'H' : 'R') + _heLeters[_labelIndex] + ".jpg";
            NotifyPropertyChanged("Label" + _labelIndex);
        }

        private void DoSetBackground(object obj)
        {
            Common.StaticVar.inline.IsCard= "Handwriting" == obj.ToString();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\He\Letters\" + obj+ ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
    }
}
