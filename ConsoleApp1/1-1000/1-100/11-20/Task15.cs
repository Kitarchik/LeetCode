namespace ConsoleApp1;

public class Task15
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num] += 1;
            }
            else
            {
                dict.Add(num, 1);
            }
        }
        dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        var result = new List<IList<int>>();
        foreach (var num in dict.Keys)
        {
            foreach (var secondNum in dict.Keys)
            {
                if (secondNum >= num)
                {
                    if (secondNum != num || dict[num] > 1)
                    {
                        var target = (num + secondNum) * (-1);
                        if (target >= secondNum && (target != 0 || dict[0] > 2))
                        {
                            if (dict.ContainsKey(target))
                            {
                                if ((target == num && dict[num] > 1) ||
                                    (target == secondNum && dict[secondNum] > 1) ||
                                    (target != num && target != secondNum))
                                    result.Add(new List<int> { num, secondNum, target });
                            }
                        }
                    }
                }
            }
        }

        return result;
    }
}
