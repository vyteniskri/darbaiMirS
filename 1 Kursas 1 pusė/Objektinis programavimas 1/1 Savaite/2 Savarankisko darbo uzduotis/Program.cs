using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankisko_darbo_uzduotis
{
    class Program
    {
        static void Main(string[] args)
        {
            double rezults;
            double x;
            Console.WriteLine("Iveskite x reiksme");
            x = double.Parse(Console.ReadLine());
            if (-2 <= x && x <= 0)
                rezults = Math.Exp(-x);
            else
                if (0 < x && x < 2)
                rezults = 2 * (x * x) + 1;
            else
                rezults = 1 / (x * x);
            Console.WriteLine("x = {0}, rezults = {1}", x, rezults);
            Console.ReadKey();

        }
    }
}
