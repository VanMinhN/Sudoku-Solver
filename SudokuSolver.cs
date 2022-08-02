using System;
public class SodukuSolver
{
    static int SIZE = 9;
    public static bool solveAlgo(char[,] board, int row, int col)
    {
        /*
        *   When we reach 8th row and 9th col, return true to avoid further backtracking
        */
        if (row == SIZE - 1 && col == SIZE)
        {
            return true;
        }
        /*
        *   check if col is 9, if yes then move to next row and col back to 0
        */
        if (col == SIZE)
        {
            row++;
            col = 0;
        }
        /*
        * check if the current index contains value 1-9
        */
        if (board[row, col] != '.')
        {
            return solveAlgo(board, row, col + 1);
        }
        /*
        * check to see if it is safe to place 1-9 in this cell
        */
        for (int i = 1; i < 10; i++)
        {
            if (isSafe(board, row, col, i))
            {
                board[row, col] = (char)('0' + i);

                if (solveAlgo(board, row, col + 1))
                {
                    return true;
                }
            }
            board[row, col] = '.';
        }
        return false;
    }
    /*
    * Check if it is legal to assign number into the given row+col
    */
    public static bool isSafe(char[,] board, int row, int col, int number)
    {
        char n = (char)('0' + number);
        //check if the number is present in the similar column
        for (int i = 0; i < 9; i++)
        {
            if (board[row, i].Equals(n))
            {
                return false;
            }
        }

        //check if the number is present in the similar row
        for (int i = 0; i < 9; i++)
        {
            if (board[i, col].Equals(n))
            {
                return false;
            }
        }
        //Check if the number is present in the 3x3 matrix
        int startRow = row - row % 3;
        int startCol = col - col % 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i + startRow, j + startCol].Equals(n))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void Main(String[] args)
    {
        char[,] board = new char[9, 9]{{'5','3','.','.','7','.','.','.','.'},
                        {'6','.','.','1','9','5','.','.','.'},
                        {'.','9','8','.','.','.','.','6','.'},
                        {'8','.','.','.','6','.','.','.','3'},
                        {'4','.','.','8','.','3','.','.','1'},
                        {'7','.','.','.','2','.','.','.','6'},
                        {'.','6','.','.','.','.','2','8','.'},
                        {'.','.','.','4','1','9','.','.','5'},
                        {'.','.','.','.','8','.','.','7','9'}};
        ;
        if (solveAlgo(board, 0, 0))
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No solution");
        }
    }
}
