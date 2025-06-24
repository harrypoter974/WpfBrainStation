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
    public class LdentifyConnectionsVM : BaseLernPage, IPageVM
    {
        public string ButLevel0 { get { return ButLevels[0].Background; } set { ButLevels[0].Background = value; } }
        public string ButLevel1 { get { return ButLevels[1].Background; } set { ButLevels[1].Background = value; } }
        public string ButLevel2 { get { return ButLevels[2].Background; } set { ButLevels[2].Background = value; } }

        protected LetterObject[] ButLevels = new LetterObject[3];
        private int _level = 0;
        public ICommand SetLevel { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name => nameof(LdentifyConnectionsVM);

        public LdentifyConnectionsVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetLevel = new RelayCommand(DoSetLevel);
            for (int i = 0; i < ButLevels.Length; i++)
                ButLevels[i] = new LetterObject();
        }

        void IPageVM.load()
        {
            //PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            // @"Resources\Audio\He\Title\LdentifyConnections.wav");
            base.Settings();
            ButLevels[_level].Background = string.Empty;
            NotifyPropertyChanged("ButLevel" + _level);
            _level = 0;
            ButLevels[_level].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\Easy.png";
            NotifyPropertyChanged("ButLevel0");
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\LdentifyConnections\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoSetLevel(object obj)
        {
            ButLevels[_level].Background = string.Empty;
            NotifyPropertyChanged("ButLevel" + _level);
            _level =int.Parse( obj.ToString());
            ButLevels[_level].Background = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\" + Common.StaticVar.LevelButton[_level] + ".png"; ;
            NotifyPropertyChanged("ButLevel" + _level);
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Notions\LdentifyConnections\Q"+ _level+".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\LdentifyConnections\A" + _level + ".jpg";
            }
                NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }
    }
}
