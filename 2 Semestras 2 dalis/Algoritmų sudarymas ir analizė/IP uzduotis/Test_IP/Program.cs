using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP
{

    internal class Location
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

    }

    internal class Program
    {
        const string InputFile = "IP_duomenys.txt";                                                         // C | 1
        public static void Main(string[] args)
        {
            //Stopwatch sw = Stopwatch.StartNew();                                                            // C | 1
            //sw.Start();                                                                                     // C | 1
            List<Location> places = InOutUtils.ReadPlacesFromTextFile(InputFile);                           // f(n) = n + C | 1

            //List<long> visitedIds1 = new List<long>();                                                      // C | 1
            //List<long> visitedIds2 = new List<long>();                                                      // C | 1
            //long firstName = 5844429476;                                                                    // C | 1
            //long secondName = 1013895687;                                                                   // C | 1

            //for (int i = 1; i < places.Count; i*=2)
            //{
            //    int count = i;
            //    List<long> visitedIds1 = new List<long>();                                                      // C | 1
            //    List<long> visitedIds2 = new List<long>();                                                      // C | 1
            //    long firstName = 5844429476;                                                                    // C | 1
            //    long secondName = 1013895687;
            //    long sk = 0;
            //    Stopwatch watch = Stopwatch.StartNew();                                                            // C | 1
            //    watch.Start();
            //    TaskUtils.Solve(places, firstName, secondName, visitedIds1, visitedIds2, count, ref sk);
            //    watch.Stop();
            //    Console.WriteLine($"Trukmė: {watch.Elapsed.TotalSeconds}");
            //    Console.WriteLine($"Veiksmu skaičius: {sk}");

            //}

            for (int i = 1; i < places.Count - 1; i*=2)
            {
                List<long> visitedIds1 = new List<long>();                                                      // C | 1
                List<long> visitedIds2 = new List<long>();                                                      // C | 1
                long firstName = 5844429476;                                                                    // C | 1
                long secondName = 1013895687;
                long sk = 0;
                Stopwatch watch = Stopwatch.StartNew();                                                            // C | 1
                watch.Start();
                TaskUtils.Solve(places, firstName, secondName, visitedIds1, visitedIds2, i, i + 1, ref sk);
                watch.Stop();
                //Console.WriteLine(watch.Elapsed.TotalSeconds);
                Console.WriteLine(sk);

            }

            //TaskUtils.Solve(places, firstName, secondName, visitedIds1, visitedIds2);                       // f(n) = n^3 + n^2 + n + C | 1 

            //InOutUtils.PrintResults(places, visitedIds1, TaskUtils.CalculateCost(places, visitedIds1));     // f(n) = n^2 + n + C && T(n) = n^2 + n + C | 1
            //InOutUtils.PrintResults(places, visitedIds2, TaskUtils.CalculateCost(places, visitedIds2));     // f(n) = n^2 + n + C && T(n) = n^2 + n + C | 1


            //sw.Stop(); Console.WriteLine($"Trukmė: {sw.Elapsed.TotalSeconds}");                             // C | 1

        }
        // T(n) = n^3 + n^2 + n + C = O(n^3)
    }

    internal class TaskUtils
    {
        public static double CalculateCost(List<Location> places, List<long> visitedIds)
        {
            double cost = 0.0;                                                  // C | 1
            for (int i = 0; i < visitedIds.Count - 1; i++)                      // C | n + 1
            {
                long id1 = visitedIds[i];                                       // C | n
                long id2 = visitedIds[i + 1];                                   // C | n
                Location place1 = places.First(p => p.Id == id1);               // C | n*n           
                Location place2 = places.First(p => p.Id == id2);               // C | n*n      
                if (place1 != null && place2 != null)                           // C | n
                {
                    double dx = place2.X - place1.X;                            // C | n
                    double dy = place2.Y - place1.Y;                            // C | n
                    cost += Math.Sqrt(dx * dx + dy * dy);                       // C | n
                }
            }
            return cost;                                                        // C | 1
        }
        // T(n) = n^2 + n + C

        public static void Solve(List<Location> places, long nameOfLocation1, long nameOfLocation2, List<long> visitedIds1, List<long> visitedIds2, int start1, int start2, ref long sk)
        {
            sk++;
            double[,] distances = new double[places.Count, places.Count];                   // C | 1
            sk++;
            for (int i = 0; i < places.Count; i++)                                          // C | n+1
            {
                sk++;
                for (int j = 0; j < places.Count; j++)                                      // C | (n+1)*n
                {
                    sk+=3;
                    double dx = places[j].X - places[i].X;                                  // C | n*n
                    double dy = places[j].Y - places[i].Y;                                  // C | n*n
                    distances[i, j] = Math.Sqrt(dx * dx + dy * dy);                         // C | n*n
                    sk++;
                }
                sk++;
            }
            sk+=2;
            int placeId1 = places.FindIndex(p => p.Id == nameOfLocation1);                  // C | n
            visitedIds1.Add(places[start1].Id);                                           // C | 1
            sk+=2;
            int placeId2 = places.FindIndex(p => p.Id == nameOfLocation2);                  // C | n
            visitedIds2.Add(places[start2].Id);                                           // C | 1
            sk++;
            while (visitedIds1.Count + visitedIds2.Count < places.Count)                    // C | n + 1
            {
                sk+=2;
                long nextId1 = NextId(visitedIds1, visitedIds2, places, distances, ref sk);         // f(n) = n^2 + n + C | n
                if (nextId1 != -1)                                                          // C | n
                {
                    sk++;
                    visitedIds1.Add(nextId1);                                               // C | n
                }
                sk += 2;
                long nextId2 = NextId(visitedIds2, visitedIds1, places, distances, ref sk);         // f(n) = n^2 + n + C | n
                if (nextId2 != -1)                                                          // C | n
                {
                    sk++;
                    visitedIds2.Add(nextId2);                                               // C | n
                }
                sk++;
            }
            sk+=2;
            visitedIds1.Add(places[start1].Id);                                           // C | 1
            visitedIds2.Add(places[start2].Id);                                           // C | 1
        }
        // T(n) = n^3 + n^2 + n + C


        private static long NextId(List<long> visitedIds, List<long> otherVisitedIds, List<Location> places, double[,] distances, ref long sk)
        {
            sk += 4;
            long nextId = -1;                                                               // C | 1
            double minCost = double.MaxValue;                                               // C | 1
            long lastId = visitedIds.Last();                                                // C | 1
            int lastIdx = places.FindIndex(p => p.Id == lastId);                            // C | n
            sk++;
            for (int i = 0; i < places.Count; i++)                                          // C | n + 1 
            {
                sk+=3;
                if (visitedIds.Contains(places[i].Id) || otherVisitedIds.Contains(places[i].Id))    // C | n * n
                {
                    sk++;
                    continue;                                                               // C | n
                }
                double cost = distances[lastIdx, i];                                        // C | n
                if (cost < minCost)                                                         // C | n
                {
                    sk++;
                    nextId = places[i].Id;                                                  // C | n
                    sk++;
                    minCost = cost;                                                         // C | n
                }
                sk++;
            }
            sk++;
            return nextId;                                                                  // C | 1
        }
    }
    // T(n) = n^2 + n + C

    internal class InOutUtils
    {
        public static List<Location> ReadPlacesFromTextFile(string fileName)
        {
            List<Location> places = new List<Location>();                   // C | 1
            using (StreamReader reader = new StreamReader(fileName))        // C | 1
            {
                reader.ReadLine();                                          // C | 1
                string line;                                                // C | 1
                while ((line = reader.ReadLine()) != null)                  // C | n
                {
                    string[] values = line.Split('\t');                     // C | n
                    string name = values[0];                                // C | n
                    long id = long.Parse(values[1]);                        // C | n
                    double x = double.Parse(values[2]);                     // C | n
                    double y = double.Parse(values[3]);                     // C | n
                    places.Add(new Location { Name = name, Id = id, X = x, Y = y });    // C | n
                }
            }
            return places;                                                  // C | 1
        }
        // T(n) = n + C


        public static void PrintResults(List<Location> places, List<long> visitedIds, double totalCost)
        {
            Console.WriteLine($"Aplankytu vietu skaicius: {visitedIds.Count}, Pilna kaina: {totalCost}");   // C | 1
            foreach (long id in visitedIds)                                                                 // C | n
            {
                Location place = places.First(p => p.Id == id);                                             // C | n*n
                if (place != null)                                                                          // C | n
                {
                    Console.WriteLine($"{id}: {place.Name}");                                               // C | n
                }
                else                                                                                        // C | n
                {
                    Console.WriteLine($"Negalima surasti vietos pagal identifikatoriu {id}");               // C | n
                }
            }
            Console.WriteLine();                                                                            // C | 1
        }
        // T(n) = n^2 + n + C

    }

}