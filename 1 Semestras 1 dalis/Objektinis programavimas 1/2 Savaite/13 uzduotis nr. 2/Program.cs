using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis_nr._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayersRegister registerOfFirstYear = InOutUtils.ReadPlayers(@"FirstYear.txt");
            List<Player> registerOfSecondYear = InOutUtils.ReadPlayer(@"SecondYear.txt");


            registerOfFirstYear.Number(registerOfSecondYear);
            InOutUtils.PrintZalgiris(registerOfFirstYear.PlayedInZalgiris(registerOfSecondYear), registerOfFirstYear.PlayedInZalgiri(registerOfSecondYear));
            Console.WriteLine();

            registerOfFirstYear.Compare(registerOfSecondYear);
            registerOfFirstYear.Highest2(registerOfSecondYear);
            InOutUtils.HighestPlayers(registerOfFirstYear.FilteredByHighest1(registerOfSecondYear), registerOfFirstYear.FilteredByHighest2(registerOfSecondYear));
            Console.WriteLine();

            InOutUtils.HigherThanTwo(registerOfFirstYear.TwoMetersOrHigher1(registerOfSecondYear), registerOfFirstYear.TwoMetersOrHigher2(registerOfSecondYear));

            InOutUtils.ToCsv(registerOfFirstYear.TwoMetersOrHigher1(registerOfSecondYear), registerOfFirstYear.TwoMetersOrHigher2(registerOfSecondYear), "Aukštaūgiai.csv");
        }
    }
}
