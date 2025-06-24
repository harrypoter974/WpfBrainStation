using BS.Items;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ExerciseGroupColorsVM : BaseLernPage, IPageVM
    {
        public string ExerciseGroupPic { get; set; }
        public ICommand SetGroup { get; set; }
        public ICommand RePlay { get; set; }
        private IColorsManager _logic = (IColorsManager)  SupportHandlerManager.Base.GetManager("ColorsManager");
        public string ColorCard { get; set; }
        public string ColorName { get; set; }
        public override string Name
        {
            get
            {
                return nameof(ExerciseGroupColorsVM) ;
            }
        }

        public ExerciseGroupColorsVM()
        {
            SetGroup = new RelayCommand(DoSetGroup);
            AnswerBut = new RelayCommand(DoAnswerBut);
            RePlay = new RelayCommand(DoRePlay);          
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Colors\exerciseMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged( nameof(messagePic) );
            SetGroupPic(_logic.GetGrope());
            Clear();
            IsQuestionMode = false;
            BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GShowTask.png";
           NotifyPropertyChanged(nameof(BackgroundAnswerButton));
        }

        private void SetGroupPic(object obj)
        {
            if (obj.ToString() == "1")
            {
                ExerciseGroupPic = System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Notions\Colors\ExerciseGroupColors2.jpg";
            }
            else
                ExerciseGroupPic = string.Empty;
            NotifyPropertyChanged(nameof(ExerciseGroupPic));
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
          
            if (base.IsQuestionMode)
            {
                ColorName =  _logic.GetQuestion();
                ColorCard = string.Empty;
                NotifyPropertyChanged(nameof(ColorCard));
                ColorCard = System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Notions\Colors\Cards\"+ ColorName + ".png";
                new Thread(new ThreadStart(() =>
                {
                PlayList(_logic.PlayQuestion(-1));
                })).Start();
                NotifyPropertyChanged(nameof(ColorName));
            }
            else
            {
                NotifyPropertyChanged(nameof(ColorCard));
            }
            IsQuestionMode = !IsQuestionMode;
            if (IsQuestionMode)
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GShowTask.png";
            else
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory+ @"Resources\BS.Items\BShowSolution.png";
            NotifyPropertyChanged(nameof(BackgroundAnswerButton));

        }

        private void DoSetGroup(object obj)
        {
            new WinSettingsColors().ShowDialog();
            _logic.ClearList();
        }

        private void DoRePlay(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            new Thread(new ThreadStart(() =>
                {
                    PlayList(_logic.PlayQuestion(-1));
                })).Start();

        }

        private void Clear()
        {
            ColorCard = ColorName = string.Empty;
            NotifyPropertyChanged(nameof(ColorName));
            NotifyPropertyChanged(nameof(ColorCard));
        }
    }
}
