using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _4_SAV
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Cfd = @"Students.txt";

            StudentsConteiner allStudents = InOutUtils.ReadStudents(Cfd);
            StudentsRegister register = new StudentsRegister(allStudents);
            InOutUtils.Print(allStudents);
            Console.WriteLine();

            register.AverageOfGroups();
            allStudents.Sort();
            InOutUtils.PrintGroup(allStudents);

        }
    }
}
