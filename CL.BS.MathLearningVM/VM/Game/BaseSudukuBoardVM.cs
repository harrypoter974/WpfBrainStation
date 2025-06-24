using CL.BS.MathLearningManager.Interface.Game;
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

namespace CL.BS.MathLearningVM.VM.Game
{
    public class BaseSudukuBoardVM : BaseLernPage
    {
        public override string Name =>"";
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public int Column{get; set;}
        public int Row{get; set; }
        public string BaseWinBlink { get; set; }
        public string ShowAnswerBut { get; set; }
        public string NewGameBut { get; set; }

        protected int SoldierPosition = 0;
        protected bool Is4x4;
        private int _level = 0;
        protected ISudokuManager _logic = (ISudokuManager)
SupportHandlerManager.Base.GetManager("SudokuManager");
        public string Color00 { get { return Bord[0, 0].Background; } set { Bord[0, 0].Background = value; } }
        public string Color01 { get { return Bord[0, 1].Background; } set { Bord[0, 1].Background = value; } }
        public string Color02 { get { return Bord[0, 2].Background; } set { Bord[0, 2].Background = value; } }
        public string Color03 { get { return Bord[0, 3].Background; } set { Bord[0, 3].Background = value; } }
        public string Color04 { get { return Bord[0, 4].Background; } set { Bord[0, 4].Background = value; } }

        internal void SetLevel(int v)
        {
            _level=v;
        }

        public string Color05 { get { return Bord[0, 5].Background; } set { Bord[0, 5].Background = value; } }
        public string Color06 { get { return Bord[0, 6].Background; } set { Bord[0, 6].Background = value; } }
        public string Color07 { get { return Bord[0, 7].Background; } set { Bord[0,7 ].Background = value; } }
        public string Color08 { get { return Bord[0, 8].Background; } set { Bord[0, 8].Background = value; } }

        public string Color10 { get { return Bord[1, 0].Background; } set { Bord[1, 0].Background = value; } }
        public string Color11 { get { return Bord[1, 1].Background; } set { Bord[1, 1].Background = value; } }
        public string Color12 { get { return Bord[1, 2].Background; } set { Bord[1, 2].Background = value; } }
        public string Color13 { get { return Bord[1, 3].Background; } set { Bord[1, 3].Background = value; } }
        public string Color14 { get { return Bord[1, 4].Background; } set { Bord[1, 4].Background = value; } }
        public string Color15 { get { return Bord[1, 5].Background; } set { Bord[1, 5].Background = value; } }
        public string Color16 { get { return Bord[1, 6].Background; } set { Bord[1, 6].Background = value; } }
        public string Color17 { get { return Bord[1, 7].Background; } set { Bord[1, 7].Background = value; } }
        public string Color18 { get { return Bord[1, 8].Background; } set { Bord[1, 8].Background = value; } }

        public string Color20 { get { return Bord[2, 0].Background; } set { Bord[2, 0].Background = value; } }
        public string Color21 { get { return Bord[2, 1].Background; } set { Bord[2, 1].Background = value; } }
        public string Color22 { get { return Bord[2, 2].Background; } set { Bord[2, 2].Background = value; } }
        public string Color23 { get { return Bord[2, 3].Background; } set { Bord[2, 3].Background = value; } }
        public string Color24 { get { return Bord[2, 4].Background; } set { Bord[2, 4].Background = value; } }
        public string Color25 { get { return Bord[2, 5].Background; } set { Bord[2, 5].Background = value; } }
        public string Color26 { get { return Bord[2, 6].Background; } set { Bord[2, 6].Background = value; } }
        public string Color27 { get { return Bord[2, 7].Background; } set { Bord[2, 7].Background = value; } }
        public string Color28 { get { return Bord[2, 8].Background; } set { Bord[2, 8].Background = value; } }

        public string Color30 { get { return Bord[3, 0].Background; } set { Bord[3, 0].Background = value; } }
        public string Color31 { get { return Bord[3, 1].Background; } set { Bord[3, 1].Background = value; } }
        public string Color32 { get { return Bord[3, 2].Background; } set { Bord[3, 2].Background = value; } }
        public string Color33 { get { return Bord[3, 3].Background; } set { Bord[3, 3].Background = value; } }
        public string Color34 { get { return Bord[3, 4].Background; } set { Bord[3, 4].Background = value; } }
        public string Color35 { get { return Bord[3, 5].Background; } set { Bord[3, 5].Background = value; } }
        public string Color36 { get { return Bord[3, 6].Background; } set { Bord[3, 6].Background = value; } }
        public string Color37 { get { return Bord[3, 7].Background; } set { Bord[3, 7].Background = value; } }
        public string Color38 { get { return Bord[3, 8].Background; } set { Bord[3, 8].Background = value; } }
     
        public string Color40 { get { return Bord[4, 0].Background; } set { Bord[4, 0].Background = value; } }
        public string Color41 { get { return Bord[4, 1].Background; } set { Bord[4, 1].Background = value; } }
        public string Color42 { get { return Bord[4, 2].Background; } set { Bord[4, 2].Background = value; } }
        public string Color43 { get { return Bord[4, 3].Background; } set { Bord[4, 3].Background = value; } }
        public string Color44 { get { return Bord[4, 4].Background; } set { Bord[4, 4].Background = value; } }
        public string Color45 { get { return Bord[4, 5].Background; } set { Bord[4, 5].Background = value; } }
        public string Color46 { get { return Bord[4, 6].Background; } set { Bord[4, 6].Background = value; } }
        public string Color47 { get { return Bord[4, 7].Background; } set { Bord[4, 7].Background = value; } }
        public string Color48 { get { return Bord[4, 8].Background; } set { Bord[4, 8].Background = value; } }
        public string Color50 { get { return Bord[5, 0].Background; } set { Bord[5, 0].Background = value; } }
        public string Color51 { get { return Bord[5, 1].Background; } set { Bord[5, 1].Background = value; } }
        public string Color52 { get { return Bord[5, 2].Background; } set { Bord[5, 2].Background = value; } }
        public string Color53 { get { return Bord[5, 3].Background; } set { Bord[5, 3].Background = value; } }
        public string Color54 { get { return Bord[5, 4].Background; } set { Bord[5, 4].Background = value; } }
        public string Color55 { get { return Bord[5, 5].Background; } set { Bord[5, 5].Background = value; } }
        public string Color56 { get { return Bord[5, 6].Background; } set { Bord[5, 6].Background = value; } }
        public string Color57 { get { return Bord[5, 7].Background; } set { Bord[5, 7].Background = value; } }
        public string Color58 { get { return Bord[5, 8].Background; } set { Bord[5, 8].Background = value; } }
        public string Color60 { get { return Bord[6, 0].Background; } set { Bord[6, 0].Background = value; } }
        public string Color61 { get { return Bord[6, 1].Background; } set { Bord[6, 1].Background = value; } }
        public string Color62 { get { return Bord[6, 2].Background; } set { Bord[6, 2].Background = value; } }
        public string Color63 { get { return Bord[6, 3].Background; } set { Bord[6, 3].Background = value; } }
        public string Color64 { get { return Bord[6, 4].Background; } set { Bord[6, 4].Background = value; } }
        public string Color65 { get { return Bord[6, 5].Background; } set { Bord[6, 5].Background = value; } }
        public string Color66 { get { return Bord[6, 6].Background; } set { Bord[6, 6].Background = value; } }
        public string Color67 { get { return Bord[6, 7].Background; } set { Bord[6, 7].Background = value; } }
        public string Color68 { get { return Bord[6, 8].Background; } set { Bord[6, 8].Background = value; } }
        public string Color70 { get { return Bord[7, 0].Background; } set { Bord[7, 0].Background = value; } }
        public string Color71 { get { return Bord[7, 1].Background; } set { Bord[7, 1].Background = value; } }
        public string Color72 { get { return Bord[7, 2].Background; } set { Bord[7, 2].Background = value; } }
        public string Color73 { get { return Bord[7, 3].Background; } set { Bord[7, 3].Background = value; } }
        public string Color74 { get { return Bord[7, 4].Background; } set { Bord[7, 4].Background = value; } }
        public string Color75 { get { return Bord[7, 5].Background; } set { Bord[7, 5].Background = value; } }
        public string Color76 { get { return Bord[7, 6].Background; } set { Bord[7, 6].Background = value; } }
        public string Color77 { get { return Bord[7, 7].Background; } set { Bord[7, 7].Background = value; } }
        public string Color78 { get { return Bord[7, 8].Background; } set { Bord[7, 8].Background = value; } }
        public string Color80 { get { return Bord[8, 0].Background; } set { Bord[8, 0].Background = value; } }
        public string Color81 { get { return Bord[8, 1].Background; } set { Bord[8, 1].Background = value; } }
        public string Color82 { get { return Bord[8, 2].Background; } set { Bord[8, 2].Background = value; } }
        public string Color83 { get { return Bord[8, 3].Background; } set { Bord[8, 3].Background = value; } }
        public string Color84 { get { return Bord[8, 4].Background; } set { Bord[8, 4].Background = value; } }
        public string Color85 { get { return Bord[8, 5].Background; } set { Bord[8, 5].Background = value; } }
        public string Color86 { get { return Bord[8, 6].Background; } set { Bord[8, 6].Background = value; } }
        public string Color87 { get { return Bord[8, 7].Background; } set { Bord[8, 7].Background = value; } }
        public string Color88 { get { return Bord[8, 8].Background; } set { Bord[8, 8].Background = value; } }
        //public string ButX { get { return Bord[0, 0].Uid; } set { Bord[0, 0].Uid = value; } }
        public string TB00 { get { return Bord[0, 0].Text; } set { Bord[0, 0].Text = value; } }
        public string TB01 { get { return Bord[0, 1].Text; } set { Bord[0, 1].Text = value; } }
        public string TB02 { get { return Bord[0, 2].Text; } set { Bord[0, 2].Text = value; } }
        public string TB03 { get { return Bord[0, 3].Text; } set { Bord[0, 3].Text = value; } }
        public string TB04 { get { return Bord[0, 4].Text; } set { Bord[0, 4].Text = value; } }
        public string TB05 { get { return Bord[0, 5].Text; } set { Bord[0, 5].Text = value; } }
        public string TB06 { get { return Bord[0, 6].Text; } set { Bord[0, 6].Text = value; } }
        public string TB07 { get { return Bord[0, 7].Text; } set { Bord[0, 7].Text = value; } }
        public string TB08 { get { return Bord[0, 8].Text; } set { Bord[0, 8].Text = value; } }

        public string TB10 { get { return Bord[1, 0].Text; } set { Bord[1, 0].Text = value; } }
        public string TB11 { get { return Bord[1, 1].Text; } set { Bord[1, 1].Text = value; } }
        public string TB12 { get { return Bord[1, 2].Text; } set { Bord[1, 2].Text = value; } }
        public string TB13 { get { return Bord[1, 3].Text; } set { Bord[1, 3].Text = value; } }
        public string TB14 { get { return Bord[1, 4].Text; } set { Bord[1, 4].Text = value; } }
        public string TB15 { get { return Bord[1, 5].Text; } set { Bord[1, 5].Text = value; } }
        public string TB16 { get { return Bord[1, 6].Text; } set { Bord[1, 6].Text = value; } }
        public string TB17 { get { return Bord[1, 7].Text; } set { Bord[1, 7].Text = value; } }
        public string TB18 { get { return Bord[1, 8].Text; } set { Bord[1, 8].Text = value; } }
        public string TB20 { get { return Bord[2, 0].Text; } set { Bord[2, 0].Text = value; } }
        public string TB21 { get { return Bord[2, 1].Text; } set { Bord[2, 1].Text = value; } }
        public string TB22 { get { return Bord[2, 2].Text; } set { Bord[2, 2].Text = value; } }
        public string TB23 { get { return Bord[2, 3].Text; } set { Bord[2, 3].Text = value; } }
        public string TB24 { get { return Bord[2, 4].Text; } set { Bord[2, 4].Text = value; } }
        public string TB25 { get { return Bord[2, 5].Text; } set { Bord[2, 5].Text = value; } }
        public string TB26 { get { return Bord[2, 6].Text; } set { Bord[2, 6].Text = value; } }
        public string TB27 { get { return Bord[2, 7].Text; } set { Bord[2, 7].Text = value; } }
        public string TB28 { get { return Bord[2, 8].Text; } set { Bord[2, 8].Text = value; } }
        public string TB30 { get { return Bord[3, 0].Text; } set { Bord[3, 0].Text = value; } }
        public string TB31 { get { return Bord[3, 1].Text; } set { Bord[3, 1].Text = value; } }
        public string TB32 { get { return Bord[3, 2].Text; } set { Bord[3, 2].Text = value; } }
        public string TB33 { get { return Bord[3, 3].Text; } set { Bord[3, 3].Text = value; } }
        public string TB34 { get { return Bord[3, 4].Text; } set { Bord[3, 4].Text = value; } }
        public string TB35 { get { return Bord[3, 5].Text; } set { Bord[3, 5].Text = value; } }
        public string TB36 { get { return Bord[3, 6].Text; } set { Bord[3, 6].Text = value; } }
        public string TB37 { get { return Bord[3, 7].Text; } set { Bord[3, 7].Text = value; } }
        public string TB38 { get { return Bord[3, 8].Text; } set { Bord[3, 8].Text = value; } }

        public string TB40 { get { return Bord[4, 0].Text; } set { Bord[4, 0].Text = value; } }
        public string TB41 { get { return Bord[4, 1].Text; } set { Bord[4, 1].Text = value; } }
        public string TB42 { get { return Bord[4, 2].Text; } set { Bord[4, 2].Text = value; } }
        public string TB43 { get { return Bord[4, 3].Text; } set { Bord[4, 3].Text = value; } }
        public string TB44 { get { return Bord[4, 4].Text; } set { Bord[4, 4].Text = value; } }
        public string TB45 { get { return Bord[4, 5].Text; } set { Bord[4, 5].Text = value; } }
        public string TB46 { get { return Bord[4, 6].Text; } set { Bord[4, 6].Text = value; } }
        public string TB47 { get { return Bord[4, 7].Text; } set { Bord[4, 7].Text = value; } }
        public string TB48 { get { return Bord[4, 8].Text; } set { Bord[4, 8].Text = value; } }

        public string TB50 { get { return Bord[5, 0].Text; } set { Bord[5, 0].Text = value; } }
        public string TB51 { get { return Bord[5, 1].Text; } set { Bord[5, 1].Text = value; } }
        public string TB52 { get { return Bord[5, 2].Text; } set { Bord[5, 2].Text = value; } }
        public string TB53 { get { return Bord[5, 3].Text; } set { Bord[5, 3].Text = value; } }
        public string TB54 { get { return Bord[5, 4].Text; } set { Bord[5, 4].Text = value; } }
        public string TB55 { get { return Bord[5, 5].Text; } set { Bord[5, 5].Text = value; } }
        public string TB56 { get { return Bord[5, 6].Text; } set { Bord[5, 6].Text = value; } }
        public string TB57 { get { return Bord[5, 7].Text; } set { Bord[5, 7].Text = value; } }
        public string TB58 { get { return Bord[5, 8].Text; } set { Bord[5, 8].Text = value; } }

        public string TB60 { get { return Bord[6, 0].Text; } set { Bord[6, 0].Text = value; } }
        public string TB61 { get { return Bord[6, 1].Text; } set { Bord[6, 1].Text = value; } }
        public string TB62 { get { return Bord[6, 2].Text; } set { Bord[6, 2].Text = value; } }
        public string TB63 { get { return Bord[6, 3].Text; } set { Bord[6, 3].Text = value; } }
        public string TB64 { get { return Bord[6, 4].Text; } set { Bord[6, 4].Text = value; } }
        public string TB65 { get { return Bord[6, 5].Text; } set { Bord[6, 5].Text = value; } }
        public string TB66 { get { return Bord[6, 6].Text; } set { Bord[6, 6].Text = value; } }
        public string TB67 { get { return Bord[6, 7].Text; } set { Bord[6, 7].Text = value; } }
        public string TB68 { get { return Bord[6, 8].Text; } set { Bord[6, 8].Text = value; } }

        public string TB70 { get { return Bord[7, 0].Text; } set { Bord[7, 0].Text = value; } }
        public string TB71 { get { return Bord[7, 1].Text; } set { Bord[7, 1].Text = value; } }
        public string TB72 { get { return Bord[7, 2].Text; } set { Bord[7, 2].Text = value; } }
        public string TB73 { get { return Bord[7, 3].Text; } set { Bord[7, 3].Text = value; } }
        public string TB74 { get { return Bord[7, 4].Text; } set { Bord[7, 4].Text = value; } }
        public string TB75 { get { return Bord[7, 5].Text; } set { Bord[7, 5].Text = value; } }
        public string TB76 { get { return Bord[7, 6].Text; } set { Bord[7, 6].Text = value; } }
        public string TB77 { get { return Bord[7, 7].Text; } set { Bord[7, 7].Text = value; } }
        public string TB78 { get { return Bord[7, 8].Text; } set { Bord[7, 8].Text = value; } }
        public string TB80 { get { return Bord[8, 0].Text; } set { Bord[8, 0].Text = value; } }
        public string TB81 { get { return Bord[8, 1].Text; } set { Bord[8, 1].Text = value; } }
        public string TB82 { get { return Bord[8, 2].Text; } set { Bord[8, 2].Text = value; } }
        public string TB83 { get { return Bord[8, 3].Text; } set { Bord[8, 3].Text = value; } }
        public string TB84 { get { return Bord[8, 4].Text; } set { Bord[8, 4].Text = value; } }
        public string TB85 { get { return Bord[8, 5].Text; } set { Bord[8, 5].Text = value; } }
        public string TB86 { get { return Bord[8, 6].Text; } set { Bord[8, 6].Text = value; } }
        public string TB87 { get { return Bord[8, 7].Text; } set { Bord[8, 7].Text = value; } }
        public string TB88 { get { return Bord[8, 8].Text; } set { Bord[8, 8].Text = value; } }

        public string TB0 { get { return Bord[9,0].Text; } set { Bord[4,0].Text = value; } }
        public string TB1 { get { return Bord[9,1].Text; } set { Bord[4,1].Text = value; } }
        public string TB2 { get { return Bord[9,2].Text; } set { Bord[4,2].Text = value; } }
        public string TB3 { get { return Bord[9,3].Text; } set { Bord[4, 3].Text = value; } }
        public string TB4 { get { return Bord[9, 4].Text; } set { Bord[4, 4].Text = value; } }
        public string TB5 { get { return Bord[9, 5].Text; } set { Bord[4, 5].Text = value; } }
        public string TB6 { get { return Bord[9, 6].Text; } set { Bord[4, 6].Text = value; } }
        public string TB7 { get { return Bord[9, 7].Text; } set { Bord[4, 7].Text = value; } }
        public string TB8 { get { return Bord[9, 8].Text; } set { Bord[4, 8].Text = value; } }
        public string TBSoldier0 { get { return SoldierList[0].Background; } set { SoldierList[0].Background = value; } }
        public string TBSoldier1 { get { return SoldierList[1].Background; } set { SoldierList[1].Background = value; } }
        public string TBSoldier2 { get { return SoldierList[2].Background; } set { SoldierList[2].Background = value; } }
        public string TBSoldier3 { get { return SoldierList[3].Background; } set { SoldierList[3].Background = value; } }
        public string TBSoldier4 { get { return SoldierList[4].Background; } set { SoldierList[4].Background = value; } }
        protected SoldierObject[] SoldierList = new SoldierObject[5];

        protected string[] Signals = new string[] { "1","2","3","4" ,"5","6","7","8","9"};
        protected LetterObject[,] Bord;
        protected char _Rotation;
        public BaseSudukuBoardVM(char rotation='A')
        {
            _Rotation = rotation;   
            Bord = new LetterObject[10, 9];
            for (int i = 0; i < SoldierList.Length; i++)
                SoldierList[i] = new SoldierObject();
            for (int x = 0; x < Bord.GetLength(0); x++) {        
                for (int y = 0; y < Bord.GetLength(1); y++) {
                    Bord[x,y] = new LetterObject() { Text=x==9? Signals[y]:String.Empty};
                }
            }
            Bord[0, 0].Uid = String.Empty;
            MouseMove = new RelayCommand(DoMouseMove);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseUp = new RelayCommand(DoMouseUp);
            AnswerBut = new RelayCommand(DoAnswerBut);
            RestartBoard(); 
         
            if(this is SudukuBoard9x9VM)
            {
                TextSize = 45;
                NotifyPropertyChanged(nameof(TextSize));
                CardHeight = 55;
                CardWidth = 30;
            }
            else
            {
                CardHeight = 100; 
                CardWidth = 50;
            }
            NotifyPropertyChanged(nameof(CardWidth));
            NotifyPropertyChanged(nameof(CardHeight));
            BaseWinBlink = "Collapsed";
            NotifyPropertyChanged(nameof(BaseWinBlink));
        }

        private void DoMouseUp(object obj)
        {
            string[] n = obj.ToString().Split('_');
            int x =int.Parse(n[1]);
            int y = int.Parse(n[0]);
            if (TextCard == String.Empty && Bord[y, x].Background != "Black")
            {
                Bord[y, x].Text = String.Empty;
                Bord[y, x].Background = "White";
                NotifyPropertyChanged("TB" + y + x);
                NotifyPropertyChanged("Color" + y + x);
                return;
            }
           
            if (Bord[y, x].Background != "Black")
            {
                Bord[y, x].Text = TextCard;
                NotifyPropertyChanged(nameof(Row));
                NotifyPropertyChanged(nameof(Column));
                NotifyPropertyChanged("TB" + y +x);
                TextCard= String.Empty;
               if(_logic.CheckBoard(Bord,y,x))
                {
                    Bord[y, x].Background = "White";
                }
                else
                {
                    Bord[y, x].Background = "Red";
                }
                NotifyPropertyChanged("Color" + y + x);
            }
            VisibilityCard = "Collapsed";
            NotifyPropertyChanged(nameof(VisibilityCard));
            if (BoardIsFull())
            {
                new Thread(new ThreadStart(() =>
                {
                    Thread.Sleep(1000);
                    DoAnswerBut(0);
                })).Start();
            }
        }

        internal void DoMouseDown(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);

            TextCard = Signals[int.Parse(n[2])];
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(TextCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }

        private void DoMouseMove(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row    =  int.Parse(n[0]);
            Column = int.Parse(n[1]);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
        }

        internal void RestartBoard()
        {
            NotifyPropertyChanged(nameof(VisibilityCard));
            NotifyPropertyChanged(nameof(BaseWinBlink));
            SetSoldierPosition(false);
            Clear();
       
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }
        private void SetBoard(string[,] bord)
        {
            for (int x = 0; x < bord.GetLength(0); x++)
            {
                for (int y = 0; y < bord.GetLength(1); y++)
                {
                    Bord[x, y].Text = bord[x, y];
                    Bord[x, y].Background =string.IsNullOrEmpty( bord[x, y])? "White" : "Black";
                    NotifyPropertyChanged("TB" + x + y);
                    NotifyPropertyChanged("Color" + x + y);
                }
            }
        }

        private void Clear()
        {
            for (int x = 0; x < Bord.GetLength(0)-1; x++)
            {
                for (int y = 0; y < Bord.GetLength(1); y++)
                {
                    Bord[x, y].Text = string.Empty;
                    Bord[x, y].Background = "Black";
                    NotifyPropertyChanged("TB" + x + y);
                    NotifyPropertyChanged("Color" + x + y);
                }
            }
            NewGameBut = System.AppDomain.CurrentDomain.BaseDirectory +
          @"Resources\BS.Items\buttonNewGameG.png";
            NotifyPropertyChanged(nameof(NewGameBut));
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode&& NewGameBut.Contains("buttonNewGameG.png"))
            {
                base.IsQuestionMode = false;
                string[,] b = _logic.SetQuestionBord(Is4x4, _level);
                SetBoard(b);
                ShowAnswerBut = string.Empty;
                NewGameBut = String.Empty;
                NotifyPropertyChanged(nameof(NewGameBut));
               
                NotifyPropertyChanged(nameof(ShowAnswerBut));
                //BorderAnswer = "Collapsed";
                //NotifyPropertyChanged(nameof(BorderAnswer));
        //        new Thread(new ThreadStart(() =>  {
        //        NewGameBut = System.AppDomain.CurrentDomain.BaseDirectory +
        //@"Resources\BS.Items\buttonNewGame.png";
        //        NotifyPropertyChanged(nameof(NewGameBut));
        //        Thread.Sleep(2000); })).Start();
            }
            else if(!base.IsQuestionMode)
            {
                if (NewGameBut.Contains("stopGameBut.png"))
                {
                    NewGameBut = String.Empty;
                    NotifyPropertyChanged(nameof(NewGameBut));
                    return;
                }
                new Thread(new ThreadStart(() =>
                {
                    NewGameBut = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\Math\Sudoku\stopGameBut.png";
                    NotifyPropertyChanged(nameof(NewGameBut));
                    if (obj.ToString() != "0")
                    {
                        for (int i = 0; i < 60 && NewGameBut.Contains("stopGameBut.png"); i++)
                            Thread.Sleep(50);
                    }
                    if (!NewGameBut.Contains("stopGameBut.png"))
                        return;
                    //string[,] b = _logic.SetAnswerBord(Is4x4);
                    bool w = ChackBoard();
                    NewGameBut = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\BS.Items\buttonNewGameG.png";
                    NotifyPropertyChanged(nameof(NewGameBut));
                    base.IsQuestionMode = true;
                    if (w)
                    {
                        SetSoldierPosition(true);
                        if (SoldierPosition == 4)
                        {
                            BaseWinBlink = "Visible";
                            NotifyPropertyChanged(nameof(BaseWinBlink));
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                            Thread.Sleep(2000);
                            SetSoldierPosition(false);
                            BaseWinBlink = "Collapsed";
                            NotifyPropertyChanged(nameof(BaseWinBlink));
                            Clear();
                        }
                        else
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav");
                    }
                    //else
                    //{
                    //    BorderAnswer = "Visible";
                    //    NotifyPropertyChanged(nameof(BorderAnswer));
                    //    Thread.Sleep(2000);
                    //    //  SetBoard(b);
                    //}
                    ShowAnswerBut = System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\BS.Items\ShowAnswer.png";
                    NotifyPropertyChanged(nameof(ShowAnswerBut));
                    TextCard = String.Empty;
                    NotifyPropertyChanged(nameof(TextCard));
                   
                })).Start();          
            }
        }

        internal  bool ChackBoard()
        {
            int length = 4;
            for (int X = 0; X < length; X++)
            {
                for (int Y = 0; Y < length; Y++)
                {
                    if (Bord[Y, X].Background == "Red")
                        return false;
                    if (string.IsNullOrEmpty( Bord[Y, X].Text))
                        return false;
                }
            }
            return true;
        }

        private void SetSoldierPosition(bool ToUper)
        {//He bring's the soldier up if he win's the game and in the new square he starts a new game.
            SoldierPosition = !ToUper ? 0 :
           SoldierList.Length - 1 == SoldierPosition ? SoldierList.Length - 1 : SoldierPosition + 1;
            for (int i = 0; i < SoldierList.Length; i++)
            {
                if (i == SoldierPosition)
                {
                    SoldierList[i].Background =
                    System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Pion\" + _Rotation + ".png";
                }
                else
                {
                    SoldierList[i].Background = string.Empty;
                }
                NotifyPropertyChanged("TBSoldier" + i);
            }
        }

        protected  virtual bool BoardIsFull()
        {
            return false;
        }
    }
}
