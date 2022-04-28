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
        public void AddDepartment(string name, int workerLimit, double salaryLimit)
        {
            Department departments = new Department(name, workerLimit, salaryLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = departments;
        }
        public void AddEmployee(string fullName, string position, double salary, string departmentName, string no)
        {
            foreach (Department department in _departments)
            {
                if (department.Name.ToUpper() == no.ToUpper())
                {

                    if (department.WorkerLimit > department.Employees.Length)
                    {
                        if ((department.CalcSalaryAvarage() * department.Employees.Length) + salary > department.SalaryLimit)
                        {
                            Console.WriteLine("Maas heddi asildi");
                            return;
                        }
                        Employee departments = new Employee(fullName, position, salary, departmentName);
                        Array.Resize(ref department.Employees, department.Employees.Length + 1);
                        department.Employees[department.Employees.Length - 1] = departments;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Yer Yoxdur");
                        return;
                    }
                }
            }
            Console.WriteLine($"Daxil edilen yanlisdir");
        }

        public void EditDepartments(string departmentName, string name)
        {
            Department department = FindName(departmentName);
            if (department != null)
            {
                departmentName = name;
                return;
            }
            Console.WriteLine($"{departmentName} adli department tapilmadi");
        }

        public Department FindName(string name)
        {
            foreach (Department department in _departments)
            {
                if (department.Name == name.ToUpper())
                {
                    return department;
                }
            }
            return null;
        }

        public void EditEmployee(string departmentName, string fullName, string no, double salary, string position)
        {
            Department department = FindName(departmentName);
            if (department != null)
            {
                foreach (Employee employe in department.Employees)
                {
                    if (employe.No == no)
                    {
                        if (((department.CalcSalaryAvarage() * department.Employees.Length) - employe.Salary) + salary > department.SalaryLimit)
                        {
                            Console.WriteLine("Maas heddi asildi");
                            return;
                        }
                        employe.FullName = fullName;
                        employe.Position = position;
                        employe.Salary = salary;
                    }
                }
                Console.WriteLine($"{no} nomreli isci tapilmadi");
            }
            Console.WriteLine($"{department} adinda department tapilmadi");
        }

        public Department[] GetDepartments()
        {
            return _departments;
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            Department department = FindName(departmentName);
            if (department != null)
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
                return;
            }
            Console.WriteLine($"{departmentName} adli department tapilmadi");

        }


    }
}
