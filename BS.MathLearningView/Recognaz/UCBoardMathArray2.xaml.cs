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
    /// Interaction logic for UCBoardMathArray2.xaml
    /// </summary>
    public partial class UCBoardMathArray2 : UserControl
    {
        public UCBoardMathArray2()
        {
            InitializeComponent();
            this.DataContext = new CL.BS.MathLearningVM.VM.Recognaz.BoardMathArray2VM();
        }
    }
}
