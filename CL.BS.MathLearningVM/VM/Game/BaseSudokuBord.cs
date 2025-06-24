using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Game
{
    public abstract class BaseSudokuBord : VMCommon.BasePageVM
    {
        public override string Name => "";
        internal abstract void SwitchCardRoWrite(bool isCard);
        public string PicBackground { get; set; }
        protected LetterObject[,] Bord;
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

        internal void SetNewBord(int BordSize)
        {
            for (int x = 0; x < BordSize; x++)
                for (int y = 0; y < BordSize; y++)
                    Bord[x, y] = new LetterObject();
        }

        internal void SetBord(string[,] bord,int bordSize)
        {
            for (int x = 0; x < bordSize; x++)
            {
                for (int y = 0; y < bordSize; y++)
                {
                    Bord[x, y].Text = bord[x,y]=bord[x,y];//
                    NotifyPropertyChanged("TB" + x + y);
                }
            }
        }
    }
}
