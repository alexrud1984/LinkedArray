using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrLink
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(3);

            for (int i = 0; i < 30; i++)
            {
                list.Add(i);
            }
            PrintList(list);

            for (int i = 30; i <60; i++)
            {
                list[i]=i;
            }
            PrintList(list);

            list[39] = 100;
            PrintList(list);

            for (int i = 10; i < 20; i++)
            {
                list.Insert(i, -1);
            }
            PrintList(list);

            for (int i = list.Size; i >=0; i=i-3)
            {
                list.Remove(i);
                PrintList(list);
            }

            for (int i = 0; list.Size != 0;)
            {
                list.Remove(i);
                PrintList(list);
            }
        }

        static void PrintList(List<int> list)
        {
            Console.WriteLine();
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Size: " + list.Size);

            for (int i = 0; i < list.Size; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
