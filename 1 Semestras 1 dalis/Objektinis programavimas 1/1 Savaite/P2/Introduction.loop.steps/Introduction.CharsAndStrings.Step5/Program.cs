﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step5
{
    class Program
    {
        static void Main(string[] args)
        {
            string day;
            Console.WriteLine("Kokia šiandien savaitės diena?");
            day = Console.ReadLine().ToLower();
            switch (day)
            {
                case "pirmadienis":
                    Console.WriteLine("Pirmadienis - sudėtingiausia savaitės diena.");
                    break;
                case "antradienis":
                    Console.WriteLine("Antradienis – aktyvių veiksmų, Marso diena.");
                    break;
                case "trečiadienis":
                    Console.WriteLine("Trečiadienis – sandoriams sudaryti tinkamiausia diena.");
                    break;
                case "ketvirtadienis":
                    Console.WriteLine("Ketvirtadienį reikėtų imtis visuomeniniu darbų.");
                    break;
                case "penktadienis":
                    Console.WriteLine("Penktadienį lengvai gimsta šedevrai, susitinka mylimieji.");
                    break;
                case "šeštadienis":
                    Console.WriteLine("Šeštadienis - savo problemų sprendimo diena.");
                    break;
                case "sekmadienis":
                    Console.WriteLine("Sekmadienį reikėtų pradėti naujus darbus, kurti planus.");
                    break;
                default:
                    Console.WriteLine("Tokios savaites dienos pas mus nebuna.");
                    break;
            }
            Console.ReadKey();
        }
    }
}
