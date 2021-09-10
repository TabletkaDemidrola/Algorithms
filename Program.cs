using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            GrokkingAlgorithms<int> data_int = new GrokkingAlgorithms<int>();
            data_int.array = new int[] { 7, 4, 2, 33, 66, 14, 0, 59 };
            data_int.Print();
            data_int.QuickSort();
            data_int.Print();

            GrokkingAlgorithms<string> data_string = new GrokkingAlgorithms<string>();
            data_string.array = new string[]
            {
                "aaaa",
                "abaa",
                "baaa",
                "cbaa",
                "caba",
                "bbaa",
                "aaaa"
            };
            data_string.Print();
            data_string.InsertSort();
            data_string.Print();
            Console.WriteLine("Index: " + data_string.BinarySearch("abaa").ToString());

            Console.ReadLine();
        }
    }
}
