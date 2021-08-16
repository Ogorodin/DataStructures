using System;
/*
 * SINGLY LINKED LIST means that the list is single-directional;
 * That any particular Node knows only about its next Node.
 */
namespace _01_Singly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();

            list.InsertLast(10);
            list.InsertLast(20);
            list.InsertLast(30);
            list.InsertLast(40);
            list.InsertLast(50);
            //    Console.WriteLine("------------");
            //    list.DisplayList(); // 10, 20, 30, 40, 50
            //    Console.WriteLine("------------");

            list.InsertFirst(100);
            list.InsertFirst(200);
            list.InsertFirst(300);
            //    Console.WriteLine("------------");
            //    list.DisplayList(); // 300, 200, 100, 10, 20, 30, 40, 50
            //    Console.WriteLine("------------");

            list.DeleteFirst();
            list.DeleteFirst();
            Console.WriteLine("------------");
            list.DisplayList(); // 100, 10, 20, 30, 40, 50
            Console.WriteLine("------------");

        }
    }

    public class SinglyLinkedList
    {
        private Node _first;

        // this method checks if the list is empty or not
        public bool IsEmpty()
        {
            return _first == null;
        }

        // this method inserts value at the end of the list
        public void InsertLast(int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            if (IsEmpty())
            {
                _first = newNode;
            }
            else
            {
                Node current = _first;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // this method inserts value at the beggining of the list
        public void InsertFirst(int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            if (IsEmpty())
            {
                _first = newNode;
            }
            else
            {
                newNode.Next = _first;
                _first = newNode;
            }
        }

        // this method removes the first Node from the list
        public void DeleteFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. Nothing was deleted.");
            }
            else
            {
                _first = _first.Next;
            }
        }

        // this method lists all the nodes from the list
        public void DisplayList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
            }
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

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public void DisplayNode()
        {
            Console.WriteLine(Data);
        }
    }
}

