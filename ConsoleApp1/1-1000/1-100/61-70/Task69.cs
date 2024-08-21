namespace ConsoleApp1;

public class Task69
{
    public int MySqrt(int x)
    {
        if (x == 0) return 0;
        var current = (double)x / 2;
        var next = (current + x / current) / 2;
        while ((int)current != (int)next)
        {
            current = next;
            next = (current + x / current) / 2;
        }

        return (int)current;
    }
}
