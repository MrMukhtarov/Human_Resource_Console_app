using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }

        public Employee[] Employes;

        public Department()
        {
            Employes = new Employee[0];
        }

        public double CalcSalaryAvarage()
        {
            return 0;
        }
    }
}
