using CL.BS.Common;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BS.BaseWin
{
    /// <summary>
    /// Interaction logic for WinNicknames.xaml
    /// </summary>
    public partial class WinNicknames : Window
    {
        public WinNicknames(global::MultipleMice.MouseSplitter win)
        {
            window = win;
            DataContext = new WinNicknamesVM(win);
            InitializeComponent();
        }
        protected MouseSplitter window;
        //protected string Rotation;
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (Label)sender;
            string name = l.Content.ToString();
            switch (window.currentMouse.Rotation.ToString())
            {
                case "A": StaticVar.NicknameA = name; l.Background = Brushes.Green; break;
                case "B": StaticVar.NicknameB = name; l.Background = Brushes.Yellow; break;
                case "C": StaticVar.NicknameC = name; l.Background = Brushes.Blue; break;
                case "D": StaticVar.NicknameD = name; l.Background = Brushes.Red; break;
                default:
                    break;
            }
        }

        private void ButHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
