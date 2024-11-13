using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP
{
    internal class Program
    {
        const string InputFile = "IP_duomenys.txt";
        public static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            List<Location> places = InOutUtils.ReadPlacesFromTextFile(InputFile);

            List<long> visitedIds1 = new List<long>();
            List<long> visitedIds2 = new List<long>();
            long firstName = 4314994364;
            long secondName = 3713676194;
            
            TaskUtils.Solve(places, firstName, secondName, visitedIds1, visitedIds2);

            Console.Write($"Pradžios vietovė: {places[places.FindIndex(p => p.Id == firstName)].Name}, ");
            InOutUtils.PrintResults(places, visitedIds1, TaskUtils.CalculateCost(places, visitedIds1));

            Console.Write($"Pradžios vietovė: {places[places.FindIndex(p => p.Id == secondName)].Name}, ");
            InOutUtils.PrintResults(places, visitedIds2, TaskUtils.CalculateCost(places, visitedIds2));

           
            sw.Stop(); Console.WriteLine($"Trukmė: {sw.Elapsed.TotalSeconds}");

        }
    }

}
