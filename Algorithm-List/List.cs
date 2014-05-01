using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Algorithm_List
{
    public class RandomListNode {
     public int label;
     public RandomListNode next, random;
     public RandomListNode(int x) { this.label = x; }
    }

  public  class List
    {
        public List() { }


        #region 2.1
        //Write code to remove duplicates from an unsorted linked list.
        //FOLLOW UP
        //How would you solve this problem if a temporary buffer is not allowed?
        public void RemoveDuplicate(ref LinkedList<int> l)
        {
            Hashtable table = new Hashtable();
            LinkedListNode<int> head = l.First;
            LinkedListNode<int> previous = null;

            if (head != null)
            {
                LinkedListNode<int> node = head;
                while (node != null)
                {
                    if (table.Contains(node.Value))
                    {
                        //  previous.Next = node.Next; // "Next" is read only 
                        l.Remove(node);
                    }
                    else
                    {
                        table.Add(node.Value, true);
                        previous = node;
                    }
                    node = node.Next;
                }
            }
        }

        public void RemoveDuplicateWithoutBuffer(ref LinkedList<int> l)
        {

            LinkedListNode<int> current = l.First;

            while (current != null)
            {
                LinkedListNode<int> runner = current;
                while (runner.Next != null)
                {
                    if (runner.Value == current.Next.Value)
                    {
                        //  runner.Next = runner.Next.Next;// "Next" is read only value
                        l.Remove(current);
                    }
                    else
                    {

                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }

        }



        #endregion
        #region 2.2

        //Implement an algorithm to find the kth to last element of a singly linked list.
        public int FindKth(int k, LinkedList<int> l)
        {
            LinkedListNode<int> node = l.First;
            int value = 0;
            FindKthNode(node, k, ref value);
            return value;

        }
        private int FindKthNode(LinkedListNode<int> head, int k, ref int value)
        {

            if (head == null)
            {
                return 0;
            }

            int n = FindKthNode(head.Next, k, ref value) + 1;

            if (n == k)
            {
                value = head.Value;
            }

            return n;

        }

        public LinkedListNode<int> FindKthNodeWithoutRecursive(int k, LinkedList<int> l)
        {
            LinkedListNode<int> fast = l.First;
            LinkedListNode<int> slow = l.First;

            for (int i = 0; i < k - 1; i++)
            {
                if (fast == null) return fast;
                fast = fast.Next;
            }

            if (fast == null) return null;

            while (fast.Next != null)
            {

                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;

        }
        #endregion
        #region 2.3
        //implement an algorithm to delete a node in the middle of a singly linked list, given
        // only access to that node.
        // if the list only have one node
        // myself 
        //public void DeleteList(MyNode node)
        //{
        //    MyNode temp = head;
        //    MyNode perious = head;
        //    // if the node in the head
        //    if (node == head)
        //    {
        //        head = head.next;
        //        return;
        //    }
        //    // if the node in the middle
        //    while (temp.next != null)
        //    {
        //        if (temp == node)
        //        {
        //            perious.next = temp.next;
        //            return;
        //        }
        //        else
        //        {

        //            perious = temp;
        //            temp = temp.next;
        //        }
        //    }
        //    // if the node in the tail 
        //    if (perious != null && perious.next == node)
        //    {
        //        perious.next = null;
        //    }




        //}




        #endregion

        #region 2.5
        //You have two numbers represented by a linked list, where each node contains a
        //single digit. The digits are stored in reverse order, such that the 1 's digit is at the head
        //of the list. Write a function that adds the two numbers and returns the sum as a
        //linked list. 1234： 1-2-3-4 
        LinkedList<int> result = new LinkedList<int>();
        public void AddLists(LinkedListNode<int> l1, LinkedListNode<int> l2, int carry)
        {
            /* We're done if both lists are null AND the carry value is 0 */
            if (l1 == null && l2 == null && carry == 0)
            {
                return;
            }

            /* Add value, and the data from 11 and 12 */
            int value = carry;
            if (l1 != null)
            {
                value += l1.Value;
            }
            if (l2 != null)
            {
                value += l2.Value;
            }


            result.AddLast(value % 10);


            /* Recurse */
            if (l1 != null || l2 != null)
            {
                AddLists(l1 == null ? null : l1.Next,
                l2 == null ? null : l2.Next,
                value >= 10 ? 1 : 0);
                // result.setNext(more);


            }

        }



        public class PartialSum
        {
            public LinkedList<int> sum = null;
            public int carry = 0;
        }

        public LinkedList<int> AddLists(LinkedList<int> l1, LinkedList<int> l2)
        {


            /* Pad the shorter list with zeros - see note (1) */
            if (l1.Count < l2.Count)
            {
                padList(ref l1, l2.Count - l1.Count);
            }
            else
            {
                padList(ref l2, l1.Count - l2.Count);
            }

            /* Add lists */
            PartialSum sum = AddListsHelper(l1.First, l2.First);

            /* If there was a carry value left over, insert this at the
           21 * front of the list. Otherwise, just return the linked list. */
            if (sum.carry > 0)
            {

                sum.sum.AddFirst(sum.carry);


            }

            return sum.sum;
        }

        private PartialSum AddListsHelper(LinkedListNode<int> l1, LinkedListNode<int> l2)
        {
            if (l1 == null && l2 == null)
            {
                PartialSum sum = new PartialSum();
                return sum;
            }
            /* Add smaller digits recursively */
            PartialSum s = AddListsHelper(l1.Next, l2.Next);

            /* Add carry to current data */
            int val = s.carry + l1.Value + l2.Value;

            /* Insert sum of current digits */
            LinkedListNode<int> full_result = s.sum.AddFirst(val % 10);

            /* Return sum so far, and the carry value */
            s.sum.AddFirst(full_result);
            s.carry = val / 10;
            return s;
        }

        /* Pad the list with zeros */
        private void padList(ref LinkedList<int> l, int padding)
        {

            for (int i = 0; i < padding; i++)
            {
                LinkedListNode<int> n = new LinkedListNode<int>(0);
                l.AddFirst(n);
            }

        }




        #endregion 2.5

        #region 2.7
        //2.7 Implement a function to check if a linked list is a palindrome
        public bool IsPalindrome(LinkedListNode<int> head)
        {
            LinkedListNode<int> fast = head;
            LinkedListNode<int> slow = head;


            Stack<int> stack = new Stack<int>();

            /* Push elements from first half of linked list onto stack. When
             * fast runner (which is moving at 2x speed) reaches the end of
             * the linked list, then we know we're at the middle */
            while (fast != null && fast.Next != null)
            {
                stack.Push(slow.Value);
                slow = slow.Next;
                fast = fast.Next.Next;

            }

            /* Has odd number of elements, so skip the middle element */
            if (fast != null)
            {
                slow = slow.Next;
            }

            while (slow != null)
            {
                int top = stack.Pop();

                /* If values are different, then it's not a palindrome */
                if (top != slow.Value)
                {
                    return false;
                }
                slow = slow.Next;
            }
            return true;
        }
        private class Result
        {
            public LinkedListNode<int> node;
            public bool result;
            public Result(LinkedListNode<int> n, bool r)
            {
                result = r;
                node = n;
            }
        }
        private Result IsPalindromeRecurse(LinkedListNode<int> head, int length)
        {

            if (head == null || length == 0)
            {
                return new Result(null, true);
            }
            else if (length == 1)
            {
                return new Result(head.Next, true);
            }
            else if (length == 2)
            {
                return new Result(head.Next.Next,
                 head.Value == head.Next.Value);
            }
            Result res = IsPalindromeRecurse(head.Next, length - 2);
            if (!res.result || res.node == null)
            {
                return res;
            }
            else
            {
                res.result = (head.Value == res.node.Value);
                res.node = res.node.Next;
                return res;
            }
        }

        public bool IsPalindromeWithRecurse(int length, LinkedList<int> l)
        {
            Result p = IsPalindromeRecurse(l.First, length);
            return p.result;
        }
        #endregion

        #region LeetCode Linked List Cycle

        /*
     Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

    Follow up:
    Can you solve it without using extra space?
     */
        public bool HasLoop(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return false;
            }

            LinkedListNode<int> slow = head;
            LinkedListNode<int> fast = head;

            while (true)
            {
                slow = slow.Next;

                if (fast.Next != null)
                {
                    fast = fast.Next.Next;
                }
                else
                {
                    return false;
                }

                if (slow == null || fast == null)
                {
                    return false;
                }

                if (slow == fast)
                {
                    return true;
                }
            }
        }
        #endregion


        #region LeetCode Linked List Cycle Follow up

        /**
 * Returns the node at the start of a loop in the given circular linked
 * list. A circular list is one in which a node's next pointer points
 * to an earlier node, so as to make a loop in the linked list. For
 * instance:
 *
 * input: A -> B -> C -> D -> E -> C [the same C as earlier]
 * output: C
 * list to be tested
 * @return the node at the start of the loop if there is a loop, null
 * otherwise
 */
        public LinkedListNode<int> FindLoopStart(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }

            LinkedListNode<int> loopStartNode = null;
            LinkedListNode<int> slow = head;
            LinkedListNode<int> fast = head;

            while (slow != null && fast != null)
            {
                slow = slow.Next;
                if (fast.Next == null)
                {
                    loopStartNode = null;
                    break;
                }
                fast = fast.Next.Next;

                // If slow and fast point to the same node, it means that the linkedList contains a loop.
                if (slow == fast)
                {

                    slow = head;

                    while (slow != fast)
                    {
                        // Keep incrementing the two pointers until they both
                        // meet again. When this happens, both the pointers will
                        // point to the beginning of the loop
                        slow = slow.Next; // Can't be null, as we have a loop
                        fast = fast.Next; // Can't be null, as we have a loop
                    }

                    loopStartNode = slow;
                    break;
                }
            }

            return loopStartNode;
        }

        #endregion

        #region Copy List with Random Pointer

        /*A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.Return a deep copy of the list.*/



        public RandomListNode CopyRandomList(RandomListNode head)
        {

        if (head == null ){return null;}
            //map <originalNode, newNode>
        Dictionary <RandomListNode,RandomListNode> mp = new Dictionary<RandomListNode,RandomListNode>();
        
        RandomListNode res=new RandomListNode(0);
        RandomListNode p=head;
        RandomListNode q=res;
         
        while (p!=null){
            RandomListNode tmp = new RandomListNode(p.label);
            q.next = tmp;
            mp[p]=tmp;
            p=p.next;
            q=q.next;
        }
        p=head;
        q=res.next;
        while (p!=null){
            if (p.random==null){
                q.random=null;
            }else{
                q.random = mp[p.random];
            }
            p=p.next;
            q=q.next;
        }
        return res.next;
    }

        }

        #endregion

    }


