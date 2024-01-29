using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByBirthDateAndID : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            if (a.BirthDate != b.BirthDate)
            {
                return a.BirthDate.CompareTo(b.BirthDate);
            }
            else
                return a.ID.CompareTo(b.ID);
        }
    }
}
