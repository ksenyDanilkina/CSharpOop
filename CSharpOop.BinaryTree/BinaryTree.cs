using System;
using System.Collections.Generic;
using System.Collections;

namespace CSharpOop.BinaryTree
{
    class BinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public int Count { get; private set; }

        public void Add(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>(data);
                Count++;

                return;
            }

            TreeNode<T> current = root;

            while (true)
            {
                if (data.CompareTo(current.Data) < 0)
                {
                    if (current.Left != null)
                    {
                        current = current.Left;

                        continue;
                    }

                    current.Left = new TreeNode<T>(data);
                    Count++;

                    return;
                }
                else
                {
                    if (current.Right != null)
                    {
                        current = current.Right;

                        continue;
                    }

                    current.Right = new TreeNode<T>(data);
                    Count++;

                    return;
                }
            }
        }

        public bool Contains(T data)
        {
            return GetNodeWithParent(data)[0] != null;
        }

        private TreeNode<T>[] GetNodeWithParent(T data)
        {
            if (root == null)
            {
                return new TreeNode<T>[] { null, null };
            }

            TreeNode<T> current = root;
            TreeNode<T> parent = null;

            while (true)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    break;
                }

                if (data.CompareTo(current.Data) < 0)
                {
                    if (current.Left != null)
                    {
                        parent = current;
                        current = current.Left;

                        continue;
                    }

                    current = null;

                    break;
                }
                else
                {
                    if (current.Right != null)
                    {
                        parent = current;
                        current = current.Right;

                        continue;
                    }

                    current = null;

                    break;
                }
            }

            return new TreeNode<T>[] { current, parent };
        }

        private static void Visit(Action<T> action, TreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Data);

                Visit(action, node.Left);               

                Visit(action, node.Right);
            }
        }

        public void RecursiveDepthTraversal(Action<T> action)
        {
            Visit(action, root);
        }

        public IEnumerable<T> DepthTraversal()
        {
            if (root == null)
            {
                yield break;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

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

        public IEnumerable<T> WidthTraversal()
        {
            if (root == null)
            {
                yield break;
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode<T> node = queue.Dequeue();

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

        public bool Remove(T data)
        {
            TreeNode<T>[] nodeWithParent = GetNodeWithParent(data);
            TreeNode<T> nodeForDelete = nodeWithParent[0];
            TreeNode<T> nodeForDeleteParent = nodeWithParent[1];

            if (nodeForDelete == null)
            {
                return false;
            }

            bool isLeftChild = nodeForDeleteParent != null && nodeForDeleteParent.Left == nodeForDelete;

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
                    TreeNode<T> leftMinNode = nodeForDelete.Right.Left;
                    TreeNode<T> leftMinNodeParent = nodeForDelete.Right;

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

            Count--;

            return true;
        }
    }
}
