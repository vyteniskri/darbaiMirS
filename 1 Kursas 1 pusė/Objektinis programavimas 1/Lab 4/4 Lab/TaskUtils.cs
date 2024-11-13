using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace L4
{
    class TaskUtils
    {
        public static bool RemoveComments(string line, out string newLine)
        {
            newLine = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    newLine = line.Remove(i);
                    return true;
                }
                if (line[i] == '/' && line[i + 1] == '*')
                {
                    newLine = line.Remove(i, Count(i, line));
                    return true;
                }
            }
            return false;
        }

        // 2 Savarankisko darbo uzduotis (/* */)
        private static int Count(int x, string line)
        {
            int count = 0;
            for (int i = x; i < line.Length - 1; i++)
            {
                count++;
                if (line[i] == '*' && line[i + 1] == '/')
                {
                    count++;
                    break;
                }
            }
            return count;  
        }

        public static int Process(string fin, char[] punctuation)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            int equal = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    equal = equal + FirstEqualLast(line, punctuation);
                }
            }
            return equal;
        }

        private static int FirstEqualLast(string line, char[] punctuation)
        {
            string[] parts = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries); 
            int equal = 0;
            foreach (string word in parts)
            {
                if (word.Length > 0)
                {
                    if (Char.ToLower(word[0]) == Char.ToLower(word[word.Length - 1])) //Diziosios raides lygios mazosiom
                    {
                        equal++;
                    }
                }
                
            }
            return equal;
        }

        //3 Savarankiska uzduotis
        public static int Polindrom(string fin, char[] punctuation)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            int equal = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    equal = equal + AllEqual(line, punctuation);
                }
            }
            return equal;
        }

        private static int AllEqual(string line, char[] punctuation)
        {
            string[] parts = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            int equal = 0;
            foreach (string word in parts)
            {
                if (word.Length > 0)
                {
                    int allLetters = 0;
                    int length = word.Length - 1;
                    for (int i = 0; i < word.Length - 1; i++)
                    {
                        if (word[i] == word[length--])
                        {
                            allLetters++;
                        }
                    }

                    if (allLetters == word.Length - 1)
                    {
                        equal++;
                    }
                }

            }
            return equal;
        }
        private static void AddSurname(string line, string punctuation, string name, string surname, StringBuilder newLine)
        {
            string addLine = " " + line + " ";
            int init = 1;
            int ind = addLine.IndexOf(name);

            while (ind != -1)
            {
                if (punctuation.IndexOf(addLine[ind - 1]) != -1 && punctuation.IndexOf(addLine[ind + name.Length]) != -1)
                {
                    newLine.Append(addLine.Substring(init, ind + name.Length - init));
                    newLine.Append(" " + surname);
                    init = ind + name.Length;
                }
                ind = addLine.IndexOf(name, ind + 1);
            }
            newLine.Append(line.Substring(init - 1));
        }
        public static void Process1(string fin, string fout, string punctuation, string name, string surname)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writer = File.CreateText(fout))
            {
                foreach (string line in lines)
                {
                    StringBuilder newLine = new StringBuilder();
                    AddSurname(line, punctuation, name, surname, newLine);
                    writer.WriteLine(newLine);
                }
            }
        }        //4 Savarankisko uzduotis        public static void NewChangedText(string fin, string fout, string punctuation, string word)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writer = File.CreateText(fout))
            {
                foreach (string line in lines)
                {
                    StringBuilder newLine = new StringBuilder();
                    DeleteWords(line, punctuation, word, newLine);
                    writer.WriteLine(newLine);
                }
            }
        }        private static void DeleteWords(string line, string punctuation, string word, StringBuilder newLine)
        {
            string addLine = " " + line + " ";
            int init = 1;
            int ind = addLine.IndexOf(word);

            while (ind != -1)
            {
                if (punctuation.IndexOf(addLine[ind - 1]) != -1 && punctuation.IndexOf(addLine[ind + word.Length]) != -1)
                {
                    newLine.Append(addLine.Substring(init, ind - init));
                    int onePunctuation = ind + word.Length;
                    int count = 0;
                    bool Is = false;
                    while (Is == false)
                    {
                        Is = true;
                        for (int i = 0; i < punctuation.Length - 1; i++)
                        {
                            if (addLine[onePunctuation] == punctuation[i])
                            {
                                Is = false;
                            }
                        }

                        onePunctuation++;
                        count++;

                        if (onePunctuation == addLine.Length)
                        {
                            break;
                        }
                    }
                    count--;

                    init = ind + word.Length + count;
                }
                ind = addLine.IndexOf(word, ind + 1);
            }
            newLine.Append(line.Substring(init - 1));
        }        private static string LongestWord(string line, char[] punctuation)
        {
            string[] parts = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = "";
            foreach (string word in parts)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }        private static StringBuilder RemoveVowels(string line, string vowels)
        {
            StringBuilder newLine = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                if (vowels.IndexOf(line[i]) == -1)
                {
                    newLine.Append(line[i]);
                }
            }
            return newLine;
        }
        public static void Process(string fin, string fout, string finfo, char[] punctuation, string vowels)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            string dashes = new string('-', 38);
            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {
                    writerI.WriteLine(dashes);
                    writerI.WriteLine("| Ilgiausias žodis | Pradžia | Ilgis |");
                    writerI.WriteLine(dashes);
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string longestWord = LongestWord(line, punctuation);
                            string wordNoVowels = RemoveVowels(longestWord, vowels).ToString();
                            writerI.WriteLine("| {0,-16} | {1, 7:d} | {2, 5:d} |", longestWord, line.IndexOf(longestWord), longestWord.Length);
                            string newLine = line.Replace(longestWord, wordNoVowels);
                            writerF.WriteLine(newLine);
                        }
                        else
                            writerF.WriteLine(line);
                    }
                    writerI.WriteLine(dashes);
                }
            }
        }
    }
}
