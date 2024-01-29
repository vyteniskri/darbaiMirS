using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_SAV
{
    class StudentsRegister
    {
        private StudentsConteiner AllStudents;
        public StudentsRegister()
        {
            AllStudents = new StudentsConteiner();
        }

        public StudentsRegister(StudentsConteiner students)
        {
            AllStudents = new StudentsConteiner();
            for (int i = 0; i < students.Count; i++)
            {
                this.AllStudents.Add(students.Get(i));
            }
        }

        public void Add(Student student)
        {
            AllStudents.Add(student);
        }        public int StudentsCount()
        {
            return this.AllStudents.Count;
        }

        public Student OneDog(int ind)
        {
            return AllStudents.Get(ind);
        }

        public StudentsConteiner AverageOfGroups()
        {
            double sum = 0;
            int x = 0;
            StudentsConteiner vid = new StudentsConteiner();
            string[] Add = new string[AllStudents.Count];
            for (int i = 0; i < AllStudents.Count; i++)
            {
                
                if (!Add.Contains(AllStudents.Get(i).Group))
                {
                    for (int j = 0; j < AllStudents.Count; j++)
                    {
                        if (AllStudents.Get(i).Group == AllStudents.Get(j).Group)
                        {
                            sum = sum + AllStudents.Get(j).Average;
                            x++;

                        }
                    }
                    AllStudents.Get(i).GroupAverage = sum / x;
                    x = 0;
                    sum = 0;
                    vid.Add(AllStudents.Get(i));
                } 
                Add[i] = AllStudents.Get(i).Group;
                
            }
            return vid;
        }
    }
}
