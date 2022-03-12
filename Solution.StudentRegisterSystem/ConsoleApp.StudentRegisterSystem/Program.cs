using ConsoleApp.StudentRegisterSystem.Infrastructure;
using ConsoleApp.StudentRegisterSystem.Managers;
using System;
using System.Text;

namespace ConsoleApp.StudentRegisterSystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Student System v.1";

            var groupMgr = new GroupManager();
            var studentMgr = new StudentManager();

        readMenu:
            PrintMenu();

            Menu m = ScannerManager.ReadMenu("Menudan Secin: ");

            switch (m)
            {
                case Menu.GroupAdd:
                    Console.Clear();
                    Group g = new Group();
                    g.Name = ScannerManager.ReadString("Qrupun Adini Daxil Edin: ");
                    g.Speciality = ScannerManager.ReadString("Qrupun Ixtisasini Daxil Edin: ");

                    groupMgr.Add(g);

                    goto case Menu.GroupAll;
                case Menu.GroupEdit:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    Console.WriteLine("Qrup adini deyishmek ucun => 1 | Ixtisasi deyishmek ucun => 2 | Her ikisini ucun => 3");
                    bool success = int.TryParse(Console.ReadLine(), out int menuNumber);
                    if (success && menuNumber == 1)
                    {
                        int value = ScannerManager.ReadInteger("Secilmish qrupun Nº daxil edin: ");
                        groupMgr.EditName(value);
                    }
                    if (success && menuNumber == 2)
                    {
                        int value = ScannerManager.ReadInteger("Secilmish qrupun Nº daxil edin: ");
                        groupMgr.EditSpeciality(value);
                    }
                    if (success && menuNumber == 3)
                    {
                        int value = ScannerManager.ReadInteger("Secilmish qrupun Nº daxil edin: ");
                        groupMgr.EditName_andSpeciality(value);
                    }
                    goto case Menu.GroupAll;
                case Menu.GroupRemove:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    int value2 = ScannerManager.ReadInteger("sechin");
                    groupMgr.Remove(value2);
                    goto case Menu.GroupAll;
                case Menu.GroupSingle:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    int value3 = ScannerManager.ReadInteger("Secilmish qrupun Nº daxil edin: ");
                    groupMgr.Single(value3);
                    goto readMenu;
                case Menu.GroupAll:
                    ShowAllGroups(groupMgr);
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.StudentAdd:
                    Student s = new Student();
                    s.Name = ScannerManager.ReadString("Telebenin Adi: ");
                    s.Surname = ScannerManager.ReadString("Telebenin Soyadi: ");
                    s.BirthDate = ScannerManager.ReadDate("Telebenin Dogum Tarixi: ");
                    Console.WriteLine("--------");
                    ShowAllGroups(groupMgr);
                    Console.WriteLine("--------");
                    s.GroupId = ScannerManager.ReadInteger("Telebenin Qrupu: ");

                    studentMgr.Add(s);
                    goto case Menu.StudentAll;
                case Menu.StudentEdit:
                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    Console.WriteLine("Telebe adini deyishmek ucun => 1 | Soyadi deyishmek ucun => 2 | Dogum tarixi deyishmek ucun => 3 | Qrupunu deyishmek ucun => 4");
                    bool success2 = int.TryParse(Console.ReadLine(), out int menuNumberS);
                    if (success2 && menuNumberS == 1)
                    {
                        int valueS = ScannerManager.ReadInteger("Secilmish telebenin Nº daxil edin: ");
                        studentMgr.EditName(valueS);
                    }
                    if (success2 && menuNumberS == 2)
                    {
                        int valueS = ScannerManager.ReadInteger("Secilmish telebenin Nº daxil edin: ");
                        studentMgr.EditSurname(valueS);
                    }
                    if (success2 && menuNumberS == 3)
                    {
                        int valueS = ScannerManager.ReadInteger("Secilmish telebenin Nº daxil edin: ");
                        studentMgr.EditBirthday(valueS);
                    }
                    else if (success2 && menuNumberS == 4)
                    {
                        int valueS = ScannerManager.ReadInteger("Secilmish telebenin Nº daxil edin: ");
                        studentMgr.EditStudentGroup(valueS);
                    }
                    goto case Menu.StudentAll;
                case Menu.StudentRemove:
                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    int valueSt = ScannerManager.ReadInteger("sechin");
                    studentMgr.Remove(valueSt);
                    goto case Menu.StudentAll;
                    
                case Menu.StudentSingle:
                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    int value4 = ScannerManager.ReadInteger("Secilmish telebenin Nº daxil edin: ");
                    studentMgr.Single(value4);
                    goto readMenu;
                case Menu.StudentAll:
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.All:
                    ShowAllGroups(groupMgr);
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.Exit:
                    goto lEnd;
                default:
                    break;
            }
        lEnd:
            Console.WriteLine("END...");
            Console.WriteLine("Cixmaq Ucun Her Hansi Bir Duymeni Sixin");
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));

            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m = (Menu)Enum.Parse(typeof(Menu), item);

                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }

        static void ShowAllGroups(GroupManager groupMgr)
        {
            Console.Clear();
            Console.WriteLine("**********Groups**********");
            foreach (var item in groupMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        static void ShowAllStudents(StudentManager studentMgr)
        {
            Console.Clear();
            Console.WriteLine("**********Students**********");
            foreach (var item in studentMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}

