using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_SAV
{
    class StudentsConteiner
    {
        private Student[] students;
        public int Count { get; private set; }
        private int Capacity;

        public StudentsConteiner(int capacity = 20)
        {
            this.Capacity = capacity;
            this.students = new Student[capacity];
        }

        public void Add(Student student)
        {
            this.students[Count++] = student;
        }

        public Student Get(int index)
        {
            return students[index];
        }

        public bool Contains(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.students[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            bool x = true;
            while(x)
            {
                x = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Student a = this.students[i];
                    Student b = this.students[i + 1];

                    if (a.CompareTo(b) < 0)
                    {
                        
                         this.students[i] = b;
                         this.students[i + 1] = a;
                         x = true;
                        
                    }
                }
            }
        }
    }
}
