using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_List
{
    class MyNode
    {
        public int data;
        public MyNode next;
        public MyNode() { }
        public MyNode(int value)
        {
            data = value;
        }


    }

    
    class MyList
    {
        public MyNode head;
        public int this[int index]
        {
            get
            {
                int[] arrResult = TravelList();
                return arrResult[index];


            }
            set
            {
                MyNode temp = head;
                int i = 0;
                while (temp.next != null)
                {
                    if (i == index)
                    {
                        break;
                    }
                    else
                    {
                        temp = temp.next;
                        i++;

                    }
                    if (i == index)
                    {
                        temp.data = value;
                    }
                }

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
    }
}
