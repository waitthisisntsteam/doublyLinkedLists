using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace linkedLists
{
    class Program
    {
        public class doublyLinkedListNode<T>
        {
            public T data;
            public doublyLinkedListNode<T> next;
            public doublyLinkedListNode<T> prev;

            public doublyLinkedListNode(T current)
            {
                data = current;
                next = null;
                prev = null;
            }
        }

        public class doublyLinkedList<T>
        {
            public int count;
            public doublyLinkedListNode<T> head;
            public doublyLinkedListNode<T> tail;

            public doublyLinkedList()
            {
                head = null;
                tail = null;
                count = 0;
            }

            public void AddNodeToFront(T value)
            {
                if (head == null)
                {
                    head = new doublyLinkedListNode<T>(value);
                    tail = head;
                }
                else
                {
                    doublyLinkedListNode<T> current = new doublyLinkedListNode<T>(value);
                    head.prev = current;
                    current.next = head;
                    head = current;
                }
                count++;
            }
            public void AddNodeToLast(T value)
            {
                if (head == null)
                {
                    AddNodeToFront(value);
                }
                else
                {
                    doublyLinkedListNode<T> current = new doublyLinkedListNode<T>(value);
                    tail.next = current;
                    current.prev = tail;
                    tail = current;
                }
                count++;
            }

            public void AddBefore(doublyLinkedListNode<T> nodeAhead, T value)
            {
                doublyLinkedListNode<T> runner = head;
                doublyLinkedListNode<T> current = new doublyLinkedListNode<T>(value);
                for (int i = 0; i < count; i++)
                {
                    if (runner.next == nodeAhead)
                    {
                        runner.next = current;
                        current.next = nodeAhead;
                    }
                    runner = runner.next;
                }
                if (nodeAhead.next == null)
                {
                    tail = nodeAhead;
                }
                count++;
            }

            public void AddAfter(doublyLinkedListNode<T> nodeBehind, T value)
            {
                doublyLinkedListNode<T> current = new doublyLinkedListNode<T>(value);
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
                        tail = current;
                    }
                }
                count++;
            }

            public doublyLinkedListNode<T> FindNode(T val)
            {
                var current = head;

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
                if (head == null)
                {
                    return false;
                }
                else
                {
                    if (head == tail)
                    {
                        Clear();
                        return true;
                    }
                    else
                    {
                        head = head.next;
                        count--;
                        return true;
                    }
                }
            }
            public bool RemoveLast()
            {
                if (head == null)
                {
                    return false;
                }
                else
                {
                    if (head == tail)
                    {
                        Clear();
                        return true;
                    }
                    else
                    {
                        tail = tail.prev;
                        tail.next = null;
                    }
                    count--;
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

                if (node == head)
                {
                    RemoveFirst();
                    return true;
                }

                if (node == tail)
                {
                    RemoveLast();
                    return true;
                }

                var nodeafter = node.next;
                var nodebefore = node.prev;
                nodebefore.next = nodeafter;
                count--;
                return true;
            }

            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }

            public void PrintList()
            {
                doublyLinkedListNode<T> runner = head;
                while (runner != null)
                {
                    Console.WriteLine(runner.data);
                    runner = runner.next;
                }
            }
        }

        static void Main(string[] args)
        {
            doublyLinkedList<int> linkedList = new doublyLinkedList<int>();
            linkedList.AddNodeToFront(1);
            linkedList.AddNodeToLast(2);
            linkedList.AddNodeToLast(5);
            linkedList.AddBefore(linkedList.tail, 4);
            linkedList.AddAfter(linkedList.head.next, 3);
            linkedList.AddNodeToFront(0);
            linkedList.RemoveFirst();
            linkedList.AddNodeToLast(6);
            linkedList.RemoveLast();
            linkedList.AddAfter(linkedList.head.next.next, 7);
            linkedList.Remove(7);
            linkedList.PrintList();
        }
    }
}