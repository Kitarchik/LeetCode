namespace ConsoleApp1;

public class Task409
{
    public int LongestPalindrome(string s)
    {
        var dict = new Dictionary<char, int>();
        foreach (var letter in s)
        {
            if (dict.ContainsKey(letter))
            {
                dict[letter]++;
            }
            else
            {
                dict[letter] = 1;
            }
        }

        var odd = dict.Where(x => x.Value % 2 == 1).Sum(x => x.Value - 1);
        var sum = dict.Where(x => x.Value % 2 == 0).Sum(x => x.Value);
        return dict.Any(x => x.Value % 2 == 1) ? sum + odd + 1 : sum + odd;
    }
}
