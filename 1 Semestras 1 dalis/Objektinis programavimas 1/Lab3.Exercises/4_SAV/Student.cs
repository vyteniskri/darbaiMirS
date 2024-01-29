using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_SAV
{
    class Student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int NumberOfGrades { get; set; }
        public int[] Grade { get; set; }
        public double Average { get; set; }
        public double GroupAverage { get; set; }

        public Student(string surname, string name, string group, int numberOfGrades, int[] grade)
        {
            this.Surname = surname;
            this.Name = name;
            this.Group = group;
            this.NumberOfGrades = numberOfGrades;
            this.Grade = grade;

            double sum = 0;
            for (int i = 0; i < NumberOfGrades; i++)
            {
               sum = sum + Grade[i];
            }
            this.Average = sum / NumberOfGrades;
        }

       

        public int CompareTo(Student other)
        {
            if (this.GroupAverage != other.GroupAverage)
            {
                return this.GroupAverage.CompareTo(other.GroupAverage);
            }
            else
                return  other.Group.CompareTo(this.Group);
        }


    }
}
