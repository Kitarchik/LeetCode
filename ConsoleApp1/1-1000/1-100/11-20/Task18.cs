namespace ConsoleApp1;

public class Task18
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (int first = 0; first <= nums.Length - 4; first++)
        {
            for (int second = first + 1; second <= nums.Length - 3; second++)
            {
                var third = second + 1;
                var fourth = nums.Length - 1;
                while (third < fourth)
                {
                    var sum = 0;
                    try
                    {
                        checked
                        {
                            sum = checked(nums[first] + nums[second] + nums[third] + nums[fourth]);
                        }
                    }
                    catch(OverflowException ex)
                    {
                        sum = target + 1;
                    }
                    if (sum == target)
                    {
                        if (!result.Any(x => x[0] == nums[first] && x[1] == nums[second] && x[2] == nums[third] && x[3] == nums[fourth]))
                        {
                            result.Add(new List<int> { nums[first], nums[second], nums[third], nums[fourth] });
                        }
                    }

                    if (sum <= target)
                    {
                        third++;
                    }
                    else
                    {
                        fourth--;
                    }
                }
            }
        }

        return result;
    }
}
