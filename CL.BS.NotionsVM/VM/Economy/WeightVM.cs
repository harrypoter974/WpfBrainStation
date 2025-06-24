using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Economy
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WeightVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(WeightVM);
        public string BackgroundPic { get; set; }
        public ICommand PlayWeight { get; set; }
        public WeightVM()
        {
            
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                           + @"Resources\Notions\Economy\weight0.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));            
            AnswerBut = new RelayCommand(DoSwitchPage);
            PlayWeight= new RelayCommand(DoPlayWeight);
        }

        private void DoPlayWeight(object obj)
        {
           if(BackgroundPic.Contains("weight0.jpg"))
            { 
                PlayList(new string[] { @"Resources\Audio\He\Economy\barbell of.wav" ,
                    string.Format(@"Resources\Audio\He\Economy\{0}.wav",obj) });
            }
        }

        private void DoSwitchPage(object obj)
        {
            BackgroundPic = String.Format(@"{0}Resources\Notions\Economy\weight{1}.jpg",
                System.AppDomain.CurrentDomain.BaseDirectory,  BackgroundPic.Contains("weight0.jpg") ? 1 : 0);
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
    }
}
