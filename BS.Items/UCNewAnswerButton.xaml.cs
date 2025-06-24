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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for UCNewAnswerButton.xaml
    /// </summary>
    public partial class UCNewAnswerButton : UserControl
    {
        public bool IsStarte = true;
        private int NumAttempts;
        private const int MAXNumAttempts = 1;
        public UCNewAnswerButton()
        {
            InitializeComponent();
            SetBackground();
        }

        public void Refresh()
        {
            IsStarte = true;
            NumAttempts = 0;
            SetBackground();
        }
        private void SetBackground()
        {
            string myUrl = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\BS.Items\Button" + "GV"[IsStarte ? 0 : 1];
            Background = new ImageBrush(new BitmapImage(new Uri(myUrl))) {
                Stretch = Stretch.Fill };
        }

        internal void SetStart()
        {
            IsStarte = false;
            SetBackground();
        }

        private void LRed_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsStarte = !IsStarte;
            SetBackground();
        }
    }
}
