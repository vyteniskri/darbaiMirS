﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsComparator
    {
        public virtual int Compare(Animal a, Animal b)
        {
            return a.CompareTo(b);
        }
    }
}
