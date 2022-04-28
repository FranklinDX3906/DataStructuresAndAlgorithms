using System;
using MyDataStructures;

class MainTest
{
    static void Main()
    {
        LinkedListNode nodeTest1 = new LinkedListNode(0);
        LinkedList linkedListTest1 = new LinkedList(nodeTest1);

        object[] nodeArray = new object[] { 0, 1, 2, 3 };
        var linkedListTest2 = new LinkedList(nodeArray);

        Console.WriteLine(linkedListTest1.length);
        Console.WriteLine(linkedListTest2.length);

        LinkedListNode p = linkedListTest2.startNode;
        while (p != null)
        {
            Console.WriteLine(p.value);
            p = p.next;
        }
        linkedListTest2.AddListNode(nodeTest1);
        Console.WriteLine(linkedListTest2.length);
        Console.WriteLine(linkedListTest2.GetListValues().Length);
    }
}