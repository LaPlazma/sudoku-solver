namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = (int)(Console.WindowHeight * 1.25);
            int[,] puzzle = {
                { 8,0,0,  0,0,0,    0,0,4 },
                { 5,0,0,  0,8,0,    0,1,7 },
                { 0,2,0,  5,0,0,    0,0,0 },

                { 0,0,6,  0,0,9,    0,0,0 },
                { 2,0,0,  0,7,0,    0,8,5 },
                { 0,0,0,  0,0,0,    3,0,0 },

                { 0,0,0,  0,3,0,    2,0,0 },
                { 1,0,0,  0,0,0,    4,0,0 },
                { 0,9,0,  0,0,7,    0,3,1 }
            };

            SudokuGrid sudoku = new SudokuGrid(puzzle);
            Console.WriteLine("Ausgangsgrid:");
            Console.WriteLine();
            Console.WriteLine(sudoku.ToString());
            int[] coords = sudoku.GetNextZero(sudoku.Grid, 0, 0);
            if (sudoku.Solve(sudoku.Grid, coords[0], coords[1]))
            {
                Console.WriteLine("Lösung:");
                Console.WriteLine();
                Console.WriteLine(sudoku.ToString());
            }
            else
            {
                Console.WriteLine("Das Sudoku ist nicht lösbar!");
            }
        }
    }
}