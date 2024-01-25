using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IP
{
    internal class TaskUtils
    {
		public static double CalculateCost(List<Location> places, List<long> visitedIds)
        {
            double cost = 0.0; 
            for (int i = 0; i < visitedIds.Count - 1; i++) 
            {
                long id1 = visitedIds[i];
                long id2 = visitedIds[i + 1]; 
                Location place1 = places.First(p => p.Id == id1);
                Location place2 = places.First(p => p.Id == id2);
                if (place1 != null && place2 != null)
                {
                    double dx = place2.X - place1.X;
                    double dy = place2.Y - place1.Y;
                    cost += Math.Sqrt(dx * dx + dy * dy); 
                }
            }
            return cost;
        }

        public static void Solve(List<Location> places, long nameOfLocation1, long nameOfLocation2, List<long> visitedIds1, List<long> visitedIds2)
        {
            double[,] distances = new double[places.Count, places.Count];
            for (int i = 0; i < places.Count; i++)
            {
                for (int j = 0; j < places.Count; j++)
                {
                    double dx = places[j].X - places[i].X;
                    double dy = places[j].Y - places[i].Y;
                    distances[i, j] = Math.Sqrt(dx * dx + dy * dy);
                }
            }

            int placeId1 = places.FindIndex(p => p.Id == nameOfLocation1);
            visitedIds1.Add(places[placeId1].Id);

            int placeId2 = places.FindIndex(p => p.Id == nameOfLocation2);
            visitedIds2.Add(places[placeId2].Id);

            while (visitedIds1.Count + visitedIds2.Count < places.Count) 
            {
               
                long nextId1 = NextId(visitedIds1, visitedIds2, places, distances);
                if (nextId1 != -1)
                {
                    visitedIds1.Add(nextId1);
                }
                
                long nextId2 = NextId(visitedIds2, visitedIds1, places, distances);
                if (nextId2 != -1)
                {
                    visitedIds2.Add(nextId2);
                }

            }
            visitedIds1.Add(places[placeId1].Id);
            visitedIds2.Add(places[placeId2].Id);
        }

        private static long NextId(List<long> visitedIds, List<long> otherVisitedIds, List<Location> places, double[,] distances)
        {
            long nextId = -1;
            double minCost = double.MaxValue;
            long lastId = visitedIds.Last();
            int lastIdx = places.FindIndex(p => p.Id == lastId);

            for (int i = 0; i < places.Count; i++)
            {
                if (visitedIds.Contains(places[i].Id) || otherVisitedIds.Contains(places[i].Id))
                {
                    continue;
                }
                double cost = distances[lastIdx, i];
                if (cost < minCost)
                {
                    nextId = places[i].Id;
                    minCost = cost;
                }

            }

            return nextId;
        }
    }
}
