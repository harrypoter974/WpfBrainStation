using CL.BS.MathLearningManager.Interface.Game;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Game
{
    public class ExternalSudokuEngine4x4 : IExternalSudokuEngine
	{

		/// <summary>
		///  Constructor
		/// </summary>
		public ExternalSudokuEngine4x4()
		{
			// This is answer set generated from unique solution
			_numberSet = new int[MAX_ROWS, MAX_COLS];
			// This is set after unmasking some positions and is problem set
			_problemSet = new int[MAX_ROWS, MAX_COLS];
			// copy of problem set to validates that answer positions are not changed

			_problemSetCopy = new int[MAX_ROWS, MAX_COLS];
		}




		/// <summary>
		/// Method:GenerateGame
		/// Purpose:Generates game based on complexity level.
		/// </summary>
		/// <param name="level"></param>
		public override void GenerateGame(GameLevel level)
		{

			// InitialiseSet
			// This first creates answer set by using Game combinations
			InitialiseSet();
			int minPos, maxPos, noOfSets;

			// Now unmask positions and create problem set.
			switch (level)
			{

				case GameLevel.SIMPLE:
					minPos = 1;
					maxPos = 2;
					noOfSets =4;
					UnMask(minPos, maxPos, noOfSets);
					break;
				case GameLevel.MEDIUM:
					minPos = 1;
					maxPos = 2;
					noOfSets = 3;
					UnMask(minPos, maxPos, noOfSets);
					break;
				case GameLevel.COMPLEX:
					minPos = 1;
					maxPos = 2;
					noOfSets = 3;
					UnMask(minPos, maxPos, noOfSets);
					break;
				default:
					UnMask(1, 2, 3);
					break;
			}
			// Make copy of Problem Set
			for (int i = 0; i < MAX_ROWS; i++)
			{
				for (int j = 0; j < MAX_COLS; j++)
				{

					_problemSetCopy[i, j] = _problemSet[i, j];
				}
			}



		}


		/// <summary>
		/// Method:UnMask
		/// Purpose:UnMasks set positions randomly based on complexity.
		/// </summary>
		/// <param name="minPos"></param>
		/// <param name="maxPos"></param>
		private void UnMask(int minPos, int maxPos, int noOfSets)
		{
			int seed;
			int[] posX = { 0, 0, 1, 1 };
			int[] posY = { 0, 1, 0, 1 };
			int[] maskedSet = { 0, 0, 0, 0 };
			Random number;
			int setCount = 0;
			do
			{

				seed = DateTime.Now.Millisecond;
				number = new Random(seed);
				int i = number.Next(0, 4);

				if (maskedSet[i] == 0)
				{
					maskedSet[i] = 1;
					setCount++;
					// Mask each set

					seed = DateTime.Now.Millisecond;
					number = new Random(seed);
					int maskPos = number.Next(minPos, maxPos);
					int j = 0;
					do
					{
						seed = DateTime.Now.Millisecond;
						number = new Random(seed);
						int newPos = number.Next(1, 4);
						int x = _setRowPosition[i] + posX[newPos];
						int y = _setColPosition[i] + posY[newPos];
						if (_problemSet[x, y] == 0)
						{
							_problemSet[x, y] = _numberSet[x, y];
							j++;
						}

					} while (j < maskPos);


				}
			} while (setCount < noOfSets);



		}



		public bool InitiliseExistingGame(DataSet gameSet)
		{
			// Initiliase Answerset 
			try
			{
				DataTable currentTable = gameSet.Tables["answerset"];
				int i = 0, j = 0;
				string colname = null;
				foreach (DataRow row in currentTable.Rows)
				{
					for (j = 0; j < MAX_COLS; j++)
					{

						colname = "col" + j.ToString().TrimEnd();
						string dataValue = row[colname] as string;
						if (dataValue == null)
							continue;

						if (dataValue.TrimEnd() != "")
						{
							_numberSet[i, j] = Int32.Parse(dataValue);
						}
						else
						{
							_numberSet[i, j] = 0;
						}

					}
					i++;
				}

				// Initilise problemset
				i = j = 0;
				currentTable = gameSet.Tables["numberset"];
				foreach (DataRow row in currentTable.Rows)
				{
					for (j = 0; j < MAX_COLS; j++)
					{
						colname = "col" + j.ToString().TrimEnd();

						string dataValue = row[colname] as string;
						if (dataValue == null)
							continue;

						if (dataValue.TrimEnd() != "")
						{
							_problemSet[i, j] = Int32.Parse(dataValue);
						}
						else
						{
							_problemSet[i, j] = 0;
						}


					}
					i++;
				}

				// Initliase ProblemSet Copy
				i = j = 0;
				currentTable = gameSet.Tables["problemcopyset"];
				foreach (DataRow row in currentTable.Rows)
				{
					for (j = 0; j < MAX_COLS; j++)
					{
						colname = "col" + j.ToString().TrimEnd();

						string dataValue = row[colname] as string;
						if (dataValue == null)
							continue;

						if (dataValue.TrimEnd() != "")
						{
							_problemSetCopy[i, j] = Int32.Parse(dataValue);
						}
						else
						{
							_problemSetCopy[i, j] = 0;
						}


					}
					i++;
				}

				return true;

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error occured while initilising game and error is {0}", ex.Message);
				return false;
			}


		}
		/// <summary>
		/// Method:CheckForDuplicate
		/// </summary>
		/// <param name="rowPos"></param>
		/// <param name="colPos"></param>
		/// <param name="currentValue"></param>
		/// <returns></returns>

		public bool CheckForDuplicate(int rowPos, int colPos, int currentValue)
		{
			// check rows
			for (int i = 0; i < MAX_ROWS; i++)
			{

				if (_problemSet[i, colPos] == currentValue)
				{
					if (i != rowPos)
					{
						return true;
					}
					else
					{
						continue;
					}

				}
				if (_problemSet[rowPos, i] == currentValue)
				{
					if (i != colPos)
					{
						return true;
					}
					else
					{
						continue;
					}
				}

			}

			// Check in Mini Set
			int x = rowPos / 3;
			int y = colPos / 3;
			for (int j = 0; j < MINI_SET_ROWS; j++)
			{
				for (int k = 0; k < MINI_SET_COLS; k++)
				{
					int p = x * 3 + j;
					int q = y * 3 + k;

					if ((p == rowPos) && (q == colPos))
					{
						continue;
					}
					else if (_problemSet[p, q] == currentValue)
					{
						return true;
					}

				}

			}

			return false;



		}

		public bool CheckIfAnswerPosition(int rowPos, int colPos, int dataValue)
		{


			if (_problemSetCopy[rowPos, colPos] != 0)
				return true;
			else
				return false;




		}


		/// <summary>
		/// Method:CheckForAnswerChange
		/// </summary>
		/// <param name="rowPos"></param>
		/// <param name="colPos"></param>
		/// <param name="currentValue"></param>
		/// <returns></returns>
		public bool CheckForAnswerChange(int rowPos, int colPos, int currentValue)
		{
			if (_problemSetCopy[rowPos, colPos] != 0)
			{
				if (_problemSetCopy[rowPos, colPos] != currentValue)
				{
					return true;
				}
			}
			return false;

		}

		/// <summary>
		/// Method:FormDataSet
		/// Purpose: Creates XML dynamically from array of problem,copy of problemset answer set
		/// Returns as DataSet. Easy to bind to grid.
		/// </summary>
		/// <param name="currentSet"></param>
		/// <returns></returns>
		protected override DataSet FormDataSet()
		{

			try
			{
				DataSet ds = new DataSet("sudokuset");

				StringBuilder sb = new StringBuilder();
				sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				sb.Append("<sudokuset>");
				sb.Append("<numbersets>");

				for (int i = 0; i < MAX_ROWS; i++)
				{
					sb.Append("<numberset>");
					for (int j = 0; j < MAX_COLS; j++)
					{

						sb.Append("<col" + j.ToString().TrimEnd() + ">");
						if (_problemSet[i, j] == 0)
							sb.Append(" ");
						else
							sb.Append(_problemSet[i, j].ToString().TrimEnd());
						sb.Append("</col" + j.ToString().TrimEnd() + ">");
						sb.Append("\n");

					}
					sb.Append("</numberset>");
					sb.Append("\n");
				}
				sb.Append("</numbersets>");

				// Copy ProblemCopySet
				sb.Append("<problemcopysets>");

				for (int i = 0; i < MAX_ROWS; i++)
				{
					sb.Append("<problemcopyset>");
					for (int j = 0; j < MAX_COLS; j++)
					{

						sb.Append("<col" + j.ToString().TrimEnd() + ">");
						if (_problemSetCopy[i, j] == 0)
							sb.Append(" ");
						else
							sb.Append(_problemSetCopy[i, j].ToString().TrimEnd());
						sb.Append("</col" + j.ToString().TrimEnd() + ">");
						sb.Append("\n");

					}
					sb.Append("</problemcopyset>");
					sb.Append("\n");
				}
				sb.Append("</problemcopysets>");

				// Copy ProblemCopySet
				sb.Append("<answersets>");

				for (int i = 0; i < MAX_ROWS; i++)
				{
					sb.Append("<answerset>");
					for (int j = 0; j < MAX_COLS; j++)
					{

						sb.Append("<col" + j.ToString().TrimEnd() + ">");
						if (_numberSet[i, j] == 0)
							sb.Append(" ");
						else
							sb.Append(_numberSet[i, j].ToString().TrimEnd());
						sb.Append("</col" + j.ToString().TrimEnd() + ">");
						sb.Append("\n");

					}
					sb.Append("</answerset>");
					sb.Append("\n");
				}
				sb.Append("</answersets>");

				sb.Append("</sudokuset>");
				//	Console.WriteLine(sb.ToString());


				StringReader sr = new StringReader(sb.ToString());

				ds.ReadXml(sr);


				return ds;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error ocurred while forming dataset and is {0}", ex.Message);
				return null;
			}

		}






		/// <summary>
		/// Method:InitialiseSet
		/// Purpose:Creates Answer Set
		/// </summary>
		private void InitialiseSet()
		{
			int seed = DateTime.Now.Millisecond % 2;


			for (int i = 0; i < MAX_ROWS; i++)
			{
				for (int j = 0; j < MAX_COLS; j++)
				{

					_numberSet[i, j] = _originalSet[i, j];
					_problemSet[i, j] = 0;
					_problemSetCopy[i, j] = 0;
				}
			}
			Random number = new Random(seed);
			int roworcolPos = number.Next(1, 2);
			seed = DateTime.Now.Millisecond % 2;
			number = new Random(seed);
			int setNumber = number.Next(1, 2);
			if (_swapRows)
			{
				// swapRows
				SwapData(setNumber, roworcolPos, GameCombinations.SWAP_ROWS);
				_swapRows = false;
			}
			else
			{
				// swapCols
				SwapData(setNumber, roworcolPos, GameCombinations.SWAP_COLS);
				_swapRows = true;
			}

			seed = DateTime.Now.Millisecond % 2;
			number = new Random(seed);
			setNumber = number.Next(1, 2);
			// swapSet
			SwapData(setNumber, roworcolPos, GameCombinations.SWAP_SETS);



		}

		/// <summary>
		/// Method:SwapData
		/// </summary>
		/// <param name="setNumber"></param>
		/// <param name="roworcolPos"></param>
		/// <param name="swapType"></param>

		private void SwapData(int setNumber, int roworcolPos, GameCombinations swapType)
		{

			int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
			int i = 0, j = 0;
			switch (swapType)
			{
				case GameCombinations.SWAP_COLS:
					y1 = _setColPosition[setNumber * 2] + roworcolPos;
					if (roworcolPos == 2)
					{
						y2 = _setColPosition[setNumber * 2];
					}
					else
					{
						y2 = y1 + 1;
					}
					for (i = 0; i < MAX_ROWS; i++)
					{

						_numberSet[i, y2] = _originalSet[i, y1];
						_numberSet[i, y1] = _originalSet[i, y2];

					}
					break;
				case GameCombinations.SWAP_ROWS:
					x1 = _setRowPosition[setNumber * 2] + roworcolPos;
					if (roworcolPos == 2)
					{
						x2 = _setRowPosition[setNumber * 2];
					}
					else
					{
						x2 = x1 + 1;
					}
					for (i = 0; i < MAX_COLS; i++)
					{

						_numberSet[x2, i] = _originalSet[x1, i];
						_numberSet[x1, i] = _originalSet[x2, i];

					}
					break;

				case GameCombinations.SWAP_SETS:
					if (_swapRows)
					{
						x1 = setNumber;
						if (setNumber == 2)
							x2 = 0;
						else
							x2 = x1 + 1;

						for (j = 0; j < MAX_COLS; j++)
						{
							for (i = 0; i < MINI_SET_ROWS; i++)
							{
								int temp = _numberSet[x2 * 2 + i, j];
								_numberSet[x2 * 2 + i, j] = _numberSet[x1 * 2 + i, j];
								_numberSet[x1 * 2 + i, j] = temp;

							}
						}

					}
					else
					{
						y1 = setNumber;
						if (setNumber == 1)
							y2 = 0;
						else
							y2 = y1 + 1;

						for (j = 0; j < MAX_ROWS; j++)
						{
							for (i = 0; i < MINI_SET_COLS; i++)
							{
								int temp = _numberSet[j, y1 * 2 + i];
								_numberSet[j, y1 * 2 + i] = _numberSet[j, y2 * 2 + i];
								_numberSet[j, y2 * 2 + i] = temp;
							}
						}



					}
					break;
				default:
					break;





			}



		}

		/// <summary>
		/// Method:SwapNumberSet
		/// </summary>
		/// <param name="x1"></param>
		/// <param name="y1"></param>
		/// <param name="x2"></param>
		/// <param name="y2"></param>
		/// <param name="roworcol"></param>
		/// <returns></returns>

		private bool SwapNumberSet(int x1, int y1, int x2, int y2, int roworcol)
		{
			int n1, n2, n3, n4, cnt = 0;
			if (roworcol == 1)
			{
				n1 = _numberSet[x1, y1];
				n2 = _numberSet[x2, y1];
				n3 = _numberSet[x2, y2];
				n4 = _numberSet[x1, y2];
				_numberSet[x1, y1] = n2;
				_numberSet[x2, y1] = n1;
				_numberSet[x2, y2] = n4;
				_numberSet[x1, y2] = n3;

			}
			else
			{
				n1 = _numberSet[x1, y1];
				n2 = _numberSet[x1, y2];
				n3 = _numberSet[x2, y1];
				n4 = _numberSet[x2, y2];
				_numberSet[x1, y1] = n2;
				_numberSet[x1, y2] = n1;
				_numberSet[x2, y1] = n4;
				_numberSet[x2, y2] = n3;
			}

			if (roworcol == 1)
			{
				for (int i = 1; i <= MAX_ROWS; i++)
				{
					cnt = 0;
					for (int j = 0; j < MAX_COLS; j++)
					{

						if (_numberSet[x1, j] == i)
							cnt++;
					}
					if (cnt > 1)
					{
						_numberSet[x1, y1] = n1;
						_numberSet[x2, y1] = n2;
						_numberSet[x2, y2] = n3;
						_numberSet[x1, y2] = n4;

						return false;
					}
				}

				for (int i = 1; i <= MAX_ROWS; i++)
				{
					cnt = 0;
					for (int j = 0; j < MAX_COLS; j++)
					{

						if (_numberSet[x2, j] == i)
							cnt++;
					}
					if (cnt > 1)
					{
						_numberSet[x1, y1] = n1;
						_numberSet[x2, y1] = n2;
						_numberSet[x2, y2] = n3;
						_numberSet[x1, y2] = n4;

						return false;
					}
				}

			}
			else
			{
				for (int i = 1; i <= MAX_ROWS; i++)
				{
					cnt = 0;
					for (int j = 0; j < MAX_ROWS; j++)
					{

						if (_numberSet[j, y1] == i)
							cnt++;
					}
					if (cnt > 1)
					{
						_numberSet[x1, y1] = n1;
						_numberSet[x1, y2] = n2;
						_numberSet[x2, y1] = n3;
						_numberSet[x2, y2] = n4;

						return false;

					}
				}

				for (int i = 1; i <= MAX_ROWS; i++)
				{
					cnt = 0;
					for (int j = 0; j < MAX_ROWS; j++)
					{

						if (_numberSet[j, y2] == i)
							cnt++;
					}
					if (cnt > 1)
					{
						_numberSet[x1, y1] = n1;
						_numberSet[x1, y2] = n2;
						_numberSet[x2, y1] = n3;
						_numberSet[x2, y2] = n4;

						return false;
					}

				}


			}


			return true;
		}

		/// <summary>
		/// Method: SwapNumber
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="number"></param>
		/// <param name="set1"></param>
		/// <param name="setNumber"></param>
		/// <returns></returns>


		private bool SwapNumber(int pos, int number, int set1, int setNumber)
		{
			int[] xpos = { 0, 0, 1, 1, };
			int[] ypos = { 0, 1, 0, 1 };
			int x = 0, y = 0, x1, y1;
			bool duplicate = false;
			for (int i = 0; i < MAX_ROWS; i++)
			{
				duplicate = false;

				if (i != pos)
				{
					x = _setRowPosition[setNumber] + xpos[i];
					y = _setColPosition[setNumber] + ypos[i];

					duplicate = false;
					for (int j = 0; j < MAX_COLS; j++)
					{
						if ((_numberSet[x, j] == number) || (_numberSet[j, y] == number))
						{
							duplicate = true;
							j = MAX_COLS;
						}
					}
					if (!duplicate)
					{

						int newNumber = _numberSet[x, y];
						x1 = _setRowPosition[setNumber] + xpos[pos];
						y1 = _setColPosition[setNumber] + ypos[pos];
						_numberSet[x, y] = 0;
						for (int j = 0; j < MAX_COLS; j++)
						{
							if ((_numberSet[x1, j] == newNumber) || (_numberSet[j, y1] == newNumber))
							{
								duplicate = true;
								_numberSet[x, y] = newNumber;
								j = MAX_COLS;
							}
						}

						if (!duplicate)
						{
							// swap Numbers
							_numberSet[x, y] = number;
							_numberSet[x1, y1] = newNumber;
							return true;


						}
					}
				}
			}
			return false;
		}


        #region Fields
        bool _swapRows = true;
		private int[,] _originalSet = {{4,3,2,1},
									   {1,2,4,3},
									   {3,4,1,2},
									   {2,1,3,4}
									};
		private int[,] _numberSet;
		private int[,] _problemSet;
		private int[,] _problemSetCopy;
		private int[] _setRowPosition = { 0, 0, 1, 1 };
		private int[] _setColPosition = { 0, 1, 0, 1 };

		#endregion fields

		#region constants
		private const int MAX_ROWS = 4;
		private const int MAX_COLS = 4;
		private const int MINI_SET_ROWS = 2;
		private const int MINI_SET_COLS = 2;
		#endregion constants

	}
}

