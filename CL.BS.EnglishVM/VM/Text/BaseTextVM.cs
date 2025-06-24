using BS.Items;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Text;
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

namespace CL.BS.EnglishVM.VM.Text
{
    public class BaseTextVM : BaseLernPage, IPageVM
    {
        public override string Name => "";
        public ICommand ChangeWord { get; set; }
        public ICommand SetLevel { get; set; }
        public ICommand OpenMenu { get; set; }
        public ICommand WritingFill { get; set; }
        public string PicBackground { get; set; }
        public int Speed { get; set; }
        public List<LetterObject> TBLine0 { get { return LineList[0]; } set { LineList[0] = value; } }
        public List<LetterObject> TBLine1 { get { return LineList[1]; } set { LineList[1] = value; } }
        public List<LetterObject> TBLine2 { get { return LineList[2]; } set { LineList[2] = value; } }
        public List<LetterObject> TBLine3 { get { return LineList[3]; } set { LineList[3] = value; } }
        public List<LetterObject> TBLine4 { get { return LineList[4]; } set { LineList[4] = value; } }
        public List<LetterObject> TBLine5 { get { return LineList[5]; } set { LineList[5] = value; } }
        public List<LetterObject> TBLine6 { get { return LineList[6]; } set { LineList[6] = value; } }
        public List<LetterObject> TBLine7 { get { return LineList[7]; } set { LineList[7] = value; } }
        public List<LetterObject> TBLine8 { get { return LineList[8]; } set { LineList[8] = value; } }
        protected List<LetterObject>[] LineList = new List<LetterObject>[9];
        public string LevelButton { get; set; }
        protected IEnTextManager _logic = (IEnTextManager)
   SupportHandlerManager.Base.GetManager("EnTextManager");

        public BaseTextVM()
        {
            WritingFill = new RelayCommand(DoWritingFill);
        }

        private void DoWritingFill(object obj)
        {
            System.Diagnostics.Process.Start("WpfAppTextWhiter.exe");
        }

        protected void SetText()
        {
            for (int i = 0; i < LineList.Length; i++)
                NotifyPropertyChanged("TBLine"+i);
        }

        protected void SetLevelBack(object level)
        {
            int l = int.Parse(level.ToString());
            LevelButton= System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\BS.Items\level" + l+".jpg";
            NotifyPropertyChanged(nameof(LevelButton));
        }

        internal void FillAnswerBut()
        {

            if (base.IsQuestionMode)
            {
                new Thread(new ThreadStart(() =>
                {
                    _logic.GetText(ref LineList, true);
                    SetText();
                    Thread.Sleep((int)(1000.0 * (2.1 - Speed)));
                    _logic.GetText(ref LineList, false);
                    SetText();
                })).Start();
            }
            else
            {
                _logic.GetText(ref LineList, true);
                SetText();
            }
            base.SwitchAnswerButton();
        }

        internal void OpenMenuWin(bool v)
        {
            if (!base.IsQuestionMode)
                return;
            WinEnTextMenu menu = new WinEnTextMenu(v);
            menu.ShowDialog();
            _logic.SetFill(menu.TextFile);
        }
    }
}
