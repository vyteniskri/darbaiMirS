using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5
{
    /// <summary>
    /// Class that reads and prints information
    /// </summary>
    public static class InOut
    {
        /// <summary>
        /// Method that reads information about subscribers from .txt file and forms a list
        /// </summary>
        /// <param name="directoryName">Name of a data file</param>
        /// <returns>Formated list</returns>
        public static List<Subscriber> ReadSubscribers(string directoryName)
        {
            List<Subscriber> AllSubscribers = new List<Subscriber>();

            foreach (string fileName in Directory.GetFiles(directoryName, "*.txt"))
            {
                try
                {
                    string[] Lines = File.ReadAllLines(fileName);
                    DateTime Date = DateTime.Parse(Lines[0]);
                    for (int i = 1; i < Lines.Length; i++)
                    {

                        string[] Values = Lines[i].Split(';');
                        string surname = Values[0];
                        string address = Values[1];
                        int startingMonth = int.Parse(Values[2]);
                        int subcribeLenght = int.Parse(Values[3]);
                        string code = Values[4];
                        int count = int.Parse(Values[5]);

                        Subscriber subcriber = new Subscriber(Date, surname, address, startingMonth, subcribeLenght, code, count);
                        AllSubscribers.Add(subcriber);

                    }
                }
                catch(Exception )
                {
                    
                }
                
            }
            return AllSubscribers;
        }

        /// <summary>
        /// Method that reads information about publications from .txt file and forms a list
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <returns>Formated list</returns>
        public static List<Publication> ReadPublications(string fileName)
        {
            List<Publication> AllPublications = new List<Publication>();

            string[] Lines = File.ReadAllLines(fileName);

            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string code = Values[0];
                string publicationName = Values[1];
                string publichersName = Values[2];
                decimal oneMonthPrice = decimal.Parse(Values[3]);

                Publication publication = new Publication(code, publicationName, publichersName, oneMonthPrice, 0);
                AllPublications.Add(publication);
            }
            return AllPublications;
        }

        /// <summary>
        /// Method that prints information about publications to .txt file
        /// </summary>
        /// <param name="fileName">Name of a rezults file</param>
        /// <param name="publications">List of publications</param>
        public static void PrintDataToTxt(string fileName, List<Publication> publications)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(new string('-', 93));
                writer.WriteLine(string.Format("| {0, -20} | {1, -20} | {2, -20} | {3, 20} |", "Kodas", "Pavadinimas", "Leidėjo pavadinimas", "Vieno mėnesio kaina"));
                writer.WriteLine(new string('-', 93));
                foreach (Publication publication in publications)
                {
                    writer.WriteLine(publication.ToString());
                }
                writer.WriteLine(new string('-', 93));
                writer.WriteLine();
                writer.Close();
            }
        }

        /// <summary>
        /// Method that prints information about subscribers to .txt file
        /// </summary>
        /// <param name="fileName">Name of a rezults file</param>
        /// <param name="subscribers">Subscribers list</param>
        public static void PrintDataToTxt(string fileName, List<Subscriber> subscribers)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(new string('-', 162));
                writer.WriteLine(string.Format("| {0, -20} | {1, -20} | {2, -20} | {3, 20} | {4, 20} | {5, -20} | {6, 20} |", "Įvedimo data", "Pavardė", "Adresas", "Laikotarpio pradžia", "Laikotarpio ilgis", "Leidinio kodas", "Leidinių kiekis"));
                writer.WriteLine(new string('-', 162));
                foreach (Subscriber subscriber in subscribers)
                {
                    writer.WriteLine(subscriber.ToString());
                }
                writer.WriteLine(new string('-', 162));
                writer.WriteLine();
                writer.Close();
            }
        }

        /// <summary>
        /// Method that prints rezults to .txt file
        /// </summary>
        /// <param name="fileName">Name of a rezults file</param>
        /// <param name="publichersInfo">Formated dictionary of publishers and their income</param>
        /// <param name="publications">List of publications</param>
        public static void PrintRezults(string fileName, Dictionary<string, decimal> publichersInfo, List<Publication> publications)
        {
            using (var writer = File.CreateText(fileName))
            {
                writer.WriteLine(string.Format("| {0, 25} | {1, -25} | {2, -25} | {3, 25} |" + "---->", "Leidėjo pajamos", "Leidėjo pavadinimas", "Leidėjo leidiniai", "Leidinių atneštos pajamos"));
                foreach (var publisher in publichersInfo)
                {
                    writer.Write(string.Format("| {0, 25} | {1, -25} |", publisher.Value, publisher.Key));
                    List<Publication> selectedPublications = TaskUtils.AllSpecificPublications(publications, publisher.Key);

                    foreach (Publication publication in selectedPublications)
                    {
                        writer.Write(string.Format(" {0, -25} | {1, 25} |", publication.PublicationName, publication.Income));
                    }
                    writer.WriteLine();
                }
                writer.Close();
            }
        }
    }
}
