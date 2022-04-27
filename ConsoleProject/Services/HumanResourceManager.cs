using ConsoleProject.Interfaces;
using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;

        public HumanResourceManager()
        {
            _departments = new Department[0];
        }
        public void AddDepartment(string name , int workerLimit , double salaryLimit)
        {
            Department departments = new Department(workerLimit, salaryLimit, name);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = departments;
        }
        public void AddEmployee(string fullName, string position, double salary, string departmentName, string no)
        {
            throw new NotImplementedException();
        }

        public void EditDepartments(string departmentName, string name)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(string departmentName, string name)
        {
            
        }

        public Department[] GetDepartments()
        {
            return _departments;
        }

        public void RemoveEmployee(string no , string departmentName)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToUpper() == departmentName.ToUpper())
                {
                    for (int i = 0; i < item.Employees.Length; i++)
                    {
                        if (item.Employees[i].No == no)
                        {
                            item.Employees[i] = item.Employees[item.Employees.Length - 1];
                            Array.Resize(ref item.Employees, item.Employees.Length - 1);
                            return;
                        }
                    }
                    Console.WriteLine($"{no} isci yoxdur");
                }
            }
            Console.WriteLine($"{departmentName} adli department tapilmadi");
        }

        public void EditEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
