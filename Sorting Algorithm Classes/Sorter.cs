using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_1___Home_Assignment_Solution
{
    /// <summary>
    /// Abstract class acting as parent class for all classes reflecting sorting algorithms
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class Sorter<T>
    {
        //Represents an array of unsorted data elements
        protected T[] unsortedData;

        //Overloaded contructor which allows the Sorter class to receive as input an array of unsorted elements
        public Sorter(T[] unsortedData) 
        {
            this.unsortedData = new T[unsortedData.Length];
            unsortedData.CopyTo(this.unsortedData, 0);
        }

        /// <summary>
        /// Sorts the array of unsorted elements and returns an array with the same data sorted in the required order
        /// </summary>
        /// <returns>T[] an array of elements which are sorted in the required order</returns>
        public abstract T[] Sort();

        /// <summary>
        /// The following method calls the Sort() method to sort the elements in the unsorted array
        /// Once sorted, it prints the contents of the sorted array
        /// </summary>
        public void printSortedArray()
        {
            T[] sortedArray = Sort();
            foreach (T item in sortedArray) 
            { 
                Console.WriteLine(item.ToString());
            }
        }
    }
}
