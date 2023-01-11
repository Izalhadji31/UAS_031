using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UAS_031;

namespace UAS_031
{
    class Node
    {
        public int nama_barang;
        public string jenis_barang;
        public String harga_barang;
        public Node next;
        public Node prev;
    }
    class DoubleLinkedList
    {

        Node START;
        public DoubleLinkedList()
   
        {
            START = null;
        }

        public void addnode()
        {
            int nb;
            string jb;
            string hb;
            Console.Write("\nMasukkan nama barang: ");
            nb = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan jenis barang : ");
            jb = Console.ReadLine();
            Console.Write("\nMasukkan harga barang : ");
            hb = Console.ReadLine();
            Node newnode = new Node();
            newnode.nama_barang = nb;
            newnode.jenis_barang = jb;
            newnode.harga_barang = hb;

            if (START == null || nb <= START.nama_barang)
            {
                if ((START != null) && (nb == START.nama_barang))
                {
                    Console.WriteLine("\nTidak ada barang yang sama ");
                    return;
                }

                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }

            Node previous, current;
            for current = previous = START;
                current != null && nb <= current.nama_barang;
                previous = current, current = current.next;

            {
                if(nb == current.nama_barang)
                {
                    Console.WriteLine("\nTidak ada barang yang sama ");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }

            current.prev = newnode;
            previous.next = newnode;

        }

        public bool search(int rollNO, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNO != current.nama_barang; previous = current, current =
                current.next) { }
            return (current != null);
        }

        public bool dellnode(int rollno)
        {
            Node previous, current;
            previous = current = null;
            if (search(rollno, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty ");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are:\n");
                Node currentnode;
                for (currentnode = START; currentnode != null; currentnode =
                    currentnode.next)
                    Console.WriteLine(currentnode.nama_barang + "" + currentnode.jenis_barang + "" + currentnode.harga_barang + "\n");
            }
        }

        public void descending()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the descending order of " + "roll number are:\n");
                Node currentnode;
                for (currentnode = START; currentnode != null;
                    currentnode = currentnode.next) { }
                while (currentnode != null)
                {
                    Console.Write(currentnode.nama_barang + "" + currentnode.jenis_barang + "" + currentnode.harga_barang + "\n");
                    currentnode = currentnode.prev;
                }
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu ");
                    Console.WriteLine("1. Add a ITEM to the list ");
                    Console.WriteLine("2. Delete a ITEM from the list ");
                    Console.WriteLine("3. View all ITEM in the ascending order of roll numbers ");
                    Console.WriteLine("4. View all ITEM in the descending order of roll numbers ");
                    Console.WriteLine("5. Search for a ITEM in the list ");
                    Console.WriteLine("6. EXIT\n");
                    Console.Write("Enter your choice (1-6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is empty ");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student : " + "whose records is to deleted : ");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellnode(rollno) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("record with roll number " + rollno + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nEnter the roll number of the student whose records you want to search : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nrecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number : ");
                                    Console.WriteLine("\nName : " + curr.jenis_barang);
                                }

                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch 
                {
                    Console.WriteLine("check for the values entered");
                }
            }

        }
    }
}


// 2.Doublelinkedlist
//3. 