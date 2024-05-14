using System;

namespace DSA_1___Home_Assignment_Solution
{
    /// <summary>
    /// Class representing a min-heap storing Employee objects
    /// 
    /// TODO: Implement & comment all methods in this class; additional attributes and/or methods may be added but:
    /// 1. the structure of the given methods must be adhered to and cannot be altered
    /// 2. Any methods/attributes added to this class must be declared as private and called within the methods provided
    /// </summary>
    internal class EmployeeHeap
    {
        // Underlying array of employees used for the min-heap implementation
        private Employee[] heapArray;
        private int maxSize; // Maximum capacity of the heap
        private int currentSize; // Current number of elements in the heap

        // Overloaded constructor to build a heap with a given maximum capacity
        public EmployeeHeap(int maxCapacity)
        {
            maxSize = maxCapacity;
            heapArray = new Employee[maxSize];
            currentSize = 0;
        }

        private int getRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private int getLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int getParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        // Method to maintain the min-heap property by moving the node up the heap
        private void upHeap(int index)
        {
            int parentIndex = getParentIndex(index);
            // Compare both name and surname when moving up the heap
            while (index > 0 && CompareEmployees(heapArray[index], heapArray[parentIndex]) < 0)
            {
                // Swap the current node with its parent if it violates the min-heap property
                Employee temp = heapArray[index];
                heapArray[index] = heapArray[parentIndex];
                heapArray[parentIndex] = temp;
                index = parentIndex;
                parentIndex = getParentIndex(index);
            }
        }

        // Method to maintain the min-heap property by moving the node down the heap
        private void downHeap(int index)
        {
            int smallerChildIndex;
            // Compare both name and surname when moving down the heap
            while (getLeftChildIndex(index) < currentSize)
            {
                int leftChildIndex = getLeftChildIndex(index);
                int rightChildIndex = getRightChildIndex(index);
                if (rightChildIndex < currentSize && CompareEmployees(heapArray[rightChildIndex], heapArray[leftChildIndex]) < 0)
                {
                    smallerChildIndex = rightChildIndex;
                }
                else
                {
                    smallerChildIndex = leftChildIndex;
                }
                if (CompareEmployees(heapArray[index], heapArray[smallerChildIndex]) > 0)
                {
                    // Swap the current node with the smaller child if it violates the min-heap property
                    Employee temp = heapArray[index];
                    heapArray[index] = heapArray[smallerChildIndex];
                    heapArray[smallerChildIndex] = temp;
                    index = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        // Method to insert a new employee into the heap
        public void Insert(Employee e)
        {
            if (currentSize == maxSize)
            {
                throw new InvalidOperationException("Heap is full");
            }
            heapArray[currentSize] = e;
            upHeap(currentSize);
            currentSize++;
        }

        // Method to extract the minimum employee from the heap
        public Employee Extract()
        {
            if (currentSize == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }
            Employee extracted = heapArray[0];
            heapArray[0] = heapArray[currentSize - 1];
            currentSize--;
            downHeap(0);
            return extracted;
        }

        // Method to compare two employees based on their name and surname
        private int CompareEmployees(Employee emp1, Employee emp2)
        {
            int nameComparison = emp1.Name[0].CompareTo(emp2.Name[0]);
            if (nameComparison != 0)
            {
                return nameComparison;
            }
            else
            {
                return emp1.Surname.CompareTo(emp2.Surname);
            }
        }
    }
}
