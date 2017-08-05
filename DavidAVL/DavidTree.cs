using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAVL
{
    class DavidTree <T> where T : IComparable
    {
        public int Count;

        private int currentHeight = 1;
        private TreeNode<T> top;

        public DavidTree()
        {

        }

        public void RotateRight(TreeNode<T> middleNode)
        {
            TreeNode<T> oldRightNode = middleNode.RightNode;
            middleNode.RightNode = middleNode.Parent;
            middleNode.Parent = middleNode.RightNode.Parent;

            if (middleNode.Parent == null)
            {
                top = middleNode;
            }

            middleNode.RightNode.Parent = middleNode;
            middleNode.RightNode.LeftNode = oldRightNode;
        }
        
        //literally copy pasted rotateRight and changed right to left and vice versa
        public void RotateLeft(TreeNode<T> middleNode)
        {
            TreeNode<T> oldLeftNode = middleNode.LeftNode;
            middleNode.LeftNode = middleNode.Parent;
            middleNode.Parent = middleNode.LeftNode.Parent;

            if (middleNode.Parent == null)
            {
                top = middleNode;
            }

            middleNode.LeftNode.Parent = middleNode;
            middleNode.LeftNode.RightNode = oldLeftNode;
        }
        
        public void Insert(T item)
        {
            insert(item, top);
        }

        private bool insert(T item, TreeNode<T> currentNode)
        {
            if(currentNode == null)
            {
                if(top == null)
                {
                    top = new TreeNode<T>(item);
                    return false;
                }
                currentHeight = 1;
                return true;
            }
            if(item.CompareTo(currentNode.Item) < 0)
            {
                if(insert(item, currentNode.LeftNode))
                {
                    currentNode.LeftNode = new TreeNode<T>(item);
                    currentNode.LeftNode.Parent = currentNode;
                }
            }
            else
            {
                if (insert(item, currentNode.RightNode))
                {
                    currentNode.RightNode = new TreeNode<T>(item);
                    currentNode.RightNode.Parent = currentNode;
                }
            }

            //set height
            currentNode.Height = ++currentHeight;

            //rebalance tree
            if(currentNode.Balance > 1)
            {
                RotateLeft(currentNode.RightNode);
            }
            else if(currentNode.Balance < -1)
            {
                RotateRight(currentNode.LeftNode);
            }
            return false;
        }
        
        //ezezezezz
        public void Delete(T key)
        {
            TreeNode<T> foundNode = Search(key);

            foundNode.Parent.RemoveChild(foundNode);

            BalanceTree();
        }

        public void BalanceTree()
        {
            currentHeight = 0;
            balanceTree(top);
        }
        private void balanceTree(TreeNode<T> currentNode)
        {
            if(currentNode == null)
            {
                return;
            }

            balanceTree(currentNode.LeftNode);
            balanceTree(currentNode.RightNode);

            currentNode.Height = ++currentHeight;
            if (currentNode.Balance > 1)
            {
                RotateLeft(currentNode.RightNode);
            }
            else if (currentNode.Balance < -1)
            {
                RotateRight(currentNode.LeftNode);
            }

        }

        //--------------------------------------
        //these functions are straight outta BST
        public TreeNode<T> Search(T key)
        {
            return search(key, top);
        }

        private TreeNode<T> search(T key, TreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                throw new Exception("node with key not found");
            }

            if (currentNode.Item.CompareTo(key) > 0)
            {
                return search(key, currentNode.LeftNode);
            }
            else if (currentNode.Item.CompareTo(key) != 0)
            {
                return search(key, currentNode.RightNode);
            }
            else
            {
                return currentNode;
            }
            throw new Exception("How can you see this error? You should be dead by now!");
        }

        public void PreOrder()
        {
            preOrder(top);
        }

        private void preOrder(TreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            Console.WriteLine(currentNode.Item);
            preOrder(currentNode.LeftNode);
            preOrder(currentNode.RightNode);
        }

        public void PostOrder()
        {
            postOrder(top);
        }

        private void postOrder(TreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            postOrder(currentNode.LeftNode);
            postOrder(currentNode.RightNode);

            Console.WriteLine(currentNode.Item);
        }
        
        public void InOrder()
        {
            inOrder(top);
        }

        private void inOrder(TreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            inOrder(currentNode.LeftNode);
            Console.WriteLine(currentNode.Item);
            inOrder(currentNode.RightNode);
        }
    }
}
