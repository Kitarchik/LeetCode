namespace ConsoleApp1;

public class Task260
{
    public int[] SingleNumber(int[] nums)
    {
        var xor = 0;
        foreach (var x in nums)
        {
            xor ^= x;
        }

        var diffBit = xor & (-xor);

        int num1 = 0, num2 = 0;
        foreach (int num in nums)
        {
            if ((num & diffBit) == 0)
            {
                num1 ^= num;
            }
            else
            {
                num2 ^= num;
            }
        }

        return new int[] { num1, num2 };
    }
}
