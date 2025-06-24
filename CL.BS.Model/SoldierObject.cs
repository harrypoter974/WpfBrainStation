using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Model
{
    public class SoldierObject
    {
        //Also used for buttons

        public string Background { get; set; }

        public SoldierObject Duplicate()
        {
            return new SoldierObject()
            { Background = this.Background};
        }
    }
}
