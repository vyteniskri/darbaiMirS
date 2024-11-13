using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiso_darbo_uzduotis
{
    class ApartmentsRegister
    {
        private List<Apartment> AllApartments;

        public ApartmentsRegister()
        {
            AllApartments = new List<Apartment>();
        }

        public ApartmentsRegister(List<Apartment> apartments)
        {
            AllApartments = new List<Apartment>();
            foreach (Apartment apartment in apartments)
            {
                this.AllApartments.Add(apartment);
            }
        }

        public void Add(Apartment apartment)
        {
            AllApartments.Add(apartment);
        }

        public int Count()
        {
            return this.AllApartments.Count;
        }

        public Apartment OneApartment(int index)
        {
            return AllApartments[index];
        }

        public ApartmentsRegister RightApartments(int numberOfRooms, int apartmentHightFrom, int apartmentHightTo, decimal prise)
        {
            ApartmentsRegister Filtered = new ApartmentsRegister();
            for (int i = 0; i < AllApartments.Count(); i++)
            {
                if (AllApartments[i].NumberOfRooms == numberOfRooms && AllApartments[i].Prise <= prise && AllApartments[i].Hight() >= apartmentHightFrom && AllApartments[i].Hight() <= apartmentHightTo)
                {
                   
                    Filtered.Add(AllApartments[i]);

                } 
            }
            return Filtered;
        }

       
    }
}
