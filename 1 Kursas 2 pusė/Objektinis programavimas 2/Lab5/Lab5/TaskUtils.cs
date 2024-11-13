using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lab5
{
    /// <summary>
    /// Class that does calculations
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Method that forms a list of subscribers filtered by month
        /// </summary>
        /// <param name="subscribers">List of subscribers</param>
        /// <param name="month">Certain month</param>
        /// <returns>Formated list</returns>
        public static List<Subscriber> FilteredByMonth(List<Subscriber> subscribers, int month)
        {
            List<Subscriber> selectedSubscribers = new List<Subscriber>();

            subscribers.ForEach(subscriber =>
            {
                {
                    int subscribtionPeriod = subscriber.StartingMonth + subscriber.SubcribeLenght;
                    int startAgain = 1000;

                    for (int i = subscriber.StartingMonth; i <= subscribtionPeriod; i++)
                    {
                        if (i > 12)
                        {
                            startAgain = i - 12;
                        }

                        if (i == month || startAgain == month)
                        {
                            selectedSubscribers.Add(subscriber);
                        }
                    }
                }
            });

            return selectedSubscribers;
        }

        /// <summary>
        /// Method that counts income of publications
        /// </summary>
        /// <param name="subscribers">List of subscribers</param>
        /// <param name="publications">List of publications</param>
        public static void CountPublicationIncome(List<Subscriber> subscribers, List<Publication> publications)
        {
            subscribers.ForEach(subscriber =>
            {
                publications.ForEach(publication =>
                {
                    if (subscriber.Code == publication.Code)
                    {
                        publication.Income = publication.Income + subscriber.Count * publication.OneMonthPrice;
                    }
                });

            });

        }

        /// <summary>
        /// Method that forms a dictionary of publishers and their income
        /// </summary>
        /// <param name="publications">List of publications</param>
        /// <returns>Formated dictionary</returns>
        public static Dictionary<string, decimal> CountPublichersIncome(List<Publication> publications)
        {
            Dictionary<string, decimal> totalIncome = new Dictionary<string, decimal>();

            List<string> list = new List<string>();
            publications.ForEach(publication =>
            { 
                if (!list.Contains(publication.PublichersName) && publication.Income != 0)
                {
                    decimal sum = publications.Where(x => x.PublichersName == publication.PublichersName).Sum(p => p.Income);

                    list.Add(publication.PublichersName);
                    totalIncome.Add(publication.PublichersName, sum);
                   
                }
            });

            return totalIncome;
        }

        /// <summary>
        /// Method that forms a sorted dictionary of certain keys and values
        /// </summary>
        /// <param name="publishersInfo">Dictionary of publishers and their income</param>
        /// <returns>Formated dictionary</returns>
        public static Dictionary<string, decimal> SortedDictionary(Dictionary<string, decimal> publishersInfo)
        {
            publishersInfo = publishersInfo.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            return publishersInfo;
        }

        /// <summary>
        /// Method that forms a list of certain publishers
        /// </summary>
        /// <param name="publications">List of publications</param>
        /// <param name="publicher">Publisher's name</param>
        /// <returns>Formated list</returns>
        public static List<Publication> AllSpecificPublications(List<Publication> publications, string publicher)
        {
            publications = publications.Where(x => x.PublichersName == publicher).ToList();
            return publications;
        }
    }
}