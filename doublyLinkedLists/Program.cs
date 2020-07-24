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
            list.AddNodeToFront(1);
            list.AddNodeToLast(2);
            list.AddNodeToLast(5);
            list.AddBefore(list.Tail, 4);
            list.AddAfter(list.Head.next, 3);
            list.AddNodeToFront(0);
            list.RemoveFirst();
            list.AddNodeToLast(6);
            list.RemoveLast();
            list.AddAfter(list.Head.next.next, 7);
            list.Remove(7);
            list.PrintList();
        }
    }
}