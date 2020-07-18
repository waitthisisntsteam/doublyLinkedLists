using System;
using Xunit;
using doublyLinkedLists;
using linkedLists;

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
        [InlineData(1, new int[] { 6 })]
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
                Assert.Null(list.Head.prev);
                Assert.Null(list.Tail.next);
                Assert.NotNull(list.Head);
                Assert.NotNull(list.Tail);
                Assert.Equal(values[0], list.Head.data);
                Assert.Equal(values[values.Length - 1], list.Tail.data);
            }

        }

        [Theory]
        public void ListTestAddAfter(int expectedCount, int[] values)
        {
            var list = new DoublyLinkedList<int>();
        }

    }
}
