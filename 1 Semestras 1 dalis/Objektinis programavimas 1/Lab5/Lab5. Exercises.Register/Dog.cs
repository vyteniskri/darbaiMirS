using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    public class Dog : Animal
    {
       
        private const int VaccinationDuration = 1;
        public bool Aggresive { get; set; }

        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender, bool aggresive) : base(id, name, breed, birthDate, gender)
        {
            this.Aggresive = aggresive;
        }


        public override bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) < 0;
            }

        }

        public override string ToString
        {
            get
            {
                string line = string.Format("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-18} |", ID, Name, Breed, BirthDate, Gender, Aggresive);
                return line;
            }
        }
    }
}
