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
            Department department = FindName(name);
            if (department == null)
            {
                Department departments = new Department(name, workerLimit, salaryLimit);
                Array.Resize(ref _departments, _departments.Length + 1);
                _departments[_departments.Length - 1] = departments;
                return;
            }
            else
            {
                Console.WriteLine("Eyni adda ikinci sirket ola bulmez");
            }

        }
        public void AddEmployee(string fullName, string position, double salary, string departmentName)
        {
            Department department = FindName(fullName);
            if (department != null)
            {
                if (department.WorkerLimit > department.Employees.Length)
                {
                    if ((department.CalcSalaryAvarage() * department.Employees.Length) + salary > department.SalaryLimit)
                    {
                        Console.WriteLine("Maas heddi asildi");
                        return;
                    }
                    Employee employee = new Employee(fullName, position, salary, departmentName);
                    Array.Resize(ref department.Employees, department.Employees.Length + 1);
                    department.Employees[department.Employees.Length - 1] = employee;
                    return;
                }
                else
                {
                    Console.WriteLine("Yer Yoxdur");
                    return;
                }
            }
        }

        public void EditDepartments(string name, string newname)
        {
            Department department = FindName(name);
            if (department != null)
            {
                department.Name = newname;
                if (department.Employees != null)
                {
                    foreach (Employee employee in department.Employees)
                    {
                        employee.No.Replace(employee.No.Substring(0, 2), department.Name.Substring(0, 2).ToUpper());
                        employee.DepartmentName = newname;
                    }
                }
            }
            Console.WriteLine($"{name} adli department tapilmadi");
        }

        public Department FindName(string name)
        {
            foreach (Department department in _departments)
            {
                if (department.Name.ToUpper() == name.ToUpper())
                {
                    return department;
                }
            }
            return null;
        }

        public void EditEmployee(string departmentName,  string no, double salary, string position)
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
                        employe.Position = position;
                        employe.Salary = salary;
                        employe.DepartmentName = departmentName;
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

                if (departmentName.ToUpper() == departmentName.ToUpper())
                {
                    for (int i = 0; i < department.Employees.Length; i++)
                    {
                        if (department.Employees[i].No == no)
                        {
                            department.Employees[i] = department.Employees[department.Employees.Length - 1];
                            Array.Resize(ref department.Employees, department.Employees.Length - 1);
                            return;
                        }
                    }
                    Console.WriteLine($"{no} isci yoxdur");
                }

                Console.WriteLine($"{departmentName} adli department tapilmadi");
                return;
            }
            Console.WriteLine($"{departmentName} adli department tapilmadi");

        }
    
    }
}
