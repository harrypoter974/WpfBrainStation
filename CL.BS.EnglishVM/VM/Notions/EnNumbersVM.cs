using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnNumbersVM : BaseLernPage, IPageVM
    {
        public ICommand ShowNum { get; set; }
        public ICommand SwichGroup { get; set; }
        public string BackgroundPic { get; set; }
        private bool _smallerThan11 = true;
        public override string Name
        {
            get
            {
                return nameof(EnNumbersVM);
            }
        }

        public EnNumbersVM()
        {
            ShowNum = new RelayCommand(DoShowNum);
            SwichGroup = new RelayCommand(DoSwichGroup);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\Numbers\open1.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\En\Numbers\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }

        private void DoSwichGroup(object group)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _smallerThan11 = !_smallerThan11;
             BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Numbers\open" + (_smallerThan11?1:10)+".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));

        }

        public void DoShowNum(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            //new Thread(new ThreadStart(() =>
            //{  })).Start();
                string[] Num = index.ToString().Split(',');
                string num = (_smallerThan11 ? Num[1] : Num[0]);

                if (num == "100")
                {
                    PlayList(new string[] {
                        @"Resources\Audio\En\Numbers\1.wav"
                      , @"Resources\Audio\En\Numbers\100.wav" });
                }
                else
                {
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\En\Numbers\" + num + ".wav");
                }
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Lang\En\Numbers\" + num + ".jpg";
                NotifyPropertyChanged(nameof(BackgroundPic));
          
        }
    }
}
