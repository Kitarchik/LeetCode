namespace ConsoleApp1;

public class Task20
{
    public bool IsValid(string s)
    {
        var dict = new Dictionary<char, char>
        {
            {')', '(' },
            {']', '[' },
            {'}', '{' },
        };
        var closingParenthesis = ")]}";
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (!closingParenthesis.Contains(c))
            {
                stack.Push(c);
            }
            else
            {

                if (stack.Any() && stack.Peek() == dict[c])
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        return !stack.Any();
    }
}
