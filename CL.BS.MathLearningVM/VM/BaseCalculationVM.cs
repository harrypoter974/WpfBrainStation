using BS.Items;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM
{
    public abstract class BaseCalculationVM : BaseLernPage
    {
        protected string[] Limit = new string[] { "10", "20", "30" };
        public ICommand ChangeLimit { get; set; }
        protected bool InProses = false;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        protected Common.StaticVar.ArithmeticType _type;
        public string TAnswer2 { get; set; }
        public string TAnswer1 { get; set; }
        public string AnswerPic1 { get; set; }
        public string AnswerPic2 { get; set; }
        public List<LetterObject> LstNum { get; set; }
        public string AnswerVisibility { get; set; }
        public ICommand TypeNum { get; set; }
        public ICommand OpenDefinitions { get; set; }
        public string LevelBut0 { get { return LevelButs[0].Background; } set { LevelButs[0].Background = value; } }
        public string LevelBut1 { get { return LevelButs[1].Background; } set { LevelButs[1].Background = value; } }
        public string LevelBut2 { get { return LevelButs[2].Background; } set { LevelButs[2].Background = value; } }
        protected LetterObject[] LevelButs = new LetterObject[3];
        protected string Result = string.Empty;

        public BaseCalculationVM(Common.StaticVar.ArithmeticType type)
        {
            _type = type;
            OpenDefinitions = new RelayCommand(DoOpenDefinitions);
            ChangeLimit = new RelayCommand(DoChangeLimit);
            for (int i = 0; i < LevelButs.Length; i++)
                LevelButs[i] = new LetterObject();
            KeyboardVisibility = Visibility.Hidden;
            NotifyPropertyChanged("KeyboardVisibility");
            TypeNum = new RelayCommand(DoTypeNum);
        }


        private void DoTypeNum(object num)
        {
            string nl = num.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < Result.Length - 1; i++)
                    ns += Result[i];
                Result = ns;
                if (Result.Length == 1)
                {
                    TAnswer2 = Result[0].ToString();
                    TAnswer1 = string.Empty;
                }
                else
                {
                    TAnswer2 = TAnswer1 = string.Empty;
                }
                NotifyPropertyChanged(nameof(TAnswer2));
                NotifyPropertyChanged(nameof(TAnswer1));
            }
            else
            {
                if ((Result.Length == 0))
                {
                    TAnswer2 = nl;
                    NotifyPropertyChanged(nameof(TAnswer2));
                }
                else if ((Result.Length == 1))
                {
                    TAnswer1 = nl;
                    NotifyPropertyChanged(nameof(TAnswer1));
                }
                Result += nl;
            }
        }
        public override void CardAnswer()
        {
            if (Result.Length < 2)
            {
                Result += TextCard;
            }
            if (Result.Length == 2)
            {
                TAnswer2 = Result[0].ToString();
                TAnswer1 = Result[1].ToString();
            }
            else if (Result.Length == 1)
            {
                TAnswer2 = Result[0].ToString();
                TAnswer1 = string.Empty;
            }
            else
            {
                TAnswer2 = TAnswer1 = string.Empty;
            }
            NotifyPropertyChanged("TAnswer2");
            NotifyPropertyChanged("TAnswer1");
        }
        protected void DoChangeLimit(object obj)
        {
            LevelButs[Common.StaticVar.inline.DomainNumIndex].Background = string.Empty;
            NotifyPropertyChanged("LevelBut" + Common.StaticVar.inline.DomainNumIndex);
            string num = obj.ToString();
            Common.StaticVar.inline.DomainNumIndex =int.Parse( num);
            LevelButs[Common.StaticVar.inline.DomainNumIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Number\m" + Limit[Common.StaticVar.inline.DomainNumIndex] + ".png";
            NotifyPropertyChanged("LevelBut" + num);
        }

        protected void load()
        {
            base.Settings();
            TAnswer2 = TAnswer1 = string.Empty;
            LstNum = new List<LetterObject>();
            NotifyPropertyChanged("LstNum");
            NotifyPropertyChanged("TAnswer2");
            NotifyPropertyChanged("TAnswer1");
            DoChangeLimit(0);
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Lang\He\Niqqud\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            InProses = false;
        }

        protected void CheckResult(string answer)
        {
            new Thread(new ThreadStart(() =>
            {
                InProses = true;
                if (Result == answer)
                {
                    PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                            @"Resources\Audio\He\Good\Win" + _ran.Next(8) + ".wav" });
                }
                else
                {
                    PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                        @"Resources\Audio\He\Bad\Error" + _ran.Next(3) + ".wav" });
                }
                Thread.Sleep(2000);
                TAnswer2 = TAnswer1 = string.Empty;
                LstNum = new List<LetterObject>();
                NotifyPropertyChanged("LstNum");
                NotifyPropertyChanged("TAnswer2");
                NotifyPropertyChanged("TAnswer1");

                InProses = false;
            })).Start();
        }

        private void DoOpenDefinitions(object type)
        {
            new WinMathDefinitions(type).Show();
        }

        protected void SetAnswerBord(int numLength)
        {
            //string type = Common.GlobalVar.EnterType.CARD ==   Common.StaticVar.inline.enterType? "Num" : "Write";
            if (numLength==1)
            {
                AnswerPic1 = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Math\Board1.jpg";
               
            }
            else
            {//
                AnswerPic1 = string.Empty;
                //AnswerPic1 = System.AppDomain.CurrentDomain.BaseDirectory
                //   + @"Resources\BS.Items\Write1.png";
                //AnswerPic2 = string.Empty;
            }
            NotifyPropertyChanged(nameof(AnswerPic1));
           // NotifyPropertyChanged(nameof(AnswerPic2));
        }
    }
}
