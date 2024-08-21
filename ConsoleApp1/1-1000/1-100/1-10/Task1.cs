using System.Text;

namespace ConsoleApp1;

public class Task1
{
    public static bool IsPalindromeReverse(ListNode head)
    {
        var builder = new StringBuilder();
        while (head != null)
        {
            builder.Append(head.val);
            head = head.next;
        }

        return builder.ToString() == new string(builder.ToString().Reverse().ToArray());
    }

    public static bool IsPalindromeStack(ListNode head)
    {
        var stack = new Stack<int>();
        var isEven = false;
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null)
        {
            stack.Push(slow.val);
            slow = slow.next;
            fast = fast.next;
            if (fast.next == null)
            {
                isEven = true;
            }
            else
            {
                fast = fast.next;
            }
        }
        slow = isEven ? slow : slow.next;
        while (slow != null)
        {
            if (stack.Pop() != slow.val)
            {
                return false;
            }
            slow = slow.next;
        }

        return true;
    }

    public static bool IsPalindrome(ListNode head)
    {
        var isEven = false;
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next;
            if (fast.next == null)
            {
                isEven = true;
            }
            else
            {
                fast = fast.next;
            }
        }

        var center = slow;
        var result = head;
        var current = head;
        var newEnd = center;
        while (current != center)
        {
            var nextCurrent = current.next;
            current.next = newEnd;
            newEnd = current;
            if (nextCurrent == center)
            {
                result = current;
            }
            current = nextCurrent;
        }

        center = isEven ? center : center.next;
        while (center != null)
        {
            if (result.val != center.val)
            {
                return false;
            }
            result = result.next;
            center = center.next;
        }

        return true;
    }

    private static (ListNode Center, bool IsEven) GetCenter(ListNode head)
    {
        var isEven = false;
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next;
            if (fast.next == null)
            {
                isEven = true;
            }
            else
            {
                fast = fast.next;
            }
        }

        return (slow, isEven);
    }

    private static ListNode RevertList(ListNode start, ListNode end)
    {
        var result = start;
        var current = start;
        var newEnd = end;
        while (current != end)
        {
            var nextCurrent = current.next;
            current.next = newEnd;
            newEnd = current;
            if (nextCurrent == end)
            {
                result = current;
            }
            current = nextCurrent;
        }

        return result;
    }

    private static bool CompareLists(ListNode head1, ListNode head2)
    {
        while (head2 != null)
        {
            if (head1.val != head2.val)
            {
                return false;
            }
            head1 = head1.next;
            head2 = head2.next;
        }

        return true;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
