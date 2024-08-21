namespace ConsoleApp1;

public class Task974
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        var result = 0;
        nums[0] = nums[0] % k;
        if (nums[0] < 0)
        {
            nums[0] = k + nums[0];
        }
        if (nums[0] == 0)
        {
            result++;
            dict.Add(0, 1);
        }
        else
        {
            dict.Add(nums[0], 1);
        }

        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = (nums[i] + nums[i - 1]) % k;
            if (nums[i] < 0)
            {
                nums[i] = k + nums[i];
            }
            if (nums[i] == 0)
            {
                result++;
            }
            if (dict.TryGetValue(nums[i], out int value))
            {
                result += value;
                dict[nums[i]] = ++value;
            }
            else
            {
                dict.Add(nums[i], 1);
            }
        }

        return result;
    }
}
