using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathComperVM2 : BaseLernPage, IPageVM
    {
        public override string Name => "MathComperVM2";

        void IPageVM.load()
        {
            new Thread(new ThreadStart(() =>
            {
                PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                         Common.StaticVar.inline.IsBoy?@"Resources\Audio\He\General\putItDown.wav":
                        @"Resources\Audio\He\General\put_it_down.wav",
@"Resources\Audio\He\General\card.wav",@"Resources\Audio\He\General\big.wav" ,
@"Resources\Audio\He\General\Equal.wav" ,@"Resources\Audio\He\General\or.wav"
,@"Resources\Audio\He\General\small.wav"   });
            })).Start();
            base.Settings();
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }
    }
}
