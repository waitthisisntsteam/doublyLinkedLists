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
    public class DoublyLinkedList<T>
    {
        public int Count { get; private set; }
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }

        public DoublyLinkedList()
        {
            Clear();
        }

        public void AddNodeToFront(T value)
        {
            if (Head == null)
            {
                Head = new DoublyLinkedListNode<T>(value);
                Tail = Head;
            }
            else
            {
                DoublyLinkedListNode<T> current = new DoublyLinkedListNode<T>(value);
                Head.prev = current;
                current.next = Head;
                Head = current;
            }
            Count++;
        }
        public void AddNodeToLast(T value)
        {
            if (Head == null)
            {
                AddNodeToFront(value);
            }
            else
            {
                DoublyLinkedListNode<T> current = new DoublyLinkedListNode<T>(value);
                Tail.next = current;
                current.prev = Tail;
                Tail = current;
                Count++;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> nodeAhead, T value)
        {
                      
            if (nodeAhead == Head)
            {
                AddNodeToFront(value);
                return;
            }

            DoublyLinkedListNode<T> runner = Head;
            DoublyLinkedListNode<T> current = new DoublyLinkedListNode<T>(value);


            for (int i = 0; i < Count; i++)
            {
                if (runner.next == null)
                {
                    return;
                }
                if (runner.next == nodeAhead)
                {
                    runner.next = current;
                    current.next = nodeAhead;
                }
                runner = runner.next;
            }
            if (nodeAhead.next == null)
            {
                Tail = nodeAhead;
            }
            Count++;
        }

        public void AddAfter(DoublyLinkedListNode<T> nodeBehind, T value)
        {
            DoublyLinkedListNode<T> current = new DoublyLinkedListNode<T>(value);
            if (nodeBehind == null)
            {
                return;
            }
            else
            {
                current.next = nodeBehind.next;
                nodeBehind.next = current;
                current.prev = nodeBehind;
                if (current.next == null)
                {
                    Tail = current;
                }
            }
            Count++;
        }

        public DoublyLinkedListNode<T> FindNode(T val)
        {
            var current = Head;

            while (current != null)
            {
                if (current.data.Equals(val))
                {
                    break;
                }

                current = current.next;
            }

            return current;
        }
        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                if (Head == Tail)
                {
                    Clear();
                    return true;
                }
                else
                {
                    Head = Head.next;
                    Head.prev = null;
                    Count--;
                    return true;
                }
            }
        }
        public bool RemoveLast()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                if (Head == Tail)
                {
                    Clear();
                    return true;
                }
                else
                {
                    Tail = Tail.prev;
                    Tail.next = null;
                }
                Count--;
                return true;
            }
        }
        public bool Remove(T value)
        {
            var node = FindNode(value);

            if (node == null)
            {
                return false;
            }

            if (node == Head)
            {
                RemoveFirst();
                return true;
            }

            if (node == Tail)
            {
                RemoveLast();
                return true;
            }

            var nodeafter = node.next;
            var nodebefore = node.prev;
            nodebefore.next = nodeafter;
            Count--;
            return true;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void PrintList()
        {
            Console.WriteLine("-------------------------");
            DoublyLinkedListNode<T> runner = Head;
            while (runner != null)
            {
                Console.WriteLine(runner.data);
                runner = runner.next;
            }
            Console.WriteLine("-------------------------");

        }

        public void PrintListBackwards()
        {

        }

        public override string ToString()
        {
            return $"Count: {Count}, Head: {Head?.ToString() ?? "Null"}, Tail: {Tail?.ToString() ?? "Null"}";
        }
    }
}
