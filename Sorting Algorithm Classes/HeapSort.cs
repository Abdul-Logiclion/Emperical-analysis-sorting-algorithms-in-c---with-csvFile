using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace DSA_1___Home_Assignment_Solution
{
    /// <summary>
    /// Class allowing the sorting of Employee objects using Heap Sort where a Min-Heap is used
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of employees must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// 3. The Min-Heap class EmployeeHeap.cs must be utilized to sort elements
    /// </summary>
    internal class HeapSort : Sorter<Employee>
    {
        private EmployeeHeap minHeap;
        private int sortArraySize;
         private int currentSize;

        public HeapSort(Employee[] unsortedEmployees) : base(unsortedEmployees)
        {
            sortArraySize=unsortedEmployees.Length;
            currentSize=unsortedEmployees.Length;

            minHeap = new EmployeeHeap(unsortedEmployees.Length);
            foreach (var employee in unsortedEmployees)
            {
                minHeap.Insert(employee);
            }
        }

        public override Employee[] Sort()
        {
            // Extract employees from the min-heap and store them in a sorted array
            Employee[] sortedEmployees = new Employee[sortArraySize];
            int index = 0;
            while (currentSize> 0)
            {
                sortedEmployees[index++] = minHeap.Extract();

                currentSize--;
            }

            return sortedEmployees;
        }
    }
}
