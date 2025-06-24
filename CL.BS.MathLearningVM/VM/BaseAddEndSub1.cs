using CL.BS.Common;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM
{
    public abstract class BaseAddEndSub1 : BaseCalculationVM
    {
        public string BoyName { get; set; }
        public string GirlName { get; set; }
        public string  BoyPic { get; set; }
        public string GirlPic { get; set; }

        public BaseAddEndSub1(StaticVar.ArithmeticType type) : base(type)
        {
            Limit = new string[] { "5", "10", "30" };
        }

        protected void SetName()
        {
            if (string.IsNullOrEmpty(Common.StaticVar.inline.Name))
            {
                BoyName = "הלל";
                GirlName = "יעל";
                GirlPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GirlImage.png";
                BoyPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\BoyImage.png";
            }
            else if (Common.StaticVar.inline.IsBoy)
            {
                BoyName = Common.StaticVar.inline.Name.Replace("Nickname\\",string.Empty);
                GirlName = "יעל";
                GirlPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GirlImage.png";
                BoyPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\BoyImage.png";
            }
            else
            {
                BoyName = Common.StaticVar.inline.Name.Replace("Nickname\\", string.Empty); 
                GirlName = "הלל";
                GirlPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\BoyImage.png";
                BoyPic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GirlImage.png";
            }
            NotifyPropertyChanged("BoyName");
            NotifyPropertyChanged("GirlName");
            NotifyPropertyChanged("BoyPic");
            NotifyPropertyChanged("GirlPic");
        }
    }
}
