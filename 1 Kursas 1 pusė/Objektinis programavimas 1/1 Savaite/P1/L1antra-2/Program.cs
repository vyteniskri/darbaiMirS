using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//----------------
// Program calculates the volume V of cone, when radiuses of bases
// R, r and height H are entered using keyboard
namespace L1antra_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = 3.1415; // mathematical costant
            double H; // height of cone
            double R, r; // radiuse of bases of cone
            double V; // Volume of cone
            Console.WriteLine("Įveskite kūgio aukštinės reikšmę");
            H = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kūgio viršutinio pagrindo spindulio reikšmę");
            r = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kūgio apatinio pagrindo spindulio reikšmę");
            R = double.Parse(Console.ReadLine());
            V = (1.0 / 3) * pi * H * (R * R + R * r + r * r);
            Console.WriteLine("Kūgio tūris = {0, 5:f}", V);
        }
    }
}
