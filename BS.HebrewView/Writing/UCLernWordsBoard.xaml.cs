using CL.BS.HebrewVM.VM.Writing;
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

namespace BS.HebrewView.Writing
{
    /// <summary>
    /// Interaction logic for UCLernWordsBoard.xaml
    /// </summary>
    public partial class UCLernWordsBoard : UserControl
    {
        public UCLernWordsBoard()
        {
            InitializeComponent();
            this.DataContext = new LernWordsBoardVM();
        }
    }
}
