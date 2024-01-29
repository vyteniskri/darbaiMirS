using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma_savarankisko_darbo_uzduotis
{
    static class TaskUtils
    {
        public static decimal AllMoney(List<Turist> Turists)
        {
            decimal count = 0;
            foreach (Turist turist in Turists)
            {
                
                    count = count + turist.DevidedByFour();
            
            }
             return count * 100;
           
        }

        public static List<Turist> MostMoney(List<Turist> Turists)
        {
            List<Turist> NamesAndSurnames = new List<Turist>();
            decimal count = 0;
            for (int i = 0; i < Turists.Count; i++)
            {
                if(Turists[i].Money > count)
                {
                    count = Turists[i].Money;
                }
            }
            for (int i = 0; i < Turists.Count; i++)
            {
                if (Turists[i].Money == count)
                {
                    NamesAndSurnames.Add(Turists[i]);
                }
            }
            return NamesAndSurnames;
        }
        
    }
}
