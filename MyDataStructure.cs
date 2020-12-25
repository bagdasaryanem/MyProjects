using System;
using System.Collections.Generic;
using System.Text;

namespace MyDataStructure_
{
    class Node
    {
        public Node Prev;
        public int Info;
        public Node Next;
        public Node(int i)
        {
            Info = i;
            Prev = null;
            Next = null;
        }
    }

    class DoublyLinkedList
    {
        private Node _start;
        public DoublyLinkedList()
        {
            _start = null;
        }

        public void InsertEmptyList(int data)
        {
            Node temp = new Node(data);
            _start = temp;
        }
        public void InsertAtEnd(int data)
        {
            Node temp = new Node(data);
            Node p = _start;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = temp;
            temp.Prev = p;
        }
        public void CreateList()
        {
            Console.WriteLine("Enter the size of the doubly linked list");
            var n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
            {
                return;
            }
            Console.WriteLine("enter the first element");
            var data = Convert.ToInt32(Console.ReadLine());
            InsertEmptyList(data);
            for (var i = 2; i <= n; i++)
            {
                Console.WriteLine("Enter the next element");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }
        
        public void DeleteFirstNode()
        {
            if (_start == null)
                return;
            if (_start.Next == null)
            {
                _start = null;
                return;
            }
            _start = _start.Next;
            _start.Prev = null;
        }
        public void DeleteLastNode()
        {
            if (_start == null)
                return;
            if (_start.Next == null)
            {
                _start = null;
                return;
            }
            Node p = _start;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Prev.Next = null;
        }
        public void DeleteNode(int x)
        {
            if (_start == null)
            {
                return;
            }
            if (_start.Next == null)
            {
                if (_start.Info == x)
                    _start = null;
                else
                    Console.WriteLine(x + " not found");
                return;
            }
            if (_start.Info == x)
            {
                _start = _start.Next;
                _start.Prev = null;
                return;
            }
            Node p = _start.Next;
            while (p.Next != null)
            {
                if (p.Info == x)
                    break;
                p = p.Next;
            }
            if (p.Next != null)
            {
                p.Prev.Next = p.Next;
                p.Next.Prev = p.Prev;
            }
            else
            {
                if (p.Info == x)
                {
                    p.Prev.Next = null;
                }
                else
                    Console.WriteLine(x + " not found");
            }
        }

        public void DisplayList()
        {
            Node p;
            if (_start == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            Console.WriteLine("List is :  ");
            p = _start;
            while (p != null)
            {
                Console.Write(p.Info + "  ");
                p = p.Next;
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.CreateList();
            while (true)
            {
                Console.WriteLine("1. Display list ");
                Console.WriteLine("2. Delete first node ");
                Console.WriteLine("3. Delete last node ");
                Console.WriteLine("4. Delete any node ");
                Console.WriteLine("5. Quit ");
                Console.WriteLine("Enter your choice :");
                var choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 5)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        list.DisplayList();
                        break;
                    case 2:
                        list.DeleteFirstNode();
                        break;
                    case 3:
                        list.DeleteLastNode();
                        break;
                    case 4:
                        Console.WriteLine(" Enter the element to be Deleted :");
                        var data = Convert.ToInt32(Console.ReadLine());
                        list.DeleteNode(data);
                        break;
                    default:
                        Console.WriteLine(" Wrong choice");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
