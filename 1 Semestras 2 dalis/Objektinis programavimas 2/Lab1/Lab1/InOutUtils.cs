using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lab1
{
    /// <summary>
    /// Class that prints or reads information
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Creates a register of given information
        /// </summary>
        /// <param name="fileName">Specific file name</param>
        /// <param name="columnSize">Information about the columns size</param>
        /// <param name="rowsSize">Information about the rows size</param>
        /// <returns>Formated list and rows, columns information </returns>
        public static Register ReadAllLines(string fileName, out int columnSize, out int rowsSize)
        {
            Register allWholes = new Register();
            string[] allLines = File.ReadAllLines(fileName);

            string[] Values = allLines[0].Split(' ');
            columnSize = int.Parse(Values[0]);
            rowsSize = int.Parse(Values[1]);

            for (int i = 0; i < allLines.Count(); i++)
            {
                if (i > 0)
                {
                    Whole whole = new Whole(allLines[i]);
                    allWholes.Add(whole);
                }
            }
            return allWholes;
        }

        /// <summary>
        /// Prints information to .txt file
        /// </summary>
        /// <param name="fileName">Specific file name</param>
        /// <param name="allData">Register information</param>
        public static void PrintAllLinesToTxt(string fileName, Register allData)
        {
            string[] lines = new string[allData.Count() + 6];
            lines[0] = string.Format(new string('-', 47));
            lines[1] = string.Format("| {0,-20} | {1,-20} |", "Eilučių skaičius", "Stulpelių skaičius");
            lines[2] = string.Format(new string('-', 47));
            lines[3] = string.Format("| {0,20} | {1,20} |", allData.ColumnsSize, allData.RowsSize);
            lines[4] = string.Format(new string('-', 47));

            for (int i = 0; i < allData.Count(); i++)
            {
                lines[i + 5] = allData.WholeLine(i).ToString();
            }
            lines[allData.Count() + 5] = string.Format(new string('-', 24));

            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Prints information to .txt file
        /// </summary>
        /// <param name="fileName">Specific file name</param>
        /// <param name="allData">Conteiner informattion</param>
        public static void PrintAllLinesToTxt(string fileName, WholesConteiner allData)
        {
            string[] lines = new string[allData.Count + 8];
            lines[0] = string.Format(new string('-', 24));
            lines[1] = string.Format("| {0,-20} |", "Kurmių skaičius");
            lines[2] = string.Format(new string('-', 24));
            lines[3] = string.Format("| {0,20} |", allData.Count);
            lines[4] = string.Format(new string('-', 24));
            lines[5] = string.Format("| {0,-20} |", "Kurmių urvų dydžiai");
            lines[6] = string.Format(new string('-', 24));

            for (int i = 0; i < allData.Count; i++)
            {
                lines[i + 7] = string.Format("| {0,20} |", allData.GetArea(5, i));
            }
            lines[allData.Count + 7] = string.Format(new string('-', 24));

            File.WriteAllLines(fileName, lines);
        }

    }
}