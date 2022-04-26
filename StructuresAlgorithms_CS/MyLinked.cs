// 链表类与链表节点类（自用）
// 作者: DX3906

using System;

namespace MyLinkedList
{
    ///链表节点
    class ListNode
    {
        public object value;
        public ListNode? next { set; get; }
        public ListNode(object value)
        {
            this.value = value;
        }
    }

    ///链表
    class LinkedList
    {
        public int length { private set; get; } //链表长度
        public ListNode endNode;
        public ListNode startNode;
        public LinkedList(ListNode startNode)
        {
            startNode = startNode;
            length++;
        }

        ///使用列表方式生成链表
        public LinkedList(int[] nodeArray)
        {
            if (nodeArray.Length == 0)
            {
                return;
            }
            startNode = new ListNode(nodeArray[0]);
            length ++;
            ListNode p = startNode;
            for (int i = 1; i < nodeArray.Length; i++)
            {
                p.next = new ListNode(nodeArray[i]);
                p = p.next;
                length++;
            }
            endNode = p;
        }
        ///增加一个节点
        public void AddListNode(ListNode node)
        {
            if (length == 0)
            {
                startNode = node;
                length++;
                endNode = startNode;
            }
            else
            {
                length++;
                endNode.next = node;
                endNode = endNode.next;
            }
        }

    }
}