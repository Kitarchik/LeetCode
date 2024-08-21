namespace ConsoleApp1;

public class Task32
{
    public int LongestValidParentheses(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;
        var open = '(';
        var stack = new Stack<char>();
        var max = 0;
        var current = 0;
        var lastUnclosedOpen = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == open)
            {
                stack.Push(s[i]);
                lastUnclosedOpen.Push(i);
                current++;
            }
            else
            {
                if (stack.Any() && stack.Peek() == open)
                {
                    stack.Pop();
                    var candidate = lastUnclosedOpen.Pop();
                    current++;
                    if (i - candidate + 1 > max)
                    {
                        max = i - candidate + 1;
                    }
                }
                else
                {
                    var end = i;
                    while (lastUnclosedOpen.Any())
                    {
                        var candidate = lastUnclosedOpen.Pop();
                        if (end - candidate - 1 > max)
                        {
                            max = end - candidate - 1;
                        }
                        end = candidate;
                    }
                    current = 0;
                    stack.Clear();
                    lastUnclosedOpen.Clear();
                }
            }

            if (!stack.Any() && current > max)
            {
                max = current;
            }
        }

        if (lastUnclosedOpen.Any())
        {
            var end = s.Length;
            while (lastUnclosedOpen.Any())
            {
                var candidate = lastUnclosedOpen.Pop();
                if (end - candidate - 1 > max)
                {
                    max = end - candidate - 1;
                }
                end = candidate;
            }
        }
        else
        {
            if (current > max)
            {
                max = current;
            }
        }

        return max;
    }
}
