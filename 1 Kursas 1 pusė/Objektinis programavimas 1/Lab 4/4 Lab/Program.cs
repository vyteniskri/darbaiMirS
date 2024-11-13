using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace L4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = @"Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            const string CFa = "Analize.txt";

            char[] punctuation1 = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            string punctuation2 = " .,!?:;\t'";

            LettersFrequency letters = new LettersFrequency();
            InOut.Repetitions(CFd, letters);
            InOut.PrintRepetitions(CFr, letters);
            Console.WriteLine("Daugiausiai raidžių: {0}", letters.MostUsedLetter);

            int Length = InOut.LongestLine(CFd);
            InOut.RemoveLine(CFd, CFr, Length);

            //2 savarankiško darbo užduotis (//, /**/)
            InOut.Process(CFd, CFr, CFa);

            Console.WriteLine("Sutampančių žodžių: {0, 3:d}", TaskUtils.Process(CFd, punctuation1));

            //3 Savarankiško darbo užduotis (polindromai)
            Console.WriteLine("Žodžiai polindromai: {0, 3:d}", TaskUtils.Polindrom(CFd, punctuation1));

            string name = "Arvydas";
            string surname = "Sabonis";
            TaskUtils.Process1(CFd, CFr, punctuation2, name, surname);

            //4 Savarankiško užduotis (žodžiai su skyrikliais)
            string word = "iki";
            TaskUtils.NewChangedText(CFd, CFr, punctuation2, word);

            const string vowels = "AEIYOUaeiyouĄąĘęĖėĮįŲųŪū";
            TaskUtils.Process(CFd, CFr, CFa, punctuation1, vowels);

        }
    }
}
