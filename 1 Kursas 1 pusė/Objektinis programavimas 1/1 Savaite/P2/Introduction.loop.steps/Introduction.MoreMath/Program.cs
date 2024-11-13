﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.MoreMath
{
    class Program
    {
        static void Main(string[] args)
        {
            double functionResult;
            int a;
            double x;
            Console.WriteLine("Įveskite a reikšmę:");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite x reikšmę:");
            x = double.Parse(Console.ReadLine());
            if (x <= 0)
                functionResult = a * Math.Exp(-x);
            else
                if (x < 1)
                functionResult = 5 * a * x - 7;
            else
                functionResult = Math.Pow(x + 1, 0.5);
            Console.WriteLine("Reiksme a = {0}, reiksme x = {1}, fx = {2}", a, x, functionResult);
            Console.ReadKey();
        }
    }
}
