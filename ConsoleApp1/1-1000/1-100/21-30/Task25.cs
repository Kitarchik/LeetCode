namespace ConsoleApp1;

public class Task25
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var end = head;
        for (int i = 0; i < k; i++)
        {
            end = end?.next;
        }

        var start = head;
        var firstIteration = ReverseList(start, end);
        start = firstIteration;
        var tempEnd = start;
        for (int i = 0; i < k - 1; i++)
        {
            tempEnd = tempEnd?.next;
        }

        for (int i = 0; i < k; i++)
        {
            start = start?.next;
            end = end?.next;
            if (end == null && i < k - 1)
            {
                tempEnd = null;
            }
        }

        while (!(tempEnd == null && end == null))
        {
            start = ReverseList(start, end);
            tempEnd.next = start;
            for (int i = 0; i < k; i++)
            {
                tempEnd = tempEnd?.next;
                start = start?.next;
                end = end?.next;
                if (end == null && i < k - 1)
                {
                    tempEnd = null;
                }
            }
        }

        return firstIteration;
    }

    private ListNode ReverseList(ListNode start, ListNode end)
    {
        var currentEnd = end;
        while (start != end)
        {
            var temp = start.next;
            start.next = currentEnd;
            currentEnd = start;
            start = temp;
        }

        return currentEnd;
    }
}
