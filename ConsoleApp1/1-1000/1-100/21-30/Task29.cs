namespace ConsoleApp1;

public class Task29
{
    public int Divide(int dividend, int divisor)
    {
        var result = (long)dividend / divisor;
        return result > int.MaxValue ?
            int.MaxValue
            : result < int.MinValue ? int.MinValue : (int)result;
    }
}
