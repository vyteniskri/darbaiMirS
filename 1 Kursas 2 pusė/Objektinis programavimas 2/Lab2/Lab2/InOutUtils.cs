using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Lab2
{
    /// <summary>
    /// Class that prints or reads information
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Creates a list of workers
        /// </summary>
        /// <param name="fileName">Specific file name of given data</param>
        /// <returns>Formated list</returns>
        public static LinkListWorkers ReadInfo1(string fileName)
        {
            LinkListWorkers list = new LinkListWorkers();

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] Values = line.Split(' ');
                DateTime date = DateTime.Parse(Values[0]);
                string surname = Values[1];
                string name = Values[2];
                string code = Values[3];
                int vntCount = int.Parse(Values[4]);

                Worker worker = new Worker(date, surname, name, code, vntCount, 0, 0, 0);

                list.Add(worker);
            }
            return list;
        }

        /// <summary>
        /// Creates a list of different parts
        /// </summary>
        /// <param name="fileName">Specific file name of given data</param>
        /// <returns>Formated list</returns>
        public static LinkListParts ReadInfo2(string fileName)
        {
            LinkListParts list = new LinkListParts();

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] Values = line.Split(' ');
                string code = Values[0];
                string name = Values[1];
                decimal price = decimal.Parse(Values[2]);

                Part part = new Part(code, name, price);

                list.Add(part);
            }
            return list;
        }

        /// <summary>
        /// Method that print information about workers to .txt file
        /// </summary>
        /// <param name="fileName">Specific file name of the place where information will be printed</param>
        /// <param name="workers">List of workers</param>
        /// <param name="header">Specific header of the information</param>
        public static void PrintGivenData(string fileName, LinkListWorkers workers, string header)
        {
            using (var writer = File.AppendText(fileName))
            {
                if (header != "")
                {
                    writer.WriteLine(header);
                }
                writer.WriteLine(new string('-', 116));
                for (workers.Begin(); workers.Exist(); workers.Next())
                {
                    writer.WriteLine(workers.Get().ToString());
                }
                writer.WriteLine(new string('-', 116));
                writer.WriteLine();
                writer.Close();
            }
            
        }

        /// <summary>
        /// Method that print information about parts to .txt file
        /// </summary>
        /// <param name="fileName">Specific file name of the place where information will be printed</param>
        /// <param name="parts">List of parts</param>
        public static void PrintGivenData(string fileName, LinkListParts parts)
        {
            using (var writer = File.AppendText(fileName))
            {
                
                writer.WriteLine(new string('-', 70));
                for (parts.Begin(); parts.Exist(); parts.Next())
                {
                    writer.WriteLine(parts.Get().ToString());
                }
                writer.WriteLine(new string('-', 70));
                writer.WriteLine();
                writer.Close();
            }

        }

        /// <summary>
        /// Method that prints who is the richest worker
        /// </summary>
        /// <param name="fileName">Specific file name of the place where information will be printed</param>
        /// <param name="worker">Information about one worker</param>
        public static void PrintRichestWorker(string fileName, Worker worker)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine("Daugiausiai uždirbęs darbininkas:");
                writer.WriteLine(new string('-', 93));
                writer.WriteLine(worker.ToString());
                writer.WriteLine(new string('-', 93));
                writer.WriteLine();
                writer.Close();
            }
        }

        /// <summary>
        /// Method that prints information about workers who make only one type of parts
        /// </summary>
        /// <param name="fileName">Specific file name of the place where information will be printed</param>
        /// <param name="workers">List of workers</param>
        public static void PrintSinglePartMakers(string fileName, LinkListWorkers workers)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine("Tik vieno pavadinimo detales gaminusių darbininkų sąrašas:");
                writer.WriteLine(new string('-', 116));
                for (workers.Begin(); workers.Exist(); workers.Next())
                {
                    writer.WriteLine(workers.Get().ToString());
                }
                writer.WriteLine(new string('-', 116));
                writer.WriteLine();
                writer.Close();
            }
        }



    }
}