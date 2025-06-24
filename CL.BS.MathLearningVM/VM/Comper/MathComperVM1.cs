using CL.BS.Contract;
using CL.BS.MathLearningVM.Comper;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.MathLearningVM.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public  class MathComperVM1: BaseMathComperVM, IPageVM
    {
        public Visibility Fish0 { get { return _listFishs[0].visibility; } set { _listFishs[0].visibility = value; } }
        public Visibility Fish1 { get { return _listFishs[1].visibility; } set { _listFishs[1].visibility = value; } }
        public Visibility Fish2 { get { return _listFishs[2].visibility; } set { _listFishs[2].visibility = value; } }
        public Visibility Fish3 { get { return _listFishs[3].visibility; } set { _listFishs[3].visibility = value; } }
        public Visibility Fish4 { get { return _listFishs[4].visibility; } set { _listFishs[4].visibility = value; } }
        public Visibility Fish5 { get { return _listFishs[5].visibility; } set { _listFishs[5].visibility = value; } }
        public Visibility Fish6 { get { return _listFishs[6].visibility; } set { _listFishs[6].visibility = value; } }
        public Visibility Fish7 { get { return _listFishs[7].visibility; } set { _listFishs[7].visibility = value; } }
        public Visibility Fish8 { get { return _listFishs[8].visibility; } set { _listFishs[8].visibility = value; } }
        public Visibility Fish9 { get { return _listFishs[9].visibility; } set { _listFishs[9].visibility = value; } }
        private List<LetterObject> _listFishs;
        public override string Name => "MathComperVM1";

        void IPageVM.load()
        {
            for (int i = 0; i < _listFishs.Count(); i++)
            {
                _listFishs[i].visibility = Visibility.Visible;
                NotifyPropertyChanged("Fish" + i);
            }
            base.ComperLoad();
        }

        public MathComperVM1()
        {
            _listFishs = new List<LetterObject>();
            for (int i = 0; i < 10; i++)
                _listFishs.Add(new LetterObject() { visibility = Visibility.Visible });
        }

        public override void AskQuestion()
        {
            if (Common.StaticVar.PlayMode)
                return;
           
            if (base.IsQuestionMode)
            {
                if (GoNext())
                    return;
                QuestionPlay();
                bool[] fishList = _logic.GetFish();
                TextResult = string.Empty;
                for (int i = 0; i < fishList.Length; i++)
                {
                    _listFishs[i].visibility = fishList[i] ? Visibility.Visible : Visibility.Hidden;
                    NotifyPropertyChanged("Fish" + i);
                }
            }
            else
            {
                TextResult = _logic.GetFishAns();
            }
            base.SwitchAnswerButton();
            NotifyPropertyChanged("TextResult");
        }
    }
}
