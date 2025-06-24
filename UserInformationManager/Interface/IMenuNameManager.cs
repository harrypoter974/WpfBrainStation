using CL.BS.VMCommon;
using System;
using System.Collections.Generic;

namespace UserInformationManager.Interface
{
    public interface IMenuNameManager
    {
        List<string> GetName(object letter);
    }
}
