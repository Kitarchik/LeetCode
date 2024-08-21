namespace ConsoleApp1;

public class Task35
{
    public int SearchInsert(int[] nums, int target)
    {
        if (nums.Length == 0)
        {
            return nums[0] >= target ? 0 : 1;
        }
        if (target < nums[0])
        {
            return 0;
        }
        if (target > nums[nums.Length - 1])
        {
            return nums.Length;
        }
        var left = 0;
        var right = nums.Length;
        var index = -1;

        while (left < right)
        {
            var center = (left + right) / 2;
            if (nums[center] == target)
            {
                index = center;
                break;
            }
            else if (nums[center] < target)
            {
                left = center + 1;
            }
            else
            {
                right = center;
            }
        }

        if (index == -1)
        {
            return nums[left] > target ? left : left + 1;
        }

        return index;
    }
}
