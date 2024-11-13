using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiso_darbo_uzduotis
{
    class Program
    {
        static void Main(string[] args)
        {
            ApartmentsRegister register = InOutUtils.ReadApartments(@"Apartments.txt");
            InOutUtils.PrintApartments(register);

            Console.WriteLine("Įveskite kambarių skaičių:");
            int numberOfRooms = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite aukštus nuo, iki:");
            int apartmentHightFrom = int.Parse(Console.ReadLine());
            int apartmentHightTo = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kainą:");
            decimal prise = decimal.Parse(Console.ReadLine());
            ApartmentsRegister right = register.RightApartments(numberOfRooms, apartmentHightFrom, apartmentHightTo, prise);

            Console.WriteLine("Tinkami kambariai:");
            InOutUtils.PrintApartments(right);
            Console.ReadKey();
        }
    }
}
