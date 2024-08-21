namespace ConsoleApp1;

//test 2
//var c1 = new char[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' };
//var c2 = new char[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' };
//var c3 = new char[] { '.', '2', '.', '1', '.', '9', '.', '.', '.' };
//var c4 = new char[] { '.', '.', '7', '.', '.', '.', '2', '4', '.' };
//var c5 = new char[] { '.', '6', '4', '.', '1', '.', '5', '9', '.' };
//var c6 = new char[] { '.', '9', '8', '.', '.', '.', '3', '.', '.' };
//var c7 = new char[] { '.', '.', '.', '8', '.', '3', '.', '2', '.' };
//var c8 = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '6' };
//var c9 = new char[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' };

//test 5
//var c1 = new char[] { '.', '.', '.', '.', '.', '7', '.', '.', '9' };
//var c2 = new char[] { '.', '4', '.', '.', '8', '1', '2', '.', '.' };
//var c3 = new char[] { '.', '.', '.', '9', '.', '.', '.', '1', '.' };
//var c4 = new char[] { '.', '.', '5', '3', '.', '.', '.', '7', '2' };
//var c5 = new char[] { '2', '9', '3', '.', '.', '.', '.', '5', '.' };
//var c6 = new char[] { '.', '.', '.', '.', '.', '5', '3', '.', '.' };
//var c7 = new char[] { '8', '.', '.', '.', '2', '3', '.', '.', '.' };
//var c8 = new char[] { '7', '.', '.', '.', '5', '.', '.', '4', '.' };
//var c9 = new char[] { '5', '3', '1', '.', '7', '.', '.', '.', '.' };

//test 6
//var c1 = new char[] { '.', '.', '.', '2', '.', '.', '.', '6', '3' };
//var c2 = new char[] { '3', '.', '.', '.', '.', '5', '4', '.', '1' };
//var c3 = new char[] { '.', '.', '1', '.', '.', '3', '9', '8', '.' };
//var c4 = new char[] { '.', '.', '.', '.', '.', '.', '.', '9', '.' };
//var c5 = new char[] { '.', '.', '.', '5', '3', '8', '.', '.', '.' };
//var c6 = new char[] { '.', '3', '.', '.', '.', '.', '.', '.', '.' };
//var c7 = new char[] { '.', '2', '6', '3', '.', '.', '5', '.', '.' };
//var c8 = new char[] { '5', '.', '3', '7', '.', '.', '.', '.', '8' };
//var c9 = new char[] { '4', '7', '.', '.', '.', '1', '.', '.', '.' };

//var board = new char[][] { c1, c2, c3, c4, c5, c6, c7, c8, c9 };

public class Task37
{
    private List<Cell> _variants = new();
    private List<Answer> _answers = new();
    private readonly Stack<State> _states = new();

    public void SolveSudoku(char[][] board)
    {
        Init(board);
        var dupletsRemoved = false;
        while (_answers.Count < 81)
        {
            PrintBoard(board);

            var unvisitedAnswers = _answers.Where(x => !x.IsVisited).ToList();
            foreach (var answer in unvisitedAnswers)
            {
                var number = answer.Number;
                CheckColumn(answer, number);
                CheckRow(answer, number);
                CheckQuadrant(number, answer.Quadrant);
                answer.IsVisited = true;
            }

            if (FindSoloVariants(board) == 0)
            {
                CheckRowsForSingleVariant();
                if (FindSoloVariants(board) == 0)
                {
                    CheckColumnsForSingleVariant();
                    if (FindSoloVariants(board) == 0)
                    {
                        FindByRowsAndColumns();
                        if (FindSoloVariants(board) == 0)
                        {
                            if (!dupletsRemoved)
                            {
                                RemoveDuplets();
                                dupletsRemoved = true;
                            }
                            else
                            {
                                _states.Push(new State(_variants, _answers, board));
                                Guess(board, 0);
                                dupletsRemoved = false;
                            }
                        }
                    }
                }
            }
            CheckBoard(board);
        }

        PrintBoard(board);
    }

    private void Init(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                _variants.Add(new Cell(i, j));
            }
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (char.IsDigit(board[j][i]))
                {
                    _answers.Add(new Answer(i, j, board[j][i] - '0'));
                    var variant = _variants.First(x => x.X == i && x.Y == j);
                    _variants.Remove(variant);
                }
            }
        }
    }

    private void CheckColumn(Answer answer, int number)
    {
        var variants = _variants.Where(x => x.X == answer.X).ToList();
        foreach (var variant in variants)
        {
            variant.Numbers.Remove(number);
        }
    }

    private void CheckRow(Answer answer, int number)
    {
        var variants = _variants.Where(x => x.Y == answer.Y).ToList();
        foreach (var variant in variants)
        {
            variant.Numbers.Remove(number);
        }
    }

    private void CheckQuadrant(int number, int quadrantNumber)
    {
        var quadrantVariants = _variants.Where(x => x.Quadrant == quadrantNumber).ToList();
        foreach (var variant in quadrantVariants)
        {
            variant.Numbers.Remove(number);
        }
    }

    private void CheckRowsForSingleVariant()
    {
        for (int i = 0; i < 9; i++)
        {
            var variants = _variants.Where(x => x.Y == i).ToList();
            if (variants.Any())
            {
                var numbers = variants.SelectMany(x => x.Numbers).Distinct().ToList();
                foreach (var number in numbers)
                {
                    var variantsWithNumber = variants.Where(x => x.Numbers.Contains(number)).ToList();
                    if (variantsWithNumber.Count == 1)
                    {
                        variantsWithNumber.Single().Numbers = new List<int> { number };
                    }
                }
            }
        }
    }

    private void CheckColumnsForSingleVariant()
    {
        for (int i = 0; i < 9; i++)
        {
            var variants = _variants.Where(x => x.X == i).ToList();
            if (variants.Any())
            {
                var numbers = variants.SelectMany(x => x.Numbers).Distinct().ToList();
                foreach (var number in numbers)
                {
                    var variantsWithNumber = variants.Where(x => x.Numbers.Contains(number)).ToList();
                    if (variantsWithNumber.Count == 1)
                    {
                        variantsWithNumber.Single().Numbers = new List<int> { number };
                    }
                }
            }
        }
    }

    private void FindByRowsAndColumns()
    {
        for (int i = 1; i <= 9; i++)
        {
            var answers = _answers.Where(x => x.Number == i).ToList();
            var quadrants = new HashSet<int>();
            var rows = new HashSet<int>();
            var columns = new HashSet<int>();
            foreach (var answer in answers)
            {
                quadrants.Add(answer.Quadrant);
                rows.Add(answer.Y);
                columns.Add(answer.X);
            }
            var quadrantAdded = true;
            while (quadrantAdded)
            {
                quadrantAdded = false;
                for (int quadrant = 0; quadrant < 9; quadrant++)
                {
                    if (!quadrants.Contains(quadrant))
                    {
                        var variants = _variants
                            .Where(x =>
                                x.Quadrant == quadrant &&
                                x.Numbers.Contains(i) &&
                                !rows.Contains(x.Y) &&
                                !columns.Contains(x.X))
                            .ToList();
                        if (variants.Count > 1)
                        {
                            if (variants.Select(x => x.Y).Distinct().Count() == 1)
                            {
                                rows.Add(variants[0].Y);
                                quadrants.Add(quadrant);
                                quadrantAdded = true;
                            }
                            else if (variants.Select(x => x.X).Distinct().Count() == 1)
                            {
                                columns.Add(variants[0].X);
                                quadrants.Add(quadrant);
                                quadrantAdded = true;
                            }
                        }
                    }
                }
            }

            for (int quadrant = 0; quadrant < 9; quadrant++)
            {
                if (!quadrants.Contains(quadrant))
                {
                    var variants = _variants.Where(x => x.Quadrant == quadrant).ToList();
                    var neededColumns = Enumerable.Range(quadrant % 3 * 3, 3);
                    var neededRows = Enumerable.Range(quadrant / 3 * 3, 3);
                    foreach (var row in neededRows)
                    {
                        if (rows.Contains(row))
                        {
                            variants = variants.Where(x => x.Y != row).ToList();
                        }
                    }
                    foreach (var column in neededColumns)
                    {
                        if (columns.Contains(column))
                        {
                            variants = variants.Where(x => x.X != column).ToList();
                        }
                    }
                    if (variants.Count == 1)
                    {
                        variants.Single().Numbers = new List<int> { i };
                    }
                }
            }
        }
    }

    private void RemoveDuplets()
    {
        for (int i = 0; i < 9; i++)
        {
            var row = _variants.Where(x => x.Y == i).ToList();
            for (int j = 0; j < row.Count; j++)
            {
                if (row[j].Numbers.Count == 2)
                {
                    for (int k = j + 1; k < row.Count; k++)
                    {
                        if (row[k].Numbers.SequenceEqual(row[j].Numbers))
                        {
                            for (int x = 0; x < row.Count; x++)
                            {
                                if (x != j && x != k)
                                {
                                    row[x].Numbers.Remove(row[j].Numbers[0]);
                                    row[x].Numbers.Remove(row[j].Numbers[1]);
                                }
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            var column = _variants.Where(x => x.X == i).ToList();
            for (int j = 0; j < column.Count; j++)
            {
                if (column[j].Numbers.Count == 2)
                {
                    for (int k = j + 1; k < column.Count; k++)
                    {
                        if (column[k].Numbers.SequenceEqual(column[j].Numbers))
                        {
                            for (int x = 0; x < column.Count; x++)
                            {
                                if (x != j && x != k)
                                {
                                    column[x].Numbers.Remove(column[j].Numbers[0]);
                                    column[x].Numbers.Remove(column[j].Numbers[1]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void Guess(char[][] board, int index)
    {
        for (int i = 0; i < 9; i++)
        {
            var row = _variants.Where(x => x.Y == i).ToList();
            if (row.Count == 2)
            {
                CreateAnswer(row[0], board, index);
                break;
            }
            var column = _variants.Where(x => x.X == i).ToList();
            if (column.Count == 2)
            {
                CreateAnswer(column[0], board, index);
                break;
            }
        }
    }

    private int FindSoloVariants(char[][] board)
    {
        var soloVariants = _variants.Where(x => x.Numbers.Count == 1).ToList();
        foreach (var variant in soloVariants)
        {
            CreateAnswer(variant, board);
        }

        return soloVariants.Count;
    }

    private void CheckBoard(char[][] board)
    {
        if (!IsBoardValid())
        {
            var state = _states.Pop();
            _variants = state.Variants;
            _answers = state.Answers;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    board[i][j] = state.Board[i][j];
                }
            }
            Guess(board, 1);
        }
    }

    private bool IsBoardValid()
    {
        var valid = true;
        valid = !_variants.Any(x => x.Numbers.Count == 0);
        for (int i = 0; i < 9; i++)
        {
            if (valid)
            {
                var row = _answers.Where(x => x.Y == i).ToList();
                valid = row.Count == row.Select(x => x.Number).Distinct().Count();
                var column = _answers.Where(x => x.X == i).ToList();
                valid = column.Count == column.Select(x => x.Number).Distinct().Count();
                var quadrant = _answers.Where(x => x.Quadrant == i).ToList();
                valid = quadrant.Count == quadrant.Select(x => x.Number).Distinct().Count();
            }
        }

        return valid;
    }

    private void CreateAnswer(Cell variant, char[][] board, int index = 0)
    {
        var answerChar = variant.Numbers[index].ToString()[0];
        _answers.Add(new Answer(variant.X, variant.Y, answerChar - '0'));
        _variants.Remove(variant);
        board[variant.Y][variant.X] = answerChar;
    }

    private void PrintBoard(char[][] board)
    {
        Console.WriteLine();
        for (int i = 0; i < board.Length; i++)
        {
            if (i % 3 == 0)
            {
                Console.WriteLine("------------------------");
            }
            Console.WriteLine($"| {board[i][0]} {board[i][1]} {board[i][2]} | {board[i][3]} {board[i][4]} {board[i][5]} | {board[i][6]} {board[i][7]} {board[i][8]} |");
        }
        Console.WriteLine("------------------------");
    }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<int> Numbers { get; set; }
        public int Quadrant { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Quadrant = x / 3 + y / 3 * 3;
        }

        public Cell(int x, int y, List<int> numbers) : this(x, y)
        {
            Numbers = new List<int>();
            Numbers.AddRange(numbers);
        }
    }

    public class Answer
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }
        public int Quadrant { get; set; }
        public bool IsVisited { get; set; }

        public Answer(int x, int y, int answer)
        {
            X = x;
            Y = y;
            Number = answer;
            Quadrant = x / 3 + y / 3 * 3;
        }
    }

    public class State
    {
        public List<Cell> Variants { get; set; }
        public List<Answer> Answers { get; set; }
        public char[][] Board { get; set; }
        public State(List<Cell> variants, List<Answer> answers, char[][] board)
        {
            Variants = new();
            foreach (var variant in variants)
            {
                Variants.Add(new Cell(variant.X, variant.Y, variant.Numbers));
            }
            Answers = new();
            Answers.AddRange(answers);
            Board = new char[9][];
            for (int i = 0; i < 9; i++)
            {
                Board[i] = new char[9];
                for (int j = 0; j < 9; j++)
                {
                    Board[i][j] = board[i][j];
                }

            }
        }
    }
}
