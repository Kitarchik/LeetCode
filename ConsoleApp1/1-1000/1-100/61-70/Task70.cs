namespace ConsoleApp1;

public class Task70
{
    public int ClimbStairs(int n)
    {
        var previous = 1;
        var result = 2;
        var count = 2;
        if (n == 1) return 1;
        if (n == 2) return 2;
        while (count < n)
        {
            var temp = result;
            result += previous;
            previous = temp;
            count++;
        }
        return result;
    }
}
