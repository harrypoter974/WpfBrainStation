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

namespace CL.BS.NotionsVM.VM.Sentences
{
   public class BaseSentences : BaseMenuVM, IPageVM
    {
        public string BackgroundPic { get; set; }
        public bool IsBoy { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public ICommand SwitchLanguage { get; set; }
        public ICommand SwitchGender { get; set; }
        public ICommand PlaySentence { get; set; }
        private string[] _lan = new string[] { "He", "En", "Ar" };
        private bool _playRun;
        protected DateTime _startTime;
        public override string Name => "";
        public BaseSentences()
        {
            IsBoy=true; 
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject() { Background=string.Empty};
          
            SetBackground();
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            SwitchGender = new RelayCommand(DoSwitchGender);
            PlaySentence = new RelayCommand(DoPlaySentence);
        }

        void IPageVM.load()
        {
            bool f = true;
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (Common.StaticVar.inline.Languages[i] && f)
                {
                    LanguageBut[i].Background = string.Format(@"{0}Resources\Notions\Animals\AnimalStitle{1}.png",
                        System.AppDomain.CurrentDomain.BaseDirectory, i);
                    NotifyPropertyChanged("LanguageBut" + i);
                    f = false;
                }
                else if (!Common.StaticVar.inline.Languages[i])
                {
                    LanguageBut[i].Background = string.Format(@"{0}Resources\Notions\Animals\language{1}.png",
       System.AppDomain.CurrentDomain.BaseDirectory, i);
                    NotifyPropertyChanged("LanguageBut" + i);
                }
            }
            Settings();
            _startTime = DateTime.Now;
        }
      
        protected void DoSwitchLanguage(object obj)
        {
            int i = int.Parse(obj.ToString());
            if (!Common.StaticVar.inline.Languages[i])
                return;
            int is1 = 0;
            for (int j = 0; j < LanguageBut.Length; j++)
            {
                if (!string.IsNullOrEmpty(LanguageBut[j].Background))
                    if (LanguageBut[j].Background.Contains("AnimalStitle"))
                        is1++;
            }
            if (is1 == 1 && !string.IsNullOrEmpty(LanguageBut[i].Background))
                return;
            LanguageBut[i].Background = LanguageBut[i].Background != string.Empty ? string.Empty :
           string.Format(@"{0}Resources\Notions\Animals\AnimalStitle{1}.png",
           System.AppDomain.CurrentDomain.BaseDirectory, i);
            NotifyPropertyChanged("LanguageBut" + i);
            Common.StaticVar.PlayMode = false;
        }
        private void DoPlaySentence(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            new Thread(new ThreadStart(() =>
            {
                _playRun = true;
                for (int l = 0; l < LanguageBut.Length; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        string url = string.Format(@"{0}Resources\Audio\{1}\Sentences\{2}{3}.wav",
                 System.AppDomain.CurrentDomain.BaseDirectory,
                 (_lan[l]), (IsBoy ? 'M' : 'F'), obj);
                        PlayUrl(url);
                        WhitAntilPlayStop(ref _playRun);
                        //WhitTime(600, ref _playRun);
                    }
                }
                _playRun = false;
            })).Start();
        }

        private void DoSwitchGender(object obj)
        {
            IsBoy = !IsBoy;
            SetBackground();
        }


        protected virtual void SetBackground() { }
    }
}
