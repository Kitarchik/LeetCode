using System.Text;

namespace ConsoleApp1;

public class Task14
{
    public static string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1) return strs[0];
        var result = new StringBuilder();
        var found = false;
        int index = 0;
        while (!found)
        {
            if (index == strs[0].Length)
            {
                found = true;
            }
            else
            {
                var candidate = strs[0][index];
                foreach (var str in strs)
                {
                    if (index == str.Length || str[index] != candidate)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    result.Append(candidate);
                }
                index++;
            }
        }

        return result.ToString();
    }
}
