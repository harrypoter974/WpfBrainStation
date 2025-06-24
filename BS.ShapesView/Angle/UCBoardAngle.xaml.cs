using CL.BS.ShapesVM.VM.Angle;
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

namespace BS.ShapesView.Angle
{
    /// <summary>
    /// Interaction logic for UCBoardAngle.xaml
    /// </summary>
    public partial class UCBoardAngle : UserControl
    {
        public UCBoardAngle()
        {
            InitializeComponent();
            this.DataContext = new BoardAngleVM();
        }
    }
}
