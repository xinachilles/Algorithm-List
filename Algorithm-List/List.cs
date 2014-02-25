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
          
     
            #region 2.1
            //Write code to remove duplicates from an unsorted linked list.
            //FOLLOW UP
            //How would you solve this problem if a temporary buffer is not allowed?
            public void RemoveDuplicate(ref LinkedList<int> l)
            {
                Hashtable table = new Hashtable();
                LinkedListNode<int> head = l.First;
                LinkedListNode<int>  previous = null;

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
            public LinkedListNode<int> Partition(int x)
            {
                LinkedListNode<int> beforeStart = null;
                LinkedListNode<int> beforeEnd = null;
                LinkedListNode<int> afterStart = null;
                LinkedListNode<int> afterEnd = null;
                LinkedListNode<int> node = head;

                while (node != null)
                {


                    if (node.Value <= x)
                    {

                        if (beforeStart == null)
                        {

                            beforeStart = node;
                            beforeEnd = beforeStart;
                        }
                        else
                        {
                            beforeEnd.Next = node;
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
                            afterEnd.Next = node;
                            afterEnd = node;

                        }

                    }

                    node = node.next;

                }

                if (beforeStart != null)
                {
                    beforeEnd.Next = afterStart;
                    afterEnd.Next = null;
                    return beforeStart;
                }
                else
                {
                    afterEnd.Next = null;
                    return afterStart;

                }
            }
            // only use two variable
            public LinkedListNode<int> Partition2(int x)
            {

                LinkedListNode<int> node = head;
                LinkedListNode<int> beforeStart = null;
                LinkedListNode<int> afterStart = null;

                /* Partition list */
                while (node != null)
                {
                    MyNode next = node.Next;
                    if (node.Value < x)
                    {
                        /* Insert node into start of before list */
                        node.Next = beforeStart;
                        beforeStart = node;
                    }
                    else
                    {
                        /* Insert node into front of after list */
                        node.Next = afterStart;
                        afterStart = node;
                    }
                    node = Next;
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
                    beforeStart = beforeStart.Next;
                }
                beforeStart.Next = afterStart;

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

            public bool IsPalindromeWithRecurse(int length)
            {
                Result p = IsPalindromeRecurse(head, length);
                return p.result;
            }
            #endregion

     


        }
    
    }

