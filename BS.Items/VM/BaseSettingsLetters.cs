using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BS.Items.VM
{
    class BaseSettingsLetters : INotifyPropertyChanged
    {
        /// <summary>    
        ///  that menu is set the letter that will be lerl by the childrens  
        /// </summary>

        public ICommand Clear { get; set; }
        public ICommand letterType { get; set; }
        public string letter0 { get { return LetterList[0].Background; } set { LetterList[0].Background = value; } }
        public string letter1 { get { return LetterList[1].Background; } set { LetterList[1].Background = value; } }
        public string letter2 { get { return LetterList[2].Background; } set { LetterList[2].Background = value; } }
        public string letter3 { get { return LetterList[3].Background; } set { LetterList[3].Background = value; } }
        public string letter4 { get { return LetterList[4].Background; } set { LetterList[4].Background = value; } }
        public string letter5 { get { return LetterList[5].Background; } set { LetterList[5].Background = value; } }
        public string letter6 { get { return LetterList[6].Background; } set { LetterList[6].Background = value; } }
        public string letter7 { get { return LetterList[7].Background; } set { LetterList[7].Background = value; } }
        public string letter8 { get { return LetterList[8].Background; } set { LetterList[8].Background = value; } }
        public string letter9 { get { return LetterList[9].Background; } set { LetterList[9].Background = value; } }
        public string letter10 { get { return LetterList[10].Background; } set { LetterList[10].Background = value; } }
        public string letter11 { get { return LetterList[11].Background; } set { LetterList[11].Background = value; } }
        public string letter12 { get { return LetterList[12].Background; } set { LetterList[12].Background = value; } }
        public string letter13 { get { return LetterList[13].Background; } set { LetterList[13].Background = value; } }
        public string letter14 { get { return LetterList[14].Background; } set { LetterList[14].Background = value; } }
        public string letter15 { get { return LetterList[15].Background; } set { LetterList[15].Background = value; } }
        public string letter16 { get { return LetterList[16].Background; } set { LetterList[16].Background = value; } }
        public string letter17 { get { return LetterList[17].Background; } set { LetterList[17].Background = value; } }
        public string letter18 { get { return LetterList[18].Background; } set { LetterList[18].Background = value; } }
        public string letter19 { get { return LetterList[19].Background; } set { LetterList[19].Background = value; } }
        public string letter20 { get { return LetterList[20].Background; } set { LetterList[20].Background = value; } }
        public string letter21 { get { return LetterList[21].Background; } set { LetterList[21].Background = value; } }
        public string letter22 { get { return LetterList[22].Background; } set { LetterList[22].Background = value; } }
        public string letter23 { get { return LetterList[23].Background; } set { LetterList[23].Background = value; } }
        public string letter24 { get { return LetterList[24].Background; } set { LetterList[24].Background = value; } }
        public string letter25 { get { return LetterList[25].Background; } set { LetterList[25].Background = value; } }
        public string letter26 { get { return LetterList[26].Background; } set { LetterList[26].Background = value; } }
        public string letter27 { get { return LetterList[27].Background; } set { LetterList[27].Background = value; } }
        public string letter28 { get { return LetterList[28].Background; } set { LetterList[28].Background = value; } }
        public string letter29 { get { return LetterList[29].Background; } set { LetterList[29].Background = value; } }

        public string letterPic0 { get { return LetterList[0].Letter; } set { LetterList[0].Letter = value; } }
        public string letterPic1 { get { return LetterList[1].Letter; } set { LetterList[1].Letter = value; } }
        public string letterPic2 { get { return LetterList[2].Letter; } set { LetterList[2].Letter = value; } }
        public string letterPic3 { get { return LetterList[3].Letter; } set { LetterList[3].Letter = value; } }
        public string letterPic4 { get { return LetterList[4].Letter; } set { LetterList[4].Letter = value; } }
        public string letterPic5 { get { return LetterList[5].Letter; } set { LetterList[5].Letter = value; } }
        public string letterPic6 { get { return LetterList[6].Letter; } set { LetterList[6].Letter = value; } }
        public string letterPic7 { get { return LetterList[7].Letter; } set { LetterList[7].Letter = value; } }
        public string letterPic8 { get { return LetterList[8].Letter; } set { LetterList[8].Letter = value; } }
        public string letterPic9 { get { return LetterList[9].Letter; } set { LetterList[9].Letter = value; } }
        public string letterPic10 { get { return LetterList[10].Letter; } set { LetterList[10].Letter = value; } }
        public string letterPic11 { get { return LetterList[11].Letter; } set { LetterList[11].Letter = value; } }
        public string letterPic12 { get { return LetterList[12].Letter; } set { LetterList[12].Letter = value; } }
        public string letterPic13 { get { return LetterList[13].Letter; } set { LetterList[13].Letter = value; } }
        public string letterPic14 { get { return LetterList[14].Letter; } set { LetterList[14].Letter = value; } }
        public string letterPic15 { get { return LetterList[15].Letter; } set { LetterList[15].Letter = value; } }
        public string letterPic16 { get { return LetterList[16].Letter; } set { LetterList[16].Letter = value; } }
        public string letterPic17 { get { return LetterList[17].Letter; } set { LetterList[17].Letter = value; } }
        public string letterPic18 { get { return LetterList[18].Letter; } set { LetterList[18].Letter = value; } }
        public string letterPic19 { get { return LetterList[19].Letter; } set { LetterList[19].Letter = value; } }
        public string letterPic20 { get { return LetterList[20].Letter; } set { LetterList[20].Letter = value; } }
        public string letterPic21 { get { return LetterList[21].Letter; } set { LetterList[21].Letter = value; } }
        public string letterPic22 { get { return LetterList[22].Letter; } set { LetterList[22].Letter = value; } }
        public string letterPic23 { get { return LetterList[23].Letter; } set { LetterList[23].Letter = value; } }
        public string letterPic24 { get { return LetterList[24].Letter; } set { LetterList[24].Letter = value; } }
        public string letterPic25 { get { return LetterList[25].Letter; } set { LetterList[25].Letter = value; } }
        public string letterPic26 { get { return LetterList[26].Letter; } set { LetterList[26].Letter = value; } }
        public string letterPic27 { get { return LetterList[27].Letter; } set { LetterList[27].Letter = value; } }
        public string letterPic28 { get { return LetterList[28].Letter; } set { LetterList[28].Letter = value; } }
        public string letterPic29 { get { return LetterList[29].Letter; } set { LetterList[29].Letter = value; } }


        protected ViewObject[] LetterList = new ViewObject[30];
        protected bool _lockLetter=false;
        internal int FintIndex(object obj)
        {
            char cl = obj.ToString()[0];
            for (int i = 0; i < LetterList.Length; i++)
            {
                if (LetterList[i].Uid == cl)
                    return i;
            }
            return -1;
        }

        internal void ClearLetter()
        {
            for (int i = 0; i < LetterList.Length; i++)
            {
                LetterList[i].Background = StaticVar.Green;
                NotifyPropertyChanged("letter" + i);
            }
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
        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
        #endregion
    }
}
