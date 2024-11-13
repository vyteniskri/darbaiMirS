using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.If.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            Console.WriteLine("Iveskite spausdinama simboli");
            character = (char)Console.Read();
            for (int i = 1; i < 51; i++)
                if (i % 5 == 0)
                    Console.WriteLine(character);
                else
                    Console.Write(character);
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
