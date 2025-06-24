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
    /// Interaction logic for UCBoardMathExRecognaz10.xaml
    /// </summary>
    public partial class UCBoardMathExRecognaz10 : UserControl
    {
        public UCBoardMathExRecognaz10()
        {
            InitializeComponent();
            this.DataContext = new CL.BS.MathLearningVM.VM.Recognaz.BoardMathExRecognaz10VM();
        }
    }
}
