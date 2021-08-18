using System;

namespace _022_Circular_Linked_List_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList list = new CircularLinkedList();


            list.InsertLast(1000);
            list.InsertLast(2000);
            list.InsertLast(3000);

            list[1] = 5;

            list.DisplayList();

            Console.WriteLine("Return from index 2: " + list[2]);
        }
    }

    public class CircularLinkedList
    {
        private Node _first;
        private Node _last;

        public int Length
        {
            get
            {
                Node current = _first;
                int counter = 0;
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
            get { return _first == null; }
        }

        public int this[uint index]
        {
            get
            {

                if (IsEmpty || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    Node current = _first;
                    int counter = 0;
                    while (current != null)
                    {
                        if (index == counter)
                        {
                            break;
                        }
                        current = current.Next;
                        counter++;
                    }
                    return current.Data;
                }
            }
            /*
             *  This will replace the value on the selected index position;
             */
            set // (Node value)
            {
                if (IsEmpty || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                int newData = value;
                Node current = _first;
                int indexCounter = 0;
                while (current != null)
                {
                    if (indexCounter == index)
                    {
                        current.Data = newData;
                        break;
                    }
                    indexCounter++;
                    current = current.Next;
                }
            }
        }

        public void InsertFirst(int data)
        {
            Node newNode = new Node { Data = data };

            if (IsEmpty) // insert 1st value
            {
                _first = newNode;
                _last = newNode;
            }
            else if (_first == _last) // insert 2nd value; only 1 Node in the list
            {
                _first = newNode;
                _first.Next = _last;
            }
            else
            {
                Node temp = _first;
                _first = newNode;
                _first.Next = temp;
            }
        }

        public void InsertLast(int data)
        {
            Node newNode = new Node { Data = data };

            if (IsEmpty)
            {
                _first = newNode;
                _last = newNode;
            }
            else if (_first == _last)
            {
                _last = newNode;
                _first.Next = _last;
            }
            else
            {
                _last.Next = newNode;
            }
        }

        /*
         * This method inserts a new Node at the index from the method parameter
         * and adds to the list length
         */
        public void InsertAt(int index, int data)
        {
            Node newNode = new Node { Data = data };

            if (IsEmpty || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0) // new Node in place of first element [index 0]
            {
                InsertFirst(data);
            }
            else if (index == Length) // new Node in place of the last element [last index]
            {
                InsertLast(data);
            }
            else // starts from index [1]
            {
                Node previous = _first;
                Node current = _first.Next;
                int counter = 1;
                while (current != null)
                {
                    if (counter == index)
                    {

                        Node temp = current;
                        current = newNode;
                        current.Next = temp;
                        previous.Next = current;
                        break;

                    }
                    current = current.Next;
                    previous = previous.Next;
                    counter++;
                }
            }
        }

        public void DeleteFirst()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty. Nothing to delete.");
            }
            else if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                _first = _first.Next;
            }
        }

        public void DeleteLast()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty. Nothing to delete.");
            }
            else if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                // WTF!!!
                Node current = _first;
                while (current.Next != _last)
                {
                    current = current.Next;
                }

                _last = current;
                _last.Next = null;
            }
        }

        public void DisplayList()
        {
            if (_first == null)
            {
                Console.WriteLine("List is empty. Nothing to display");
            }
            else
            {
                Node current = _first;
                while (current != null)
                {
                    current.DisplayNode();
                    current = current.Next;
                }
                Console.WriteLine($"Length: { Length }");
            }
        }
    }

    public class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }
        public bool HasNext { get { return Next != null; } }

        public void DisplayNode()
        {
            Console.WriteLine($"{ Data }");
        }
    }
}
