using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public  class PictureToStoryManager : IPictureToStory2Manager, IManager
    {
      private  PictureToStory2Engine _logic = new PictureToStory2Engine();
        string IManager.ManagerName => "PictureToStoryManager";

        void IPictureToStory2Manager.ClearBord()
        {
            _logic.ClearBord();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        List<LetterObject>[] IPictureToStory2Manager.SetPicList(int v)
        {
            return _logic.SetPicList(v);
        }
    }
}
