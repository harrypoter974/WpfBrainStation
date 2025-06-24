using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInformationManager.Engine;
using UserInformationManager.Interface;

namespace UserInformationManager.Manager
{
    #region MEF
    [Export(typeof(IManager))]
    #endregion MEF
    public class UserInfoManager : IUserInfoManager, IManager
    {
        string IManager.ManagerName => nameof(UserInfoManager);
        UserInfoEngine _logic = new UserInfoEngine();
        List<string> IUserInfoManager.GetAllStudents()
        {
            return _logic.GetAllStudents();
        }

        void IUserInfoManager.SetPassword(string password)
        {
            _logic.SetPassword(password);
        }

        void IUserInfoManager.SetStudent(int index)
        {
          _logic.SetStudent(index);
        }
    }
}
