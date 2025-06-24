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
    /// Interaction logic for UCFracture.xaml
    /// fix
    /// </summary>
    public partial class UCFracture : UserControl
    {
        private string TaxtQes;
        public UCFracture()
        {
            InitializeComponent();
        }
        //internal void SetText(float num1, string Operator, float num2)
        //{
        //    TaxtQes = num1 + Operator + num2;
        //    string[] stringNum = num1.ToString().Split('.');

        //    if (num1 >= 1)
        //    {
        //        LNum1.Source = new BitmapImage(new Uri(
        //             System.AppDomain.CurrentDomain.BaseDirectory +
        //             @"Resources\Learning\Math\NumLetters\" + stringNum[0] + ".png"));//.Content = ;
        //    }
        //    else
        //        LNum1.Source = new BitmapImage();
        //    if (stringNum.Length > 1)
        //    {
        //        string numFMone1;
        //        switch (stringNum[1])
        //        {//
        //            case "25": numFMone1 = "14"; ; break;
        //            case "5": numFMone1 = "12"; ; break;
        //            case "75": numFMone1 = "34"; ; break;
        //            default:
        //                numFMone1 = string.Empty;
        //                break;
        //        }
        //        if (numFMone1 != string.Empty)
        //        {
        //            LNumFMone1.Source = new BitmapImage(new Uri(
        //                                System.AppDomain.CurrentDomain.BaseDirectory +
        //                                @"Resources\Learning\Math\NumLetters\" + numFMone1[0] + ".png"));
        //            LNumFMechane1.Source = new BitmapImage(new Uri(
        //            System.AppDomain.CurrentDomain.BaseDirectory +
        //            @"Resources\Learning\Math\NumLetters\" + numFMone1[1] + ".png"));
        //        }

        //    }
        //    else
        //    {
        //        LNumFMone1.Source = new BitmapImage();
        //        LNumFMechane1.Source = new BitmapImage();
        //    }
        //    LOperator.Source = new BitmapImage(new Uri(
        //             System.AppDomain.CurrentDomain.BaseDirectory +
        //             @"Resources\Learning\Math\NumLetters\" + Operator + ".png"));// 
        //    stringNum = num2.ToString().Split('.');
        //    if (num2 >= 1)
        //    {
        //        LNum2.Source = new BitmapImage(new Uri(
        //             System.AppDomain.CurrentDomain.BaseDirectory +
        //             @"Resources\Learning\Math\NumLetters\" + stringNum[0] + ".png"));// stringNum[0];
        //    }
        //    else
        //        LNum2.Source = new BitmapImage();
        //    if (stringNum.Length > 1)
        //    {
        //        string numFMone2;
        //        switch (stringNum[1])
        //        {//
        //            case "25": numFMone2 = "14"; break;
        //            case "5": numFMone2 = "12"; break;
        //            case "75": numFMone2 = "34"; break;
        //            default:
        //                numFMone2 = string.Empty;
        //                break;
        //        }
        //        if (numFMone2 != string.Empty)
        //        {
        //            LNumFMone2.Source = new BitmapImage(new Uri(
        //                                System.AppDomain.CurrentDomain.BaseDirectory +
        //                                @"Resources\Learning\Math\NumLetters\" + numFMone2[0] + ".png"));
        //            LNumFMechane2.Source = new BitmapImage(new Uri(
        //            System.AppDomain.CurrentDomain.BaseDirectory +
        //            @"Resources\Learning\Math\NumLetters\" + numFMone2[1] + ".png"));
        //        }
        //    }
        //}

        internal string GetText()
        {
            return TaxtQes;
        }
    }
}
