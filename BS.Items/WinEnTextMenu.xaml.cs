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
    /// Interaction logic for WinEnTextMenu.xaml
    /// </summary>
    public partial class WinEnTextMenu : Window
    {
        private bool IsSmole;
        public string TextFile;
        private string path = @"C:\BSEnText";
        public WinEnTextMenu(bool IsSmole = true)
        {
            this.IsSmole = IsSmole;
            InitializeComponent();
            string[] textFile = System.IO.Directory.GetFiles(path);

            List<Label> items = new List<Label>();
            for (int i = 0; i < textFile.Length; i++)
            {
                string fileName = textFile[i].Split('\\')[2];
                if (IsSmole && !fileName.Contains(".b"))
                {
                    Label l = new Label() { Content = fileName };
                    l.MouseDown += ListBox1_Selected;
                    items.Add(l);
                }
                else if (!IsSmole && fileName.Contains(".b"))
                {
                    Label l = new Label() { Content = fileName };
                    l.MouseDown += ListBox1_Selected;
                    items.Add(l);
                }
            }
            ListBox1.ItemsSource = items;
        }
        private void ListBox1_Selected(object sender, RoutedEventArgs e)
        {
            TextFile = path + "\\" + ((Label)sender).Content.ToString();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            TextFile = string.Empty;
            Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
