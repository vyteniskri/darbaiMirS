using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiso_darbo_uzduotis
{
    class Apartment
    {
        public int NrOfApartment { get; set; }
        public double SizeOfApartment { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal Prise { get; set; }
        public int PhoneNr { get; set; }

        public Apartment(int nrOfApartment, double sizeOfApartment, int numberOfRooms, decimal prise, int phoneNr)
        {
            this.NrOfApartment = nrOfApartment;
            this.SizeOfApartment = sizeOfApartment;
            this.NumberOfRooms = numberOfRooms;
            this.Prise = prise;
            this.PhoneNr = phoneNr;    
        }

        public int Hight()
        {
            int hight = new int();
            int allApartments = 27;
            int allApartments1 = 0;
            for (int i = 1; i < 20; i++)
            {

                if (this.NrOfApartment <= allApartments)
                {
                    if ((this.NrOfApartment - allApartments1) % 3 != 0)
                    {
                        hight = (this.NrOfApartment - allApartments1) / 3 + 1;
                        break;
                    }
                    hight = (this.NrOfApartment - allApartments1) / 3 ;
                    break;
                }
                allApartments = allApartments + 27;
                allApartments1 = allApartments1 + 27;

            }
            return hight;

        }
    }
}
