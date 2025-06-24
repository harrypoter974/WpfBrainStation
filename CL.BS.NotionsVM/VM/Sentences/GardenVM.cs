using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Sentences
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class GardenVM : BaseSentences, IPageVM
    {
        public override string Name => "GardenVM";
        public GardenVM()
        {
        }

        protected override void SetBackground()
        {
           
            BackgroundPic = string.Format(@"{0}Resources\Notions\Sentences\Garden{1}.jpg",
             System.AppDomain.CurrentDomain.BaseDirectory, (IsBoy ? 'B' : 'G'));
            NotifyPropertyChanged("BackgroundPic");
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime,
 DateTime.Now, Name, "LERM", "", Common.GeneralFunctions.GetLanguage(LanguageBut), 0);
        }
    }
}
