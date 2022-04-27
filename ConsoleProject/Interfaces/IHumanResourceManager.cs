using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        void AddDepartment(string name , int workerLimit , double salaryLimit);
        Department[] GetDepartments();
        void EditDepartments(string departmentName , string name);
        void AddEmployee(string fullName,string position,double salary, string departmentName, string no);
        void RemoveEmployee(string no,string departmentName);
        void EditEmployee();
    }
}
