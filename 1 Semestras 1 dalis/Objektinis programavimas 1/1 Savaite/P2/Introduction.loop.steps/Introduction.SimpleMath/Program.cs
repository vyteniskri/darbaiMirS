﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.SimpleMath
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareRootResult;
            int z;
            Console.WriteLine("Iveskite z reiksme:");
            z = int.Parse(Console.ReadLine());
            if (z - 1 >= 0)
            {
                squareRootResult = Math.Pow(z - 1, 0.5);
                Console.WriteLine(" z = {0} f(x) = {1}", z, squareRootResult);
            }
            else
                Console.WriteLine(" z = {0} f-ja neegzistuoja", z);
            Console.ReadKey();
        }
    }
}
