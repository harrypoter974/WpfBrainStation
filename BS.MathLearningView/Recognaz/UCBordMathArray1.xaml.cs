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

namespace BS.MathLearningView.Recognaz
{
    /// <summary>
    /// Interaction logic for UCBordMathArray1.xaml
    /// </summary>
    public partial class UCBordMathArray1 : UserControl
    {
        public UCBordMathArray1()
        {
            InitializeComponent();
            this.DataContext = new CL.BS.MathLearningVM.VM.Recognaz.BordMathArray1VM();
        }
    }
}
