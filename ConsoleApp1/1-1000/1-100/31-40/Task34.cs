namespace ConsoleApp1;

public class Task34
{
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0) return new int[] { -1, -1 };
        if (nums.Length == 1)
        {
            return nums[0] == target ? new int[] { 0, 0 } : new int[] { -1, -1 };
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
            return new int[] { -1, -1 };
        }
        var leftIndex = index;
        var rightIndex = index;
        while (leftIndex >= 0 && nums[leftIndex] == target)
        {
            leftIndex--;
        }
        while (rightIndex < nums.Length && nums[rightIndex] == target)
        {
            rightIndex++;
        }

        return new int[] { leftIndex + 1, rightIndex - 1 };
    }
}
