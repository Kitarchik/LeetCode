namespace ConsoleApp1;

public class Task27
{
    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0] == val ? 0 : 1;
        var right = nums.Length - 1;
        while (right >= 0 && nums[right] == val)
        {
            right--;
        }
        if (right < 0) return 0;

        var left = 0;
        while (left < right)
        {
            if (nums[left] == val)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                while (nums[right] == val)
                {
                    right--;
                }
            }
            left++;
        }

        return left + 1;
    }
}
