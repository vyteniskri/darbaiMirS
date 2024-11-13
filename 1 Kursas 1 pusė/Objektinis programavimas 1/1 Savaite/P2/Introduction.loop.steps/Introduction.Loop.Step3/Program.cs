using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaičiai nuo 1 iki 10 ir jų kvadratai:");
            for (int i = 5; i < 15; i++)
                Console.WriteLine("{0} {1} {2}", i, i * i, i * i * i);
            Console.ReadKey();
        }
    }
}
