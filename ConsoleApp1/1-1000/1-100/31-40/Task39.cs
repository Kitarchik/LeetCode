namespace ConsoleApp1;

public class Task39
{
    private readonly List<IList<int>> result = new();
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        BuildSumTree(0, target, new List<int>(), 0, candidates);
        return result;
    }

    private void BuildSumTree(int sum, int target, List<int> numbers, int index, int[] candidates)
    {
        if (sum < target)
        {
            for (int i = index; i < candidates.Length; i++)
            {
                var num = new List<int>();
                num.AddRange(numbers);
                num.Add(candidates[i]);
                BuildSumTree(sum + candidates[i], target, num, i, candidates);
            }
        }
        else if (sum == target)
        {
            result.Add(numbers);
        }
    }
}
