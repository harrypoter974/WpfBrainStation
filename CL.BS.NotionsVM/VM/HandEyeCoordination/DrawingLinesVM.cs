using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class DrawingLinesVM : BaseLernPage, IPageVM
    {
        public string ButLevel0 { get { return ButLevels[0].Background; } set { ButLevels[0].Background = value; } }
        public string ButLevel1 { get { return ButLevels[1].Background; } set { ButLevels[1].Background = value; } }
        public string ButLevel2 { get { return ButLevels[2].Background; } set { ButLevels[2].Background = value; } }
        protected LetterObject[] ButLevels = new LetterObject[3];
        private int _level=0,  _lineIndex = 0;
        public ICommand SetLevel { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name => "DrawingLinesVM";

        public DrawingLinesVM()
        {
            SetLevel = new RelayCommand(DoSetLevel);
            AnswerBut = new RelayCommand(DoAnswerBut);
            for (int i = 0; i < ButLevels.Length; i++)
                ButLevels[i] = new LetterObject();
        }

        void IPageVM.load()
        {
            //PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            //   @"Resources\Audio\He\Title\DrawingLines.wav");
            base.Settings();
            ButLevels[_level].Background = string.Empty;
            NotifyPropertyChanged("ButLevel"+_level);
            _level = _lineIndex = 0;
            ButLevels[_level].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\Easy.png";
            NotifyPropertyChanged("ButLevel0");
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _lineIndex++;
                if (!File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\DrawingLines\Q" 
+ _level + _lineIndex + ".jpg"))
                    _lineIndex = 0;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\DrawingLines\Q" + _level + _lineIndex + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\DrawingLines\A" + _level + _lineIndex + ".jpg";
            }
            NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }

        private void DoSetLevel(object obj)
        {
            _lineIndex = 0; ButLevels[_level].Background = string.Empty;
            NotifyPropertyChanged("ButLevel" + _level);     
            _level = int.Parse(obj.ToString());
            ButLevels[_level].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\"  +Common.StaticVar.LevelButton[_level] + ".png"; ;
            NotifyPropertyChanged("ButLevel"+_level);
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");
        }
    }
}
