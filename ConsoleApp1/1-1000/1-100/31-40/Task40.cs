namespace ConsoleApp1;

public class Task40
{
    private readonly List<IList<int>> result = new();
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        BuildSumTree(0, target, new List<int>(), -1, candidates);
        return result;
    }

    private void BuildSumTree(int sum, int target, List<int> numbers, int index, int[] candidates)
    {
        if (sum < target)
        {
            for (int i = index + 1; i < candidates.Length; i++)
            {
                var num = new List<int>();
                num.AddRange(numbers);
                num.Add(candidates[i]);
                BuildSumTree(sum + candidates[i], target, num, i, candidates);
            }
        }
        else if (sum == target)
        {
            var res = numbers.OrderBy(x => x).ToList();
            if (!result.Any(x => x.SequenceEqual(res)))
            {
                result.Add(res);
            }
        }
    }
}
