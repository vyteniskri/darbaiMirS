using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
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
        public static Worker RichestWorker(LinkListWorkers workers, LinkListParts parts)
        {
            LinkListWorkers workersAndTheirMoney = WorkersAndTheirMoney(workers, parts);
            Worker worker = new Worker();
            decimal money = 0;

            for (workersAndTheirMoney.Begin(); workersAndTheirMoney.Exist(); workersAndTheirMoney.Next())
            {
                if (workersAndTheirMoney.Get().MoneyCount > money)
                {
                    money = workersAndTheirMoney.Get().MoneyCount;
                    worker = workersAndTheirMoney.Get();
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
        private static LinkListWorkers WorkersAndTheirMoney(LinkListWorkers workers, LinkListParts parts)
        {
            LinkListWorkers listOfWorkers = new LinkListWorkers();
            LinkListWorkers surnamesOfWorkers = SurnamesOfWorkers(workers);

            for (surnamesOfWorkers.Begin(); surnamesOfWorkers.Exist(); surnamesOfWorkers.Next())
            {

                Worker worker = WorkersSalary(surnamesOfWorkers.Get().Surname, workers, parts);

                listOfWorkers.Add(worker);


            }
            return listOfWorkers;
        }

        /// <summary>
        /// Method that formats a list of workers who can repeat only once
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <returns>A list</returns>
        private static LinkListWorkers SurnamesOfWorkers(LinkListWorkers workers)
        {
            LinkListWorkers surnames = new LinkListWorkers();

            for (workers.Begin(); workers.Exist(); workers.Next())
            {
                if (!surnames.Contains(workers.Get().Surname))
                {
                    surnames.Add(workers.Get());
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
        private static Worker WorkersSalary(string surname, LinkListWorkers workers, LinkListParts parts)
        {
            int DaysWorked = 0;
            int PartsCount = 0;
            decimal MoneyCount = 0;

            LinkListWorkers date = new LinkListWorkers();

            for (workers.Begin(); workers.Exist(); workers.Next())
            {
                if (workers.Get().Surname == surname)
                {
                    decimal money = 0;
                    PartsCount = PartsCount + workers.Get().VntCount;

                    for (parts.Begin(); parts.Exist(); parts.Next())
                    {
                        if (workers.Get().Code == parts.Get().Code)
                        {
                            money = workers.Get().VntCount * parts.Get().Price;
                        }
                    }

                    MoneyCount = MoneyCount + money;

                    if (!date.Contains(workers.Get().Date))
                    {
                        date.Add(workers.Get());
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
        public static LinkListWorkers SinglePartMakers(LinkListWorkers workers, LinkListParts parts)
        {
            LinkListWorkers singlePartsWorkers = new LinkListWorkers();
            LinkListWorkers surnamesOfWorkers = SurnamesOfWorkers(workers);

            for (surnamesOfWorkers.Begin(); surnamesOfWorkers.Exist(); surnamesOfWorkers.Next())
            {
                Worker worker = SinglePartMaker(surnamesOfWorkers.Get().Surname, workers, parts);

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
        private static Worker SinglePartMaker(string surname, LinkListWorkers workers, LinkListParts parts)
        {
            LinkListWorkers onePartMaker = new LinkListWorkers();
            Worker worker = new Worker();
            int totalNumberOfParts = 0;
            decimal moneyCount = 0;
            int howManyParts = 0;


            for (workers.Begin(); workers.Exist(); workers.Next())
            {
                if (workers.Get().Surname == surname && !onePartMaker.Contains(workers.Get().Code))
                {
                    onePartMaker.Add(workers.Get());
                    howManyParts++;
                }

                if (workers.Get().Surname == surname)
                {
                    decimal money = 0;

                    totalNumberOfParts = totalNumberOfParts + workers.Get().VntCount;

                    for (parts.Begin(); parts.Exist(); parts.Next())
                    {
                        if (workers.Get().Code == parts.Get().Code)
                        {
                            money = workers.Get().VntCount * parts.Get().Price;

                        }
                    }

                    moneyCount = moneyCount + money;

                    worker = new Worker(DateTime.MinValue, workers.Get().Surname, workers.Get().Name, workers.Get().Code, 0, 0, totalNumberOfParts, moneyCount);
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
        public static LinkListWorkers ListByAttributes(int S, decimal K, LinkListWorkers workers, LinkListParts parts)
        {
            LinkListWorkers listOfWorkers = new LinkListWorkers();

            for (workers.Begin(); workers.Exist(); workers.Next())
            {
                if (workers.Get().VntCount > S)
                {
                    for (parts.Begin(); parts.Exist(); parts.Next())
                    {
                        if (workers.Get().Code == parts.Get().Code && parts.Get().Price < K)
                        {
                            listOfWorkers.Add(workers.Get());
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