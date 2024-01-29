using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Savarankisko_darbo_uzduotis
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            double rezults;
            char character;
            Console.WriteLine("Iveskite du skaicius:");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite operacijos simboli:");
            character = char.Parse(Console.ReadLine());
            if (character == '+')
            {
                rezults = a + b;
                Console.WriteLine("a = {0}, b = {1}, rezults = {2}", a, b, rezults);
            }
            else
                if (character == '-')
            {
                rezults = a - b;
                Console.WriteLine("a = {0}, b = {1}, rezults = {2}", a, b, rezults);
            }
            else
                if (character == '*')
            {
                rezults = a * b;
                Console.WriteLine("a = {0}, b = {1}, rezults = {2}", a, b, rezults);
            }  
            else
                if (character == '/')
            {
                rezults = a / b;
                Console.WriteLine("a = {0}, b = {1}, rezults = {2}", a, b, rezults);
            }     
            else
                Console.WriteLine("a = {0}, b = {1}, Klaidinga operacija", a, b);
            Console.ReadKey();
        }
    }
}
