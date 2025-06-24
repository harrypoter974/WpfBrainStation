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
using System.Windows.Shapes;

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for WinBrahotList.xaml
    /// </summary>
    public partial class WinBrahotList : Window
    {
        public WinBrahotList()
        {
            InitializeComponent();
            string[] nameList;
         
                nameList = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\JudaismImage\Brahot\");
            for (int i = 0; i < nameList.Length; i++)
            {
                if (nameList[i].Contains(".xls"))
                {
                    string[] name = nameList[i].Split('\\');
                    ListBox1.Items.Add(name[name.Length - 1].Split('.')[0]);
                }
            }
            SlectedItem = ListBox1.Items[0] + ".xls";
        }
        public string SlectedItem;

        private void ListBox1_Selected(object sender, RoutedEventArgs e)
        {
            SlectedItem = ListBox1.Items[ListBox1.SelectedIndex] + ".xls";
            Close();
        }
    }
}
