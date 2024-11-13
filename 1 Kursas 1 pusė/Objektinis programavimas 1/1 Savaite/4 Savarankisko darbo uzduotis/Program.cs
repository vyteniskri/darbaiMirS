using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankisko_darbo_uzduotis
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Koks tavo vardas?");
            name = Console.ReadLine();
            if (name.EndsWith("is"))
            {
                name = name.Replace("is", "i");
            }
            else
                if (name.EndsWith("as"))
            {
                name = name.Replace("as", "ai");
            }
            else
                if (name.EndsWith("ys"))
            {
                name = name.Replace("ys", "y");
            }
            else
                if (name.EndsWith("ė"))
            {
                name = name.Replace("ė", "e");
                }

            Console.WriteLine("Labas, {0}!", name);
            Console.ReadKey();
        }
    }
}
