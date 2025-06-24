using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;

namespace CL.BS.MenuVM.Control
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuControlShapeVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return nameof(MenuControlShapeVM);
            }
        }
        public override string ToString()
        {
            return "MenuShapeVM";
        }
        public MenuControlShapeVM()
        {
            Pages = new string[] {
   "ClockMenuVM", "ClockCompassesVM", "ClockDigitsVM", "ClockBingoAnalogVM"
   , "MenuMeasurementsVM", "ConceptsLengthVM", "ConceptsVM",
  "MeasurementCircumferenceVM", "AreaVM", "CubageVM", "AngleVM",
  "MenuShapeAndAngleVM", "LineOpenVM", "AngleOpenVM", 
"TringelOpenVM", "RectOpenVM", "CirclesOpenVM", "ShapeOpenVM", 
                "ShapeGameVM", "ShapeMemoryVM" };
        }

    }
}
