using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Animals
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AnimalsLanguagesVM : BaseLernPage, IPageVM
    {
        public override string Name => "AnimalsLanguagesVM";
        private bool[] _languagesList = new bool[] { false, false, false };
        private bool _isRun = false;
        private string[] _animalsList = new string[]
{@"Resources\Audio\He\General\Giraffe"    ,@"Resources\Audio\En\Animals\Giraffe" ,  @"Resources\Audio\Ar\Animals\ArGiraffe"
,@"Resources\Audio\He\General\Zebra"      ,@"Resources\Audio\En\Animals\Zebra"   ,  @"Resources\Audio\Ar\Animals\ArZebra"
,@"Resources\Audio\He\General\Panda"      ,@"Resources\Audio\En\Animals\Panda"   ,  @"Resources\Audio\Ar\Animals\ArPanda"
,@"Resources\Audio\He\OneSyllable\Elephant"   ,@"Resources\Audio\En\Animals\Elephant" , @"Resources\Audio\Ar\Animals\ArElephant"
,@"Resources\Audio\He\General\Mouse"      ,@"Resources\Audio\En\Animals\Mouse"   ,  @"Resources\Audio\Ar\Animals\ArMouse"
,@"Resources\Audio\He\OneSyllable\Turtle"    ,@"Resources\Audio\En\Animals\Turtle"  ,  @"Resources\Audio\Ar\Animals\ArTurtle"
,@"Resources\Audio\He\General\Frog"     ,@"Resources\Audio\En\Animals\Frog"    ,  @"Resources\Audio\Ar\Animals\ArFrog"
,@"Resources\Audio\He\OneSyllable\Fish"    ,@"Resources\Audio\En\Animals\Fish"    ,  @"Resources\Audio\Ar\Animals\ArFish"
,@"Resources\Audio\He\ClosingLetter\\Snake",@"Resources\Audio\En\Animals\Snake"   ,  @"Resources\Audio\Ar\Animals\ArSnake"
,@"Resources\Audio\He\General\Lion"      ,@"Resources\Audio\En\Animals\Lion"    ,  @"Resources\Audio\Ar\Animals\ArLion"
,@"Resources\Audio\He\OneSyllable\Monkey"   ,@"Resources\Audio\En\Animals\Monkey"   , @"Resources\Audio\Ar\Animals\ArMonkey"
,@"Resources\Audio\He\ClosingLetter\Bear", @"Resources\Audio\En\Animals\Bear"    ,  @"Resources\Audio\Ar\Animals\ArBear" };
        public string BackgroundPic { get; set; }
        public ICommand ShowItem { get; set; }
        public ICommand PlayAllAnimals { get; set; }
        public ICommand SetLanguage { get; set; }
        public string ButPlayAllAnimals { get; set; }
        public string ButStope { get; set; }
        public string LanguageBut0 { get { return Items[0].Background; } set { Items[0].Background = value; } }
        public string LanguageBut1 { get { return Items[1].Background; } set { Items[1].Background = value; } }
        public string LanguageBut2 { get { return Items[2].Background; } set { Items[2].Background = value; } }
        public Visibility Item0 { get { return Items[0].visibility; } set { Items[0].visibility = value; } }
        public Visibility Item1 { get { return Items[1].visibility; } set { Items[1].visibility = value; } }
        public Visibility Item2 { get { return Items[2].visibility; } set { Items[2].visibility = value; } }
        public Visibility Item3 { get { return Items[3].visibility; } set { Items[3].visibility = value; } }
        public Visibility Item4 { get { return Items[4].visibility; } set { Items[4].visibility = value; } }
        public Visibility Item5 { get { return Items[5].visibility; } set { Items[5].visibility = value; } }
        public Visibility Item6 { get { return Items[6].visibility; } set { Items[6].visibility = value; } }
        public Visibility Item7 { get { return Items[7].visibility; } set { Items[7].visibility = value; } }
        public Visibility Item8 { get { return Items[8].visibility; } set { Items[8].visibility = value; } }
        public Visibility Item9 { get { return Items[9].visibility; } set { Items[9].visibility = value; } }
        public Visibility Item10 { get { return Items[10].visibility; } set { Items[10].visibility = value; } }
        public Visibility Item11 { get { return Items[11].visibility; } set { Items[11].visibility = value; } }
        protected LetterObject[] Items = new LetterObject[12];

        public AnimalsLanguagesVM()
        {
            ShowItem = new RelayCommand(DoShowAnimals);
            PlayAllAnimals = new RelayCommand(DoPlayAllAnimals);
            SetLanguage = new RelayCommand(DoSetLanguage);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
          @"Resources\Notions\Animals\AnimalsLanguages0.jpg";
            NotifyPropertyChanged("BackgroundPic");
            for (int i = 0; i < Items.Length; i++) { 
                Items[i] = new LetterObject();
                if (i < 3)
                {
                    Items[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
                    NotifyPropertyChanged("LanguageBut" + i);
                }
            }
        }

        void IPageVM.disload()
        {
            _isRun = false;
            ButPlayAllAnimals = string.Empty;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Animals\AnimalsLanguages0.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        void IPageVM.load()
        {
            base.Settings();
            ClireBord();
        }

        private void DoShowAnimals(object obj)
        {
            ClireBord();
            int i = int.Parse(obj.ToString());
            Items[i ].visibility = Visibility.Collapsed;
            NotifyPropertyChanged("Item" + i);
            Items[i % 12].visibility = Visibility.Collapsed;
            new Thread(new ThreadStart(() =>
            {
                _isRun = true;
                int num = i*3;
                for (int j=0;j < 3&& _isRun; j++,num++)
                {
                    if (_languagesList[j])
                        continue;
                    BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Animals\AnimalsLanguages" + j+ ".jpg";
                    NotifyPropertyChanged("BackgroundPic");
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + _animalsList[num] + ".wav");
                    WhitAntilPlayStop(ref _isRun);
                    WhitTime(500, ref _isRun);
                }
                _isRun = false;
            })).Start();
        }

        private void DoSetLanguage(object obj)
        {
            int i = int.Parse(obj.ToString());
            _languagesList[i] = !_languagesList[i];
            Items[i].Background = _languagesList[i] ? "" : System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Notions\Animals\AnimalStitle" + i+".png";
            NotifyPropertyChanged("LanguageBut" + i);

        }

        private void DoPlayAllAnimals(object obj)
        {
            if (_isRun&&obj.ToString()== "Stope")
            {
                _isRun = false;
                ButPlayAllAnimals=string.Empty;
                ButStope = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\BS.Items\ReadingObject.jpg";  
                NotifyPropertyChanged("ButStope");
            }
            else if(!_isRun && obj.ToString() != "Stope")
            {
                new Thread(new ThreadStart(() =>
                {
                    _isRun = true;

                    ButPlayAllAnimals = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Lang\PlayLetters.png";
                    ButStope =string.Empty;
                    NotifyPropertyChanged("ButPlayAllAnimals");
                    NotifyPropertyChanged("ButStope");
                    for (int i = 0; i < _animalsList.Length&&_isRun; i++)
                    {
                        if(i % 3 == 0)
                        {
                            Items[i /3].visibility = Visibility.Collapsed;
                            NotifyPropertyChanged("Item" + (i/3));
                        }
                        if (_languagesList[i % 3])
                            continue;
                        
                        BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
 @"Resources\Notions\Animals\AnimalsLanguages"+(i%3)+".jpg";
                        NotifyPropertyChanged("BackgroundPic");
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + _animalsList[i] + ".wav");                        
                        WhitAntilPlayStop(ref _isRun);
                        WhitTime(500, ref _isRun);
                    }
                    ButStope = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\BS.Items\ReadingObject.png";
                    NotifyPropertyChanged("ButPlayAllAnimals");
                    NotifyPropertyChanged("ButStope");
                    _isRun = false;
                })).Start();
            }
        }

        private void ClireBord()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].visibility = Visibility.Visible;
                NotifyPropertyChanged("Item" + i);

            }
        }
    }
}
