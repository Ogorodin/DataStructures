using System;

namespace _011_Singly_Linked_List_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();

            list.InsertLast(1000);
            list.InsertLast(2000);
            list.InsertLast(3000);
            list.InsertLast(4000);
            list.InsertLast(5000);

            list.InsertAt(5, 1);



            list.DisplayList();



        }
    }

    public class SinglyLinkedList
    {
        private Node _first;
        public int Length
        {
            get
            {
                Node current = _first;
                int count = 0;

                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }
        public bool IsEmpty
        {
            get { return _first == null; }
        }


        public Node this[uint index]
        {
            get
            {
                if (IsEmpty || index >= Length)
                    throw new IndexOutOfRangeException();

                Node current = _first;
                int counter = 0;
                while (current.Next != null)
                {
                    if (counter == index) break;
                    current = current.Next;
                    counter++;
                }
                return current;
            }

            set
            {
                if (IsEmpty || index >= Length) throw new IndexOutOfRangeException(); // list is empty and has no indexes

                Node current = _first;
                int counter = 0;
                while (current != null)
                {
                    if (counter == index)
                    {
                        current.Data = value.Data;
                        break;
                    }
                    current = current.Next;
                    counter++;
                }
            }
        }

        public void InsertFirst(int data)
        {
            Node newNode = new Node { Data = data };
            if (IsEmpty)
            {
                _first = newNode;
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
            }
            else
            {
                Node current = _first;
                while (current.HasNext)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void DeleteFirst()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty. Nothing to delete.");
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
            else if (Length == 1)
            {
                _first = null;
            }
            else
            {
                Node current = _first;
                while (current.Next.HasNext)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        }

        /*
         * This method will place a new Node on the requested index
         * and push the older node to the next place
         */
        public void InsertAt(uint index, int data)
        {
            if (IsEmpty || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            Node newNode = new Node() { Data = data };

            Node previous = _first;
            Node current = _first.Next;
            int counter = 1;

            while (current != null)
            {
                if (index == counter)
                {
                    newNode.Next = current;
                    previous.Next = newNode;
                }
                current = current.Next;
                previous = previous.Next;
                counter++;
            }




        }
        public void DisplayList()
        {
            if (_first == null)
            {
                Console.WriteLine("List is empty. Nothing to display.");
            }
            else
            {
                Node current = _first;
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
                Console.WriteLine($"Length: { Length }");
            }

        }

    }






}
public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public bool HasNext
    {
        get
        {
            return Next != null;
        }
    }

    public void DisplayNode()
    {
        Console.WriteLine($"{ Data }");
    }
}

