using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_2_arraysorter
{
    public class ArraySorter<T> where T : IComparable<T>
    {

        public T[] Items { get; private set; }
        private int _size;
     //   public T[] Items;
        private int _start;
        private int _end;

        private bool _isAscending = true;
        private bool _isSorted = false;
        private IComparer<T> _comparer;

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public ArraySorter(T[] items, int size , IComparer<T> comparer = null) 
        {
            Items = items;
            _size = size;
            BuildHeap();
            _comparer = comparer;

        }




        private void BuildHeap()
        {
            int length = Size;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(length, i);
            }
        }


        public void sink(T[] array, int heapSize, int toSinkPos)
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

        public void swap(T[] array, int pos0, int pos1)
        {
            T tmpVal = array[pos0];
            array[pos0] = array[pos1];
            array[pos1] = tmpVal;
        }

        public int getLeftKidPos(int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        public int getRightKidPos(int parentPos)
        {
            return 2 * (parentPos + 1);
        }

        public void Enqueue(T item) 
        {

            Items[_end = _end + 1] = item;
            _end = _end % Items.Length;
        
        }
        
        public T Dequeue() 
        {
            T item = Items[_start = _start + 1];

            _start = _start % Items.Length;

            return item;
        }
        
        public void SortAscending()
        {

            if (!_isAscending)
            {
                _isAscending = true;
                _isSorted = false;
                BuildHeap();
            }

            if (!_isSorted)
            {
                int length = Size;
                for (int i = length - 1; i >= 0; i--)
                {
                    Swap(i, 0);
                    Heapify(i, 0);
                }

                _isSorted = true;
            }

        }


        private void Swap(int idxA, int idxB)
        {
            var tmp = Items[idxA];
            Items[idxA] = Items[idxB];
            Items[idxB] = tmp;
        }

        private void Heapify(int length, int i)
        {
            int largest = i;

            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left < length && Less(Items[largest], Items[left]))
            {
                largest = left;
            }
            if (right < length && Less(Items[largest], Items[right]))
            {
                largest = right;
            }

            if (i != largest)
            {
                Swap(i, largest);
                Heapify(length, largest);
            }
        }

        private bool Less(T first, T second)
        {
            if (_comparer == null)
            {
                if (_isAscending)
                {
                    return first.CompareTo(second) < 0;
                }

                return first.CompareTo(second) > 0;
            }
            return _comparer.Compare(first, second) < 0;
        }



        public void Sort(IComparer<T> comparer)
        {

            IComparer<T> tmp = _comparer;
            _comparer = comparer;
            if (!_isAscending)
            {
                _isAscending = true;
            }

            _isSorted = false;
            BuildHeap();
            SortAscending();
            _comparer = tmp;
            _isSorted = true;

        }

    }
}
