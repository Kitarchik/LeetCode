namespace ConsoleApp1;

public class Task31
{
    public void NextPermutation(int[] nums)
    {
        if (nums.Length <= 1) return;

        var right = nums.Length - 2;
        while (right >= 0 && nums[right] >= nums[right + 1])
        {
            right--;
        }

        var pivotIndex = right;

        if (pivotIndex >= 0)
        {
            right = nums.Length - 1;
            while (right >= 0 && nums[pivotIndex] >= nums[right])
            {
                right--;
            }

            (nums[pivotIndex], nums[right]) = (nums[right], nums[pivotIndex]);
        }

        var left = pivotIndex + 1;
        right = nums.Length - 1;
        while (left < right)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
            left++;
            right--;
        }
    }
}
