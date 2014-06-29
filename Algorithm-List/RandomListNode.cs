using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_List
{
    class RandomListNode
    {
       
        /*A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null. 
Return a deep copy of the list.*/

        /* Definition for singly-linked list with a random pointer.*/
          public int label;
          public RandomListNode next, random;
          public RandomListNode(int x) { this.label = x; }
    }

    class RandomList 
    {
        public RandomListNode head; 
        public RandomList (int[,] n ) 
        {

            foreach (int[] item in n)
            {
                int data = item[0];
                int radom = item[1];
                AppendToTaile(data,radom);
            }
        }
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null) return null;
            Dictionary<RandomListNode, RandomListNode> hm = new Dictionary<RandomListNode, RandomListNode>();
            RandomListNode newHead = new RandomListNode(head.label);
            hm.Add(head, newHead);

            RandomListNode p = head;
            RandomListNode q = newHead;

            p = p.next;

            while (p != null)
            {
                RandomListNode temp = new RandomListNode(p.label);
                hm.Add(p, temp);
                p = p.next;

                q.next = temp;
                q = temp;
            }


            p = head;
            q = newHead;
            while (p != null)
            {
                if (p.random != null)
                {
                    q.random = hm[p.random];
                }
                else {

                    q.random = null;
                }
                
                p = p.next;
                q = q.next;
            }
            return hm[head];
        }

        public void AppendToTaile(int data, int radom_data){
            if (head == null)
            {
                head = new RandomListNode(data);
                head.next = null;
                head.random = null;

            }
            else {
                RandomListNode n = new RandomListNode(data);
                n.next = null;
                n.random = null;
                RandomListNode temp = head;
                while (temp.next !=null)
                {
                    temp = temp.next;
                }

                temp.next = n;

            }
        
        }
    }
       
}
    

