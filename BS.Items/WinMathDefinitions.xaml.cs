﻿using BS.Items.VM;
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

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for WinMathDefinitions.xaml
    /// </summary>
    public partial class WinMathDefinitions : Window
    {
        public WinMathDefinitions(object type)
        {
            InitializeComponent();
            this.DataContext = new MathDefinitionsVM(type);
        }

        private void labelClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
