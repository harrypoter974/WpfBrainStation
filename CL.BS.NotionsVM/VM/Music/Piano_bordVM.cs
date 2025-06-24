using System;
using CL.BS.VMCommon;
using System.Windows.Input;
using CL.BS.Contract;
using CL.BS.Model;

namespace CL.BS.NotionsVM.VM.Music
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class Piano_bordVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(Piano_bordVM);
        public string HappySmily { get; set; }
        public string VPic { get; set; }
        private bool _isExercise;
        private string[] ScaleList = new string[]
        {  "do"  ,"re","mi" ,"fa" ,"sol","la" ,"ti","do2" };
        public string Answer0 { get { return AnswerList[0].Background; } set { AnswerList[0].Background = value; } }
        public string Answer1 { get { return AnswerList[1].Background; } set { AnswerList[1].Background = value; } }
        public string Answer2 { get { return AnswerList[2].Background; } set { AnswerList[2].Background = value; } }
        public string Answer3 { get { return AnswerList[3].Background; } set { AnswerList[3].Background = value; } }
        public string Answer4 { get { return AnswerList[4].Background; } set { AnswerList[4].Background = value; } }
        public string Answer5 { get { return AnswerList[5].Background; } set { AnswerList[5].Background = value; } }
        public string Answer6 { get { return AnswerList[6].Background; } set { AnswerList[6].Background = value; } }
        public string Answer7 { get { return AnswerList[7].Background; } set { AnswerList[7].Background = value; } }
        private SoldierObject[] AnswerList = new SoldierObject[8];
        private int _pianoIndex = 8;
        public Piano_bordVM()
        {
            for (int i = 0; i < AnswerList.Length; i++)
                AnswerList[i] = new SoldierObject() { Background= "Collapsed" };
            AnswerBut = new RelayCommand(DoTapSound);
            VPic= string.Format(@"{0}\Resources\BS.Items\GreenV.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(VPic));
        }
        internal void setVolume(double v)
        {
            Volume = v;
            NotifyPropertyChanged(nameof(Volume));
        }
        private void DoTapSound(object obj)
        {

            _pianoIndex = int.Parse(obj.ToString());
            if (_isExercise)
            {
                Common.StaticVar.PlayMode = false;
                PlayUrl(String.Format(@"{0}Resources\Audio\Music\{1}.wav",
                    System.AppDomain.CurrentDomain.BaseDirectory, ScaleList[_pianoIndex]));
            }
            else
            {
                PlayList(new string[] {
 String.Format(@"Resources\Audio\Music\Ex_{0}.wav", ScaleList[_pianoIndex]),
 String.Format(@"Resources\Audio\Music\{0}.wav", ScaleList[_pianoIndex])});
            }
        }

        internal void CheckQuestion(int pianoIndex)
        {
            AnswerList[pianoIndex].Background = "Visible";
            NotifyPropertyChanged("Answer" + pianoIndex);
            HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory, pianoIndex==_pianoIndex ? "Happy" : "Sad");
            NotifyPropertyChanged(nameof(HappySmily));
            _pianoIndex = pianoIndex;
        }

        internal void Clear()
        {
            if (_pianoIndex == 8)
                return;
            AnswerList[_pianoIndex].Background = "Collapsed"; 
            NotifyPropertyChanged("Answer" + _pianoIndex);
            HappySmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            _pianoIndex = 8;
        }
        internal void IsExercise(bool isExercise)
        {
            _isExercise = isExercise;
        }
    }
}
