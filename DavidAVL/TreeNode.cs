﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAVL
{
    class TreeNode<T>
    {
        public int Balance
        {
            get
            {
                int temp = 0;
                if(LeftNode != null)
                {
                    temp -= LeftNode.Height;
                }
                if(RightNode != null)
                {
                    temp += RightNode.Height;
                }
                return temp;
            }
        }


        public int Height;
        public T Item;
        public TreeNode<T> LeftNode;
        public TreeNode<T> RightNode;
        public TreeNode<T> Parent;
        
        public TreeNode (T item)
        {
            Item = item;
            Height = 1;
        }

        public void SetChild(TreeNode<T> newChild)
        {
            if(newChild.Parent == LeftNode)
            {
                LeftNode = newChild;
            }
            RightNode = newChild;
        }

    }
}
