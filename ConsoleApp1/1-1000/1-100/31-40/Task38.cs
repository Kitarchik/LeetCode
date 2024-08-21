using System.Text;

namespace ConsoleApp1;

public class Task38
{
    public string CountAndSay(int n)
    {
        var result = "1";
        if (n == 1) return result;
        var i = 1;
        while (i < n)
        {
            result = ConvertString(result);
            i++;
        }

        return result;
    }

    private string ConvertString(string input)
    {
        int i = 0;
        var result = new StringBuilder();
        while (i < input.Length)
        {
            var count = 1;
            var symbol = input[i];
            while (i < input.Length - 1 && input[i] == input[i + 1])
            {
                count++;
                i++;
            }
            i++;
            result.Append(count);
            result.Append(symbol);
        }

        return result.ToString();
    }
}
