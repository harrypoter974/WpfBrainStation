using CL.BS.Common;
using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class NumberStructureExerciseVM1: NumberStructureExerciseVM, IPageVM
    {
        public override string Name =>nameof(NumberStructureExerciseVM1);

        void IPageVM.load()
        {
            UrlPlay = string.Empty;
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\NumberStructure\messageExercise.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            _logic.SetGroup(1);
            new Thread(new ThreadStart(() =>
            {
                PlayList(new string[] { Common.StaticVar.inline.PlayName(),
(Common.StaticVar.inline.IsBoy ? @"Resources\Audio\He\Sentences\A21.wav": @"Resources\Audio\He\Sentences\A22.wav")});
            })).Start();
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }
      public NumberStructureExerciseVM1() : base()
        {
            TypeNum = new RelayCommand(DoTypeNum);
            AddCake = new RelayCommand(DOAddCak);
        }

        private void DoTypeNum(object obj)
        {
            string nl = obj.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < Result.Length - 1; i++)
                    ns += Result[i];
                Result = ns;
            }
            else
            {
                Result += nl;
            }
            for (int i = 0; i < 2; i++)
            {
                if (i < Result.Length)
                    _resList[i].Background = Result[i].ToString();
                else
                    _resList[i].Background = String.Empty;
            }
            for (int i = 0; i < 2; i++)
                NotifyPropertyChanged("TBRes" + i);
        }

        protected void DOAddCak(object obj)
        {
            if (_lockCack)
                return;
            UrlPlay = String.Empty;
            UrlPlay = String.Format(@"{0}\Resources\Audio\Music\do.wav", System.AppDomain.CurrentDomain.BaseDirectory);
            if (!base.IsQuestionMode)
            {
                int i = int.Parse(obj.ToString());
                if (cakesNum[i] < 9 || (i == 1 && cakesNum[i] < 10))
                {
                    int n = i * 10 + cakesNum[i];
                    Cakes[n].Background = String.Format(@"{0}Resources\Math\NumberStructure\cake{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, i);
                    string tn = n < 10 ? "0" + n : n.ToString();
                    NotifyPropertyChanged("cake" + tn);
                    cakesNum[i]++;
                }
                else if (i == 0 && cakesNum[i + 1] < 10)
                {
                    new Thread(new ThreadStart(() =>
                    {
                        RectVisibility0 = "Visible";
                        NotifyPropertyChanged(nameof(RectVisibility0));
                        _lockCack = true;
                        int n = i * 10 + cakesNum[i];
                        string tn = n < 10 ? "0" + n : n.ToString();
                        Cakes[n].Background = String.Format(@"{0}Resources\Math\NumberStructure\cake{1}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, i);
                        NotifyPropertyChanged("cake" + tn);
                        cakesNum[i]++;
                        Thread.Sleep(1000);
                        for (int l = 0; l < 10; l++)
                            DoSubCake(i);
                        _lockCack = false;
                        DOAddCak(i + 1);
                        RectVisibility0 = "Collapsed";
                        NotifyPropertyChanged(nameof(RectVisibility0));
                    })).Start();
                }
            }
        }
    }
}
