using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace EnumeratorTest
{
    class EnumeratorTest
    {
        static void Main(string[] args)
        {
            Tree<int> tree1 = new Tree<int>(10);
            tree1.Insert(5);
            tree1.Insert(11);
            tree1.Insert(5);
            tree1.Insert(-12);
            tree1.Insert(15);
            tree1.Insert(0);
            tree1.Insert(14);
            tree1.Insert(-8);
            tree1.Insert(10);
            
            foreach (int item in tree1)
                  Console.WriteLine($"{item} ");

            Tree<char> cheyne = new Tree<char>(' ');
            cheyne.Insert('c');
            cheyne.Insert('h');
            cheyne.Insert('e');
            cheyne.Insert('y');
            cheyne.Insert('n');
            cheyne.Insert('e');

            foreach (char letter in cheyne)            
                Console.WriteLine(letter);
            

        }
    }
}
