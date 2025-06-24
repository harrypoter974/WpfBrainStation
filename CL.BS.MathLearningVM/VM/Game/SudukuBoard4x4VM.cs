using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Game
{
    public class SudukuBoard4x4VM: BaseSudukuBoardVM
    {
        public SudukuBoard4x4VM(char rotation = 'A') : base(rotation) { Is4x4 = true; }
        private  bool ChackBoard() { 
            bool chack = true;
            int[] cList = new int[] { 0, 0, 0, 0 };
            for (int y = 0; y < cList.GetLength(0); y++)
            {
                for (int x = 0; x < cList.GetLength(0); x++)
                {
                    int i = Common.GeneralFunctions.GetIndexInList(Signals, Bord[x, y].Text);
                    if (i == -1)
                        return false;
                    cList[i]++;
                    if (cList[i] == 2)
                        return false;
                }
                cList = new int[] { 0, 0, 0, 0 };
            }

            for (int x = 0; x < cList.GetLength(0); x++)
            {
                for (int y = 0; y < cList.GetLength(0); y++)
                {
                    int i = Common.GeneralFunctions.GetIndexInList(Signals, Bord[x, y].Text);
                    if (i == -1)
                        return false;
                    cList[i]++;
                    if (cList[i] == 2)
                        return false;
                }
                cList = new int[] { 0, 0, 0, 0 };
            }
            cList = new int[] { 0, 0, 0, 0 };
            string[] chackList = new string[] { Bord[0, 0].Text, Bord[0, 1].Text, Bord[1, 0].Text, Bord[1, 1].Text };
            for (int i = 0; i < cList.GetLength(0); i++)
            {
                int ci = Common.GeneralFunctions.GetIndexInList(Signals, chackList[i]);
                if (ci == -1)
                    return false;
                cList[ci]++;
                if (cList[ci] == 2)
                    return false;
            }
            cList = new int[] { 0, 0, 0, 0 };
            chackList = new string[] { Bord[2, 0].Text, Bord[3, 0].Text, Bord[2, 1].Text, Bord[3, 1].Text };
            for (int i = 0; i < cList.GetLength(0); i++)
            {
                int ci = Common.GeneralFunctions.GetIndexInList(Signals, chackList[i]);
                if (ci == -1)
                    return false;
                cList[ci]++;
                if (cList[ci] == 2)
                    return false;
            }
            cList = new int[] { 0, 0, 0, 0 };
            chackList = new string[] { Bord[0, 2].Text, Bord[1, 2].Text, Bord[0, 3].Text, Bord[1, 3].Text };
            for (int i = 0; i < cList.GetLength(0); i++)
            {
                int ci = Common.GeneralFunctions.GetIndexInList(Signals, chackList[i]);
                if (ci == -1)
                    return false;
                cList[ci]++;
                if (cList[ci] == 2)
                    return false;
            }
            cList = new int[] { 0, 0, 0, 0 };
            chackList = new string[] { Bord[2, 2].Text, Bord[3, 2].Text, Bord[2, 3].Text, Bord[3, 3].Text };
            for (int i = 0; i < cList.GetLength(0); i++)
            {
                int ci = Common.GeneralFunctions.GetIndexInList(Signals, chackList[i]);
                if (ci == -1)
                    return false;
                cList[ci]++;
                if (cList[ci] == 2)
                    return false;
            }
            return chack;
        }
        protected override bool BoardIsFull()
        {
            int size = 4;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (string.IsNullOrEmpty(Bord[x, y].Text))
                        return false;
            return true;
        }
    }
}
