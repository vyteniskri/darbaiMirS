using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Pirma_savarankisko_darbo_uzduotis
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Turist> allTurists = InOutUtils.ReadTurists(@"Turists.txt");
            InOutUtils.PrintTurists(allTurists);

            Console.WriteLine("Is viso bus surinkta pinigu:");
            Console.WriteLine("{0} cnt.", (int)TaskUtils.AllMoney(allTurists));

            Console.WriteLine("Daugiausiai pinigu skyre: ");
            List<Turist> Names = TaskUtils.MostMoney(allTurists);
            InOutUtils.PrintNamesSurnames(Names);
        }
    }
}
