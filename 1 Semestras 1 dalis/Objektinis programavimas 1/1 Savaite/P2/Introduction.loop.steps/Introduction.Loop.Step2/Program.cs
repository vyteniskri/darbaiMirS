using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaičiai nuo 1 iki 10 ir jų kvadratai:");
            for (int i = 5; i < 15; i++)
                Console.WriteLine("{0} {1}", i, i * i);
            Console.ReadKey();
        }
    }
}
