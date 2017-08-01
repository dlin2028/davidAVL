using System;
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
            while (true)
            {
                Console.WriteLine("Operation: ");
                string operation = Console.ReadLine().ToLower();

                if (operation == "lazy")
                {
                    tree.Insert(5);
                    tree.Insert(3);
                    tree.Insert(4);
                    tree.Insert(7);
                    tree.Insert(6);
                }
                else if (operation == "inorder")
                {
                    tree.InOrder();
                }
                else if (operation == "preorder")
                {
                    tree.PreOrder();
                }
                else if (operation == "postorder")
                {
                    tree.PostOrder();
                }
                else if (operation != "insert" && operation != "search")
                {
                    Console.WriteLine("Type help for help");
                }
                else
                {
                    Console.WriteLine("Arguements: ");
                    int arguements = int.Parse(Console.ReadLine());
                    if (operation == "insert")
                    {
                        tree.Insert(arguements);
                    }
                    else if (operation == "search")
                    {
                        Console.WriteLine(tree.Search(arguements).ToString());
                    }
                }
            }
        }
    }
}
