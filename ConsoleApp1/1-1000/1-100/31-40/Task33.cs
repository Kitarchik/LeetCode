namespace ConsoleApp1;

public class Task33
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0) return -1;
        if (nums.Length == 1) return nums[0] == target ? 0 : -1;
        if (nums[0] < nums[^1])
        {
            return SubBinarySearch(nums, 0, nums.Length - 1, target);
        }
        else
        {
            if (target == nums[0]) return 0;
            var shift = 0;
            var start = 0;
            var end = nums.Length - 1;
            while (start <= end && shift == 0)
            {
                var center = (end + start) / 2;
                if (nums[center] > nums[center + 1])
                {
                    shift = center + 1;
                }
                else if (nums[center - 1] > nums[center])
                {
                    shift = center;
                }
                else
                {
                    if (nums[center] > nums[0])
                    {
                        start = center;
                    }
                    else
                    {
                        end = center;
                    }
                }
            }

            if (target < nums[0])
            {
                return SubBinarySearch(nums, shift, nums.Length - 1, target);
            }
            else
            {
                return SubBinarySearch(nums, 0, shift, target);
            }
        }
    }

    private int SubBinarySearch(int[] nums, int start, int end, int target)
    {
        var result = -1;
        while (end - start > 1 && result < 0)
        {
            var center = (end + start) / 2;
            if (nums[center] == target)
            {
                return center;
            }

            if (target > nums[center])
            {
                start = center;
            }
            else
            {
                end = center;
            }
        }

        if (nums[end] == target)
        {
            return end;
        }
        if (nums[start] == target)
        {
            return start;
        }

        return result;
    }
}
