using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class GrokkingAlgorithms<T> where T : IComparable
    {
        public T[] array;
        private bool isSorted = false;

        public void QuickSort()
        {
            array = QuickSort(array);
            isSorted = true;
        }

        private T[] QuickSort(T[] array)
        {
            if(array.Length <= 2)
            {
                return array;
            }
            else
            {
                int index = array.Length / 2;
                T[] pivot = new T[] { array[index] };
                T[] less = Less(array, pivot[0]);
                T[] greater = Greater(array, pivot[0]);
                return ConcatArrays(QuickSort(less), pivot, QuickSort(greater)); 
            }
        }

        public int BinarySearch(T element)
        {
            if (!isSorted)
            {
                throw new Exception("Array didn't sorted \n");
            }

            int left = 0;
            int right = array.Length - 1;
            return BinarySearch(element, left, right);
        }

        private int BinarySearch(T element, int left, int right)
        {
            if(left > right)
            {
                throw new Exception("Element didn't found");
            }

            int middle = (right + left) / 2;

            if (array[middle].CompareTo(element) == 0)
            {
                return middle;
            }
            else
            {
                if(array[middle].CompareTo(element) > 0)
                {
                    return BinarySearch(element, left, middle - 1);
                }
                else
                {
                    return BinarySearch(element, middle + 1, right);
                }
            }

        }

        public T[] InsertSort()
        {
            for(int i = 1; i < array.Length; i++)
            {
                for(int j = i; (j > 0) && (array[j - 1].CompareTo(array[j]) > 0); j--)
                {
                    Swap(ref array[j-1], ref array[j]);
                }
            }
            isSorted = true;
            return array;
        }

        public void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString() + ' ');
            }
            Console.WriteLine();
        }

        private T[] Less(T[] array, T pivot)
        {
            List<T> temp = new List<T>();
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i].CompareTo(pivot) < 0)
                {
                    temp.Add(array[i]);
                }
            }
            if(temp.Count == 0)
            {
                return Array.Empty<T>();
            }
            return temp.ToArray();
        }

        private T[] Greater(T[] array, T pivot)
        {
            List<T> temp = new List<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(pivot) > 0)
                {
                    temp.Add(array[i]);
                }
            }
            if (temp.Count == 0)
            {
                return Array.Empty<T>();
            }
            return temp.ToArray();
        }

        private static T[] ConcatArrays(params T[][] list)
        {
            var result = new T[list.Sum(a => a.Length)];
            int offset = 0;
            for (int x = 0; x < list.Length; x++)
            {
                list[x].CopyTo(result, offset);
                offset += list[x].Length;
            }
            return result;
        }

        private void Swap(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

    }
}
