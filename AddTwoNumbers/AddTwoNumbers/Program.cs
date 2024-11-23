class Programm
{
    static void Main(string[] args)
    {
        var result = new Solution().AddTwoNumbers(
            new ListNode(3, new ListNode(4, new ListNode(2))),
            new ListNode(4, new ListNode(6, new ListNode(5))));
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        List<int> n1 = new();
        List<int> n2 = new();
        
        do
        {
            n1.Add(l1 == null ? 0 : l1.val);
            n2.Add(l2 == null ? 0 : l2.val);
            l1 = l1?.next;
            l2 = l2?.next;
        } while (l1 != null || l2 != null);

        ListNode result = new ListNode();
        ListNode current = result;
        int high = 0;
        for (int i = 0; i < n1.Count; i++)
        {
            int sum = n1[i] + n2[i] + high;
            int remainder;
            high = Math.DivRem(sum, 10, out remainder);
            current.next = new ListNode(remainder);
            current = current.next;
        }

        if (high > 0) { current.next = new ListNode(high); }

        return result.next;
    }
}

public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode next = next;
}