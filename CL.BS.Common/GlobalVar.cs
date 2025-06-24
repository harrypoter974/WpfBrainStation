using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Common
{
  public  class GlobalVar
    {
        public static bool IAnsweredFirst = false;
        public static string Group = "Animals";
        public enum EnterType { CARD, WRITING, TYPING };
        public static EnterType[] EnterTypeList = new EnterType[]
      { EnterType.CARD, EnterType.WRITING , EnterType.TYPING};

    }
}
