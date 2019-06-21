using System;
using System.Collections.Generic;

namespace Audible_Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            flipEveryOtherNode(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Console.ReadKey();
        }

        public static void flipEveryOtherNode(int[] numbers)
        {
            ForwardNode<int> previousNode = null;

            // Convert array to linked list (O(N))
            for (var i = numbers.Length - 1; i >= 0; i--)
                previousNode = new ForwardNode<int>(numbers[i], previousNode);

            pairwiseNodeValueFlip(previousNode);

            // Iterate through the node values
            foreach(var item in previousNode.AsEnumerable())
                Console.WriteLine(item);
        }

        public static ForwardNode<int> pairwiseNodeValueFlip(ForwardNode<int> node)
        {
            var firstNode = node;
            var secondNode = node.next;

            if (firstNode == null)
                return null;
            if (secondNode == null)
                return firstNode;

            var firstNodeValue = firstNode.value;
            var secondNodeValue = secondNode.value;

            node.value = secondNodeValue;
            node.next.value = firstNodeValue;

            node.next.next = pairwiseNodeValueFlip(node.next.next);

            return node;
        }
    }

    class ForwardNode<T>
    {
        public T value { get; set; }
        public ForwardNode<T> next { get; set; }

        public ForwardNode(T value, ForwardNode<T> next)
        {
            this.value = value;
            this.next = next;
        }

        // Convert linked list back to enumerable (O(N))
        public IEnumerable<T> AsEnumerable()
        {
            var node = this;

            while (node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }
    }
}
