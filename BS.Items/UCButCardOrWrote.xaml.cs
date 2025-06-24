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
    /// Interaction logic for UCButCardOrWrote.xaml
    /// </summary>
    public partial class UCButCardOrWrote : UserControl
    {
        public bool IsCard = true;
        public UCButCardOrWrote()
        {
            InitializeComponent();
            //SetBackground();
        }

        //private void LBotton_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    IsCard = !IsCard;
        //    SetBackground();
        //}

        //private void SetBackground()
        //{
        //    string[] picName = { "Card.png", "Writing.png" };
        //    string myUrl = System.AppDomain.CurrentDomain.BaseDirectory
        //        + @"Resources\BS.Items\Button" + picName[IsCard ? 0 : 1];
        //    Background = new ImageBrush(new BitmapImage(new Uri(myUrl)));
        //}
    }
}
