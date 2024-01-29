using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.If.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            int a, b;
            Console.WriteLine("Iveskite bendra spausdinamu simboliu kieki");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite vienos eilutes simboliu kieki");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite spausdinama simboli");
            character = (char)Console.Read();
            for (int i = 1; i < a; i++)
                if (i % b == 0)
                    Console.WriteLine(character);
                else
                    Console.Write(character);
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
