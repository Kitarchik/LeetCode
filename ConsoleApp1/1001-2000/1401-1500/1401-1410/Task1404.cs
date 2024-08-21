namespace ConsoleApp1;

public class Task1404
{
    public int NumSteps(string s)
    {
        var result = 0;
        if (s == "1") return 0;
        var tempResult = 0;
        var index = s.Length - 1;
        while (s[index] == '0')
        {
            result++;
            index--;
        }
        if (index == 0)
        {
            return result;
        }

        for (int i = index; i >= 0; i--)
        {
            tempResult++;
            if (s[i] == '0')
            {
                result += tempResult;
                tempResult = 1;
            }
        }

        result += tempResult + 1;

        return result;
    }
}
