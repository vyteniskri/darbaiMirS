using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class WorkerThread
    {
        private object cLock;

        public WorkerThread(object s)
        {
            this.cLock = s;
        }

        public void removeData(DataMonitor dataMonitor, SortedResultMonitor sortedResultMonitor)
        {

            Student s;
            while ((s = dataMonitor.RemoveItem()) != null)
            {
               
                s.Calculate();

                if (Char.IsLetter(s.hash[0]))
                {
                    Monitor.Enter(cLock);
                    sortedResultMonitor.AddItemSorted(s);
                    Monitor.Exit(cLock);
                }

            }


        }

    }
}
