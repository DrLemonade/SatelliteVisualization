using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVHelper.Configuration;
using CSVHelper;

namespace CSVReaders
{

    public class DoublyLinkedLIst<T>
    {
        private int Size;
        private Node<T> Head;
        private Node<T> Tail;

        public DoublyLinkedLIst()
        {

            Head = null;
            Tail = null;
            Size = 0;

        }

        public void insertFirst(T data)
        {

            Node<T> temp = new Node<T>(null, data, Head);
            Head = temp;
            Size++;

        }

        public void insertLast(T data)
        {

            Node<T> temp = new Node<T(Tail, data, null);
            Tail = temp;
            Size++;

        }


        private class Node
        {
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }
            public T Data { get; set; }

            public Node(Node<T> prev, T data, Node<T> next)
            {

                Prev = prev;
                Data = data;
                Next = next;

            }
        }

    }
}