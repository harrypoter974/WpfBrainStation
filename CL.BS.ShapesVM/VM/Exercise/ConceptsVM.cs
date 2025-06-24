using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ConceptsVM : BaseLernPage, IPageVM
    {
        public override string Name => "ConceptsVM";
        private string _topic = "Angle1";
        public string BackgroundPic { get; set; }
        public ICommand ToExercise { get; set; }
        public ICommand ChangeTo { get; set; }

        public ConceptsVM()
        {
            ToExercise = new RelayCommand(DoToExercise);
            ChangeTo = new RelayCommand(DoChangeTo);
        }

        private void DoToExercise(object obj)
        {
            switch (_topic)
            {
                case "Length": DoGoToPage("ConceptsLengthVM"); break;
                case "Angle1": case "Angle0":DoGoToPage("ConceptsAngleVM"); break;
                case "Measurement": DoGoToPage("ConceptsMeasurementVM"); break;
            }
        }

        private void DoChangeTo(object obj)
        {
            if (!string.IsNullOrEmpty( obj.ToString()))
                _topic = obj.ToString();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                             @"Resources\Shapes\Concepts\" + obj + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
    }
    
}
