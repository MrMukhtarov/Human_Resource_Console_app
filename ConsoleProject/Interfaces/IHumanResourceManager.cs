using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        void Departments();
        void AddDepartment();
        void GetDepartments();
        void EditDepartments();
        void AddEmployee();
        void RemoveEmployee();
        void EditEmployee();
    }
}
