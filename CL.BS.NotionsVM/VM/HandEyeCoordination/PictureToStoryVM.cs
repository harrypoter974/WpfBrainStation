using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PictureToStoryVM : BaseLernPage, IPageVM
    {
        public string PlayerBut0 { get { return PlayerBut[0].Background; } set { PlayerBut[0].Background = value; } }
        public string PlayerBut1 { get { return PlayerBut[1].Background; } set { PlayerBut[1].Background = value; } }
        public string PlayerBut2 { get { return PlayerBut[2].Background; } set { PlayerBut[2].Background = value; } }

        protected LetterObject[] PlayerBut = new LetterObject[3];
        public ICommand SetPlayer { get; set; }
        public string BackgroundPic { get; set; }
        public string Pic10 { get { return PicList[0].Background; } set { PicList[0].Background = value; } }
        public string Pic13 { get { return PicList[1].Background; } set { PicList[1].Background = value; } }
        public string Pic20 { get { return PicList[2].Background; } set { PicList[2].Background = value; } }
        public string Pic21 { get { return PicList[3].Background; } set { PicList[3].Background = value; } }
        public string Pic22 { get { return PicList[4].Background; } set { PicList[4].Background = value; } }
        public string Pic23 { get { return PicList[5].Background; } set { PicList[5].Background = value; } }
        public string Pic40 { get { return PicList[6].Background; } set { PicList[6].Background = value; } }
        public string Pic41 { get { return PicList[7].Background; } set { PicList[7].Background = value; } }
        public string Pic42 { get { return PicList[8].Background; } set { PicList[8].Background = value; } }
        public string Pic43 { get { return PicList[9].Background; } set { PicList[9].Background = value; } }
        private string[] _picNameList = new string[] {"Pic10","Pic13","Pic20","Pic21","Pic22","Pic23","Pic40",
            "Pic41","Pic42","Pic43"       };
        protected LetterObject[] PicList = new LetterObject[10];
        private int _picIndex = 0;
        private int _playerIndex =2;
        private char _storyName = 'a';
        public override string Name =>nameof(PictureToStoryVM);

        public PictureToStoryVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetPlayer= new RelayCommand(DoSetPlayer);
            for (int i = 0; i < PlayerBut.Length; i++)
                PlayerBut[i] = new LetterObject();
            for (int i = 0; i < PicList.Length; i++)
                PicList[i] = new LetterObject();
        }

        void IPageVM.load()
        {
            //PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            // @"Resources\Audio\He\Title\PictureToStory.wav");
            base.Settings();
            DoSetPlayer(0);
            _picIndex = 0;
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            ClearBord();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\PictureToStory\message.png";
            }
            else
                messagePic = string.Empty;
            BackgroundPic= System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Notions\PictureToStory\open.jpg";
            NotifyPropertyChanged("messagePic");
            NotifyPropertyChanged("BackgroundPic");
        }

        protected void DoSetPlayer(object obj)
        {
           BackgroundPic=  PlayerBut[_playerIndex].Background = string.Empty;           
            NotifyPropertyChanged("BackgroundPic");
            BackgroundAnswerButton = string.Empty;
            NotifyPropertyChanged("BackgroundAnswerButton");
            NotifyPropertyChanged("PlayerBut" + _playerIndex);
            int pi = int.Parse(obj.ToString());
            if (pi == -1)
            {
                PlayerBut[2].Background = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\Number\4b.png";
                NotifyPropertyChanged("PlayerBut2");
                _playerIndex = 3;
            }
            else
            {
                PlayerBut[pi].Background = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\Number\" +new int[]{1,2,4 }[pi] + "b.png";
                NotifyPropertyChanged("PlayerBut" + pi);
                _playerIndex = pi;
            }
            ClearBord();
        }

        private void DoAnswerBut(object obj)
        {
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");
            if (_picIndex == 4)
            {
                _picIndex = 0;
                _storyName = _storyName == 'c' ? 'a' : (char)(_storyName + 1);
                ClearBord();
                BackgroundAnswerButton = string.Empty;
                NotifyPropertyChanged("BackgroundAnswerButton");
            }
            if (_playerIndex == 0)
            {
                int pi = new int[] { 0, 2, 4, 1 }[_picIndex];
                PicList[pi].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\PictureToStory\" + _storyName + _picIndex + ".png";
                NotifyPropertyChanged(_picNameList[pi]);
            }
            else if (_playerIndex == 1)
            {
                PicList[_picIndex + 2].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\PictureToStory\" + _storyName + _picIndex + ".png";
                NotifyPropertyChanged(_picNameList[_picIndex + 2]);
            }
            else
            {
                PicList[_picIndex + 6].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\PictureToStory\" + _storyName + _picIndex + ".png";
                NotifyPropertyChanged(_picNameList[_picIndex + 6]);
            }
            _picIndex++;
            if (_picIndex == 4)
            {
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\PictureToStory\newStory.jpg";
                NotifyPropertyChanged("BackgroundAnswerButton");
            }
        }

        private void ClearBord()
        {
            for (int i = 0; i < PicList.Length; i++)
            {
                PicList[i].Background = string.Empty;
            NotifyPropertyChanged(_picNameList[i]);
            }
        }
    }
}
