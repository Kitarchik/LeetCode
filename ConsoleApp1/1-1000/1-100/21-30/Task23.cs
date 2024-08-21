namespace ConsoleApp1;

public class Task23
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
        {
            return null;
        }
        var minHeap = new PriorityQueue<ListNode, int>();

        foreach (ListNode list in lists)
        {
            if (list != null)
            {
                minHeap.Enqueue(list, list.val);
            }
        }

        ListNode head = new ListNode();
        ListNode current = head;

        while (minHeap.Count > 0)
        {
            var element = minHeap.Dequeue();

            //Add min element from minheap into merge list
            current.next = new ListNode(element.val);
            current = current.next;

            //Add another element into minHeap from list of dequeued list
            if (element.next != null)
            {
                minHeap.Enqueue(element.next, element.next.val);
            }
        }
        return head.next;
    }
}
