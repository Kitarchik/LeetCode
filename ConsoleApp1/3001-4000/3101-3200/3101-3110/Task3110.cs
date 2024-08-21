namespace ConsoleApp1;

public class Task3110
{
    public int ScoreOfString(string s)
    {
        var result = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            result += Math.Abs(s[i] - s[i + 1]);
        }

        return result;
    }
}
