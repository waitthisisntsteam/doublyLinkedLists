using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Net.Http.Headers;
using System;
using System.Text.RegularExpressions;

namespace linkedLists
{
    public class Program
    {

        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //linkedList.AddNodeToFront(1);
            //linkedList.AddNodeToLast(2);
            //linkedList.AddNodeToLast(5);
            //linkedList.AddBefore(linkedList.Tail, 4);
            //linkedList.AddAfter(linkedList.Head.next, 3);
            //linkedList.AddNodeToFront(0);
            //linkedList.RemoveFirst();
            //linkedList.AddNodeToLast(6);
            //linkedList.RemoveLast();
            //linkedList.AddAfter(linkedList.Head.next.next, 7);
            //linkedList.Remove(7);
            //linkedList.PrintList();

            Console.WriteLine(list);

            for (int i = 0; i < 5; i++)
            {
                list.AddNodeToLast(i);              
            }
            list.PrintList();

            for (int i = -1; i < 6; i++)
            {
                list.Remove(i);

            }
        }
    }
}