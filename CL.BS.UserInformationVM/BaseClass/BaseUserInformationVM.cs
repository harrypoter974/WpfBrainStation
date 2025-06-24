using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.UserInformationVM.BaseClass
{
    public abstract class BaseUserInformationVM : BaseLernPage
    {
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public BaseUserBord[]Bords=new BaseUserBord[4];

        public BaseUserBord Bord0 { get { return Bords[0]; } set {Bords[0] = value; } }
        public BaseUserBord Bord1 { get { return Bords[1]; } set {Bords[1] = value; } }
        public BaseUserBord Bord2 { get { return Bords[2]; } set {Bords[2] = value; } }
        public BaseUserBord Bord3 { get { return Bords[3]; } set { Bords[3] = value; } }
        public BaseUserInformationVM()
        {
        }
    }
}
