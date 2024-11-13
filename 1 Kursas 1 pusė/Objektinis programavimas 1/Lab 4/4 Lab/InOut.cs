using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace L4
{
    class InOut
    {
        public static void PrintRepetitions(string fout, LettersFrequency letters)
        {
            using (var writer = File.CreateText(fout))
            {
                int number = letters.MostUsedNumber;
                while (number >= 0)
                {
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        if (letters.Get(ch) == number)
                        {
                            writer.WriteLine("{0, 3:c} {1, 4:d}", ch, letters.Get(ch));
                        }
                        if (letters.Get(Char.ToUpper(ch)) == number)
                        {
                            writer.WriteLine("{0, 3:c} {1, 4:d}", Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
                        } 
                    }
                    number--;
                }  
            }
        }

        public static void Repetitions(string fin, LettersFrequency letters)
        {
            using (StreamReader reader = new StreamReader(fin))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    letters.line = line;
                    letters.Count();
                    letters.MostUsed();
                }
            }
        }

        public static int LongestLine(string fin)
        {
            int No = -1;
            int length = -1;
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > length)
                    {
                        length = line.Length;
                        No = lineNo;
                    }
                    lineNo++;
                }

            }
            return length;
        }

        public static void RemoveLine(string fin, string fout, int length)
        {
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                using (var writer = File.CreateText(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (length != line.Length)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }

        public static void Process(string fin, string fout, string finfo)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string newLine = line;
                            if (TaskUtils.RemoveComments(line, out newLine)) //2 savarankiška 
                            {
                                writerI.WriteLine(line);
                            }
                            if (newLine.Length > 0)
                            {
                                writerF.WriteLine(newLine);
                            }
                        }
                        else
                            writerF.WriteLine(line);
                    }
                }
            }
        }
    }
}
