using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class BinarySearchTree
    {
        public class TNode
        {
            public int Data;
            public TNode Left;
            public TNode Right;
            public void DisplayNode()
            {
                Console.Write(Data + " ");
            }
        }
        public TNode root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int i)
        {
            TNode newNode = new TNode();
            newNode.Data = i;
            if (root == null)
                root = newNode;
            else
            {
                TNode current = root;
                TNode parent;
                while (true)
                {
                    parent = current;
                    if (i < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }

                        else
                        {
                            current = current.Right;
                            if (current == null)
                            {
                                parent.Right = newNode;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Preorder(TNode Root)
        {
            if (Root != null)
            {
                Console.Write(Root.Data + " ");
                Preorder(Root.Left);
                Preorder(Root.Right);
            }
        }

        public void Inorder(TNode Root)
        {
            if (Root != null)
            {
                Inorder(Root.Left);
                Console.Write(Root.Data + " ");
                Inorder(Root.Right);
            }
        }

        public void Postorder(TNode Root)
        {
            if (Root != null)
            {
                Postorder(Root.Left);
                Postorder(Root.Right);
                Console.Write(Root.Data + " ");
            }
        }

        public bool Delete(int key)
        {
            TNode current = root;
            TNode parent = root;
            bool isLeftChild = true;
            while (current.Data != key)
            {
                parent = current;
                if (key < current.Data)
                {
                    isLeftChild = true;
                    current = current.Right;
                }
                else
                {
                    isLeftChild = false;
                    current = current.Right;
                }

                if (current == null)
                {
                    return false;
                }
            }
            if ((current.Left == null) && (current.Right == null))
            {
                if (current == root)
                {
                    root = null;
                }
                else if (isLeftChild)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (current.Right == null)
            {
                if (current == root)
                {
                    root = current.Left;
                }
                else if (isLeftChild)
                {
                    parent.Left = current.Left;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            else if (current.Left == null)
            {
                if (current == root)
                {
                    root = current.Right;
                }
                else if (isLeftChild)
                {
                    parent.Left = parent.Right;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            else
            {
                TNode successor = GetSuccessor(current);
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.Left = successor;
                }
                else
                {
                    parent.Right = successor;
                    successor.Left = current.Left;
                }
            }
            return true;
        }

        public TNode GetSuccessor(TNode delNode)
        {
            TNode successorParent = delNode;
            TNode successor = delNode;
            TNode current = delNode.Right;
            while (!(current == null))
            {
                successorParent = current;
                successor = current;
                current = current.Left;
            }
            if (!(successor == delNode.Right))
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }
            return successor;
        }

        public int GetMin(TNode root)
        {
            TNode cur = root;
            while (cur.Left != null)
                cur = cur.Left;
            return cur.Data;
        }

        //Returns the data in the farthest right node
        public int GetMax(TNode root)
        {
            TNode cur = root;
            while (cur.Right != null)
                cur = cur.Right;
            return cur.Data;
        }
    }
}
