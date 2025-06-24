using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.EnglishManager.Interface.Recognition;
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

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class  EnLettersKnowVM: BaseLernPage,  IPageVM
    {
        public string labeA { get { return _letterList[0].Background; } set { _letterList[0].Background = value; } }
        public string labeB { get { return _letterList[1].Background; } set { _letterList[1].Background = value; } }
        public string labeC { get { return _letterList[2].Background; } set { _letterList[2].Background = value; } }
        public string labeD { get { return _letterList[3].Background; } set { _letterList[3].Background = value; } }
        public string labeE { get { return _letterList[4].Background; } set { _letterList[4].Background = value; } }
        public string labeF { get { return _letterList[5].Background; } set { _letterList[5].Background = value; } }
        public string labeG { get { return _letterList[6].Background; } set { _letterList[6].Background = value; } }
        public string labeH { get { return _letterList[7].Background; } set { _letterList[7].Background = value; } }
        public string labeI { get { return _letterList[8].Background; } set { _letterList[8].Background = value; } }
        public string labeJ { get { return _letterList[9].Background; } set { _letterList[9].Background = value; } }
        public string labeK { get { return _letterList[10].Background; } set { _letterList[10].Background = value; } }
        public string labeL { get { return _letterList[11].Background; } set { _letterList[11].Background = value; } }
        public string labeM { get { return _letterList[12].Background; } set { _letterList[12].Background = value; } }
        public string labeN { get { return _letterList[13].Background; } set { _letterList[13].Background = value; } }
        public string labeO { get { return _letterList[14].Background; } set { _letterList[14].Background = value; } }
        public string labeP { get { return _letterList[15].Background; } set { _letterList[15].Background = value; } }
        public string labeQ { get { return _letterList[16].Background; } set { _letterList[16].Background = value; } }
        public string labeR { get { return _letterList[17].Background; } set { _letterList[17].Background = value; } }
        public string labeS { get { return _letterList[18].Background; } set { _letterList[18].Background = value; } }
        public string labeT { get { return _letterList[19].Background; } set { _letterList[19].Background = value; } }
        public string labeU { get { return _letterList[20].Background; } set { _letterList[20].Background = value; } }
        public string labeV { get { return _letterList[21].Background; } set { _letterList[21].Background = value; } }
        public string labeW { get { return _letterList[22].Background; } set { _letterList[22].Background = value; } }
        public string labeX { get { return _letterList[23].Background; } set { _letterList[23].Background = value; } }
        public string labeY { get { return _letterList[24].Background; } set { _letterList[24].Background = value; } }
        public string labeZ { get { return _letterList[25].Background; } set { _letterList[25].Background = value; } }
        protected LetterObject[] _letterList = new LetterObject[26];
        private bool _playRun = false,_playList=false;
        private char _preLetter = '0';
        public ICommand PlayLetter { get; set; }
        public ICommand PlayAllLetter { get; set; }
        public ICommand StopPlayAllLetter { get; set; }
        public string PlayAllNumBut { get; set; }
        public string StopPlayAllNumBut { get; set; }
        public override string Name
        {
            get
            {
                return nameof(EnLettersKnowVM);
            }
        }
        private IEnLettersKnowManager _logic = (IEnLettersKnowManager)
        SupportHandlerManager.Base.GetManager("EnLettersKnowManager");

        public EnLettersKnowVM()
        {
            PlayLetter = new RelayCommand(DoPlayLetter);
            char c = 'A';
            for (int i = 0; i < _letterList.Length; i++,c++)
                _letterList[i] = new LetterObject() { Uid = c.ToString() };
            PlayAllLetter = new RelayCommand(DoPlayAllLetter);
            StopPlayAllLetter = new RelayCommand(DoStopPlayAllLetter);
        }

        private void DoStopPlayAllLetter(object obj)
        {
            _playRun = false;
            PlayAllNumBut = string.Empty;
            StopPlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\PlayLetter.png";
            NotifyPropertyChanged(nameof(PlayAllNumBut));
            NotifyPropertyChanged(nameof(StopPlayAllNumBut));
        }
        private void DoPlayAllLetter(object obj)
        {
            _playRun =true;
            if (Common.StaticVar.PlayMode|| _playList)
                return;
   
            PlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Lang\PlayLetters.png";
            StopPlayAllNumBut = string.Empty;
            NotifyPropertyChanged(nameof(PlayAllNumBut));
            NotifyPropertyChanged(nameof(StopPlayAllNumBut));
            if (_preLetter != '0')
            {
                int j = GetIndex(_preLetter);
                _letterList[j].Background = string.Empty;
                NotifyPropertyChanged("labe" + _letterList[j].Uid);
            }
            new Thread(new ThreadStart(() =>
            {
                _playList = true;
                for (int i = 0; i < _letterList.Length&& _playRun; i++)
                {
                    _letterList[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
       @"Resources\Lang\En\Letters\" + _letterList[i].Uid + ".jpg";
                    NotifyPropertyChanged("labe" + _letterList[i].Uid);
                    UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory +
                  @"Resources\Audio\En\Letters\" + _letterList[i].Uid + ".wav";
                    if (_playRun)
                    {
                      
                        WhitTime(1900, ref _playRun);
                        _letterList[i].Background = string.Empty;
                        NotifyPropertyChanged("labe" + _letterList[i].Uid);                        
                    }
                }
                PlayAllNumBut = string.Empty;
                StopPlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Lang\PlayLetter.png";
                NotifyPropertyChanged(nameof(PlayAllNumBut));
                NotifyPropertyChanged(nameof(StopPlayAllNumBut));
                _playList = false;
            })).Start();
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Letters\messageLetter.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic)); 
            _playList = false;
            _startTime=DateTime.Now;
        }
           
        private void DoPlayLetter(object letter)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (_preLetter != '0')
            {
                int j = GetIndex(_preLetter);
                _letterList[j].Background = string.Empty;
                NotifyPropertyChanged("labe" + _letterList[j].Uid);
            }
            _preLetter = letter.ToString().ToUpper()[0];
            int i = GetIndex(_preLetter);
            _letterList[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\Letters\" + letter + ".jpg";
            NotifyPropertyChanged("labe" + _letterList[i].Uid);
            PlayUrl( System.AppDomain.CurrentDomain.BaseDirectory + 
                @"Resources\Audio\En\Letters\" + letter + ".wav");
            _logic.SetLetter(letter);
        }

        private int GetIndex(char l)
        {
            for (int i = 0; i < _letterList.Length; i++)
            {
                if (_letterList[i].Uid[0] == l)
                    return i;
            }
            return -1;   
        }

        void IPageVM.disload()
        {
            DoStopPlayAllLetter(0);
            DatabaseManager.Inline.SaveActivity(4, _startTime, DateTime.Now,
           Name, "LERM", "", "E", 0);
        }
    }
}
