namespace ConsoleApp1;

public class Task2486
{
    public int AppendCharacters(string s, string t)
    {
        var current = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t[current])
            {
                current++;
                if (current == t.Length)
                {
                    return 0;
                }
            }
        }

        return t.Length - current;
    }
}
