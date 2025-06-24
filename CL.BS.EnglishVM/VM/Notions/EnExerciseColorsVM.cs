using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Notions;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnExerciseColorsVM : BaseLernPage, IPageVM
    {
        public string ExerciseGroupPic { get; set; }
        public ICommand SetGroup { get; set; }
        public ICommand RePlay { get; set; }
        private IEnColorManager _logic = (IEnColorManager)
     SupportHandlerManager.Base.GetManager("EnColorManager");
        public string ColorCard { get; set; }

        public string ColorName { get; set; }
        public override string Name => nameof(EnExerciseColorsVM);

        public EnExerciseColorsVM()
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
            NotifyPropertyChanged(nameof(messagePic));
            Clear();
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
                //new Thread(new ThreadStart(() =>
                //{ })).Start();
                    ColorName = _logic.GetQuestion();
                    PlayList(_logic.PlayQuestion());
                    ColorCard = string.Empty;
                    NotifyPropertyChanged(nameof(ColorCard));
                    ColorCard = System.AppDomain.CurrentDomain.BaseDirectory
                  + @"Resources\Notions\Colors\Cards\" + ColorName + ".png";
               
                NotifyPropertyChanged(nameof(ColorName));
            }
            else
            {
                NotifyPropertyChanged(nameof(ColorCard));
            }
            base.SwitchAnswerButton();

        }

        private void DoSetGroup(object obj)
        {
        }
        private void DoRePlay(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            new Thread(new ThreadStart(() =>
            {
                PlayList(_logic.PlayQuestion());
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
