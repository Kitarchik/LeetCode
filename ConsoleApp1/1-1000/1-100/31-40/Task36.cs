namespace ConsoleApp1;

public class Task36
{
    public bool IsValidSudoku(char[][] board)
    {
        return IsValidRows(board) && IsValidColumns(board) && IsValidQuadrants(board);
    }

    private bool IsValidRows(char[][] board)
    {
        foreach (var row in board)
        {
            var set = new HashSet<int>();
            foreach (var symbol in row)
            {
                if (char.IsDigit(symbol))
                {
                    if (!set.Add(symbol - '0'))
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private bool IsValidColumns(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            var set = new HashSet<int>();
            foreach (var row in board)
            {
                if (char.IsDigit(row[i]))
                {
                    if (!set.Add(row[i] - '0'))
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private bool IsValidQuadrants(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            var set = new HashSet<int>();
            for (int j = (i % 3) * 3; j < (i % 3) * 3 + 3; j++)
            {
                for (int k = (i / 3) * 3; k < (i / 3) * 3 + 3; k++)
                {
                    if (char.IsDigit(board[j][k]))
                    {
                        if (!set.Add(board[j][k] - '0'))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }
}
