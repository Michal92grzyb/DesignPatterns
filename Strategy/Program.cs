using System;
using System.Collections.Generic;

namespace Strategy
{
    // The Strategy pattern suggests that you take a class that does something specific 
    // in a lot of different ways and extract all of these algorithms into separate classes called strategies.
    // And you can change those strategies at runtime.

    interface ISortStrategy
    {
        List<int> Sort(List<int> dataset);
    }

    class BubbleSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> dataset)
        {
            Console.WriteLine("Sorting using Bubble Sort !");
            return dataset;
        }
    }

    class QuickSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> dataset)
        {
            Console.WriteLine("Sorting using Quick Sort !");
            return dataset;
        }
    }

    class Sorter
    {
        private ISortStrategy _sorter;

        public Sorter(ISortStrategy sorter)
        {
            _sorter = sorter;
        }

        public void SetSortStrategy(ISortStrategy sorter)
        {
            _sorter = sorter;
        }

        public List<int> Sort(List<int> unSortedList)
        {
            return _sorter.Sort(unSortedList);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var unSortedList = new List<int> { 1, 10, 2, 16, 19 };

            var sorter = new Sorter(new BubbleSortStrategy());
            sorter.Sort(unSortedList); // // Output : Sorting using Bubble Sort !

            sorter.SetSortStrategy(new QuickSortStrategy());
            sorter.Sort(unSortedList); // // Output : Sorting using Quick Sort !
        }
    }
}
