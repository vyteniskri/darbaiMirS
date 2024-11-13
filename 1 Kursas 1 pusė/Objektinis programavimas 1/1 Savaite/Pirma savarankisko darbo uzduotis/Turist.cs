using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma_savarankisko_darbo_uzduotis
{
    class Turist
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Money { get; set; }

        public Turist(string name, string surname, decimal money)
        {
            this.Name = name;
            this.Surname = surname;
            this.Money = money;

        }

        public decimal DevidedByFour()
        {
            decimal MoneyDevided = this.Money / 4;
            return MoneyDevided;
        }


    }
}
