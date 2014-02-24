using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Algorithm_List
{
    
        class List
        {
            public List() { }
            public LinkedListNode<int> head;
            public int this[int index]
            {
                get
                {
                    int[] arrResult = TravelList();
                    return arrResult[index];


                }
                set
                {
                    LinkedListNode<int> temp = head;
                    int i = 0;
                    while (temp.Next != null)
                    {
                        if (i == index)
                        {
                            break;
                        }
                        else
                        {
                            temp = temp.Next;
                            i++;

                        }
                        if (i == index)
                        {
                            temp.Value = value;
                        }
                    }

                }

            }
            #region 2.1
            //Write code to remove duplicates from an unsorted linked list.
            //FOLLOW UP
            //How would you solve this problem if a temporary buffer is not allowed?
            public void RemoveDuplicate()
            {
                Hashtable table = new Hashtable();
                MyNode previous = null;
                if (head != null)
                {
                    MyNode node = head;
                    while (node != null)
                    {
                        if (table.Contains(node.data))
                        {
                            previous.next = node.next;
                        }
                        else
                        {
                            table.Add(node.data, true);
                            previous = node;
                        }
                        node = node.next;
                    }
                }
            }

            public void RemoveDuplicateWithoutBuffer()
            {

                MyNode current = head;

                while (current != null)
                {
                    MyNode runner = current;
                    while (runner.next != null)
                    {
                        if (runner.data == current.next.data)
                        {
                            runner.next = runner.next.next;
                        }
                        else
                        {

                            runner = runner.next;
                        }
                    }

                    current = current.next;
                }

            }



            #endregion
            #region 2.2

            //Implement an algorithm to find the kth to last element of a singly linked list.
            public int FindKth(int k)
            {
                LinkedListNode<int> node = head;
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

            public LinkedListNode<int> FindKthNodeWithoutRecursive(int k)
            {
                LinkedListNode<int> fast = head;
                LinkedListNode<int> slow = head;

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


            public bool DeleteNode(MyNode n)
            {
                if (n == null || n.next == null)
                {
                    return false; // Failure
                }
                MyNode next = n.next;
                n.data = next.data;
                n.next = next.next;
                return true;
            }

            //public void DeleteList(ref MyNode node)
            //{

            //    if (node != null && node.next != null)
            //    {

            //        MyNode temp = node;
            //        MyNode perious = null;
            //        while (temp.next != null)
            //        {
            //            temp.data = temp.next.data;
            //            perious = temp;
            //            temp = temp.next;

            //        }
            //        if (perious != null) perious.next = null;

            //    }

            //    if (node != null && node.next == null)
            //    {

            //        node = null;

            //    }


            //}

            #endregion
            #region 2.4
            //Write code to partition a linked list around a value x, such that all nodes less than x
            //come before all nodes greater than or equal to x.
            public MyNode Partition(int x)
            {
                MyNode beforeStart = null;
                MyNode beforeEnd = null;
                MyNode afterStart = null;
                MyNode afterEnd = null;
                MyNode node = head;

                while (node != null)
                {


                    if (node.data <= x)
                    {

                        if (beforeStart == null)
                        {

                            beforeStart = node;
                            beforeEnd = beforeStart;
                        }
                        else
                        {
                            beforeEnd.next = node;
                            beforeEnd = node;

                        }

                    }

                    else
                    {
                        if (afterStart == null)
                        {
                            afterStart = node;
                            afterEnd = afterStart;
                        }
                        else
                        {
                            afterEnd.next = node;
                            afterEnd = node;

                        }

                    }

                    node = node.next;

                }

                if (beforeStart != null)
                {
                    beforeEnd.next = afterStart;
                    afterEnd.next = null;
                    return beforeStart;
                }
                else
                {
                    afterEnd.next = null;
                    return afterStart;

                }
            }
            // only use two variable
            public MyNode Partition2(int x)
            {

                MyNode node = head;
                MyNode beforeStart = null;
                MyNode afterStart = null;

                /* Partition list */
                while (node != null)
                {
                    MyNode next = node.next;
                    if (node.data < x)
                    {
                        /* Insert node into start of before list */
                        node.next = beforeStart;
                        beforeStart = node;
                    }
                    else
                    {
                        /* Insert node into front of after list */
                        node.next = afterStart;
                        afterStart = node;
                    }
                    node = next;
                }

                /* Merge before list and after list */
                if (beforeStart == null)
                {
                    return afterStart;
                }

                /* Find end of before list, and merge the lists */
                MyNode before_head = beforeStart;
                while (beforeStart.next != null)
                {
                    beforeStart = beforeStart.next;
                }
                beforeStart.next = afterStart;

                return before_head;
            }


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
                s.sum.AddFirst( full_result);
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
            public bool IsPalindrome(MyNode head)
            {
                MyNode fast = head;
                MyNode slow = head;


                Stack<int> stack = new Stack<int>();

                /* Push elements from first half of linked list onto stack. When
                 * fast runner (which is moving at 2x speed) reaches the end of
                 * the linked list, then we know we're at the middle */
                while (fast != null && fast.next != null)
                {
                    stack.Push(slow.data);
                    slow = slow.next;
                    fast = fast.next.next;
                }

                /* Has odd number of elements, so skip the middle element */
                if (fast != null)
                {
                    slow = slow.next;
                }

                while (slow != null)
                {
                    int top = stack.Pop();

                    /* If values are different, then it's not a palindrome */
                    if (top != slow.data)
                    {
                        return false;
                    }
                    slow = slow.next;
                }
                return true;
            }
            private class Result
            {
                public MyNode node;
                public bool result;
                public Result(MyNode n, bool r)
                {
                    result = r;
                    node = n;
                }
            }
            private Result IsPalindromeRecurse(MyNode head, int length)
            {

                if (head == null || length == 0)
                {
                    return new Result(null, true);
                }
                else if (length == 1)
                {
                    return new Result(head.next, true);
                }
                else if (length == 2)
                {
                    return new Result(head.next.next,
                     head.data == head.next.data);
                }
                Result res = IsPalindromeRecurse(head.next, length - 2);
                if (!res.result || res.node == null)
                {
                    return res;
                }
                else
                {
                    res.result = (head.data == res.node.data);
                    res.node = res.node.next;
                    return res;
                }
            }

            public bool IsPalindromeWithRecurse(int length)
            {
                Result p = IsPalindromeRecurse(head, length);
                return p.result;
            }
            #endregion

            public List(int[] n)
            {

                foreach (var item in n)
                {
                    AppendToTaile(item);
                }
            }
            private void AppendToTaile(int d)
            {

                // if n is head
                if (head == null)
                {
                    head = new MyNode();
                    head.data = d;
                }
                else
                {
                    MyNode temp = head;
                    MyNode end = new MyNode();
                    end.data = d;
                    while (temp.next != null)
                    {
                        temp = temp.next;
                    }
                    temp.next = end;
                    end.next = null;

                }
            }

            public int[] TravelList()
            {

                List<int> n = new List<int>();
                MyNode temp = head;
                // n.Clear();
                while (temp != null)
                {
                    n.Add(temp.data);
                    temp = temp.next;

                }

                return n.ToArray();

            }

            public int[] TravelList(MyNode node)
            {

                List<int> n = new List<int>();
                MyNode temp = node;
                // n.Clear();
                while (temp != null)
                {
                    n.Add(temp.data);
                    temp = temp.next;

                }

                return n.ToArray();

            }



            // return the node which its next node contrain the 'data'
            private MyNode TravelList(int data)
            {
                MyNode temp = head;
                while (temp.next != null)
                {
                    if (temp.next.data == data)
                    {
                        return temp;

                    }
                    else
                    {
                        temp = temp.next;
                    }
                }
                return null;
            }

            private void MyDeleteList(int data)
            {
                // if the head contain the data, delete the head
                if (head.data == data)
                {
                    head = head.next;

                }
                else
                {
                    MyNode d_node = TravelList(data);
                    if (d_node != null)
                    {
                        d_node.next = d_node.next.next;

                    }

                }

            }




            public MyNode FindBeginning()
            {
                MyNode slow = head;
                MyNode fast = head;

                /* Find meeting point. This will be LOOP_SIZE - k steps into the
                 * linked list. */
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                    if (slow == fast)
                    { // Collision
                        break;
                    }
                }

                /* Error check - no meeting point, and therefore no loop */
                if (fast == null || fast.next == null)
                {
                    return null;
                }

                /* Move slow to Head. Keep fast at Meeting Point. Each are k
                * steps from the Loop Start. If they move at the same pace,
                * they must meet at Loop Start. */
                slow = head;
                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                /* Both now point to the start of the loop. */
                return fast;
            }

            public int length(LinkedListNode<int> node)
            {
                int i = 0;
                while (node != null)
                {
                    node = node.Next;
                    i = i + 1;
                }
                return i;
            }


        }
    
    }

