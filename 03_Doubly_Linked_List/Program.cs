using System;

namespace _03_Doubly_Linked_List
{

    class Program
    {
        public static void Main()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.InsertLast(1000);
            list.InsertLast(2000);
            list.InsertLast(3000);
            list.InsertLast(4000);

            Console.WriteLine("------------");
            Console.WriteLine(list.Last.Data);
            Console.WriteLine("------------");

            list.DeleteLast();

            list.InsertLast(10000);

            Console.WriteLine("------------");
            Console.WriteLine(list.Last.Data);
            Console.WriteLine("------------");

            list.DisplayList();

        }

    }

    public class DoublyLinkedList
    {

        private Node _first;
        private Node _last;

        public Node Last
        {
            get
            {
                return _last;
            }
        }

        public int Length
        {
            get
            {
                int counter = 0;
                Node current = _first;

                while (current != null)
                {
                    counter++;
                    current = current.Next;
                }
                return counter;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return _first == null;
            }
        }
        public void InsertFirst(int data)
        {
            Node newNode = new Node { Data = data };

            if (IsEmpty) // insert 1st element
            {
                _first = newNode;
                _last = newNode;
            }
            else if (_first == _last) // insert 2nd element, only one element in the list
            {
                _first = newNode;
                _first.Next = _last;
                _last.Previous = _first;
            }
            else // more then 2 elements in the list
            {
                Node temp = _first;
                _first = newNode;
                _first.Next = temp;
            }
        }

        public void InsertLast(int data)
        {
            Node newNode = new Node { Data = data };
            if (IsEmpty) // insert 1st element
            {
                _first = newNode;
                _last = newNode;
            }
            else if (_first == _last) // there is only one element in the list
            {
                _last = newNode;
                _last.Previous = _first;
                _first.Next = _last;
            }
            else // other cases
            {
                Node temp = _last;
                temp.Next = newNode;
                _last = newNode;
                _last.Previous = temp;
            }
        }

        public void DeleteFirst()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty. Nothing to delete.");
                Console.WriteLine($"Length: {{ { Length } }}");
            }
            else if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                _first = _first.Next;
                _first.Previous = null;
            }
        }

        public void DeleteLast()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty. Nothing to delete");
            }
            if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                _last.Previous.Next = null;
                _last = _last.Previous;

            }
        }

        public void DisplayList()
        {
            if (IsEmpty)
            {
                Console.Write("List is empty. Nothing to display.");
            }
            else
            {
                Node current = _first;
                while (current != null)
                {
                    current.DisplayNode();
                    current = current.Next;
                }
                Console.WriteLine($"Length: {{ { Length } }}");
            }
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public bool HasNext
        {
            get { return Next == null; }
        }

        public void DisplayNode()
        {
            Console.WriteLine($"{ Data }");
        }

    }
}


