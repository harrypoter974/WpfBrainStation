using BS.Items.VM;
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

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for UCSpeaker.xaml
    /// </summary>
    public partial class XUCSpeaker : UserControl
    {
        public XUCSpeaker()
        {
            InitializeComponent();

        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TBVolume.Text = "" + ((int)(sliderVolume.Value*100.0));
            CL.BS.Common.StaticVar.inline.Volume = sliderVolume.Value;
        }
    }
}
