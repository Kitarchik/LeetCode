namespace ConsoleApp1;

public class Task17
{
    private readonly Dictionary<char, string> dict = new()
    {
        {'1', string.Empty },
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"},
    };

    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits)) return new List<string>();
        var result = new List<string>();
        GetCombinations(0, string.Empty, digits, result);
        return result;
    }

    public void GetCombinations(int i, string currStr, string digits, List<string> result)
    {
        if (currStr.Length == digits.Length)
        {
            result.Add(currStr);
            return;
        }

        foreach (var c in dict[digits[i]])
        {
            GetCombinations(i + 1, currStr + c, digits, result);
        }
    }
}
