using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PictureToStory2VM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(PictureToStory2VM);
        public ICommand SetPlayer { get; set; }
        private IPictureToStory2Manager _logic = (IPictureToStory2Manager)
SupportHandlerManager.Base.GetManager("PictureToStoryManager");
        public string PlayerBut0 { get { return PlayerBut[0].Background; } set { PlayerBut[0].Background = value; } }
        public string PlayerBut1 { get { return PlayerBut[1].Background; } set { PlayerBut[1].Background = value; } }
        public string PlayerBut2 { get { return PlayerBut[2].Background; } set { PlayerBut[2].Background = value; } }
        private int _playerIndex = 0;
        protected LetterObject[] PlayerBut = new LetterObject[3];

        public List<LetterObject> LstPic0 { get; set; }
        public List<LetterObject> LstPic1 { get; set; }
        public List<LetterObject> LstPic2 { get; set; }
        public List<LetterObject> LstPic3 { get; set; }
        public PictureToStory2VM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetPlayer = new RelayCommand(DoSetPlayer);
            for (int i = 0; i < PlayerBut.Length; i++)
                PlayerBut[i] = new LetterObject();
        }

        private void DoSetPlayer(object obj)
        {
            PlayerBut[_playerIndex].Background = string.Empty;
            NotifyPropertyChanged("PlayerBut" + _playerIndex);
            int pi = int.Parse(obj.ToString());
            if (pi == -1)
            {
                PlayerBut[2].Background = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\Number\4b.png";
                NotifyPropertyChanged("PlayerBut2");
                _playerIndex = 2; 
            }
            else
            {
                PlayerBut[pi].Background = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\Number\" + new int[] { 1, 2, 4 }[pi] + "b.png";
                NotifyPropertyChanged("PlayerBut" + pi);
                _playerIndex = pi;
            }
            ClearBord();
        }

        private void ClearBord()
        {
            LstPic0 =  LstPic1 = LstPic2 = LstPic3 = new List<LetterObject>();
            NotifyPropertyChanged(nameof(LstPic0));
            NotifyPropertyChanged(nameof(LstPic1));
            NotifyPropertyChanged(nameof(LstPic2));
            NotifyPropertyChanged(nameof(LstPic3));
            _logic.ClearBord();
        }

        private void DoAnswerBut(object obj)
        {
            List<LetterObject>[] list = _logic.SetPicList(_playerIndex);
            LstPic0 =new List<LetterObject>( list[0]);
            LstPic1 = new List<LetterObject>( list[1]);
            LstPic2 = new List<LetterObject>( list[2]);
            LstPic3 = new List<LetterObject>(list[3] );
            NotifyPropertyChanged(nameof(LstPic0));
            NotifyPropertyChanged(nameof(LstPic1));
            NotifyPropertyChanged(nameof(LstPic2));
            NotifyPropertyChanged(nameof(LstPic3));
        }
        void IPageVM.load()
        {
            DoSetPlayer(-1);
            base.Settings();
        }
    }
}
