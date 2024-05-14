using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_1___Home_Assignment_Solution
{
    /// <summary>
    /// Class allowing the sorting of Employee objects using Merge Sort
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of employees must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class MergeSort : Sorter<Employee>
    {

        private Employee[] employeesToSort;
        public MergeSort(Employee[] unsortedEmployees) : base(unsortedEmployees) { 

         employeesToSort = new Employee[unsortedEmployees.Length];
 
      for (int i = 0; i < unsortedEmployees.Length; i++)
    {
        // Assuming Employee constructor takes name, surname, and title as parameters
        string name = unsortedEmployees[i].Name;
        string surname = unsortedEmployees[i].Surname;
        string title = unsortedEmployees[i].JobTitle;
        
        employeesToSort[i] = new Employee(name, surname, title);
        
    }

        }
        

        
        public override Employee[] Sort()
        {
            // Implement Merge Sort algorithm to sort employees by both name and surname
            MergeSortRecursive(employeesToSort, 0, employeesToSort.Length - 1);
            return employeesToSort;
        }

        private void MergeSortRecursive(Employee[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                // Recursively sort the two halves
                MergeSortRecursive(arr, left, mid);
                MergeSortRecursive(arr, mid + 1, right);

                // Merge the sorted halves
                Merge(arr, left, mid, right);
            }
        }

        private void Merge(Employee[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Create temporary arrays to hold the two halves
            Employee[] L = new Employee[n1];
            Employee[] R = new Employee[n2];

            // Copy data to temporary arrays L[] and R[]
            for (int i = 0; i < n1; ++i)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; ++j)
                R[j] = arr[mid + 1 + j];

            // Merge the temporary arrays back into arr[l..r]
            int i1 = 0, i2 = 0;
            int k = left;
            while (i1 < n1 && i2 < n2)
            {
                if (L[i1].Name[0].CompareTo(R[i2].Name[0]) < 0 || (L[i1].Name[0] == R[i2].Name[0] && L[i1].Surname.CompareTo(R[i2].Surname) <= 0))
                 arr[k++] = L[i1++];
                else
                arr[k++] = R[i2++];
            }

            // Copy the remaining elements of L[], if there are any
            while (i1 < n1)
                arr[k++] = L[i1++];

            // Copy the remaining elements of R[], if there are any
            while (i2 < n2)
                arr[k++] = R[i2++];
        }

    }
}
