using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_1___Home_Assignment_Solution
{
    /// <summary>
    /// Class describing an Employee object as required for Task 1
    /// This class requires no further addition/modification
    /// </summary>
    internal class Employee
    {
        private string name;
        public string Name { get => name; set => name = value; }

        private string surname;
        public string Surname { get => surname; set => surname = value; }

        private string jobTitle;
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        public Employee(string name, string surname, string jobTitle)
        {
            this.name = name;
            this.surname = surname;
            this.jobTitle = jobTitle;
        }

        public override string ToString()
        {
            return $"Name : {this.name} {this.surname}\tJob Title:{this.jobTitle}";
        }




    }
}
