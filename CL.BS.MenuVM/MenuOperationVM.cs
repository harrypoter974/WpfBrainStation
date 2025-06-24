using BS.Items;
using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuOperationVM : BaseMenuVM, IPageVM
    {
        private const string CODE_TRUE = "11423";
        private const string CODE_GAME = "1324";
        string FILE_NAME = @"C:\bs\passwordText.txt";
        private int _fillExperience = 0;
        private const string MESSAGE0="מעבר לכניסה עם קוד", MESSAGE1 = "הכנסת קוד כניסה", MESSAGE2= "הכנסת קוד כניסה שניית";
        public string passwordText0 { get; set; }
        public string passwordText1 { get; set; }
        private string Password = String.Empty;
        public string BackgroundError { get; set; }
        public string MessageText { get; set; }
        public string Visibility { get; set; }
        private string _mCodeTad, _gCodeTad, _wCodeTad, _kCodeTad;
        private bool _miceNotOpen;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public string Button0 { get { return Buttons[0].Background; } set { Buttons[0].Background = value; } }
        public string Button1 { get { return Buttons[1].Background; } set { Buttons[1].Background = value; } }
        public string Button2 { get { return Buttons[2].Background; } set { Buttons[2].Background = value; } }
        public string Button3 { get { return Buttons[3].Background; } set { Buttons[3].Background = value; } }
        protected LetterObject[] Buttons = new LetterObject[4];
        public string OpenTeamViewerBut { get; set; }
        public string ButSaveMice { get; set; }
        public ICommand LockTopics { get; set; }
        public ICommand Control { get; set; }
        public ICommand Working { get; set; }
        public ICommand MiceToKill { get; set; }
        public ICommand GoToInDevelopment { get; set; }
        public ICommand Download { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Enter { get; set; }
        public ICommand TypeNum { get; set; }
        public override string Name => "MenuOperationVM";

        private DateTime dateTime = DateTime.Now.AddHours(-5);
        public MenuOperationVM()
        {
            Control = new RelayCommand(goToControl);
            Delete = new RelayCommand(DoDelete);
            LockTopics = new RelayCommand(DoLockTopics);
            GoToInDevelopment = new RelayCommand(DoGoToInDevelopment);
            Working = new RelayCommand(DoWorking);
            Download = new RelayCommand(DoDownload);
            for (int i = 0; i < Buttons.Length; i++)
                Buttons[i] = new LetterObject();
            TypeNum = new RelayCommand(DoTypeNum);
            Enter = new RelayCommand(DoEnter);
            BackgroundError = "White";
            NotifyPropertyChanged(nameof(BackgroundError));
            if (!File.Exists(FILE_NAME))
                File.WriteAllText(FILE_NAME, string.Empty);
            string[] t = File.ReadAllText(FILE_NAME).Split('#');
            Password = t[0];
            MessageText = MESSAGE0;
            NotifyPropertyChanged(nameof(MessageText));
        }

        private void DoDelete(object obj)
        {
            switch (obj.ToString()[0])
            {
                case 'g': _gCodeTad = String.Empty; break;
                case 'w': _wCodeTad = String.Empty; break;
                case 'm': _mCodeTad = String.Empty; break;
                default:
                    break;
            }
        }

        private void DoEnter(object obj)
        {
            if (dateTime  < DateTime.Now.AddHours(-4))
            {
                if (Password == passwordText0)
                {
                    if (MessageText == MESSAGE0)
                    {
                        MessageText = MESSAGE1;
                        NotifyPropertyChanged(nameof(MessageText));
                        passwordText0 = String.Empty;
                        NotifyPropertyChanged(nameof(passwordText0));

                    }
                }
                else
                {
                    if (MessageText == MESSAGE0)
                    {
                        _fillExperience++;
                        if (_fillExperience == 3)
                        {
                            BackgroundError = "Transparent";
                            NotifyPropertyChanged(nameof(BackgroundError));
                            dateTime = DateTime.Now;
                            new Thread(new ThreadStart(() =>
                            {
                                Thread.Sleep(1000*60*4); 
                                _fillExperience = 0;
                                BackgroundError = "White";
                                NotifyPropertyChanged(nameof(BackgroundError));
                            })).Start();
                        }
                    }
                   else  if (MessageText == MESSAGE1)
                    {
                        MessageText = MESSAGE2;
                        NotifyPropertyChanged(nameof(MessageText));
                    }
                    else if (MessageText == MESSAGE2)
                    {
                        Password = passwordText0;
                        File.WriteAllText(FILE_NAME, Password);
                        MessageText = "הסיסמה שונתה בהצלחה";
                        NotifyPropertyChanged(nameof(MessageText));
                        new Thread(new ThreadStart(() =>
                        {
                            Thread.Sleep(3000);
                               MessageText = MESSAGE0;
                            NotifyPropertyChanged(nameof(MessageText));
                            passwordText0 = String.Empty;
                            NotifyPropertyChanged(nameof(passwordText0));
                        })).Start();
                    }
                }            
            }
        }


        private void DoTypeNum(object obj)
        {
            string l = obj.ToString();
            if (l[1] != 'd') 
            {
                if(l[0]=='a')
                    passwordText0 += l[1];
                else
                    passwordText1 += l[1];
            }
            else
            {
                string t = string.Empty;
                if (l[0] == 'a')
                {
                    for (int i = 0; i < passwordText0.Length - 1; i++)
                        t += passwordText0[i];
                    passwordText0 = t;
                }
                else
                {
                    for (int i = 0; i < passwordText1.Length - 1; i++)
                        t += passwordText1[i];
                    passwordText1 = t;
                }
            }
            NotifyPropertyChanged("passwordText"+(l[0] == 'a'?0:1));
        }
        void IPageVM.disload()
        {
            if (!_miceNotOpen)
            {
                CL.BS.Common.MiceKiller.KillAllMices(false);
                keybd_event((byte)Keys.E, 0, 0, 0);
                //Common.RestoresMice.SaveMice();

            }
        }

        void IPageVM.load()
        {
            Settings();
            _miceNotOpen = true;
            _wCodeTad = _mCodeTad = _gCodeTad= _kCodeTad = string.Empty;
            OpenTeamViewerBut = "White";
            NotifyPropertyChanged("OpenTeamViewerBut");
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].Background = string.Empty;
                NotifyPropertyChanged("Button" + i);
            }
            passwordText0 = passwordText1 =string.Empty;
            NotifyPropertyChanged(nameof(passwordText0));
            NotifyPropertyChanged(nameof(passwordText1));
        }

        private void DoWorking(object obj)
        {
           if (CODE_TRUE == _wCodeTad)
                keybd_event((byte)System.Windows.Forms.Keys.E, 0, 0, 0);
        }

        private void DoGoToInDevelopment(object obj)
        {
            if (CODE_TRUE == _gCodeTad)
                DoGoToPage("MenuPuzzlesVM");
        }


        private void goToControl(object obj)
        {
            if (_miceNotOpen && CODE_GAME == _mCodeTad)
            {
                DoGoToPage("MenuControlVM");
            }
        }
        private void DoLockTopics(object obj)
        {
            string s = obj.ToString();
            if (s[0] == 'k') {
                _kCodeTad += s[1];
                if (CODE_GAME == _kCodeTad)
                {
                    Buttons[0].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\OpenButton.png";
                    NotifyPropertyChanged(nameof(Button0) );
                }
            }         
            else if (s[0] == 'w') {
                _wCodeTad += s[1];
                if (CODE_TRUE == _wCodeTad)
                {
                    Buttons[1].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\OpenButton.png";
                    NotifyPropertyChanged(nameof(Button1));
                    OpenTeamViewerBut = "Transparent";
                    NotifyPropertyChanged("OpenTeamViewerBut");
                }
            }
            else    if (s[0] == 'm')
            {
                _mCodeTad += s[1];
                if (CODE_GAME == _mCodeTad)
                {
                    Buttons[0].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\OpenButton.png";
                    NotifyPropertyChanged(nameof(Button0));
                }
            }
            else if (s[0] == 'g')
            {
                _gCodeTad += s[1];
                if (CODE_TRUE == _gCodeTad)
                {
                    Buttons[2].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\OpenButton.png";
                    NotifyPropertyChanged(nameof(Button2) );
                }
            }
        }

        private void DoMiceToKill(object obj)
        {
            if (CODE_TRUE == _kCodeTad)
            {
                CL.BS.Common.MiceKiller.KillAllMices(true);
                new WinMiceKiller().ShowDialog();
                CL.BS.Common.MiceKiller.KillAllMices(false);
            }
        }
        /*
        */
        private void DoDownload(object obj)
        {
            System.Windows.Application.Current.Shutdown();

            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\AnyDesk\\AnyDesk.exe");
            //new Thread(new ThreadStart(() =>
            //{
            //    ButSaveMice = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButSaveMice.jpg";
            //    NotifyPropertyChanged("ButSaveMice");
            //    Common.RestoresMice.restoresMice();
            //    Thread.Sleep(200);
            //    ButSaveMice = "";
            //    NotifyPropertyChanged("ButSaveMice");
            //})).Start();
        }
    }
}
