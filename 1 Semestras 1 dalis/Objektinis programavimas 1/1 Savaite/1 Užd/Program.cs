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
            Console.WriteLine();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(character);
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
