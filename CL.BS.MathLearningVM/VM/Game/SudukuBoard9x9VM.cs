using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Game
{
    public class SudukuBoard9x9VM: BaseSudukuBoardVM
    {
        public SudukuBoard9x9VM(char rotation = 'A') : base(rotation) { Is4x4 = false; }
        private  bool ChackBoard()
        {
            bool chack = true;
            int[] cList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0,0 };
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
                cList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
                cList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
           int [,]indexBost=new int[,] { { 0, 0 }, { 0, 3 },{ 0, 6} ,
           { 3, 0 }, { 3, 3 },{ 3, 6},  { 6, 0 }, { 6, 3 },{ 6, 6}};  
            string[] chackList;
            for (int l = 0; l < indexBost.GetLength(0); l++)
            {
                cList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                chackList = new string[]
 { Bord[indexBost[l,0]+0,indexBost[l,1]+ 0].Text, Bord[indexBost[l,0]+0,indexBost[l,1]+1].Text, Bord[indexBost[l,0]+0, indexBost[l,1]+2].Text
, Bord[indexBost[l,0]+1,indexBost[l,1]+ 0].Text, Bord[indexBost[l,0]+1,indexBost[l,1]+1].Text, Bord[indexBost[l,0]+1, indexBost[l,1]+2].Text
, Bord[indexBost[l,0]+2,indexBost[l,1]+ 0].Text, Bord[indexBost[l,0]+2,indexBost[l,1]+1].Text, Bord[indexBost[l,0]+2, indexBost[l,1]+2].Text};
                for (int i = 0; i < cList.GetLength(0); i++)
                {
                    int ci = Common.GeneralFunctions.GetIndexInList(Signals, chackList[i]);
                    if (ci == -1)
                        return false;
                    cList[ci]++;
                    if (cList[ci] == 2)
                        return false;
                }
            }          
            return true;
        }
        protected override bool BoardIsFull()
        {
            int size = Bord.GetLength(1);
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (string.IsNullOrEmpty(Bord[x, y].Text)) 
                        return false;
            return true;
        }
    }
}
