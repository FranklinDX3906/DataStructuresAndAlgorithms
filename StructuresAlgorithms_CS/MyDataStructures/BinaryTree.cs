// 二叉树树类
// 作者: DX3906

using System;

namespace MyDataStructures
///数据结构（个人用）命名空间
{
    class BinaryTreeNode
    ///二叉树节点类
    {
        public object value;
        public BinaryTreeNode? left { set; get; }
        public BinaryTreeNode? right { set; get; }
        public BinaryTreeNode(object value)
        {
            this.value = value;
        }
    }

    class BinaryTree
    ///二叉树类
    {
        public BinaryTreeNode? root;
        public BinaryTree(BinaryTreeNode root)
        ///通过根节点建设树
        {
            this.root = root;
        }
        public object[] GetPreOrder()
        ///返回前序遍历结果
        {
            if (this.root == null)
            {
                return new object[0];
            }
            else
            {
                List<object> listRes = new List<object>();
                Helper(this.root);

                void Helper(BinaryTreeNode p)
                ///递归辅助
                {
                    if (p == null)
                    {
                        return;
                    }
                    else
                    {
                        listRes.Add(p.value);
                        Helper(p.left);
                        Helper(p.right);
                    }
                }

                object[] arrRes = listRes.ToArray();
                return arrRes;
            }
        }
        public object[] GetInOrder()
        ///返回中序遍历结果
        {
            if (this.root == null)
            {
                return new object[0];
            }
            else
            {
                List<object> listRes = new List<object>();
                Helper(this.root);

                void Helper(BinaryTreeNode p)
                ///递归辅助
                {
                    if (p == null)
                    {
                        return;
                    }
                    else
                    {
                        Helper(p.left);
                        listRes.Add(p.value);
                        Helper(p.right);
                    }
                }

                object[] arrRes = listRes.ToArray();
                return arrRes;
            }
        }
        public object[] GetPosOrder()
        ///返回后序遍历结果
        {
            if (this.root == null)
            {
                return new object[0];
            }
            else
            {
                List<object> listRes = new List<object>();
                Helper(this.root);

                void Helper(BinaryTreeNode p)
                ///递归辅助
                {
                    if (p == null)
                    {
                        return;
                    }
                    else
                    {
                        Helper(p.left);
                        Helper(p.right);
                        listRes.Add(p.value);
                    }
                }

                object[] arrRes = listRes.ToArray();
                return arrRes;
            }
        }
        public BinaryTree(int[] preOrderArr, int[] inOrderArr, int[] posOrderArr)
        ///根据三种遍历顺序构造树
        {
            if (preOrderArr.Length == 0)
            ///根据中序和后序构建
            {
                int post_idx;
                Dictionary<object, int> idx_map = new Dictionary<object, int>();

                BinaryTreeNode helper(int in_left, int in_right)
                {
                    // 如果这里没有节点构造二叉树了，就结束
                    if (in_left > in_right)
                    {
                        return null;
                    }

                    // 选择 post_idx 位置的元素作为当前子树根节点
                    var root_val = posOrderArr[post_idx];
                    BinaryTreeNode root = new BinaryTreeNode(root_val);

                    // 根据 root 所在位置分成左右两棵子树
                    int index = idx_map[root_val];

                    // 下标减一
                    post_idx--;
                    // 构造右子树
                    root.right = helper(index + 1, in_right);
                    // 构造左子树
                    root.left = helper(in_left, index - 1);
                    return root;
                }

                post_idx = posOrderArr.Length - 1;
                int idx = 0;
                foreach (object val in inOrderArr)
                {
                    idx_map.Add(val, idx++);
                }

                this.root = helper(0, inOrderArr.Length - 1);
            }
            else if (posOrderArr.Length == 0)
            ///根据前序和中序构建
            {
                Dictionary<object, int> indexMap;

                BinaryTreeNode helper(int preorder_left, int preorder_right, int inorder_left, int inorder_right)
                {
                    if (preorder_left > preorder_right)
                    {
                        return null;
                    }

                    // 前序遍历中的第一个节点就是根节点
                    int preorder_root = preorder_left;
                    // 在中序遍历中定位根节点
                    int inorder_root = indexMap[preOrderArr[preorder_root]];

                    // 先把根节点建立出来
                    BinaryTreeNode root = new BinaryTreeNode(preOrderArr[preorder_root]);
                    // 得到左子树中的节点数目
                    int size_left_subtree = inorder_root - inorder_left;
                    // 递归地构造左子树，并连接到根节点
                    // 先序遍历中「从 左边界+1 开始的 size_left_subtree」个元素就对应了中序遍历中「从 左边界 开始到 根节点定位-1」的元素
                    root.left = helper(preorder_left + 1, preorder_left + size_left_subtree, inorder_left, inorder_root - 1);
                    // 递归地构造右子树，并连接到根节点
                    // 先序遍历中「从 左边界+1+左子树节点数目 开始到 右边界」的元素就对应了中序遍历中「从 根节点定位+1 到 右边界」的元素
                    root.right = helper(preorder_left + size_left_subtree + 1, preorder_right, inorder_root + 1, inorder_right);
                    return root;
                }
                int n = preOrderArr.Length;
                // 构造哈希映射，帮助我们快速定位根节点
                indexMap = new Dictionary<object, int>();
                for (int i = 0; i < n; i++)
                {
                    indexMap.Add(inOrderArr[i], i);
                }
                this.root = helper(0, n - 1, 0, n - 1);
            }
            else
            ///根据前序和后序构建
            {
                BinaryTreeNode helper(int i0, int i1, int N)
                {
                    if (N == 0)
                    {
                        return null;
                    }
                    BinaryTreeNode root = new BinaryTreeNode(preOrderArr[i0]);
                    if (N == 1)
                    {
                        return root;
                    }
                    int L = 1;
                    for (; L < N; ++L)
                        if (posOrderArr[i1 + L - 1] == preOrderArr[i0 + 1])
                            break;

                    root.left = helper(i0 + 1, i1, L);
                    root.right = helper(i0 + L + 1, i1 + L, N - 1 - L);
                    return root;
                }
                this.root = helper(0, 0, preOrderArr.Length);
            }
        }
    }


}