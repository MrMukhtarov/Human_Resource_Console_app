using ConsoleProject.Models;
using ConsoleProject.Services;
using System;
namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("=====Welcome Human Resource Manager=====\n");
                Console.WriteLine("Etmek istediyiniz emeliyyatin reqemini daxil edin\n");
                Console.WriteLine("1. Departamenet yaratmaq: ");
                Console.WriteLine("2. Isci elave etmek: ");
                Console.WriteLine("3. Departamentdeki iscilerin siyahisini gostermrek: ");
                Console.WriteLine("4. Departameantlerin siyahisini gostermek: ");
                Console.WriteLine("5. Departmanetde deyisiklik etmek: ");
                Console.WriteLine("6. Isci uzerinde deyisiklik etmek: ");
                Console.WriteLine("7. Iscilerin siyahisini gostermek: ");
                Console.WriteLine("8. Departamentden isci silinmesi: ");
                Console.WriteLine("9. Sistemden cix");
                string choose = Console.ReadLine();
                int chooseNum;
                while (!int.TryParse(choose, out chooseNum) || chooseNum > 9 || chooseNum < 1)
                {
                    Console.WriteLine("Zehmet olmasa duzgun secim edin");
                    choose = Console.ReadLine();
                }
                Console.Clear();
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        ShowEmoloyeByDepartmentName(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        EditDepartment(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        ShowAllEmploye(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 9:
                        return;
                }
            } while (true);
        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }
        }
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("0: Menyuya Qayitmaq");
            Console.WriteLine("Departmentin adini daxil edin");
            string chooseDepartment = Console.ReadLine();
            if (chooseDepartment == "0")
            {
                return;
            }
            while (string.IsNullOrWhiteSpace(chooseDepartment) || chooseDepartment.Length < 2)
            {
                Console.WriteLine("departmentName duzgun daxil edilmeyib");
                chooseDepartment = Console.ReadLine();
            }
            Console.WriteLine("Departmentin isci limitini daxil edin");
            int.TryParse(Console.ReadLine(), out int workerlimit);
            Console.WriteLine("Departmentin budcesini elave et");
            string salaryLimit = Console.ReadLine();
            double SalaryNum;
            double.TryParse(salaryLimit, out SalaryNum);
            while (!double.TryParse(salaryLimit, out SalaryNum) || SalaryNum < 250 || salaryLimit.Contains(','))
            {
                Console.WriteLine("Departmentin mass limitini duzgun daxil edin");
                salaryLimit = Console.ReadLine();
            }
            humanResourceManager.AddDepartment(chooseDepartment, workerlimit, SalaryNum);
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }
        }
        static void EditDepartment(ref HumanResourceManager humanResourceManager)
        {
          
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("Departmentler siyahisinda deyisiklik etmek istediyiniz departmentin adini secin");
            string chooseDepartmentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(chooseDepartmentName) || chooseDepartmentName.Length < 2)
            {
                Console.WriteLine("Departmentin adini duzgun daxil edin");
                chooseDepartmentName = Console.ReadLine();
            }
            if (humanResourceManager.FindName(chooseDepartmentName) == null)
            {
                Console.WriteLine("Department adi tapilmadi");
                Console.WriteLine("Department adi tapilmadi");
                chooseDepartmentName = Console.ReadLine();
            }
            Console.WriteLine("Yeni adi daxil edin");
            string chooseNewDepartmentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(chooseNewDepartmentName) || chooseNewDepartmentName.Length < 2)
            {
                Console.WriteLine("Departmentin yeni adini duzgun daxil edin");
                chooseNewDepartmentName = Console.ReadLine();
            }
            humanResourceManager.EditDepartments(chooseDepartmentName, chooseNewDepartmentName);
        }
        static void ShowEmoloyeByDepartmentName(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("Istediyiniz departmenti secin");
            string departmentName = Console.ReadLine();
            if (humanResourceManager.GetDepartments().Length < 0)
            {
                Console.WriteLine("Departmaent yoxdur");
            }
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin");
            string employeeNo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(employeeNo))
            {
                Console.WriteLine("Nomreni duzgun daxil edin");
                employeeNo = Console.ReadLine();
            }
            Console.WriteLine("Silmek istediyiniz departmentin adini daxil edin");
            string departmentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(departmentName) || departmentName.Length < 2)
            {
                Console.WriteLine("Department adini duzgun daxil edin");
                departmentName = Console.ReadLine();
            }
            humanResourceManager.RemoveEmployee(employeeNo, departmentName);
        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
          
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("Departmentin adini daxil edin");
            string departmentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(departmentName) || departmentName.Length < 2)
            {
                Console.WriteLine("Department adini duzgun daxil edin");
                departmentName = Console.ReadLine();
            }
            Console.WriteLine("Adinizi ve soyadinizi daxil edin");
            string fullName = Console.ReadLine();
            while (!fullName.TrimStart().TrimEnd().Contains(" "))
            {
                    Console.WriteLine("zehmet olmasa ad ve soyadi duzgun daxil edin");
                    fullName = Console.ReadLine();
            }
            Console.WriteLine("Iscinin vezifesini daxil edin");
            string position = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(position) || position.Length < 2)
            {
                Console.WriteLine("IScinin vezifesini duzgun daxil edin");
                position = Console.ReadLine();
            }
            Console.WriteLine("Iscinin maasini daxil edin");
            string salary = Console.ReadLine();
            double SalaryNum;
            while (string.IsNullOrWhiteSpace(salary) || !double.TryParse(salary,out SalaryNum) || SalaryNum < 250 || salary.Contains(','))
            {
                Console.WriteLine("Iscinin maasini duzgun daxil edin");
                salary = Console.ReadLine();
            }
            humanResourceManager.AddEmployee(fullName, position, SalaryNum, departmentName.ToUpper()); 
        }
        static void ShowAllEmploye(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("Deyismek istdeyiniz iacinin Departmentini daxil edin");
            string departmentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(departmentName) || departmentName.Length < 2)
            {
                Console.WriteLine("Department adini duzgun daxil edin");
                departmentName = Console.ReadLine();
            }
            foreach (Department department1 in humanResourceManager.Departments)
            {
                foreach (Employee employee in department1.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("Deyismek istediyiniz isci npmresini daxil edin ");
            string no = Console.ReadLine();
            Console.WriteLine("Isicinin gelirini daxul edin");
            double.TryParse(Console.ReadLine(), out double employeSalary);
            Console.WriteLine("iscinin vezifesini daxil edin");
            string employeposition = Console.ReadLine();

            humanResourceManager.EditEmployee(departmentName, no, employeSalary, employeposition);
        }
    }
}

