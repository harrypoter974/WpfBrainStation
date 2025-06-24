using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class RecognaseLeters3VM : BaseLernPage, IPageVM
    {
        public ICommand SetDomain { get; set; }
        public string SetDomainBack { get; set; }
        public List<LetterObject> LstProduct { get; set; }
        private IRecognaseLeters3Manager _logic = (IRecognaseLeters3Manager)
SupportHandlerManager.Base.GetManager("RecognaseLeters3Manager");
        public override string Name
        {
            get
            {
                return "RecognaseLeters3VM";
            }
        }

        public RecognaseLeters3VM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetDomain= new RelayCommand(DoSetDomain);
        }

        private void DoSetDomain(object obj)
        {
            SetDomainBack = _logic.SetDomain(obj);
            NotifyPropertyChanged("SetDomainBack");
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Niqqud\message3.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            new Thread(new ThreadStart(() =>
            {
            PlayList(_logic.GetInstructions());
            })).Start();
            LstProduct = new List<LetterObject>();
            NotifyPropertyChanged("LstProduct");
            SetDomainBack = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Letters\open.png";
            NotifyPropertyChanged("SetDomainBack");
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                LstProduct =_logic.SetQuestion();
            }
            else
            {
                string s = "";
                LstProduct = _logic.GetAnswer(ref s);
                new Thread(new ThreadStart(() =>
                { 
                PlayUrl(s);
                })).Start();
            }
            base.SwitchAnswerButton();
            NotifyPropertyChanged("LstProduct");
        }
    }
}
