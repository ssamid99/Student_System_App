using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.StudentRegisterSystem.Managers
{
    public class StudentManager
    {
        Student[] data = new Student[0];


        public void Add(Student entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void EditName(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Telebe adini deyishin..!");
                    string newName = ScannerManager.ReadString("Ad daxil edin!");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newName);
                    break;
                }
            }
        }
        public void EditSurname(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Telebe soyadini deyishin..!");
                    string newSurname = ScannerManager.ReadString("Soyad daxil edin!");
                    data[i].Surname = data[i].Surname.Replace(data[i].Surname, newSurname);
                    break;
                }
            }
        }
        public void EditBirthday(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Telebenin dogum tarixini deyishin..!");
                    DateTime newDateTime = ScannerManager.ReadDate("Tarix daxil edin!");
                    data[i].BirthDate = newDateTime;
                    break;
                }
            }
        }
        public void EditStudentGroup(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == 0)
                {
                    Console.WriteLine("Telebenin qrupunu deyishin..!");
                    int newGroupId = ScannerManager.ReadInteger("Qrup Nº daxil edin!");
                    data[i].GroupId = newGroupId;
                    break;
                }
            }
        }
        public void Remove(int value)
        {

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    int studentIndex = value - 1;
                    data = data.Where((source, index) => index != studentIndex).ToArray();
                }

            }
        }
        public void Single(int value)
        {
            string singleStudent = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    singleStudent = $"Telebe adi: {data[i].Name} | Telebenin soyadi: {data[i].Surname} | Telebenin dogum tarixi: {data[i].BirthDate} | Telebenin qrupu: {data[i].GroupId}";
                    break;
                }
            }
            Console.WriteLine(singleStudent);
        }
        public Student[] GetAll()
        {
            return data;
        }
    }
}

