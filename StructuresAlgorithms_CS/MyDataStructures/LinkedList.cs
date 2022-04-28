// 链表类（自用）
// 作者: DX3906

using System;

namespace MyDataStructures
///数据结构（个人用）命名空间
{
    class LinkedListNode
    ///链表节点类
    {
        public object value;
        public LinkedListNode? next { set; get; }
        public LinkedListNode(object value)
        ///使用值构造链表节点
        {
            this.value = value;
        }
    }

    class LinkedList
    ///链表类
    {
        public int length { private set; get; } = 0; //链表长度
        public LinkedListNode endNode;
        public LinkedListNode startNode;
        public LinkedList(LinkedListNode startNode)
        ///使用链表节点构造链表
        {
            this.startNode = startNode;
            this.length++;
        }
        public LinkedList(object[] nodeArray)
        ///使用列表方式生成链表
        {
            if (nodeArray.Length == 0)
            {
                return;
            }
            this.startNode = new LinkedListNode(nodeArray[0]);
            this.length++;
            LinkedListNode p = this.startNode;
            for (int i = 1; i < nodeArray.Length; i++)
            {
                p.next = new LinkedListNode(nodeArray[i]);
                p = p.next;
                this.length++;
            }
            this.endNode = p;
        }
        public void AddListNode(LinkedListNode node)
        ///增加一个节点
        {
            if (length == 0)
            {
                this.startNode = node;
                this.length++;
                this.endNode = this.startNode;
            }
            else
            {
                this.length++;
                this.endNode.next = node;
                this.endNode = this.endNode.next;
            }
        }
        public object[] GetListValues()
        {
            ///获取所有的节点
            if (length == 0)
            {
                Console.WriteLine("This is an empty list!");
                return new object[0];
            }
            else
            {
                List<object> listValues = new List<object>();
                LinkedListNode p = this.startNode;
                for (int i = 0; i < this.length; i++)
                {
                    listValues.Add(p.value);
                    p = p.next;
                }
                object[] arrValues = listValues.ToArray();
                return arrValues;
            }

        }
    }
}
