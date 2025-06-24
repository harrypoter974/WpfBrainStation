using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MenuVM.GeneralGame
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuHeGeneralkitchenwareVM : BaseMenuHeGeneralVM, IPageVM
    {
        public override string Name => nameof(MenuHeGeneralkitchenwareVM) ;
        public MenuHeGeneralkitchenwareVM() : base("kitchenware")  { }
    }
}
