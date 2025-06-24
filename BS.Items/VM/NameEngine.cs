using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BS.Items.VM
{
    class NameEngine
    {
        private System.Windows.Media.Brush _back;
        private Thickness _thick = new Thickness(5);

        public NameEngine()
        {
            _back = new ImageBrush(new BitmapImage(new Uri(
                                   System.AppDomain.CurrentDomain.BaseDirectory +
                                   @"Resources\BS.Items\beackPic.jpg")));
        }

        internal List<Button> GetName(object letter)
        {
            List<Button> ls = new List<Button>();
            string[] nameList = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory +
                 "Resources\\Audio\\He\\Name\\" + StaticVar.SelectBoy);//(StaticVar.SelectBoy == "Boy" ? "Boy" : "Girl")
            for (int i = 0; i < nameList.Length; i++)
            {
                string[] name = nameList[i].Split('\\');
                if (name[name.Length - 1].Split('.')[0][0] == letter.ToString()[0])
                    ls.Add(new Button()
                    {
                        Content = name[name.Length - 1].Split('.')[0],
                        FontWeight = FontWeights.Bold,
                        BorderBrush = System.Windows.Media.Brushes.Transparent,
                        Padding = new Thickness(5),
                        Background = _back,
                        FontSize = 28,
                        Margin = _thick,
                        Width = 150
                    });
            }
            return ls;
        }
    }
}
