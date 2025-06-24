using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Reading;
using CL.BS.HebrewManager.Interface.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class HeReading3Manager : IManager, IHeReading3Manager
    {
        private HeReading3Engine _logic = new HeReading3Engine();
        int _nikodIndex;
        public string ManagerName
        {
            get
            {
               return "HeReading3Manager";
            }
        }

        void IHeReading3Manager.ClireVar()
        {

        }

        string IHeReading3Manager.getWord( object indexWord, bool IsLearn)
        {
            return _logic.GetWord(_nikodIndex,indexWord,IsLearn) ;
        }

        void IHeReading3Manager.SetIndex(object index)
        {
            _nikodIndex=int.Parse(index.ToString());
        }

        int IHeReading3Manager.GetIndex()
        {
           return _nikodIndex;
        }

        string IHeReading3Manager.GetSyllable(object syllable)
        {
            return _logic.GetSyllable(_nikodIndex,syllable);
        }

        int IHeReading3Manager.GetPageIndex()
        {
            return _logic.GetPageIndex();
        }
    }
}
