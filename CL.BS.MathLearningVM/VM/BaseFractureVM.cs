using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.MathLearningVM.VM
{
    public abstract class BaseFractureVM : BaseCalculationVM
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public string     LNum1         { get; set; }
        public string     LNumFMone1    { get; set; }
        public string     LNumFMechane1 { get; set; }
        public Visibility Line1         { get; set; }
        public string     LOperator     { get; set; }
        public string     LNum2         { get; set; }
        public string     LNumFMone2    { get; set; }
        public string     LNumFMechane2 { get; set; }
        public Visibility Line2         { get; set; }
        public string     LNum       { get; set; }
        public string     LNumMone   { get; set; }
        public string     LNumMachne { get; set; }
        private LetterObject[] _numBord = new LetterObject[4];
        public Visibility NumBord0 { get { return _numBord[0].visibility; } set { _numBord[0].visibility = value; } }
        public Visibility NumBord1 { get { return _numBord[1].visibility; } set { _numBord[1].visibility = value; } }
        public Visibility NumBord2 { get { return _numBord[2].visibility; } set { _numBord[2].visibility = value; } }
        public Visibility NumBord3 { get { return _numBord[3].visibility; } set { _numBord[3].visibility = value; } }
        private string _taxtQes;
        private readonly string _pathNum = System.AppDomain.CurrentDomain.BaseDirectory +  @"Resources\Math\NumLetters\";
        public string BoyName { get; set; }
        public string GirlName { get; set; }
        public string BoyPic { get; set; }
        public string GirlPic { get; set; }

        public BaseFractureVM(Common.StaticVar.ArithmeticType type) : base(type) {
            for (int i = 0; i < _numBord.Length; i++)
                _numBord[i] = new LetterObject() { visibility=Visibility.Collapsed};

            TypeNum = new RelayCommand(FractureTypeNum);
        }

        private void FractureTypeNum(object obj)
        {
            string nl = obj.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < Result.Length - 1; i++)
                    ns += Result[i];
                Result = ns;
            }
            else if (Result.Length < 3)
            {
                Result += nl;
            }
            if (Result.Length == 3)
            {
                LNum = Result[0].ToString();
                LNumMone = Result[1].ToString();
                LNumMachne = Result[2].ToString();
            }
            else if (Result.Length == 2)
            {
                LNum = Result[0].ToString();
                LNumMone = Result[1].ToString();
                LNumMachne = string.Empty;
            }
            else if (Result.Length == 1)
            {
                LNum = Result[0].ToString();
                LNumMone = LNumMachne = string.Empty;
            }
            else
            {
                LNum = LNumMone = LNumMachne = string.Empty;
            }
            NotifyPropertyChanged("LNum");
            NotifyPropertyChanged("LNumMone");
            NotifyPropertyChanged("LNumMachne");
        }

        internal void SetQuestion(float[] num)
        {
         Result = LNum1 = LNumFMone1 = LNumFMechane1 = string.Empty;       
        NotifyPropertyChanged("LNum1");
        NotifyPropertyChanged("LNumFMone1");
        NotifyPropertyChanged("LNumFMechane1");
        string Operator=GetOperatorChar();
            _taxtQes = num[0] + Operator + num[1];
            string[] stringNum = num[0].ToString().Split('.');

            if (num[0] >= 1)
            {
                LNum1 = _pathNum + stringNum[0] + ".png";
            }
            else
                LNum1 =string.Empty;
            Line1 = Visibility.Visible;
            if (stringNum.Length > 1)
            {
                string numFMone1;
                switch (stringNum[1])
                {//
                    case "25": numFMone1 = "14"; ; break;
                    case "5":  numFMone1 = "12"; ; break;
                    case "75": numFMone1 = "34"; ; break;
                    default:
                        numFMone1 = string.Empty;
                        Line1 = Visibility.Collapsed;
                        break;
                }
                if (numFMone1 != string.Empty)
                {
                    LNumFMone1 = _pathNum + numFMone1[0] + ".png";
                    LNumFMechane1  = _pathNum + numFMone1[1] + ".png";
                }

            }
            else
            {
                LNumFMone1 = LNumFMechane1 = string.Empty;
            }
            LOperator = _pathNum + Operator + ".png";
            stringNum = num[1].ToString().Split('.');
            if (num[1]>= 1)
            {
                LNum2 = _pathNum + stringNum[0] + ".png";
            }
            else
                LNum2 =string.Empty;
            if (stringNum.Length > 1)
            {
                string numFMone2;
                Line2 = Visibility.Visible;
                switch (stringNum[1])
                {//
                    case "25": numFMone2 = "14"; break;
                    case "5": numFMone2 = "12"; break;
                    case "75": numFMone2 = "34"; break;
                    default:
                        Line2 = Visibility.Collapsed;
                        numFMone2 = string.Empty;
                        break;
                }
                if (numFMone2 != string.Empty)
                {
                    LNumFMone2 = _pathNum + numFMone2[0] + ".png";
                    LNumFMechane2 = _pathNum + numFMone2[1] + ".png";
                }
            }
            NotifyPropertyChanged("LNum1");
            NotifyPropertyChanged("LNumFMone1");
            NotifyPropertyChanged("LNumFMechane1");
            NotifyPropertyChanged("Line1");
            NotifyPropertyChanged("LOperator");
            NotifyPropertyChanged("LNum2");
            NotifyPropertyChanged("LNumFMone2");
            NotifyPropertyChanged("LNumFMechane2");
            NotifyPropertyChanged("Line2");

        }

        protected void SetAnswer(float answer)
        {
            if (answer == -1)
            {
                LNum = LNumMone = LNumMachne = string.Empty;
            }
            else
            {
                string[] r = answer.ToString().Split('.');
                if (r.Length == 1)
                {
                    r = new string[] { r[0], string.Empty };
                }
                else
                {
                    switch (r[1])
                    {
                        case "75": r[1] = "34"; break;
                        case "5":  r[1] = "12"; break;
                        case "25": r[1] = "14"; break;
                        default:
                            break;
                    }
                }
                new Thread(new ThreadStart(() =>
                {
                 
                    if (Result == r[0]+r[1])
                    {
                        PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                            @"Resources\Audio\He\Good\Win" + _ran.Next(8) + ".wav" });
                    }
                    else
                    {
                        PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                        @"Resources\Audio\He\Bad\Error" + _ran.Next(3) + ".wav" });
                    }
                })).Start();
                string[] a = answer.ToString().Split('.');
                if (answer >= 1)
                {
                    LNum = a[0].ToString();
                }
                else
                    LNum = string.Empty;
                if (a.Length > 1)
                {
                    string numFMone;
                    switch (a[1])
                    {//
                        case "25": numFMone = "14"; ; break;
                        case "5": numFMone = "12"; ; break;
                        case "75": numFMone = "34"; ; break;
                        default:
                            numFMone = string.Empty;
                            Line1 = Visibility.Collapsed;
                            break;
                    }
                    if (numFMone != string.Empty)
                    {
                        LNumMone = numFMone[0].ToString() ;
                        LNumMachne = numFMone[1].ToString() ;
                    }

                }
                else
                {
                    LNumMone = LNumMachne = string.Empty;
                }
            }
            NotifyPropertyChanged("LNum");
            NotifyPropertyChanged("LNumMone");
            NotifyPropertyChanged("LNumMachne");
        }
        protected void SetBord(LetterObject[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                _numBord[i] = list[i];
                NotifyPropertyChanged("NumBord" + i);
            }
        }


        private string GetOperatorChar()
        {
            switch (_type)
            {
                case Common.StaticVar.ArithmeticType.Add:
                    return "+";
                case Common.StaticVar.ArithmeticType.Moltipol:
                    return "x";
                case Common.StaticVar.ArithmeticType.Sub:
                    return "-";
                case Common.StaticVar.ArithmeticType.Splite:
                    return "s";
                default:
                    return "";
            };
        }

        protected void SetName()
        {
            if (string.IsNullOrEmpty(Common.StaticVar.inline.Name))
            {
                BoyName = "הלל";
                GirlName = "יעל";
                GirlPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GirlImage.png" ;
                BoyPic = System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\BS.Items\BoyImage.png";
            }
            else if (Common.StaticVar.inline.IsBoy)
            {
                BoyName = Common.StaticVar.inline.Name.Replace("Nickname\\", string.Empty);
                GirlName = "יעל";
                GirlPic = System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\BS.Items\GirlImage.png";
                BoyPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\BoyImage.png" ;
            }
            else
            {
                BoyName = Common.StaticVar.inline.Name.Replace("Nickname\\", string.Empty);
                GirlName = "הלל";
                GirlPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\BoyImage.png" ;
                BoyPic = System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\BS.Items\GirlImage.png";
            }
            NotifyPropertyChanged("BoyName");
            NotifyPropertyChanged("GirlName");
            NotifyPropertyChanged("BoyPic");
            NotifyPropertyChanged("GirlPic");
        }
    }
}
