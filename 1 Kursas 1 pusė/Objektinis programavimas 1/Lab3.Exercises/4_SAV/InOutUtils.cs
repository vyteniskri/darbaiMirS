using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _4_SAV
{
    class InOutUtils
    {
        public static StudentsConteiner ReadStudents(string fileName)
        {
            StudentsConteiner students = new StudentsConteiner();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] Values = line.Split(';');
                string surname = Values[0];
                string name = Values[1];
                string group = Values[2];
                int numberOfGrades = int.Parse(Values[3]);

                int[] grade = new int[numberOfGrades];

                for (int i = 0; i < numberOfGrades; i++)
                {
                    
                    grade[i] = int.Parse(Values[i + 4]);
                    
                }
                Student student = new Student(surname, name, group, numberOfGrades, grade);

                students.Add(student);
            }
            return students;
        }

        public static void Print(StudentsConteiner students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students.Get(i);
                Console.Write("| {0,20} | {1, 20} | {2,20} | {3,-20} | ", student.Surname, student.Name, student.Group, student.NumberOfGrades);
                for (int j = 0; j < student.NumberOfGrades; j++)
                {
                    Console.Write(student.Grade[j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintGroup(StudentsConteiner students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students.Get(i).GroupAverage != 0)
                {
                    Console.WriteLine("{0};{1}", students.Get(i).GroupAverage, students.Get(i).Group);
                }
                
            }
        }


    }
}
