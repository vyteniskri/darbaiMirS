using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Pirma_savarankisko_darbo_uzduotis
{
    class InOutUtils
    {
        public static List<Turist> ReadTurists(string fileName)
        {
            List<Turist> Turists = new List<Turist>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string surname = Values[1];
                decimal money = decimal.Parse(Values[2]);

                Turist turist = new Turist(name, surname, money);
                Turists.Add(turist);
            }
            return Turists;

        }

        public static void PrintTurists(List<Turist> Turists)
        {
            foreach (Turist turist in Turists)
            {
                Console.WriteLine("{0} {1} {2}", turist.Name, turist.Surname, turist.Money);
            }
        }

        public static void PrintNamesSurnames(List<Turist> Turists)
        {
            foreach (Turist turist in Turists)
            {
                Console.WriteLine("{0} {1}", turist.Name, turist.Surname);
            }
        }
    }
}
