using CL.BS.Model;
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
    /// Interaction logic for WinWordList.xaml
    /// </summary>
    public partial class WinWordList : Window
    {
        private List<ItemObject> lstWords;
        private VM.WordListVM _logic;
        public WinWordList(List<ItemObject> lstWords)
        {
            InitializeComponent();
            this.lstWords = lstWords;
            this.DataContext =  _logic= new VM.WordListVM( lstWords);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _logic.DoSelectionOfWord( listBox.SelectedIndex);
        }
        public List<ItemObject> GetWords()
        {
            return _logic.MyList;
        }
    }
}
