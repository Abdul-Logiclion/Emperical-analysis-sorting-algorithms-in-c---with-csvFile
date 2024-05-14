using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_1___Home_Assignment_Solution
{
    /// <summary>
    /// Class allowing the sorting of Employee objects using Quick Sort where the pivot is the right-most element
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of employees must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class QuickSort : Sorter<Employee>
    {



        private Employee[] employeesToSort;

        public QuickSort(Employee[] unsortedEmployees) : base(unsortedEmployees) {
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
            QuickSortRecursive(employeesToSort, 0, employeesToSort.Length - 1);
            
            return employeesToSort;

            
        }

        private void QuickSortRecursive(Employee[] arr, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(arr, left, right);

                // Recursively sort the two halves
                QuickSortRecursive(arr, left, partitionIndex - 1);
                QuickSortRecursive(arr, partitionIndex + 1, right);
            }
        }

        private int Partition(Employee[] arr, int left, int right)
        {
            Employee pivot = arr[right]; // Choosing the right-most element as pivot
            int i = left - 1; // Index of smaller element

            for (int j = left; j < right; j++)
            {
                // Compare name and surname for sorting
                if (CompareNames(arr[j], pivot) < 0)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private int CompareNames(Employee emp1, Employee emp2)
        {
            int nameComparison = emp1.Name[0].CompareTo(emp2.Name[0]);


            if (nameComparison != 0)
            {
            return nameComparison;
            }
                
            
            return emp1.Surname.CompareTo(emp2.Surname);;
        }

        private void Swap(Employee[] arr, int i, int j)
        {
            Employee temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

    }
}
