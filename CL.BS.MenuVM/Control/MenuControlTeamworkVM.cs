using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MenuVM.Control
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuControlTeamworkVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return nameof(MenuControlTeamworkVM);
            }
        }
        public override string ToString()
        {
            return "MenuTeamworkVM";
        }
        public MenuControlTeamworkVM()
        {
            Pages = new string[] {
 "PictureToStoryVM", "ExerciseColorsVM","GroupPlayingVM","EducationalStaffVM" };
        }
    }
}
