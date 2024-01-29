using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _13_Uzd_Nesikartojantys_žodžiai
{
    /// <summary>
    /// Class that prints or reads information
    /// </summary>
    class InOut
    {
        /// <summary>
        /// Prints information to .txt file
        /// </summary>
        /// <param name="words">array of strings</param>
        /// <param name="fileName">Specific file name</param>
        public static void SpecificWords(string[] words, string fileName)
        {
            int count = 0;
            using (var writer = File.AppendText(fileName))
            {
                foreach (string word in words)
                {
                    if (word != null)
                    {
                        writer.WriteLine(word);
                        count++; //Count of words
                    }
                    
                }

                if (count == 0)
                {
                    writer.WriteLine("Tokių žodžių nėra.");
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteLine("Žodžių skaičius:");
                    writer.WriteLine(count);
                    writer.WriteLine();
                }
                   
            }
        }


    }
}
