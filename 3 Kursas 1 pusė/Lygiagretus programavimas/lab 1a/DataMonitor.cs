using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class DataMonitor
    {
        private Student[] monitor;

        public int TotalCount;

        public int Count;
        
        private object cLock = new object();

        private object ob = new object();
        
        public DataMonitor(int count)
        {
            monitor = new Student[count / 2];
            this.TotalCount = count;
        }

        public void AddItem(Student student)
        {
            lock (cLock)
            {
                monitor[Count] = student;
                Count++;
                Monitor.Pulse(cLock);
                
            }
            
        }

        public Student RemoveItem()
        {

            Monitor.Enter(ob);
            if (TotalCount == 0)
            {
                Monitor.Exit(ob);
                return null;
            }

            lock (cLock)
            {

                if (Count == 0)
                {

                    Monitor.Wait(cLock);

                }

                Student student = monitor[Count - 1];
                monitor[Count - 1] = null;
                Count--;
                TotalCount--;
                Monitor.Exit(ob);
                return student;

            }
        }

    }
}
