﻿using System;
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

namespace WpfBrainStation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// https://www.tutorialspoint.com/svn/svn_life_cycle.htm
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void labelNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new WindowBase().Show();
            Close();
        }
    }
}
