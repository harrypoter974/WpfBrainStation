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
    public class CopyShapesVM : BaseLernPage, IPageVM
    {
        public string ButLevel0 { get { return ButLevels[0].Background; } set { ButLevels[0].Background = value; } }
        public string ButLevel1 { get { return ButLevels[1].Background; } set { ButLevels[1].Background = value; } }
        public string ButLevel2 { get { return ButLevels[2].Background; } set { ButLevels[2].Background = value; } }
        protected SoldierObject[] ButLevels = new SoldierObject[3];
        private int _level = 0;
        private int _questionIndex = 0;
        public string BackgroundPic { get; set; }
        public ICommand SetLevel { get; set; }
        public override string Name => "CopyShapesVM";

        public CopyShapesVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetLevel = new RelayCommand(DoSetLevel);
            for (int i = 0; i < ButLevels.Length; i++)
                ButLevels[i] = new SoldierObject();
        }

        void IPageVM.load()
        {
          //  PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
          //@"Resources\Audio\He\Title\CopyShapes.wav");
            ButLevels[_level].Background = string.Empty;
            NotifyPropertyChanged("ButLevel" + _level);
            _level = 0;
            ButLevels[_level].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\Easy.png";
            NotifyPropertyChanged("ButLevel0");
            BackgroundPic =string.Empty;
            NotifyPropertyChanged("BackgroundPic");
            Common.StaticVar.PlayMode = false;
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\CopyShapes\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            base.Settings();
        }

        private void DoSetLevel(object obj)
        {
            ButLevels[_level].Background = string.Empty;
            NotifyPropertyChanged("ButLevel" + _level);
            _level = int.Parse(obj.ToString());
            ButLevels[_level].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\" + Common.StaticVar.LevelButton[_level] + ".png"; ;
            NotifyPropertyChanged("ButLevel" + _level);
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\CopyShapes\Q" + _level + _questionIndex+ ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\CopyShapes\A" + _level + _questionIndex+ ".jpg";
                _questionIndex = _questionIndex == 2 ? 0 : _questionIndex + 1;
            }
            NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }
    }
}
