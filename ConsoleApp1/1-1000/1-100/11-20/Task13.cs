using System.Runtime.CompilerServices;

namespace ConsoleApp1;

public class Task13
{
    public static int RomanToInt(string s)
    {
        var dict = new Dictionary<char, int>()
        {
            { 'M', 1000},
            { 'D', 500 },
            { 'C', 100 },
            { 'L', 50 },
            { 'X', 10 },
            { 'V', 5 },
            { 'I', 1 }
        };

        var result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length && dict[s[i + 1]] > dict[s[i]])
            {
                result -= dict[s[i]];
            }
            else
            {
                result += dict[s[i]];
            }
        }

        return result;
    }
}
