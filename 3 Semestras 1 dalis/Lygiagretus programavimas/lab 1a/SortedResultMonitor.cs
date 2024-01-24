using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class SortedResultMonitor
    {
        private Student[] monitor;

        public int Count;

        private int currentIndex;

        public SortedResultMonitor(int count)
        {
            monitor = new Student[count];
        }

        public void AddItemSorted(Student student)
        {
            char firstSymbol = student.hash[0];

            if (Count == 0)
            {
                monitor[Count] = student;
                Count++;
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                char currentStudentFirstS = monitor[i].hash[0];

                if (firstSymbol <= currentStudentFirstS)
                {
                    for (int j = Count; j > i; j--)
                    {
                        monitor[j] = monitor[j - 1];
                    }
                    monitor[i] = student;
                    Count++;
                    return;
                }
                else if ((i + 1) == Count && firstSymbol >= currentStudentFirstS)
                {
                    monitor[i + 1] = student;
                    Count++;
                    return;
                }
                else if ((i + 1) != Count && firstSymbol >= currentStudentFirstS && firstSymbol <= monitor[i + 1].hash[0])
                {

                    for (int j = Count; j > i + 1; j--)
                    {
                        monitor[j] = monitor[j - 1];
                    }
                    monitor[i + 1] = student;
                    Count++;
                    return;
                }


            }

        }

        public Student GetItem()
        {
            Student s = monitor[currentIndex++];
            if (currentIndex == Count)
            {
                currentIndex = 0;
            }
            return s;
            
        }
    }
}
