using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _4_Savarankiso_darbo_uzduotis
{
    class InOutUtils
    {
        public static ApartmentsRegister ReadApartments(string fileName)
        {
            ApartmentsRegister Apartments = new ApartmentsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int nrOfApartment = int.Parse(Values[0]);
                double sizeOfApartment = double.Parse(Values[1]);
                int numberOfRooms = int.Parse(Values[2]);
                decimal prise = decimal.Parse(Values[3]);
                int phoneNr = int.Parse(Values[4]);

                Apartment apartment = new Apartment(nrOfApartment, sizeOfApartment, numberOfRooms, prise, phoneNr);

                Apartments.Add(apartment);
            }
            return Apartments;
        }
        
        public static void PrintApartments(ApartmentsRegister apartments)
        {
            int x = 0;
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("| {0, 8} | {1, 8} | {2, 8} | {3, 8} | {4, 8} |", "Buto numeris", "Bendras plotas", "Kambarių skaičius", "Pardavimo kaina", "Telefono numeris");
            Console.WriteLine(new string('-', 90));
            for (int i = 0; i < apartments.Count(); i++)
            {
                Apartment apartment = apartments.OneApartment(i);
                Console.WriteLine("| {0, 12} | {1, 14} | {2, 17} | {3, 15} | {4, 16} |", apartment.NrOfApartment, apartment.SizeOfApartment, apartment.NumberOfRooms, apartment.Prise, apartment.PhoneNr);
                x++;
            }
           
            if (x == 0)
            {
                Console.WriteLine("Tokių butų nėra.");
            }
            Console.WriteLine(new string('-', 90));
        }

    }
}
