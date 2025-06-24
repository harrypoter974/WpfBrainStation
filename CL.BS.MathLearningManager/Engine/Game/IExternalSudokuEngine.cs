using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Game
{
    public abstract class IExternalSudokuEngine
    {
        public abstract void GenerateGame(GameLevel sIMPLE);
        public DataSet GameSet
        {
            get { return FormDataSet(); }
        }

        protected abstract DataSet FormDataSet();
    }
}
