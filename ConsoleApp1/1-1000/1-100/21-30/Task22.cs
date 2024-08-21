namespace ConsoleApp1;

public class Task22
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        GenerateVariants(0, 0, n, new List<char>(), result);
        return result;
    }

    private void GenerateVariants(int countOpen, int countClose, int max, List<char> input, List<string> result)
    {
        if (input.Count == max * 2)
        {
            result.Add(new string(input.ToArray()));
        }
        else
        {
            if (countOpen < max)
            {
                var newInput = new List<char>(input)
                {
                    '('
                };
                GenerateVariants(countOpen + 1, countClose, max, newInput, result);
            }
            if (countClose < countOpen)
            {
                var newInput = new List<char>(input)
                {
                    ')'
                };
                GenerateVariants(countOpen, countClose + 1, max, newInput, result);
            }
        }
    }
}
