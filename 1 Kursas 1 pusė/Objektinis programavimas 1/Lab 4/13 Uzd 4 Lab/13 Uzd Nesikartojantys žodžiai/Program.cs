using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Main function of this program is to format all kinds of text with simbols and characters

//Vytenis Kriščiūnas

namespace _13_Uzd_Nesikartojantys_žodžiai
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Represents a .txt file from which data will be read
        /// </summary>
        const string CFd1 = @"Knyga1.txt";
        /// <summary>
        /// Represents a .txt file from which data will be read
        /// </summary>
        const string CFd2 = @"Knyga2.txt";
        /// <summary>
        /// Represents a .txt file where data will be put
        /// </summary>
        const string CFr = "Rodikliai.txt";

        static void Main(string[] args)
        {
            
            File.Delete(CFr);
            string punctuation = "[ ,\\-!.;l]";
            string[] singleWords = TaskUtils.WordsRepeatOneTime(CFd1, CFd2, punctuation);
            string[] lines = new string[2];
            
            lines[0] = string.Format("Žodžiai, kurie kartojasi tik po vieną kartą ir jų nėra antrame faile .txt:\n");
            File.AppendAllText(CFr, lines[0], Encoding.UTF8);
            InOut.SpecificWords(singleWords, CFr);

            lines[1] = string.Format("Žodžiai, kurie yra abejuose failuose surikiuoti pasikartojimo skaičių mažėjimo tvarka, o kai pasikartojimų skaičius sutampa – pagal abėcėlę:\n");
            File.AppendAllText(CFr, lines[1], Encoding.UTF8);
            string[] multiWords = TaskUtils.WordsThatRepeat(CFd1, CFd2, punctuation);
            InOut.SpecificWords(multiWords, CFr);
            
        }
    }
}
