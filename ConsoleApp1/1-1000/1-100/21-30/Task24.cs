namespace ConsoleApp1;

public class Task24
{
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        var prefirst = (ListNode)null;
        var first = head;
        var second = first.next;
        var third = second?.next;
        var newHead = second;

        while (second != null)
        {
            first.next = third;
            second.next = first;
            if (prefirst != null)
            {
                prefirst.next = second;
            }
            prefirst = first;
            first = third;
            second = first?.next;
            third = second?.next;
        }

        return newHead;
    }
}
