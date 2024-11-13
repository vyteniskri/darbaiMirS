using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class Cat : Animal
    {
        private const int VaccinationDurationMonths = 6;
        public Cat(int id, string name, string breed, DateTime birthDate, Gender gender): base(id, name, breed, birthDate, gender)
        {

        }

        public override bool RequiresVaccination
        {
            get
            {
                if (this.LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) < 0;
            }
        }

        public override string ToString
        {
            get
            {
                string line = string.Format("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-18} |", ID, Name, Breed, BirthDate, Gender, "");
                return line;
            }
        }


    }
}
