using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Skaičiai nuo 1 iki 10 ir jų kvadratai:");
            Console.WriteLine("Įveskite a reikšmę");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite b reikšmę");
            b = int.Parse(Console.ReadLine());
            for (int i = a; i < b; i++)
                Console.WriteLine("{0} {1}", i, i * i);
            Console.WriteLine("Kiek kartų buvo skaičiuota");
            Console.WriteLine("{0} ", b - a); 
            Console.ReadKey();
        }
    }
}
