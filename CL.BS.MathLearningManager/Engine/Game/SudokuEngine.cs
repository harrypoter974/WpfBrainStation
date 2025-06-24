using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Data;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class SudokuEngine
    {
        private IExternalSudokuEngine _logic ;
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private  string[][,] _bord=new string[2][,];
        private bool _Is4x4 = true;

             
        internal static LetterObject[,] GetBord(int[,] bord)
        {
            LetterObject[,] nb = new LetterObject[bord.GetLength(0), bord.GetLength(1)];
            int[] numCounter = new int[9];
            int[,] blenkCeal = new int[9, 2];

            for (int x = 0; x < blenkCeal.GetLength(0); x++)
            {
                List<int> blenkNum = new List<int>(bord.GetLength(0) == 4 ? new int[] { 0, 1, 2, 3 }:new int[] { 0, 1, 2, 3, 4, 5 });
                for (int y = 0; y < blenkCeal.GetLength(1); y++)
                {
                    blenkCeal[x, y] = blenkNum[_ran.Next(blenkNum.Count)];
                    blenkNum.Remove(blenkCeal[x, y]);
                }
            }
            for (int x = 0; x < bord.GetLength(0); x++)
            {
                for (int y = 0; y < bord.GetLength(1); y++)
                {
                    int num = bord[x, y] - 1;
                    nb[x, y] = new LetterObject();
                    if (numCounter[num] == blenkCeal[num, 0] || numCounter[num] == blenkCeal[num, 1])
                    {
                        nb[x, y].Text = "0";
                    }
                    else
                        nb[x, y].Text = bord[x, y].ToString();
                    numCounter[num]++;
                }
            }
            return nb;
        }

        internal string[,] SetQuestionBord(bool is4x4, int level)
        {
            string[][,] newBord = new string[2][,];
            _Is4x4 = is4x4;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    _logic = new IExternalSudokuEngine[] { new ExternalSudokuEngine4x4(),new ExternalSudokuEngine9x9()}[is4x4?0 : 1];
                    bool isTheSame = true;
                    while (isTheSame)
                    {
                        if (_bord[0] == null)
                            isTheSame = false;
                        _logic.GenerateGame(new GameLevel[] { GameLevel.SIMPLE, GameLevel.MEDIUM, GameLevel.COMPLEX }[level]);
                        int length = is4x4 ? 4 : 9;
                        newBord[0] = new string[length, length];
                        newBord[1] = new string[length, length];
                        DataSet ds = _logic.GameSet;

                        DataTable custCol = ds.Tables["numberset"];//
                        for (int x = 0; x < length; x++)
                        {
                            DataRow dr = custCol.Rows[x];
                            for (int y = 0; y < length; y++)
                            {
                                newBord[0][x, y] = dr.ItemArray[y].ToString();
                                if (isTheSame)
                                    isTheSame = newBord[0][x, y] == _bord[0][x, y];
                            }
                        }
                        custCol = ds.Tables["answerset"];//
                        for (int x = 0; x < length; x++)
                        {
                            DataRow dr = custCol.Rows[x];
                            for (int y = 0; y < length; y++)
                            {
                                newBord[1][x, y] = dr.ItemArray[y].ToString();
                            }
                        }
                    }
                    break;
                }
                catch (Exception)
                {
                    if (i == 2)
                    {
                        newBord[0] = newBord[1] = new string[(is4x4 ? 4 : 9), (is4x4 ? 4 : 9)];
                        _bord = newBord;
                        return newBord[0];
                    }
                }
            }

            _bord = newBord;
            return _bord[0];
        }

        private bool MyEquals(string[,] v1, string[,] v2)
        {
            if (v2 == null)
                return false;
            for (int x = 0; x < v1.GetLength(0); x++)
            {
                for (int y = 0; y < v1.GetLength(1); y++)
                {
                    if (v1[x, y] != v2[x, y])
                        return false;
                }
            }
            return true;
        }

        internal string[,] SetAnswerBord(bool is4x4)
        {
           return  _bord[1] ;
        }

        internal void GenerateGame(bool is4x4)
        {
            _Is4x4 = is4x4;
            _logic = new IExternalSudokuEngine[] { new ExternalSudokuEngine4x4(), new ExternalSudokuEngine9x9() }[is4x4 ? 0 : 1];
            _logic.GenerateGame( GameLevel.SIMPLE);
        }

        internal bool CheckBoard(LetterObject[,] bord,int y, int x)
        {
            string num = bord[y, x].Text;
            int length = _Is4x4 ? 4 : 9;
            for (int i = 0; i < length; i++)
            {
                if (y != i)
                    if (bord[i, x].Text == num)
                        return false;
                if (x!=i)
                    if (bord[y, i].Text == num)
                        return false;
            }
            length = _Is4x4 ?2 : 3;
            int startX = length + x - x % length, startY=length+ y - y % length;
            for (int X = x-x%length; X < startX; X++)
            {
                for (int Y = y - y % length; Y < startY; Y++)
                {
                    if (Y != y && X != x)
                    {
                        if (bord[Y, X].Text == num)
                            return false;
                    }
                }
            }
            return true;
        }
        internal static void AddDeltaToBord(ref int[,] bord)
        {
            int delta = _ran.Next(5);
            for (int x = 0; x < bord.GetLength(0); x++)
                for (int y = 0; y < bord.GetLength(1); y++)
                    bord[x, y] += delta;
        }
    }
}
