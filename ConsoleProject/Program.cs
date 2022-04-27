using ConsoleProject.Models;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department(9 , 200 , "B");
            Console.WriteLine($"{department.Name}{department.SalaryLimit}{department.WorkerLimit}");
        }
    }
}
