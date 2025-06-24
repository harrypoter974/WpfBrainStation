using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Writing
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class OldLernWordsVM : BaseLernPage, IPageVM
    {
        private ILernWordsManager _logic = (ILernWordsManager)
SupportHandlerManager.Base.GetManager("LernWordsManager");
        private Dictionary<string, string[]> _words;
        private int _wordIndex = -1;
        public string BackgroundPic { get; set; }
        public ICommand SetWord { get; set; }
        public ICommand SetGroup { get; set; }
        public override string Name
        {
            get
            {
                return "OldLernWordsVM";
            }
        }

        public OldLernWordsVM()
        {
            _words = new Dictionary<string, string[]>();
            _words.Add("Animals", new string[] { "cat", "Donkey", "Lion", "sheep", "cow", "camel" });
            _words.Add("vehicle", new string[] { "motorcycle", "car", "bus", "truck", "boat", "train" });
            _words.Add("Fruit", new string[] { "locust", "Apple", "lemon", "an_orange", "Pomegranate", "fig" });
            _words.Add("Clothing", new string[] { "scarf", "undershirt", "Sweater", "Coat", "pants", "shirt" });//Swimsuit
            SetWord = new RelayCommand(DoSetWord);
            SetGroup = new RelayCommand(DoSetGroup);
        }

        private void DoSetWord(object obj)
        {
            _wordIndex = int.Parse(obj.ToString());
            base.IsQuestionMode = true;
            SetBackground();
            string group = _words[Common.GlobalVar.Group][_wordIndex] == "lemon" ? "ComplexSyllable\\" : "General\\";
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                +@"Resources\Audio\He\" + group + _words[Common.GlobalVar.Group][_wordIndex] + ".wav");
        }

        protected void DoSetGroup(object group)
        {
            Common.GlobalVar.Group = group.ToString();
            _wordIndex = -1;
            base.IsQuestionMode = true;
            SetBackground();
        
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Words\openMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            SetBackground();
        }

        private void SetBackground()
        {
            string word;
            if (_wordIndex == -1)
                word = "open";
            else
                word ='l'+ _words[Common.GlobalVar.Group][_wordIndex];
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
             + @"Resources\Lang\He\Words\" + Common.GlobalVar.Group + '\\'+ word + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
    }
}
