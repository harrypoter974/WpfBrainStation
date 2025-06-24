using CL.BS.MathLearningVM.WritingNumbers;
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

namespace BS.MathLearningView.Game
{
    /// <summary>
    /// Interaction logic for UCBord6x6.xaml
    /// </summary>
    public partial class UCBordWritingNumber : UserControl
    {
        public UCBordWritingNumber()
        {
            InitializeComponent();
            this.DataContext = new BordWritingNumberVM();
        }
    }
}
