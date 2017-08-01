using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAVL
{
    class DavidTree <T> where T : IComparable
    {
        private TreeNode<T> top;
        public int Count;
        

        public DavidTree()
        {

        }
        public void RotateRight(TreeNode<T> middleNode)
        {
            //settings parent's leftnode to rightnode
            if(middleNode.RightNode != null)
            {
                middleNode.Parent.LeftNode = middleNode.RightNode;
            }
            //setting parent parent to middlenode
            TreeNode<T> originalParent = middleNode.Parent;
            middleNode.Parent.Parent = middleNode;

            //setting parent for middlenode
            middleNode.Parent = originalParent.Parent;
            //settings the new parent's child
            originalParent.Parent.SetChild(middleNode);
            //changing the parent to the right child
            middleNode.RightNode = middleNode.Parent;
        }

        //literally copy pasted rotateRight and changed right to left and vice versa
        public void RotateLeft(TreeNode<T> middleNode)
        {
            if (middleNode.LeftNode != null)
            {
                middleNode.Parent.RightNode = middleNode.LeftNode;
            }
            TreeNode<T> originalParent = middleNode.Parent;
            
            if(middleNode.Parent.Parent != null)
            {
                middleNode.Parent.Parent = middleNode;
            }

            middleNode.Parent = originalParent.Parent;

            originalParent.Parent.SetChild(middleNode);

            middleNode.LeftNode = middleNode.Parent;
        }

        int currentHeight = 1;
        public void Insert(T item)
        {
            insert(item, top);
        }
        private bool insert(T item, TreeNode<T> currentNode)
        {
            //search through tree
            if(currentNode == null)
            {
                if(top == null)
                {
                    top = new TreeNode<T>(item);
                }
                currentHeight = 1;
                return true;
            }
            if(item.CompareTo(currentNode.Item) < 0)
            {
                if(insert(item, currentNode.LeftNode))
                {
                    currentNode.LeftNode = new TreeNode<T>(item);                    
                }
            }
            else
            {
                if (insert(item, currentNode.RightNode))
                {
                    currentNode.RightNode = new TreeNode<T>(item);
                }
            }

            //set height
            currentNode.Height = ++currentHeight;

            //rebalance tree
            if(currentNode.Balance > 1)
            {
                RotateRight(currentNode.RightNode);
            }
            else if(currentNode.Balance < -1)
            {
                RotateLeft(currentNode.LeftNode);
            }
            return false;
        }
        //help please
        public void Delete()
        {
            //binary search
            //delete node
            //rebalance tree (balance n stuff)
            //set node height
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
