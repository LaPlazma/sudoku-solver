using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class SudokuGrid
    {
        private int[,] grid;

        public int[,] Grid { get { return grid; } }

        public SudokuGrid(int[,] grid)
        {
            this.grid = grid;
        }

        public int[] GetGridRow(int rowNum)
        {
            int[] row = new int[9];
            for (int i = 0; i < 9; i++)
            {
                row[i] = grid[rowNum, i];
            }
            return row;
        }

        public int[] GetGridCol(int colNum)
        {
            int[] col = new int[9];
            for (int i = 0; i < 9; i++)
            {
                col[i] = grid[i, colNum];
            }
            return col;
        }

        public int[,] GetSqare(int rowNum, int colNum)
        {
            int rowStart = ((int)(rowNum / 3)) * 3;
            int colStart = ((int)(colNum / 3)) * 3;
            int[,] square = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    square[i, j] = grid[rowStart + i, colStart + j];
                }
            }
            return square;
        }

        public bool NumIsValid(int num, int rowNum, int colNum)
        {
            int[] gridRow = GetGridRow(rowNum);
            int[] gridCol = GetGridCol(colNum);
            int[,] square = GetSqare(rowNum, colNum);
            if (gridRow.Contains(num)) return false;
            if (gridCol.Contains(num)) return false;
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    if (square[i,j] == num) return false;
                }
            }
            return true;
        }

        public int[] GetNextZero(int[,] square, int rowNum, int colNum)
        {
            int[] coords;
            for (int i = rowNum; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    if (i == rowNum && j == 0) j = colNum;
                    if (square[i, j] == 0)
                    {
                        coords = new int[] {i, j};
                        return coords;
                    }
                }
            }
            coords = new int[] { -1, -1 };
            return coords;
        }

        public bool Solve(int[,] _grid, int rowNum, int colNum)
        {
            if (rowNum < 9 && rowNum >= 0 && colNum < 9 && colNum >= 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (NumIsValid(i, rowNum, colNum))
                    {
                        _grid[rowNum, colNum] = i;
                        int[] coords = GetNextZero(_grid, rowNum, colNum);
                        if (coords[0] != -1)
                        {
                            if (Solve(_grid, coords[0], coords[1]))
                            {
                                grid = _grid;
                                return true;
                            }
                        }
                        else
                        {
                            grid = _grid;
                            return true;
                        }
                    }
                }
                _grid[rowNum, colNum] = 0;
                return false;
            }
            else return false;
        }

        public void PrintSquare(int[,] square)
        {
            for(int i = 0; i < square.GetLength(0); i++)
            {
                for(int j = 0; j < square.GetLength(1); j++)
                {
                    Console.Write(square[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            string s = "";
            for(int i = 0; i < 9; i++)
            {
                if (i % 3 == 0) s += " +-------+-------+-------+\n";
                for(int j = 0; j < 9; j++)
                {
                    if(j % 3 == 0) s += " |";
                    s += " " + (grid[i, j] == 0 ? "-" : grid[i, j]);
                }
                s += " |\n";
            }
            s += " +-------+-------+-------+\n";
            return s;
        }
    }
}
