using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;


namespace assignment_2_arraysorter
{
    public class Program
    {



        public static void Main(string[] args)
        {
            Data[] test = new Data[10];

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int num = rnd.Next(1, 100);
                int num2 = rnd.Next(1, 100);
                test[i] = new Data(num, num2, "Data priority1: " + num + ", priority2: " + num2);
            }

            ArraySorter<Data> arraySorter = new ArraySorter<Data>(test, test.Length);

            Console.WriteLine("Print random numbers");


            foreach (var obj in test)
            {
                Console.WriteLine(obj);

            }

            Console.WriteLine("----------------------");
            Console.WriteLine("Print ascending numbers");

            arraySorter.SortAscending();

            foreach (var item in arraySorter.Items)
            {
                Console.WriteLine(item);
            }






            Console.ReadKey();
        }
    }
}
