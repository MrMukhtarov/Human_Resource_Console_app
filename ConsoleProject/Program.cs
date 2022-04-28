using ConsoleProject.Models;
using ConsoleProject.Services;
using System;

namespace ConsoleProject
{
    class Program
    {


        static void Main(string[] args)
        {
            do
            {
                HumanResourceManager humanResourceManager = new HumanResourceManager();


                Console.Clear();
                Console.WriteLine("=====Welcome Human Resource Manager=====\n");
                Console.WriteLine("Etmek istediyiniz emeliyyatin reqemini daxil edin\n");

                Console.WriteLine("1. Departameantlerin siyahisini gostermek: ");
                Console.WriteLine("2. Departamenet yaratmaq: ");
                Console.WriteLine("3. Departmanetde deyisiklik etmek: ");
                Console.WriteLine("4. Iscilerin siyahisini gostermek: ");
                Console.WriteLine("5. Departamentdeki iscilerin siyahisini gostermrek: ");
                Console.WriteLine("6. Isci elave etmek: ");
                Console.WriteLine("7. Isci uzerinde deyisiklik etmek: ");
                Console.WriteLine("8. Departamentden isci silinmesi: ");
                Console.WriteLine("9. Sistemden cix");

                string choose = Console.ReadLine();
                int chooseNum;
                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 8)
                {
                    Console.WriteLine("Zehmet olmasa duzgun secim edin");
                    choose = Console.ReadLine();
                }

                //switch (chooseNum)
                //{
                //    case 1:
                //        AddGroup(ref humanResourceManager);
                //        break;
                //    case 2:
                //        AddStudent(ref humanResourceManager);
                //        break;
                //    case 3:
                //        EditGroup(ref humanResourceManager);
                //        break;
                //    case 4:
                //        EditStudnet(ref humanResourceManager);
                //        break;
                //    case 5:
                //        ShowAllGroups(ref humanResourceManager);
                //        break;
                //    case 6:
                //        ShowAllStudents(ref humanResourceManager);
                //        break;
                //    case 7:
                //        ShowAllStudentByGroupNo(ref humanResourceManager);
                //        break;
                //    case 8:
                //        return;
                //}
            } while (true);

        }


        //switch (chooseNum)
        //{
        //    case 1:
        //        department = new Department[0];
        //        Console.WriteLine("Departamenti sec");
        //        foreach (var item in department.Length.ToString())
        //        {
        //            Console.WriteLine($"{item}");
        //        }
        //        string chooseDepartment = Console.ReadLine();
        //        int chooseDepartmentName;
        //        while (!int.TryParse(chooseDepartment, out chooseDepartmentName) || chooseDepartmentName < 1 || chooseDepartmentName > 9)
        //        {
        //            Console.WriteLine("Zehmet olmasa duzgun secim edin");
        //            chooseDepartment = Console.ReadLine();
        //        }
        //        break;
        //}
    }
}

