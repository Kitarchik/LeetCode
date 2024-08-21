namespace ConsoleApp1;

public class Task41
{
    public int FirstMissingPositive(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0)
            {
                nums[i] = -1;
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= nums.Length && nums[i] > 0)
            {
                var current = nums[i];
                nums[i] = -1;
                while (current > 0 && current <= nums.Length)
                {
                    var temp = nums[current - 1];
                    nums[current - 1] = 0;
                    current = temp;
                }
            }
            else if (nums[i] != 0)
            {
                nums[i] = -1;
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                return i + 1;
            }
        }
        return nums.Length + 1;
    }
}
