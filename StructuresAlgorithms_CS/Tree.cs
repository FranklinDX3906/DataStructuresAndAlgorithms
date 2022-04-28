// 二叉树树类
// 作者: DX3906

using System;

namespace MyDataStructures
///数据结构（个人用）命名空间
{
    class TreeNode
    ///树节点类
    {
        public object value;
        public TreeNode? left { set; get; }
        public TreeNode? right { set; get; }
        public TreeNode(object value){
            this.value = value;
        }
    }

    class Tree
    ///树类
    {
        public int height{private set;get;} = 0; //树高
        public TreeNode root;
        public Tree(TreeNode root)
        ///通过根节点建设树
        {
            this.root = root;
        }
        public int[] GetPosOrder()
        ///返回前序遍历结果
        {
            return new int[0];
        }
        public int[] GetInOrder()
        ///返回中序遍历结果
        {
            return new int[0];
        }
        public int[] GetBreOrder()
        ///返回后序遍历结果
        {
            return new int[0];
        }
    }
}