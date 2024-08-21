namespace ConsoleApp1;

public class Task10
{
    public bool IsMatch(string s, string p)
    {
        var stateMachine = BuildStateMachine(p);

        var queue = new Queue<(int, StateNode)>();
        var visited = new HashSet<(int, StateNode)>();
        queue.Enqueue((0, stateMachine));
        while (queue.Count > 0)
        {
            var (ptr, node) = queue.Dequeue();
            if (ptr >= s.Length)
            {
                if (node.IsTerminal)
                    return true;
                continue;
            }

            if (node.Transitions.TryGetValue('_', out var emptyTransitions))
            {
                foreach (var transition in emptyTransitions)
                {
                    var pair = (ptr, transition);
                    if (!visited.Contains(pair))
                    {
                        queue.Enqueue(pair);
                        visited.Add(pair);
                    }
                }
            }

            if (node.Transitions.TryGetValue('.', out var dotTransitions))
            {
                foreach (var transition in dotTransitions)
                {
                    var pair = (ptr + 1, transition);
                    if (!visited.Contains(pair))
                    {
                        queue.Enqueue(pair);
                        visited.Add(pair);
                    }
                }
            }

            if (node.Transitions.TryGetValue(s[ptr], out var charTransitions))
            {
                foreach (var transition in charTransitions)
                {
                    var pair = (ptr + 1, transition);
                    if (!visited.Contains(pair))
                    {
                        queue.Enqueue(pair);
                        visited.Add(pair);
                    }
                }
            }
        }

        return false;
    }

    private StateNode BuildStateMachine(string pattern)
    {
        var startNode = new StateNode();

        var ptr = 0;
        var currentNode = startNode;

        while (ptr < pattern.Length)
        {
            var currentChar = pattern[ptr];
            ptr++;
            if (ptr < pattern.Length && pattern[ptr] == '*')
            {
                ptr++;
                var node = new StateNode();
                node.Transitions[currentChar] = new List<StateNode>() { node };
                currentNode.Transitions['_'] = new List<StateNode>() { node };
                currentNode = node;
            }
            else
            {
                var node = new StateNode();
                if (!currentNode.Transitions.ContainsKey(currentChar))
                    currentNode.Transitions[currentChar] = new List<StateNode>();
                currentNode.Transitions[currentChar].Add(node);
                currentNode = node;
            }
        }

        currentNode.IsTerminal = true;
        AssignTerminal(startNode);

        return startNode;
    }

    private void AssignTerminal(StateNode node)
    {
        foreach (var (_, transition) in node.Transitions)
            foreach (var n in transition)
                if (n != node)
                    AssignTerminal(n);

        if (node.Transitions.TryGetValue('_', out var nextNodes))
            foreach (var nextNode in nextNodes)
                node.IsTerminal |= nextNode.IsTerminal;

    }

    private class StateNode
    {
        public bool IsTerminal { get; set; }
        public Dictionary<char, List<StateNode>> Transitions { get; } = new();
    }
}
