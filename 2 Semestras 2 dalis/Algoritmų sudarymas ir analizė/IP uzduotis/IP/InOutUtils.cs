using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP
{
    internal class InOutUtils
    {
        public static List<Location> ReadPlacesFromTextFile(string fileName)
        {
            List<Location> places = new List<Location>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    string[] values = line.Split('\t'); 
                    string name = values[0]; 
                    long id = long.Parse(values[1]);
                    double x = double.Parse(values[2]);
                    double y = double.Parse(values[3]);
                    places.Add(new Location { Name = name, Id = id, X = x, Y = y });
                }
            }
            return places;
        }

        public static void PrintResults(List<Location> places, List<long> visitedIds, double totalCost)
        {
            Console.WriteLine($"Aplankytu vietu skaicius: {visitedIds.Count}, Pilna kaina: {totalCost}");
            foreach (long id in visitedIds)
            {
                Location place = places.First(p => p.Id == id);
                if (place != null)
                {
                    Console.WriteLine($"{id}: {place.Name}");
                }
                else
                {
                    Console.WriteLine($"Negalima surasti vietos pagal identifikatoriu {id}");
                }
            }
            Console.WriteLine();
        }
    }
}
