// 主函数，用于测试
using System;
using Test;
using MyLinkedList;

class MainTest
{
    static void Main()
    {
        ListNode nodeTest1 = new ListNode(0);
        LinkedList linkedListTest1 = new LinkedList(nodeTest1);

        int[] nodeArray = new int[] { 0, 1, 2, 3 };
        LinkedList linkedListTest2 = new LinkedList(nodeArray);

        Console.WriteLine(linkedListTest1.length);
        Console.WriteLine(linkedListTest2.length);

        ListNode p = linkedListTest2.startNode;
        while(p != null){
            Console.WriteLine(p.value);
            p = p.next;
        }
        linkedListTest2.AddListNode(nodeTest1);
        Console.WriteLine(linkedListTest2.length);
    }
}