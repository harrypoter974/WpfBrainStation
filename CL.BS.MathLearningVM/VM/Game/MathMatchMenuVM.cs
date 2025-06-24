using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMatchMenuVM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(MathMatchMenuVM) ;
            }
        }
        public string Llevel0 { get; set; }
        public string Llevel1 { get; set; }
        public string IsCompetitiveBut { get; set; }
        public ICommand SetLevel { get; set; }
//        private IMathMatchManager _logic = (IMathMatchManager)
//SupportHandlerManager.Base.GetManager("IMathMatchManager");
         private int _level ; 
        private bool _isCompetitive ;  
        public MathMatchMenuVM()
        {
            SetLevel = new RelayCommand(DoSetLevel);
            AnswerBut = new RelayCommand(GoToMatch);
            DoSetLevel(1);
            DoSetLevel(3);
        }

        private void GoToMatch(object obj)
        {
            Common.StaticVar.MatchLevel = (_isCompetitive?2:0)+_level;
            DoGoToPage(nameof(MathMatchVM) );
        }

        private void DoSetLevel(object obj)
        {//Resources\Math\Match\IsCompetitiveBut
            int i=int.Parse(obj.ToString());
            if (i<3)
            {
                _level = i;
                if (_level==1)
                {
                    Llevel0 = string.Format(@"{0}Resources\BS.Items\Easy.png", System.AppDomain.CurrentDomain.BaseDirectory);
                    Llevel1 = string.Empty;
                }
                else
                {
                    Llevel0 = string.Empty;
                    Llevel1 = string.Format(@"{0}Resources\BS.Items\Hard.png", System.AppDomain.CurrentDomain.BaseDirectory);
                }
                NotifyPropertyChanged(nameof(Llevel0));
                NotifyPropertyChanged(nameof(Llevel1));
            }
            else
            {
                _isCompetitive = 4== i;
                IsCompetitiveBut=_isCompetitive? string.Format(@"{0}Resources\Math\Match\IsCompetitiveBut.png", System.AppDomain.CurrentDomain.BaseDirectory) : string.Empty ;  
                NotifyPropertyChanged(nameof(IsCompetitiveBut));
            }
        }
    }
}
