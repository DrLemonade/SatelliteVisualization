using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVHelper.Configuration;
using CSVHelper;

namespace CSVReaders
{

    public class DoublyLinkedList
    {
        public int Size { get; set; }
        private Node Head;
        private Node Tail;

        public DoublyLinkedList<T>()
        {

            Head = null;
            Tail = null;
            Size = 0;

        }

        public void insertFirst(Dictionary<string, double> data)
        {

            Node temp = new Node(null, data, Head);
            Head = temp;
            Size++;

        }

        public void insertLast(T data)
        {

            Node temp = new Node(Tail, data, null);
            Tail = temp;
            Size++;

        }


        private class Node
        {
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public Dictionary<string, double> Data { get; set; }

            public Node(Node prev, Dictionary<string, double> data, Node next)
            {

                Prev = prev;
                Data = data;
                Next = next;

            }
        }

        public T get(int index)
        {

            Node current = Head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.data;

        }

    }
}