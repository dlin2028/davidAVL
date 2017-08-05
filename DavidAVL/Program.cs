﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAVL
{
    class Program
    {
        static void Main(string[] args)
        {
            DavidTree<int> tree = new DavidTree<int>();

            Dictionary<string, Action> actions = new Dictionary<string, Action>();
            Dictionary<string, Action<string>> actionsWithArguements = new Dictionary<string, Action<string>>();

            actions.Add("lazy", () =>
            {
                tree.Insert(5);
                tree.Insert(3);
                tree.Insert(4);
                tree.Insert(7);
                tree.Insert(6);
            });

            actions.Add("inorder", () =>
            {
                tree.InOrder();
            });

            actions.Add("preorder", () =>
            {
                tree.PreOrder();
            });

            actions.Add("postorder", () =>
            {
                tree.PostOrder();
            });

            actionsWithArguements.Add("insert", (arguement) =>
            {
                tree.Insert(int.Parse(arguement));
            });

            actionsWithArguements.Add("search", (arguement) =>
            {
                Console.WriteLine(tree.Search(int.Parse(arguement)).ToString());
            });

            while (true)
            {
                Console.WriteLine("Operation: ");
                string operation = Console.ReadLine().ToLower();

                actions[operation].Invoke();
                actionsWithArguements[operation].Invoke();

            }
        }
    }
}
