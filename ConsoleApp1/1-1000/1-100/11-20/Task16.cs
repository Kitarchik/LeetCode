namespace ConsoleApp1;

public class Task16
{
    public static int ThreeSumClosest(int[] nums, int target)
    {
        if (nums.Length == 3) return nums[0] + nums[1] + nums[2];
        Array.Sort(nums);
        int? result = null;
        for (int first = 0; first < nums.Length - 2; first++)
        {
            for (int second = first + 1; second < nums.Length - 1; second++)
            {
                for (int third = second + 1; third < nums.Length; third++)
                {
                    var sum = nums[first] + nums[second] + nums[third];
                    if (sum == target) return target;
                    if (result == null || Math.Abs(sum - target) < Math.Abs(result.Value - target))
                    {
                        result = sum;
                    }
                }
            }
        }
        return result!.Value;
    }
}
