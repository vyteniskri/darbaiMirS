using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma_savarankiško_darbo_užduotis
{
    class Program
    {
        static void Main(string[] args)
        {
           
                for (int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
