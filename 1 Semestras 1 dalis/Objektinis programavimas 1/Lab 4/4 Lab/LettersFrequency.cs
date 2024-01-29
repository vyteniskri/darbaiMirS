using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4
{
    class LettersFrequency
    {
        private const int CMax = 10000;
        private int[] Frequency; // Frequency of letters
        public string line { get; set; }
        public char MostUsedLetter;
        public int MostUsedNumber = 0;
        public LettersFrequency()
        {
            line = "";
            Frequency = new int[CMax];
            for (int i = 0; i < CMax; i++)
            {
                Frequency[i] = 0;
            }
        }

        public int Get(char character)
        {
            return Frequency[character];
        }

        /** Counts repetition of letters. */
        public void Count()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (('a' <= line[i] && line[i] <= 'z') || ('A' <= line[i] && line[i] <= 'Z'))
                {
                    Frequency[line[i]]++;
                }
            }
        }

        //Dazniausiai pasikartojanti raide ir jos skaicius
        public void MostUsed()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if(Frequency[line[i]] > MostUsedNumber)
                {
                    MostUsedNumber = Frequency[line[i]];
                    MostUsedLetter = line[i];
                }
            }
        }

    }
}
