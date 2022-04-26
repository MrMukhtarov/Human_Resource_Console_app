using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Employee
    {
        private static int _count;

        public readonly int No;
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }

        static Employee()
        {
            _count = 0;
        }

        public Employee(string fullName , string position , int salary , string departmentName)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
            _count++;
            No = _count;
        }

    }
}
