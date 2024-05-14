 using DSA_1___Home_Assignment_Solution;
using System;
using System.Diagnostics;
#region generateRandomEmployees
int sampleSize = 10;
Employee[] randomEmployees = RandomTestDataGenerator.generateRandomEmployees(sampleSize);
Console.WriteLine("Printing Random Unsorted Employee Data : ");
foreach (Employee employee in randomEmployees)
{
    Console.WriteLine(employee.ToString());
}
#endregion


#region TestMergeSort
MergeSort merge_sorter = new MergeSort(randomEmployees);
Employee[] merge_sort_result = merge_sorter.Sort();
Console.WriteLine("\n\nPrinting Merge Sort Results for Random Employee Data : ");
foreach (Employee employee in merge_sort_result)
{
    Console.WriteLine(employee.ToString());
}
#endregion


#region TestQuickSort
QuickSort quick_sorter = new QuickSort(randomEmployees);
Employee[] quick_sort_result = quick_sorter.Sort();
Console.WriteLine("\n\nPrinting Quick Sort Results for Random Employee Data : ");
foreach (Employee employee in quick_sort_result)
{
    Console.WriteLine(employee.ToString());
}
#endregion


#region TestHeapSort
HeapSort heap_sorter = new HeapSort(randomEmployees);
Employee[] heap_sort_result = heap_sorter.Sort();
Console.WriteLine("\n\nPrinting Heap Sort Results for Random Employee Data : ");
foreach (Employee employee in heap_sort_result)
{
    Console.WriteLine(employee.ToString());
}
#endregion

 #region Empirical Analysis
        // Define input sizes and repetitions
        int[] inputSizes = { 100,1000,10000,100000 };
        int repetitions = 10;

        foreach (int size in inputSizes)
        {
            double mergeSortAvgTime = 0, quickSortAvgTime = 0, heapSortAvgTime = 0;

            for (int i = 0; i < repetitions; i++)
            {
                // Generate random employee objects array
                Employee[] randomEmployeesForAnalysis = RandomTestDataGenerator.generateRandomEmployees(size);

                // Perform empirical analysis for Merge Sort
                merge_sorter = new MergeSort(randomEmployeesForAnalysis);
                Stopwatch mergeSortStopwatch = Stopwatch.StartNew();
                merge_sorter.Sort();
                mergeSortStopwatch.Stop();
                mergeSortAvgTime += mergeSortStopwatch.ElapsedMilliseconds;

                // Perform empirical analysis for Quick Sort
                quick_sorter = new QuickSort(randomEmployeesForAnalysis);
                Stopwatch quickSortStopwatch = Stopwatch.StartNew();
                quick_sorter.Sort();
                quickSortStopwatch.Stop();
                quickSortAvgTime += quickSortStopwatch.ElapsedMilliseconds;

                // Perform empirical analysis for Heap Sort
                heap_sorter = new HeapSort(randomEmployeesForAnalysis);
                Stopwatch heapSortStopwatch = Stopwatch.StartNew();
                heap_sorter.Sort();
                heapSortStopwatch.Stop();
                heapSortAvgTime += heapSortStopwatch.ElapsedMilliseconds;
            }

            // Calculate average times
            mergeSortAvgTime /= repetitions;
            quickSortAvgTime /= repetitions;
            heapSortAvgTime /= repetitions;

            // Print average times
            Console.WriteLine($"Empirical Analysis for Input Size: {size}");
            Console.WriteLine($"Average Merge Sort Time: {mergeSortAvgTime} ms");
            Console.WriteLine($"Average Quick Sort Time: {quickSortAvgTime} ms");
            Console.WriteLine($"Average Heap Sort Time: {heapSortAvgTime} ms");
            Console.WriteLine();
        }
        #endregion