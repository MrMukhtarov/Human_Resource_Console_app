using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        public void AddDepartment(string name, int workerLimit, double salaryLimit);

        public void AddEmployee(string fullName, string position, double salary, string departmentName, string no);


        public void EditDepartments( string name);


        public Department FindName(string name);


        public void EditEmployee(string departmentName, string fullName, string no, double salary, string position);

        public Department[] GetDepartments();



        public void RemoveEmployee(string no, string departmentName);

    }
}
