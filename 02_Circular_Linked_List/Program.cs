using System;

/*
 *  A circular Linked List is a linked list in which the first element knows
 *  about the next and the last element of the list but remains oblivious
 *  towards the rest of the list.
 */

namespace _02_Circular_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList list = new CircularLinkedList();
            list.InsertLast(100);
            //list.InsertLast(200);
            //list.InsertLast(300);
            //list.InsertLast(400);
            //list.InsertLast(500);

            list.DeleteFirst();

            Console.WriteLine("-----------");
            list.DisplayList(); //
            Console.WriteLine($"List length: { list.Length }");


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
                if (IsEmpty)
                {
                    return 0;
                }
                else
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

            if (IsEmpty)
            {
                _first = newNode;
                _last = newNode;
            }
            else if (_first == _last) // list has only 1 element
            {
                _last = _first;
                _first = newNode;
                _first.Next = _last;
            }
            else // list has more then 1 element
            {
                newNode.Next = _first;
                _first = newNode;
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
            else if (_first == _last) // list has only 1 element
            {
                _first.Next = newNode;
                _last = newNode;
            }
            else // list has more then 1 element
            {
                _last.Next = newNode;
                _last = newNode;
            }
        }

        public void DeleteFirst()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty. Nothing to delete.");
                throw new Exception();
            }
            else if (Length == 1)
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
                Console.WriteLine("List is empty. Nothing to delete");
                throw new Exception();
            }
            else if (Length == 1)
            {
                _first = null;
                _last = null;
            }
            else
            {
                Node current = _first;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
                _last = current;
            }
        }

        public void DisplayList()
        {
            if (IsEmpty) { Console.WriteLine("List is empty. Nothing to display."); }
            else
            {
                Node current = _first;
                while (current != null)
                {
                    current.DisplayNode();
                    current = current.Next;
                }
            }

        }

    }

    /*
     * this kind of class is called a self-referential or recursive class.
    */
    public class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }

        public void DisplayNode()
        {
            Console.WriteLine(Data);
        }

        public bool HasNext
        {
            get { return this.Next != null; }
        }
    }
}
