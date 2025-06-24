using BS.Items.VM;
using CL.BS.Common;
using MultipleMice;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BS.Items
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
                case "A": StaticVar.inline.NicknameA = name; l.Background = Brushes.Green; break;
                case "B": StaticVar.inline.NicknameB = name; l.Background = Brushes.Yellow; break;
                case "C": StaticVar.inline.NicknameC = name; l.Background = Brushes.Blue; break;
                case "D": StaticVar.inline.NicknameD = name; l.Background = Brushes.Red; break;
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
