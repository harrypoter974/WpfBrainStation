using CL.BS.Model;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseItemPage : BaseLernPage
    {
        /// <summary>
        /// This class is the father of all the VM class that learn Vocabulary.
        /// It contain's all items to learn from. 
        /// </summary>

        public ICommand HideLine { get; set; }
        public ICommand ShowItem { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public string ShowBut0 { get { return Items[0].Button; } set { Items[0].Button = value; } }
        public string ShowBut1 { get { return Items[1].Button; } set { Items[1].Button = value; } }
        public string ShowBut2 { get { return Items[2].Button; } set { Items[2].Button = value; } }
        public string ShowBut3 { get { return Items[3].Button; } set { Items[3].Button = value; } }

        public Visibility LineItem0 { get { return Items[0].LineVisible; } set { Items[0].LineVisible = value; } }
        public Visibility LineItem1 { get { return Items[1].LineVisible; } set { Items[1].LineVisible = value; } }
        public Visibility LineItem2 { get { return Items[2].LineVisible; } set { Items[2].LineVisible = value; } }
        public Visibility LineItem3 { get { return Items[3].LineVisible; } set { Items[3].LineVisible = value; } }

        public Visibility Item0 { get { return Items[0].ItemsVisible; } set { Items[0].ItemsVisible = value; } }
        public Visibility Item1 { get { return Items[1].ItemsVisible; } set { Items[1].ItemsVisible = value; } }
        public Visibility Item2 { get { return Items[2].ItemsVisible; } set { Items[2].ItemsVisible = value; } }
        public Visibility Item3 { get { return Items[3].ItemsVisible; } set { Items[3].ItemsVisible = value; } }
        public Visibility Item4 { get { return Items[4].ItemsVisible; } set { Items[4].ItemsVisible = value; } }
        public Visibility Item5 { get { return Items[5].ItemsVisible; } set { Items[5].ItemsVisible = value; } }
        public Visibility Item6 { get { return Items[6].ItemsVisible; } set { Items[6].ItemsVisible = value; } }
        public Visibility Item7 { get { return Items[7].ItemsVisible; } set { Items[7].ItemsVisible = value; } }
        public Visibility Item8 { get { return Items[8].ItemsVisible; } set { Items[8].ItemsVisible = value; } }
        public Visibility Item9 { get { return Items[9].ItemsVisible; } set { Items[9].ItemsVisible = value; } }
        public Visibility Item10 { get { return Items[10].ItemsVisible; } set { Items[10].ItemsVisible = value; } }
        public Visibility Item11 { get { return Items[11].ItemsVisible; } set { Items[11].ItemsVisible = value; } }
        public Visibility Item12 { get { return Items[12].ItemsVisible; } set { Items[12].ItemsVisible = value; } }
        public Visibility Item13 { get { return Items[13].ItemsVisible; } set { Items[13].ItemsVisible = value; } }
        public Visibility Item14 { get { return Items[14].ItemsVisible; } set { Items[14].ItemsVisible = value; } }
        public Visibility Item15 { get { return Items[15].ItemsVisible; } set { Items[15].ItemsVisible = value; } }
        public Visibility Item16 { get { return Items[16].ItemsVisible; } set { Items[16].ItemsVisible = value; } }
        public Visibility Item17 { get { return Items[17].ItemsVisible; } set { Items[17].ItemsVisible = value; } }
        protected ItemObject[] Items = new ItemObject[18];
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public BaseItemPage()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                LanguageBut[i] = new SoldierObject() { Background = string.Empty };

            }
            for (int i = 0; i < Items.Length; i++)
                Items[i] = new ItemObject() { IsHideLine = true, LineVisible =Visibility.Collapsed};
            HideLine = new RelayCommand(DoHideLine); 
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
        }

        protected void DoHideLine(object obj)
        {//It Hides a line of each item.
            int i = int.Parse(obj.ToString());
            Items[i].IsHideLine = !Items[i].IsHideLine;
            Items[i].LineVisible = Items[i].IsHideLine ? Visibility.Collapsed : Visibility.Visible;
            Items[i].Button = Items[i].IsHideLine ? string.Empty : System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\BS.Items\ShowBut.jpg";
            NotifyPropertyChanged("ShowBut" + obj);
            NotifyPropertyChanged("LineItem" + obj);
        }
        private void DoSwitchLanguage(object obj)
        {
            int i = int.Parse(obj.ToString());
            if (!Common.StaticVar.inline.Languages[i])
                return;
            int is1 = 0;
            for (int j = 0; j < LanguageBut.Length; j++)
            {
                if (!string.IsNullOrEmpty( LanguageBut[j].Background))
                    if(LanguageBut[j].Background.Contains("AnimalStitle"))
                        is1++;
            }
            if (is1 == 1 && !string.IsNullOrEmpty(LanguageBut[i].Background))
                return;
            LanguageBut[i].Background = LanguageBut[i].Background != string.Empty ? string.Empty :
           string.Format(@"{0}Resources\Notions\Animals\AnimalStitle{1}.png" ,
           System.AppDomain.CurrentDomain.BaseDirectory, i );
            NotifyPropertyChanged("LanguageBut" + i);
            Common.StaticVar.PlayMode = false;
            for (int l = 0; l < 4; l++)
            {
                Items[l].IsHideLine = false;
                Items[l].LineVisible = Visibility.Collapsed;
                Items[l].Button = string.Empty;
                NotifyPropertyChanged("ShowBut" + l);
                NotifyPropertyChanged("LineItem" + l);
            }
            for (int j = 0; j < Items.Length;j++)
            {
                Items[j].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Item" + j);
            }
            if (!Common.StaticVar.inline.IsBoy)
                messagePic = "Visible";
            else
                messagePic = "Hidden";
            NotifyPropertyChanged(nameof(messagePic));
        }
        protected string GetLanguage()
        {
            string language = string.Empty;
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (LanguageBut[i].Background != string.Empty)
                    language += "HEA"[i];
            }
            return language;    
        }
        protected void ListWordVisible()
        {//Preparing BaseItemPage for a presentation.
            base.Settings();
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
            
            Common.StaticVar.PlayMode = false;
            for (int i = 0; i < 4; i++)
            {
                Items[i].IsHideLine = false;
                Items[i].LineVisible = Visibility.Collapsed;
                Items[i].Button =  string.Empty ;
                NotifyPropertyChanged("ShowBut" + i);
                NotifyPropertyChanged("LineItem" + i);
            }
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Item" + i);
            }
            if (!Common.StaticVar.inline.IsBoy)
                messagePic = "Visible";
            else
                messagePic = "Hidden";
            NotifyPropertyChanged(nameof(messagePic));
        }

        protected void ListWordVisible(bool HaveTitel = true)
        {//Preparing BaseItemPage for a presentation.
            base.Settings();
            Common.StaticVar.PlayMode = false;
            for (int i = 0; i < 4; i++)
            {
                Items[i].IsHideLine = false;
                Items[i].LineVisible = Visibility.Collapsed;
                Items[i].Button = string.Empty;
                NotifyPropertyChanged("ShowBut" + i);
                NotifyPropertyChanged("LineItem" + i);
            }
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Item" + i);
            }
            if (HaveTitel)
            {
                if (!Common.StaticVar.inline.IsBoy)
                    messagePic = "Visible";
                else
                    messagePic = "Hidden";
            }
            else
            {
                if (!Common.StaticVar.inline.IsBoy)
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\tapMessage.png";
                else
                    messagePic = string.Empty;
            }
            NotifyPropertyChanged(nameof(messagePic));
        }
    }
}
