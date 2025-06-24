

using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
#endregion MEF
public class EnAnimalsVM : BaseLernPage, IPageVM
    {
        public string BackgroundPic { get; set; }
        public ICommand ShowAnimals { get; set; }
        public ICommand SwichPage { get; set; }
        public Visibility Animals0 { get { return _animals[0].ItemsVisible; } set { _animals[0].ItemsVisible = value; } }
        public Visibility Animals1 { get { return _animals[1].ItemsVisible; } set { _animals[1].ItemsVisible = value; } }
        public Visibility Animals2 { get { return _animals[2].ItemsVisible; } set { _animals[2].ItemsVisible = value; } }
        public Visibility Animals3 { get { return _animals[3].ItemsVisible; } set { _animals[3].ItemsVisible = value; } }
        public Visibility Animals4 { get { return _animals[4].ItemsVisible; } set { _animals[4].ItemsVisible = value; } }
        public Visibility Animals5 { get { return _animals[5].ItemsVisible; } set { _animals[5].ItemsVisible = value; } }
        public Visibility Animals6 { get { return _animals[6].ItemsVisible; } set { _animals[6].ItemsVisible = value; } }
        public Visibility Animals7 { get { return _animals[7].ItemsVisible; } set { _animals[7].ItemsVisible = value; } }
        public Visibility Animals8 { get { return _animals[8].ItemsVisible; } set { _animals[8].ItemsVisible = value; } }
        public Visibility Animals9 { get { return _animals[9].ItemsVisible; } set { _animals[9].ItemsVisible = value; } }
        public Visibility Animals10 { get { return _animals[10].ItemsVisible; } set { _animals[10].ItemsVisible = value; } }
        public Visibility Animals11 { get { return _animals[11].ItemsVisible; } set { _animals[11].ItemsVisible = value; } }
        private ItemObject[] _animals = new ItemObject[12];
        private string[,] _animalList = new string[,]{
 {"Horse","Cow","Cat","Dog","Goose","Chicken","Sheep","Donkey","Camel","Goat","Rabbit" ,"Pigeon" }         ,
 { "Giraffe","Zebra","Panda","Elephant","Mouse" ,"Turtle" ,"Frog","Fish" ,"Snake"  ,"Lion"
                    ,"Monkey","Bear" } };
        public override string Name => nameof(EnAnimalsVM);

        public EnAnimalsVM()
        {
            ShowAnimals = new RelayCommand(DoShowAnimals);
            SwichPage = new RelayCommand(DoSwichPage);
            for (int i = 0; i < _animals.Length; i++)
            {
                _animals[i] =  new ItemObject() {  ItemsVisible = Visibility.Visible };
            }
            Common.StaticVar.inline.AnimalsLernWord = -1;
        }

        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Lang\En\Animals\Animals" + Common.StaticVar.inline.AnimalsLern + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\Animals\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            if (Common.StaticVar.inline.AnimalsLernWord > -1)
                DoShowAnimals(Common.StaticVar.inline.AnimalsLernWord);
        }

        public void DoShowAnimals(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
         
            Common.StaticVar.inline.AnimalsLernWord = int.Parse(obj.ToString());
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Animals\"
+ _animalList[Common.StaticVar.inline.AnimalsLern, Common.StaticVar.inline.AnimalsLernWord] + ".wav");
        
            _animals[Common.StaticVar.inline.AnimalsLernWord].ItemsVisible = Visibility.Hidden;
            NotifyPropertyChanged("Animals" + Common.StaticVar.inline.AnimalsLernWord);

        }

        private void DoSwichPage(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            Common.StaticVar.inline.AnimalsLern = int.Parse(index.ToString());
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Animals\Animals" + Common.StaticVar.inline.AnimalsLern + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            Clear();
        }

        private void Clear()
        {
            for (int i = 0; i < _animals.Length; i++)
            {
                _animals[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Animals" + i);
            }
        }

        void IPageVM.disload()
        {
            Clear();
        }
    }
}

