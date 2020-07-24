using System;
using Xunit;
using doublyLinkedLists;
using linkedLists;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace doublyLinkedLists.Tests
{
    public class ListTests
    {
        // 2 types of attributes for now
        // fact, theory
        // fact checks for invariant things, never changing
        // fact would be good to test if count is 0 if nothing is added to list


        [Fact]  //attribute
        public void ListCountIsZeroWhenEmpty()
        {
            var list = new DoublyLinkedList<int>();

            Assert.Equal(0, list.Count);

        }

        [Fact]
        public void ListHeadTailAreNullWhenEmpty()
        {
            var list = new DoublyLinkedList<int>();

            Assert.Null(list.Head);
            Assert.Null(list.Tail);
        }



        // Theory tests for various inputs
        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { 1 })]
        [InlineData(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void ListTestAddLast(int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();

            foreach (var item in values)
            {
                list.AddNodeToLast(item);
            }

            Assert.Equal(expectedCount, list.Count);
            if (expectedCount > 0)
            {
                Assert.Equal(list.Head.prev, list.Tail);
                Assert.Equal(list.Tail.next, list.Head);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                Assert.Equal(values[0], list.Head.data);
                Assert.Equal(values[values.Length - 1], list.Tail.data);
            }

        }

        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { 1 })]
        [InlineData(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void ListTestAddNodeToFront(int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();
            foreach (var item in values)
            {
                list.AddNodeToFront(item);
            }

            Assert.Equal(expectedCount, list.Count);
            if (expectedCount > 0)
            {
                Assert.Equal(list.Head.prev, list.Tail);
                Assert.Equal(list.Tail.next, list.Head);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                Assert.Equal(values[values.Length - 1], list.Head.data);
                Assert.Equal(values[0], list.Tail.data);
            }
        }

        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { 1 })]
        [InlineData(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void ListTestAddAfter(int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();            
            foreach (var item in values)
            {
                if (list.Count > 0)
                {
                    list.AddAfter(list.Tail, item);
                }
                else
                {
                    list.AddNodeToFront(item);
                }
            }

            Assert.Equal(expectedCount, list.Count);
            if (expectedCount > 0)
            {
                Assert.Equal(list.Head.prev, list.Tail);
                Assert.Equal(list.Tail.next, list.Head);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                Assert.Equal(values[0], list.Head.data);
                Assert.Equal(values[values.Length-1], list.Tail.data);
            }
        }

        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { 1 })]
        [InlineData(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void ListTestAddBefore(int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();
            foreach (var item in values)
            {
                if (list.Count > 0)
                {
                    list.AddBefore(list.Tail, item);
                }
                else
                {
                    list.AddNodeToFront(item);
                }
            }

            Assert.Equal(expectedCount, list.Count);
            if (expectedCount > 0)
            {
                Assert.Equal(list.Head.prev, list.Tail);
                Assert.Equal(list.Tail.next, list.Head);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                if (values.Length > 1)
                {
                    Assert.Equal(values[1], list.Head.data);
                }
                Assert.Equal(values[0], list.Tail.data);
            }
        }

        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { 1})]
        [InlineData(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        public void ListTestRemoveLast(int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();
            foreach (var item in values)
            {
                list.AddNodeToLast(item);
            }          

            Assert.Equal(expectedCount, list.Count);
            if (expectedCount > 0)
            {
                Assert.Equal(list.Head.prev, list.Tail);
                Assert.Equal(list.Tail.next, list.Head);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                Assert.Equal(values[0], list.Head.data);
                if (values.Length > 1)
                {
                    list.RemoveLast();
                    Assert.Equal(values[values.Length - 2], list.Tail.data);
                }
            }
        }

        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[1] { 1})]
        [InlineData(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        public void ListTestRemoveFirst (int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();
            foreach (var item in values)
            {
                list.AddNodeToLast(item);
            }

            Assert.Equal(expectedCount, list.Count);
            if (expectedCount > 0)
            {
                Assert.Equal(list.Head.prev, list.Tail);
                Assert.Equal(list.Tail.next, list.Head);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                if (values.Length > 1)
                {
                    list.RemoveFirst();
                    Assert.Equal(values[1], list.Head.data);
                }               
                Assert.Equal(values[values.Length - 1], list.Tail.data);
            }
        }

        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[1] { 1})]
        [InlineData(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        public void ListTestRemove (int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();
            foreach (var item in values)
            {
                list.AddNodeToLast(item);
            }

            Assert.Equal(expectedCount, list.Count);
            if (expectedCount > 0)
            {
                Assert.Equal(list.Head.prev, list.Tail);
                Assert.Equal(list.Tail.next, list.Head);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                if (values.Length > 1)
                {
                    list.Remove(1);
                    Assert.Equal(values[2], list.Head.next.data);
                }
                Assert.Equal(values[0], list.Head.data);
                Assert.Equal(values[values.Length - 1], list.Tail.data);
            }
        }
    }
}
