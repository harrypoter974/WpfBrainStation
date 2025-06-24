using CL.BS.EnglishVM.VM.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BS.EnglishViews.Text
{
    /// <summary>
    /// Interaction logic for UCBoardEnWritingLetter.xaml
    /// </summary>
    public partial class UCBoardEnWritingLetter : UserControl
    {
        public UCBoardEnWritingLetter()
        {
            InitializeComponent();
            this.DataContext = new BoardEnWritingLetterVM();
        }
    }
}
