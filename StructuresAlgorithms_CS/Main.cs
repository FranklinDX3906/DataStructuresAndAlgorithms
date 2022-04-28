using System;
using MyDataStructures;

class MainTest
{
    static void Main()
    {
        int[] preOrderArr = new int[] { 4, 2, 1, 3, 6, 5, 7 };
        int[] inOrderArr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        int[] posOrderArr = new int[] { 1, 3, 2, 5, 7, 6, 4 };
        BinaryTree testTree1 = new BinaryTree(preOrderArr, inOrderArr, new int[0]);
        BinaryTree testTree2 = new BinaryTree(new int[0], inOrderArr, posOrderArr);
        BinaryTree testTree3 = new BinaryTree(preOrderArr, new int[0], posOrderArr);

        object[] posTest = testTree3.GetInOrder();
        foreach (var val in posTest)
        {
            Console.WriteLine(val);
        }
    }
}