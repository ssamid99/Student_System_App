using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.StudentRegisterSystem.Managers
{
    public class GroupManager
    {
        Group[] data = new Group[0];


        public void Add(Group entity)
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
                    Console.WriteLine("Qrup adini deyishdir..! ");
                    string newName = ScannerManager.ReadString("Yeni ad daxil et!");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newName);
                    break;
                }
            }
        }
        public void EditSpeciality(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Ixtisas adini deyishin..!");
                    string newSpeciality = ScannerManager.ReadString("Ixtisas adi daxil et!");
                    data[i].Speciality = data[i].Speciality.Replace(data[i].Speciality, newSpeciality);
                    break;
                }
            }
        }
        public void EditName_andSpeciality(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Qrup adini ve ixtisasini deyishdir deyishdir..! ");
                    string newName = ScannerManager.ReadString("Yeni ad daxil et!");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newName);
                    string newSpeciality = ScannerManager.ReadString("Ixtisas adi daxil et!");
                    data[i].Speciality = data[i].Speciality.Replace(data[i].Speciality, newSpeciality);
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
                    int groupIndex = value - 1;
                    data = data.Where((source, index) => index != groupIndex).ToArray();
                }

            }
        }
        public void Single(int value)
        {
            string singleGroup = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    singleGroup = $"Qrup Nº: {data[i].Id} | Qrup Adi: {data[i].Name} | Qrup Ixtisasi: {data[i].Speciality}";
                    break;
                }
            }
            Console.WriteLine(singleGroup);
        }
        public Group[] GetAll()
        {
            return data;
        }
    }
}

