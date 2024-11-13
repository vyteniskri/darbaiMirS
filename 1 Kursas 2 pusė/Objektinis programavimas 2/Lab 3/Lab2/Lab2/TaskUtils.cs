using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Class where calculations are being made
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Method that finds the richest worker
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <param name="parts">List of parts</param>
        /// <returns>One worker</returns>
        public static Worker RichestWorker(LinkList<Worker> workers, LinkList<Part> parts)
        {
            LinkList<Worker> workersAndTheirMoney = WorkersAndTheirMoney(workers, parts);
            Worker worker = new Worker();
            decimal money = 0;

            foreach (Worker w in workersAndTheirMoney)
            {
                if (w.MoneyCount > money)
                {
                    money = w.MoneyCount;
                    worker = w;
                }
            }

            return worker;
        }

        /// <summary>
        /// Method that formats a list of workers and their salaries
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <param name="parts">List of parts</param>
        /// <returns>A list</returns>
        private static LinkList<Worker> WorkersAndTheirMoney(LinkList<Worker> workers, LinkList<Part> parts)
        {
            LinkList<Worker> listOfWorkers = new LinkList<Worker>();
            LinkList<Worker> surnamesOfWorkers = SurnamesOfWorkers(workers);

            foreach (Worker w in surnamesOfWorkers)
            {
                Worker worker = WorkersSalary(w.Surname, workers, parts);

                listOfWorkers.Add(worker);
            }
 
            return listOfWorkers;
        }

        /// <summary>
        /// Method that formats a list of workers who can repeat only once
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <returns>A list</returns>
        private static LinkList<Worker> SurnamesOfWorkers(LinkList<Worker> workers)
        {
            LinkList<Worker> surnames = new LinkList<Worker>();

            foreach (Worker w in workers)
            {
                if (!surnames.Contains(w.Surname))
                {
                    surnames.Add(w);
                }
            }

            return surnames;
        }

        /// <summary>
        /// Method that count's worker's salary
        /// </summary>
        /// <param name="surname">Worker's surname</param>
        /// <param name="workers">List of workers</param>
        /// <param name="parts">List of parts</param>
        /// <returns>One worker</returns>
        private static Worker WorkersSalary(string surname, LinkList<Worker> workers, LinkList<Part> parts)
        {
            int DaysWorked = 0;
            int PartsCount = 0;
            decimal MoneyCount = 0;

            LinkList<Worker> date = new LinkList<Worker>();

            foreach (Worker w in workers)
            {
                if (w.Surname == surname)
                {
                    decimal money = 0;
                    PartsCount = PartsCount + w.VntCount;

                    foreach (Part p in parts)
                    {
                        if (w.Code == p.Code)
                        {
                            money = w.VntCount * p.Price;
                        }
                    }

                    MoneyCount = MoneyCount + money;

                    if (!date.Contains(w.Date))
                    {
                        date.Add(w);
                        DaysWorked++;
                    }

                }
            }

            Worker worker = new Worker(DateTime.MinValue, surname, null, null, 0, DaysWorked, PartsCount, MoneyCount);
            return worker;
        }

        /// <summary>
        /// Method that formats a list of workers who make only one type of parts
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <param name="parts">List of parts</param>
        /// <returns>Formated list</returns>
        public static LinkList<Worker> SinglePartMakers(LinkList<Worker> workers, LinkList<Part> parts)
        {
            LinkList<Worker> singlePartsWorkers = new LinkList<Worker>();
            LinkList<Worker> surnamesOfWorkers = SurnamesOfWorkers(workers);

            foreach (Worker w in surnamesOfWorkers)
            {
                Worker worker = SinglePartMaker(w.Surname, workers, parts);

                if (worker != null)
                {
                    singlePartsWorkers.Add(worker);
                }
            }

            return singlePartsWorkers;
        }

        /// <summary>
        /// Method that finds workers who make only one type of parts
        /// </summary>
        /// <param name="surname">Worker's surname</param>
        /// <param name="workers">List of workers</param>
        /// <param name="parts">List of parts</param>
        /// <returns>A worker</returns>
        private static Worker SinglePartMaker(string surname, LinkList<Worker> workers, LinkList<Part> parts)
        {
            LinkList<Worker> onePartMaker = new LinkList<Worker>();
            Worker worker = new Worker();
            int totalNumberOfParts = 0;
            decimal moneyCount = 0;
            int howManyParts = 0;

            foreach (Worker w in workers)
            {
                if (w.Surname == surname && !onePartMaker.Contains(w.Code))
                {
                    onePartMaker.Add(w);
                    howManyParts++;
                }

                if (w.Surname == surname)
                {
                    decimal money = 0;

                    totalNumberOfParts = totalNumberOfParts + w.VntCount;

                    foreach (Part p in parts)
                    {
                        if (w.Code == p.Code)
                        {
                            money = w.VntCount * p.Price;

                        }
                    }

                    moneyCount = moneyCount + money;

                    worker = new Worker(DateTime.MinValue, w.Surname, w.Name, w.Code, 0, 0, totalNumberOfParts, moneyCount);
                }
            }

            if (howManyParts == 1)
            {
                return worker;
            }

            return null;
        }

        /// <summary>
        /// Method that formats a list of workers defined by attributes
        /// </summary>
        /// <param name="S">Number of parts</param>
        /// <param name="K">Value of price</param>
        /// <param name="workers">List of workers</param>
        /// <param name="parts">List of parts</param>
        /// <returns>A list</returns>
        public static LinkList<Worker> ListByAttributes(int S, decimal K, LinkList<Worker> workers, LinkList<Part> parts)
        {
            LinkList<Worker> listOfWorkers = new LinkList<Worker>();

            foreach (Worker w in workers)
            {

                if (w.VntCount > S)
                {
                    foreach (Part p in parts)
                    {
                        if (w.Code == p.Code && p.Price < K)
                        {
                            listOfWorkers.Add(w);
                        }
                    }
                    
                }
            }

            return listOfWorkers;
        }

        /// <summary>
        /// Method that finds out if a string type variable has a specific symbol and returns true or false
        /// </summary>
        /// <param name="text">String type variable</param>
        /// <returns>If it is true or false</returns>
        public static bool ContainsLetter(string text)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghjklmnopqrstuvwxyząčęėįšųūžĄČĘĖĮŠŲŪŽ";
            foreach (char a in alphabet)
            {
                if (text.Contains(a))
                {
                    return true;
                }
            }
            return false;
        }
    }

}