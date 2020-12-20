using System;
using System.Collections.Generic;
using System.Collections;

namespace CSharpOop.BinaryTree
{
    class BinaryTree
    {
        private TreeNode root;
        private int count;

        public void Add(int data)
        {
            if (root == null)
            {
                root = new TreeNode(data);
                count++;
            }
            else
            {
                TreeNode current = root;
                bool isNodeAdded = false;

                while (!isNodeAdded)
                {
                    if (data < current.Data)
                    {
                        if (current.Left != null)
                        {
                            current = current.Left;
                        }
                        else
                        {
                            current.Left = new TreeNode(data);
                            count++;
                            isNodeAdded = true;
                        }
                    }
                    else
                    {
                        if (current.Right != null)
                        {
                            current = current.Right;
                        }
                        else
                        {
                            current.Right = new TreeNode(data);
                            count++;
                            isNodeAdded = true;
                        }
                    }
                }
            }
        }

        public int GetCount()
        {
            return count;
        }

        public bool Contains(int data)
        {
            return GetNodeWithParent(data)[0] != null;
        }

        private TreeNode[] GetNodeWithParent(int data)
        {
            TreeNode current = root;
            TreeNode parent = null;

            bool isSearchEnd = false;

            while (!isSearchEnd)
            {
                if (current.Data == data)
                {
                    isSearchEnd = true;
                }
                else if (data < current.Data)
                {
                    if (current.Left != null)
                    {
                        parent = current;
                        current = current.Left;
                    }
                    else
                    {
                        isSearchEnd = true;
                        current = null;
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        parent = current;
                        current = current.Right;
                    }
                    else
                    {
                        isSearchEnd = true;
                        current = null;
                    }
                }
            }

            return new TreeNode[] { current, parent };
        }

        private void Visit(Action action, TreeNode node)
        {
            if (node.Left != null)
            {
                Visit(action, node.Left);
            }

            if (node.Right != null)
            {
                Visit(action, node.Right);
            }
        }

        public void RecursiveDepthTraversal(Action action)
        {
            if (root == null)
            {
                throw new ArgumentException("Дерево пусто");
            }

            Visit(action, root);
        }

        public IEnumerable DepthTraversal()
        {
            if (root == null)
            {
                throw new ArgumentException("Дерево пусто");
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                yield return node.Data;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }

        public IEnumerable WidthTraversal()
        {
            if (root == null)
            {
                throw new NullReferenceException("Дерево пусто");
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode node = queue.Dequeue();

                yield return node.Data;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        public bool Remove(int data)
        {
            TreeNode nodeForDelete = GetNodeWithParent(data)[0];
            TreeNode nodeForDeleteParent = GetNodeWithParent(data)[1];

            if (nodeForDelete == null)
            {
                return false;
            }

            bool isLeftChild = false;

            if (nodeForDeleteParent.Data > nodeForDelete.Data)
            {
                isLeftChild = true;
            }

            if (nodeForDelete.Left == null && nodeForDelete.Right == null)
            {
                if (nodeForDeleteParent == null)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        nodeForDeleteParent.Left = null;
                    }
                    else
                    {
                        nodeForDeleteParent.Right = null;
                    }
                }
            }
            else if (nodeForDelete.Right == null)
            {
                if (nodeForDeleteParent == null)
                {
                    root = nodeForDelete.Left;
                }
                else
                {
                    if (isLeftChild)
                    {
                        nodeForDeleteParent.Left = nodeForDelete.Left;
                    }
                    else
                    {
                        nodeForDeleteParent.Right = nodeForDelete.Left;
                    }
                }
            }
            else
            {
                if (nodeForDelete.Right.Left == null)
                {
                    nodeForDelete.Right.Left = nodeForDelete.Left;

                    if (nodeForDeleteParent == null)
                    {
                        root = nodeForDelete.Right;
                    }
                    else
                    {
                        if (isLeftChild)
                        {
                            nodeForDeleteParent.Left = nodeForDelete.Right;
                        }
                        else
                        {
                            nodeForDeleteParent.Right = nodeForDelete.Right;
                        }
                    }
                }
                else
                {
                    TreeNode leftMinNode = nodeForDelete.Right.Left;
                    TreeNode leftMinNodeParent = nodeForDelete.Right;

                    while (leftMinNode.Left != null)
                    {
                        leftMinNodeParent = leftMinNode;
                        leftMinNode = leftMinNode.Left;
                    }

                    leftMinNodeParent.Left = leftMinNode.Right;
                    leftMinNode.Left = nodeForDelete.Left;
                    leftMinNode.Right = nodeForDelete.Right;

                    if (nodeForDeleteParent == null)
                    {
                        root = leftMinNode;
                    }
                    else
                    {
                        if (isLeftChild)
                        {
                            nodeForDeleteParent.Left = leftMinNode;
                        }
                        else
                        {
                            nodeForDeleteParent.Right = leftMinNode;
                        }
                    }
                }
            }

            count--;

            return true;
        }
    }
}
