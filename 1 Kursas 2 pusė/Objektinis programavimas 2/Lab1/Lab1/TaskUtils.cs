using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    /// <summary>
    /// A class that does calculations and other tasks
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Method that makes that characters are not out of bound of the array and that there is a searched mole's whole
        /// </summary>
        /// <param name="i">Column index</param>
        /// <param name="j">Row index</param>
        /// <param name="columnEnd">Column end index</param>
        /// <param name="rowEnd">Row end index</param>
        /// <param name="symbols">Array of symbols</param>
        /// <returns>True or false</returns>
        private static bool SafeOrNot(int i, int j, int columnEnd, int rowEnd, char[,] symbols)
        {
            if (i < columnEnd && i >= 0 && j < rowEnd && j >= 0 && symbols[i, j] == 'u')
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Method that counts the number of mole's created wholes 
        /// </summary>
        /// <param name="i">Column index</param>
        /// <param name="j">Row index</param>
        /// <param name="ii">Column end index</param>
        /// <param name="jj">Row end index</param>
        /// <param name="symbols">Array of symbols</param>
        /// <param name="k">Integer that is equal to one</param>
        /// <returns>Number of wholes</returns>
        private static int CountNumberOfWholes(int i, int j, int ii, int jj, char[,] symbols, int k)
        {
            if (SafeOrNot(i, j, ii, jj, symbols) == true)
            {
                symbols[i, j] = 'z';
                return k + CountNumberOfWholes(i, j + 1, ii, jj, symbols, k) + CountNumberOfWholes(i, j - 1, ii, jj, symbols, k) + CountNumberOfWholes(i + 1, j, ii, jj, symbols, k) + CountNumberOfWholes(i - 1, j, ii, jj, symbols, k);

            }
            return 0;
        }

        /// <summary>
        /// Method that creates a conteiner of found information about the moles
        /// </summary>
        /// <param name="linesOfSymbols">Register information</param>
        /// <returns>Moles Conteiner</returns>
        public static WholesConteiner MolesWholes(Register linesOfSymbols)
        {
            WholesConteiner molesWholes = new WholesConteiner();
            char[,] symbols = linesOfSymbols.ToCharArray();
            for (int i = 0; i < linesOfSymbols.ColumnsSize; i++)
            {
                for (int j = 0; j < linesOfSymbols.RowsSize; j++)
                {
                    int numberOfWholes = CountNumberOfWholes(i, j, linesOfSymbols.ColumnsSize, linesOfSymbols.RowsSize, symbols, 1);
                    if (numberOfWholes != 0)
                    {
                        molesWholes.Add(numberOfWholes);
                    }
                }
            }
            return molesWholes;

        }

    }
}
