using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.NotionsVM.VM.Animals
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AnimalsGameMenuVM : BaseLernPage, IPageVM
    {
        public override string Name =>nameof(AnimalsGameMenuVM) ;
    }
}
