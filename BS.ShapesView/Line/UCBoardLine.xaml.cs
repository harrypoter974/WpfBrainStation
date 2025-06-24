using CL.BS.ShapesVM.VM.Line;
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

namespace BS.ShapesView.Line
{
    /// <summary>
    /// Interaction logic for UCBoardLine.xaml
    /// </summary>
    public partial class UCBoardLine : UserControl
    {
        public UCBoardLine()
        {
            InitializeComponent();
            this.DataContext = new BoardLineVM();
        }
    }
}
