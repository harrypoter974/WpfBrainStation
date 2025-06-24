using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInformationManager.Interface
{
    public interface IUserInfoManager
    {
        List<string> GetAllStudents();
        void SetStudent(int index);
        void SetPassword(string password);  
    }
}
