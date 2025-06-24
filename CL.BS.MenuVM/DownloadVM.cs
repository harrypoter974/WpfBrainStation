using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class DownloadVM : BaseMenuVM, IPageVM
    {
        public override string Name => "DownloadVM";
        public string textPassword { get; set; }
        public string OpenWeb { get; set; }
        public ICommand OpenTeamViewer { get; set; }
        public ICommand TapLetter { get; set; }
        public DownloadVM()
        {
            OpenTeamViewer = new RelayCommand(DoOpenTeamViewer);
            TapLetter = new RelayCommand(DoTapLetter);
        }

        void IPageVM.load()
        {
            Settings();
            textPassword = string.Empty;
            NotifyPropertyChanged("textPassword");
            OpenWeb = "Hidden";
            NotifyPropertyChanged("OpenWeb");
        }
        private void DoTapLetter(object obj)
        {
            if (obj.ToString() == "e"&& Common.GeneralFunctions.CheckePassword(textPassword))
            {
                OpenWeb = "Visible";
                NotifyPropertyChanged("OpenWeb");
            }
            else if (obj.ToString() == "d")
            {
                string s = string.Empty;
                for (int i = 0; i < textPassword.Length - 1; i++)
                    s += textPassword[i];
                if (textPassword.Length > 0)
                    textPassword = textPassword.Remove(textPassword.Length - 1, 1); ;
            }
            else
            {
                textPassword += obj;
            }
            NotifyPropertyChanged("textPassword");
        }

        private void DoOpenTeamViewer(object obj)
        {
            if (!textPassword.Contains("0523685822"))
                return;
            try
            {
                Process my = Process.GetCurrentProcess();
                Process.Start(@"C:\Program Files (x86)\AnyDesk\AnyDesk.exe");
                Process.Start(System.IO.Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
                my.Kill();

                CL.BS.Common.StaticVar.inline.SaveGameData();
                CL.BS.Common.MiceKiller.KillAllMices(true);
                CL.BS.Common.StaticVar.inline.SaveGameData();
                //
                //string text = System.IO.File.ReadAllText(@"C:\bs\TeamViewer.txt");
                //System.Diagnostics.Process.Start(text);
            }
            catch (Exception)
            {
            }
        }
    }
}
