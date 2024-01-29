using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _13_Uzd_Nesikartojantys_žodžiai
{
    /// <summary>
    /// Class that do all kinds of actions with strings and characters
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Formats an array of strings that repeat one time in first file and don not exsist in a second file
        /// </summary>
        /// <param name="readFile1">Specific file name</param>
        /// <param name="readFile2">Specific file name</param>
        /// <param name="punctuation">String of punctuations</param>
        /// <returns>Formated array of strings</returns>
        public static string[] WordsRepeatOneTime(string readFile1, string readFile2, string punctuation)
        {
            string[] lines = File.ReadAllLines(readFile1, Encoding.UTF8);
            string[] words = new string[10];
            int x = 0;
            foreach (string line in lines)
            {
                 if (line.Length > 0)
                 {
                    string[] parts = Regex.Split(line, punctuation + "+");
                     foreach (string word in parts)
                     {
                        if (word.Length > 0)
                        {
                            int count = Count(word, lines, punctuation);
                            bool trueFalse = SecondFileMatch(word, readFile2, punctuation);

                            if (Contains(words, word) == false && count == 1 && trueFalse == false && x < 10)
                            {
                                words[x] = word;
                                x++;
                            }
                        }
                     }
                 }
            }
            return words;
 
        }

        /// <summary>
        /// Finds out if a word contains in a array of words
        /// </summary>
        /// <param name="words">Array of words</param>
        /// <param name="word">One word</param>
        /// <returns>True of false</returns>
        private static bool Contains(string[] words, string word)
        {
            foreach (string Word in words)
            {
                if (Word == word)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Counts how many times a word was repeated in the first file
        /// </summary>
        /// <param name="word">One word</param>
        /// <param name="lines">Single line in a text</param>
        /// <param name="punctuation">String of punctuations</param>
        /// <returns>Counted integer</returns>
        private static int Count(string word, string[] lines, string punctuation)
        {
            int count = -1;
            string newWord = string.Format("(?<={0}){1}{2}+", punctuation, word, punctuation);
            Regex expression = new Regex(newWord);
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    foreach (var MyMatch in expression.Matches(punctuation[1] + line + punctuation[1]))
                    {
                        count++;
                    } 
                }
                
            }
            return count;
            
        }

        /// <summary>
        /// Finds out if word was used in a second file
        /// </summary>
        /// <param name="word">One word</param>
        /// <param name="readFile2">Specific file</param>
        /// <param name="punctuation">String of punctuations</param>
        /// <returns>True or false</returns>
        private static bool SecondFileMatch(string word, string readFile2, string punctuation)
        {
            string[] lines = File.ReadAllLines(readFile2, Encoding.UTF8);
            int count = 0;
            string newWord = string.Format("(?<={0}){1}{2}+", punctuation, word, punctuation);
            Regex expression = new Regex(newWord);
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    foreach (var MyMatch in expression.Matches(punctuation[1] + line + punctuation[1]))
                    {
                        count++;
                    }
                }
            }
            
            if (count > 0)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Formats an array of strings that repeat in the first and the second files, also this method sorts the array
        /// </summary>
        /// <param name="readFile1">Specific file</param>
        /// <param name="readFile2">Specific file</param>
        /// <param name="punctuation">String of punctuations</param>
        /// <returns>Formated array of strings</returns>
        public static string[] WordsThatRepeat(string readFile1, string readFile2, string punctuation)
        {
            string[] lines = File.ReadAllLines(readFile1, Encoding.UTF8);
            string[] words = new string[10];
            int[] count = new int[10];
            int x = 0;

            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    string[] parts = Regex.Split(line, punctuation + "+");

                    foreach (string word in parts)
                    {
                        if (word.Length > 0)
                        {
                            int howMany = TimesOfRepeat(word, readFile2, punctuation);
 
                            if (Contains(words, word) == false && howMany > 0 && x < 10)
                            {
                                words[x] = word;
                                count[x] = howMany;
                                x++;
                            }
                        }
                    }
                }
            }

            //Sort by count or alphabet
            for (int i = 0; i < x; i++)
            {
                int n = count[i];
                string m = words[i];
                for (int j = i + 1; j < x; j++)
                {
                    if (count[i] < count[j] || count[i] == count[j] && words[i].CompareTo(words[j]) > 0)
                    { 
                        count[i] = count[j];
                        count[j] = n;
                        n = count[i];

                        words[i] = words[j];
                        words[j] = m;
                        m = words[i];
                    }
                }
                
            }
            return words;
        }

        /// <summary>
        /// Counts how many times a word was repeated in the second file
        /// </summary>
        /// <param name="word">One word</param>
        /// <param name="fileName">Specific file</param>
        /// <param name="punctuation">String of punctuations</param>
        /// <returns>Counted integer</returns>
        private static int TimesOfRepeat(string word, string fileName, string punctuation)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            string newWord = string.Format("(?<={0}){1}{2}+", punctuation, word, punctuation);
            Regex expression = new Regex(newWord);
            int count = 0;

            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    foreach (var MyMatch in expression.Matches(punctuation[1] + line + punctuation[1]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        
    }
}
