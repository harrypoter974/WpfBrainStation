using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathArray4VM : MathComplexVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MathArray4VM";
            }
        }

        void IPageVM.load()
        {
            base.Settings();

            new Thread(new ThreadStart(() =>
            {
                string[] message = new string[2];
                message[0] = Common.StaticVar.inline.PlayName();
                if (Common.StaticVar.inline.IsBoy)
                    message[1] = @"Resources\Audio\He\Sentences\A12.wav";
                else
                    message[1] = @"Resources\Audio\He\Sentences\A13.wav";
                PlayList(message);
            })).Start();
        }

        public MathArray4VM()
        {
            _logic = (IMathComplexManager)
SupportHandlerManager.Base.GetManager("MathArray4Manager");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardArrayVM(_logic);//

            TBTitle = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\Math\Exercise\SummaryArray.jpg";
            NotifyPropertyChanged(nameof(TBTitle));
        }

    }
}
