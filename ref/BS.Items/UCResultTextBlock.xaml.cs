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
    /// Interaction logic for UCResultTextBlock.xaml
    /// </summary>
    public partial class UCResultTextBlock : UserControl
    {
        public UCResultTextBlock(int num = 1, bool IsCard = true)
        {
            InitializeComponent();
            int numSale;
            if (num >= 100)
                numSale = 3;
            else if (num >= 10)
                numSale = 2;
            else
                numSale = 1;
            ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(
                       System.AppDomain.CurrentDomain.BaseDirectory +
                       @"Resources\BS.Items\"
                       + (IsCard ? "Num" : "Write") + numSale + ".png")));
            Background = ib;
        }
        public void SetText(int ResultNum)
        {
            if (ResultNum < 10)
                TBResult.Text = ResultNum.ToString();
            else if (ResultNum < 100)
                TBResult.Text = ResultNum.ToString()[0] + "   " + ResultNum.ToString()[1];
            else
                TBResult.Text = ResultNum.ToString()[0] + "    " + ResultNum.ToString()[1] + "    " + ResultNum.ToString()[2];
        }
    }
}
