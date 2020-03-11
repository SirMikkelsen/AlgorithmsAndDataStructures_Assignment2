using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_2_arraysorter
{
    public class HeapSort<T> where T : IComparable
    {

        public T[] Sort(T[] array)
        {
            int heapSize = array.Length;

            buildMaxHeap(array);

            for (int i = heapSize - 1; i >= 1; i--)
            {
                swap(array, i, 0);
                heapSize--;
                sink(array, heapSize, 0);
            }

            return array;
        }


        public static void buildMaxHeap(T[] array)
        {
            int heapSize = array.Length;

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                sink(array, heapSize, i);
            }
        }

        public static void sink(T[] array, int heapSize, int toSinkPos)
        {
            if (getLeftKidPos(toSinkPos) >= heapSize)
            {
                // No left kid => no kid at all
                return;
            }


            int largestKidPos;
            bool leftIsLargest;

            if (getRightKidPos(toSinkPos) >= heapSize || array[getRightKidPos(toSinkPos)].CompareTo(array[getLeftKidPos(toSinkPos)]) < 0)
            {
                largestKidPos = getLeftKidPos(toSinkPos);
                leftIsLargest = true;
            }
            else
            {
                largestKidPos = getRightKidPos(toSinkPos);
                leftIsLargest = false;
            }



            if (array[largestKidPos].CompareTo(array[toSinkPos]) > 0)
            {
                swap(array, toSinkPos, largestKidPos);

                if (leftIsLargest)
                {
                    sink(array, heapSize, getLeftKidPos(toSinkPos));

                }
                else
                {
                    sink(array, heapSize, getRightKidPos(toSinkPos));
                }
            }

        }

        public static void swap(T[] array, int pos0, int pos1)
        {
            T tmpVal = array[pos0];
            array[pos0] = array[pos1];
            array[pos1] = tmpVal;
        }

        public static int getLeftKidPos(int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        public static int getRightKidPos(int parentPos)
        {
            return 2 * (parentPos + 1);
        }

        //public static void printArray(T[] array)
        //{

        //	foreach (T t in array)
        //	{
        //		Console.Write(' ' + t.ToString() + ' ');
        //	}

        //}
    }

}
