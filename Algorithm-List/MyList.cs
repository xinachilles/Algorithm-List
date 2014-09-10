using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_List
{
    public class MyNode
    {
        public int Value;
        public MyNode Next;
        public MyNode() { }
        public MyNode(int value)
        {
            Value = value;
            Next = null;
        }


    }


   public class MyList
    {
        public MyNode head;
        public MyNode this[int index]
        {
            get
            {
                MyNode temp = head;
                int i = 0;
                while (temp != null)
                {
                    if (index == i) { return temp; }
                    i++;
                    temp = temp.Next;

                }

                throw new ArgumentOutOfRangeException("index out of range");



            }


        }



        public MyList(int[] n)
        {

            foreach (var item in n)
            {
                AppendToTaile(item);
            }
        }




        // return the node which its next node contrain the 'data'
        private MyNode TravelListWithValue(int data)
        {
            MyNode temp = head;
            while (temp.Next != null)
            {
                if (temp.Next.Value == data)
                {
                    return temp;

                }
                else
                {
                    temp = temp.Next;
                }
            }
            return null;
        }






        public MyNode FindBeginning()
        {
            MyNode slow = head;
            MyNode fast = head;

            /* Find meeting point. This will be LOOP_SIZE - k steps into the
             * linked list. */
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                { // Collision
                    break;
                }
            }

            /* Error check - no meeting point, and therefore no loop */
            if (fast == null || fast.Next == null)
            {
                return null;
            }

            /* Move slow to Head. Keep fast at Meeting Point. Each are k
            * steps from the Loop Start. If they move at the same pace,
            * they must meet at Loop Start. */
            slow = head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            /* Both now point to the start of the loop. */
            return fast;
        }

        public int length(MyNode node)
        {
            int i = 0;
            while (node != null)
            {
                node = node.Next;
                i = i + 1;
            }
            return i;
        }

        private void MyDeleteList(int data)
        {
            // if the head contain the data, delete the head
            if (head.Value == data)
            {
                head = head.Next;

            }
            else
            {
                MyNode d_node = TravelListWithValue(data);
                if (d_node != null)
                {
                    d_node.Next = d_node.Next.Next;

                }

            }

        }

        private void AppendToTaile(int d)
        {

            // if n is head
            if (head == null)
            {
                head = new MyNode();
                head.Value = d;
            }
            else
            {
                MyNode temp = head;
                MyNode end = new MyNode();
                end.Value = d;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = end;
                end.Next = null;

            }
        }

        public int[] TravelList()
        {

            List<int> n = new List<int>();
            MyNode temp = head;
            // n.Clear();
            while (temp != null)
            {
                n.Add(temp.Value);
                temp = temp.Next;

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
                n.Add(temp.Value);
                temp = temp.Next;

            }

            return n.ToArray();

        }

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

                node = node.Next;

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
        public MyNode Partition2(int x)
        {

            MyNode node = head;
            MyNode beforeStart = null;
            MyNode afterStart = null;

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
                //node = node.Next;
                node = next;
            }

            /* Merge before list and after list */
            if (beforeStart == null)
            {
                return afterStart;
            }

            /* Find end of before list, and merge the lists */
            MyNode before_head = beforeStart;
            while (beforeStart.Next != null)
            {
                beforeStart = beforeStart.Next;
            }
            beforeStart.Next = afterStart;

            return before_head;
        }


        #endregion


        public bool DeleteNode(MyNode n)
        {
            if (n == null || n.Next == null)
            {
                return false; // Failure
            }
            MyNode next = n.Next;
            n.Value = next.Value;
            n.Next = next.Next;
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

        #region LeetCode Merge Sort
        /*
         Sort a linked list in O(n log n) time using constant space complexity.
         */

        public void ListMergeSort(int begin, int end, MyNode head)
        {
            int mid = (begin + end) / 2;
            ListMergeSort(begin, mid, head);
            ListMergeSort(mid + 1, end, head);
            Merge(begin, mid, end, head);


        }

        public void Merge(int begin, int mid, int end, MyNode head)
        {
            int n1 = mid - begin + 1;
            int n2 = end - mid;
            int[] a1 = new int[n1];
            int[] a2 = new int[n2];
            MyNode n = head;

            for (int i = 0; i < n1; i++)
            {
                a1[i] = n.Value;
                n = n.Next;
            }

            for (int i = 0; i < n2; i++)
            {
                a2[i] = n.Value;
                n = n.Next;
            }

            int k = 0;
            int j = 0;

            for (int i = begin; i <= end; i++)
            {
                if (k >= a1.Length)
                {
                    this[i].Value = a2[j];
                    j++;
                }

                if (j >= a2.Length)
                {
                    this[i].Value = a1[k];
                    k++;
                }

                if (a1[k] > a2[i])
                {
                    this[i].Value = a2[i];
                    i++;
                }
                else
                {
                    this[j].Value = a1[k];
                    k++;

                }

            }

        }

        #endregion

        #region LeetCode Insert Sort
        public void ListInsertSort(MyNode head)
        {

            for (int i = 0; i < length(head); i++)
            {
                int index = i;
                while (index > 0)
                {
                    if (this[index - 1].Value > this[index].Value)
                    {
                        int temp = this[index - 1].Value;
                        this[index - 1].Value = this[index].Value;
                        this[index].Value = temp;

                    }
                }
            }
        }



        #endregion

        #region LeetCode Reorder List
        /*
        Given a singly linked list L: L0→L1→…→Ln-1→Ln,
        reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

        You must do this in-place without altering the nodes' values.

        For example,
        Given {1,2,3,4}, reorder it to {1,4,2,3}.
        */
        public void ListReorder(MyNode head)
        {
            for (int i = 0; i < length(head) / 2; i++)
            {
                int j = length(head) - 1;
                this[i].Next = this[j];
                this[j].Next = this[i + 1];

                j--;
            }
        }
        #endregion


        #region Reverse Linked List
        public MyNode Reverse()
        {
            if (head ==null)
            {
                return null;
            }
            MyNode second = head.Next;
            MyNode third = second.Next;

            second.Next = head;
            head.Next = null;


            if (third==null)
            {
                return head;
            }

            MyNode currentNode = third;
            MyNode previousNode = second;

            while (previousNode!= null)
            {
                MyNode temp =currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = temp;

            }
            head = previousNode;

            return head;

        }

        #endregion 
        #region
        /*
                             Reverse a linked list from position m to n. Do it in-place and in one-pass.

                    For example:
                    Given 1->2->3->4->5->NULL, m = 2 and n = 4,

                    return 1->4->3->2->5->NULL.

                    Note:
                    Given m, n satisfy the following condition:
                    1 ≤ m ≤ n ≤ length of list.
         */

        public MyNode ReverseBetween(MyNode head, int m, int n)
        {
            // init m node and n node  
            MyNode mNode = head;
            MyNode nNode = head;

            // previous node of node m  
            MyNode mPreNode = new MyNode(0);
            mPreNode.Next = head;

            // set up the distance between node m and node n  
            for (int i = 0; i < n - m; i++) nNode = nNode.Next;

            // locate node m and node n  
            for (int i = 0; i < m - 1; i++)
            {
                mPreNode = mNode;
                mNode = mNode.Next;
                nNode = nNode.Next;
            }

            // check if case of reversing from head  
            bool fromHead = false;
            if (mNode == head) fromHead = true;

            // reverse node range  
            while (mNode != nNode)
            {
                MyNode temp = nNode.Next;
                nNode.Next = mNode;
                mPreNode.Next = mNode.Next;
                mNode.Next = temp;
                mNode = mPreNode.Next;
            }

            // case of reverse started from head  
            if (fromHead == true) return nNode;

            // other cases  
            return head;
        }

        public MyNode ReverseBetweenII(MyNode head, int m, int n)
        {
            if (head ==null || m>n )
            {
                return null;
            }

            MyNode mPreNode = head;
            MyNode nPreNode = head;
            MyNode node = head; 
            int i = 0;
            while (node !=null   )
            {
                if (node == null)
                {
                    return null;
                }

                if (i+1 == m)
                {
                    mPreNode = node;
                }

                if (i+1 == n)
                {
                    nPreNode = node;
                    break;
                }

                i = i + 1;
                node = node.Next;
            }

            
            if (mPreNode == head)
            {
                MyNode temp = nPreNode.Next.Next;
                nPreNode.Next.Next = mPreNode.Next;
                head = mPreNode.Next;
                nPreNode.Next = mPreNode.Next;
                mPreNode.Next = temp;
                
            }
            else {
                MyNode mNode = mPreNode.Next;
                MyNode nNode = nPreNode.Next;
                MyNode nNodeNext = nPreNode.Next.Next;

                mPreNode.Next = nNode;
                node.Next = mNode.Next;
                nNode.Next = mNode;
                mNode = nNodeNext;
            
            }
            return head;
        }
        #endregion

        #region LeetCode Remove Duplicates from Sorted List
        /*
            Given a sorted linked list, delete all duplicates such that each element appear only once.

            For example,

            Given 1->1->2, return 1->2.
            Given 1->1->2->3->3, return 1->2->3.
         */

        //public MyNode DeleteDuplicates(MyNode head)
        //{
        //    MyNode current = head;
        //    if (current == null)
        //    {
        //        return null;
        //    }

        //    MyNode afterCurrent = null;
        //    while (current.Next != null)
        //    {
        //        afterCurrent = current.Next;
        //        if (afterCurrent.Value == current.Value)
        //        {
        //            current.Next = afterCurrent.Next;
        //        }
        //        current = current.Next;
        //        if (current == null)
        //        {
        //            break;
        //        }
        //    }

        //    return head;

        //}

        public MyNode DeleteDuplicates(MyNode head)
        {
            if (head == null || head.Next == null)
                return head;

            MyNode prev = head;
            MyNode p = head.Next;

            while (p != null)
            {
                if (p.Value == prev.Value)
                {
                    prev.Next = p.Next;
                    p = p.Next;
                    //no change prev
                }
                else
                {
                    prev = p;
                    p = p.Next;
                }
            }

            return head;
        }
        #endregion

        #region LeetCode Remove Duplicates from Sorted List II

        //Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.
        //For example,
        //Given 1->2->3->3->4->4->5, return 1->2->5.
        //Given 1->1->1->2->3, return 2->3.

        public MyNode DeleteDuplicates3(MyNode head)
        {
            if (head == null)
                return head;
            MyNode root = new MyNode(0);
            MyNode cur = head;
            MyNode pre = root;

            while (cur != null)
            {
                bool isDup = false;
                while (cur.Next != null && cur.Value == cur.Next.Value)
                {
                    isDup = true;
                    cur = cur.Next;
                }
                if (isDup)
                {
                    cur = cur.Next;
                }
                else
                {
                    pre.Next = cur;
                    pre = cur;
                    cur = cur.Next;
                    pre.Next = null;

                }
            }
            return root.Next;
        
        }
        #endregion

        #region Remove Duplicates from Sorted Array
            //        Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

            //Do not allocate extra space for another array, you must do this in place with constant memory.

            //For example,
            //Given input array A = [1,1,2],

            //Your function should return length = 2, and A is now [1,2].
       public void RemoveDuplicates(ref int[] a, ref int n) {
        
           HashSet<int> newHash = new HashSet<int>();
           foreach (int item in a)
           {
               if (newHash.Contains(item) == false)
               {
                   newHash.Add(item);
               }   
           }

           a = newHash.ToArray<int>();
           n = a.Length;
          
    }
        #endregion
    }
}
