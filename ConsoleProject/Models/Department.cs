using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Department
    {
        private string _name;

        private int _workerLimit;

        private double _salaryLimit;

        public Employee[] Employees;

        public Employee[] Avarage;

        public double SalaryLimit 
        {
            get => _salaryLimit;
            set
            {
                while (value < 250)
                {
                    Console.WriteLine("Minimum verilecek emek haqqi 250 olmalidir");
                    int salaryLimit;
                    if (int.TryParse(Console.ReadLine() , out salaryLimit))
                    {
                        value = salaryLimit;
                    }
                    else
                    {
                        Console.WriteLine("Herf daxil etmek olmaz");
                    }
                }
                _salaryLimit = value;
            }
        }
        public int WorkerLimit 
        {
            get => _workerLimit;
            set
            {
                while (value < 1)
                {
                    Console.WriteLine("Minimum isci sayi 10 ola biler");
                    int workerLimit;
                    if (int.TryParse(Console.ReadLine(), out workerLimit))
                    {
                        value = workerLimit;
                    }
                    else
                    {
                        Console.WriteLine("Herf daxil etmek olmaz");
                    }
                }
                _workerLimit = value;
            }
        }
        public string Name 
        {
            get => _name;
            set
            {
                while (value.Length < 2)
                {
                    Console.WriteLine("Ad minimum 2 herfden ibaret ola biler");
                    value = Console.ReadLine();
                }
                _name = value;
            }  
        }
        public Department(string name , int workerLimit , double salaryLimit)
        {
            Employee[] employe = new Employee[0];
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
            Name = name;
        }
        public double CalcSalaryAvarage()
        {
            double total = 0;
            foreach (Employee employe in Employees)
            {
                total += employe.Salary;
            }
            total = total / Employees.Length;
            return total;
        }
    }
}
