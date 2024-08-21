namespace ConsoleApp1;

public class Task19
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var length = 0;
        var current = head;
        while (current != null)
        {
            current = current.next;
            length++;
        }
        current = head;
        if (length == n)
        {
            return head.next;
        }

        for (int i = 0; i < length - n - 1; i++)
        {
            current = current.next;
        }
        var r = current.next;
        current.next = r.next;

        return head;
    }
}
