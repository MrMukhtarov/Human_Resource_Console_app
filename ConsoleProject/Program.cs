using ConsoleProject.Models;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Department department = new Department("Nicat",5,220);
            //Console.WriteLine($"{department.Name}{department.SalaryLimit}{department.WorkerLimit}");
            Employee emoloye = new Employee("Nicat Muxtarov", "Senior", 251, "Maliyye");
            //Console.WriteLine($"{emoloye.FullName}{emoloye.Position}{emoloye.Salary}{emoloye.No}{emoloye.DepartmentName}");
        }
    }
}
