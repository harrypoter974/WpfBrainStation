using CL.BS.MathLearningVM.Recognaz;
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

namespace BS.MathLearningView.Recognaz
{
    /// <summary>
    /// Interaction logic for UCBordMathRecognaz2.xaml
    /// </summary>
    public partial class UCBordMathRecognaz2 : UserControl
    {
        public UCBordMathRecognaz2()
        {
            InitializeComponent();
            this.DataContext = new BordMathRecognaz2VM();
        }
    }
}
