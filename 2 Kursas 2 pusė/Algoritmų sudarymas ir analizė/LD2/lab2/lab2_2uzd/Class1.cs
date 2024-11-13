using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Class2
    {
        private static long sk1;
        private static long sk2;
        public static void Main(string[] args)
        {
            int n = 0;
            int[,] A = new int[0, 0];

            Console.WriteLine("Pirmoji lygtis");
            n = 2;
            A = new int[2, 2];
            Test1(A, n);
            n = 4;
            A = new int[4, 4];
            Test1(A, n);
            n = 8;
            A = new int[8, 8];
            Test1(A, n);
            n = 16;
            A = new int[16, 16];
            Test1(A, n);
            n = 17;
            A = new int[17, 17];
            Test1(A, n);
            Console.WriteLine();

            //Console.WriteLine("Antroji lygtis");
            //n = 10;
            //A = new int[10, 10];
            //Test2(A, n);
            //n = 100;
            //A = new int[100, 100];
            //Test2(A, n);
            //n = 1000;
            //A = new int[1000, 1000];
            //Test2(A, n);
            //n = 10000;
            //A = new int[10000, 10000];
            //Test2(A, n);
            //Console.WriteLine();

            //Irodymas, kad algoritmai veikia
            //A = new int[4, 4]
            //{
            //    { 5, 3, 4, 9 },
            //    { 8, 2, 9, 4 },
            //    { 10, 0, 6, 0 },
            //    { 11, 1, 7, 8 }
            //};
            //int rezult1 = getMinCostPath1(A, n - 1, 0, 0, n - 1);
            //Console.WriteLine(rezult1);
            //int rezult2 = minCost(A, n-1);
            //Console.WriteLine(rezult2);


        }

        public static void Test1(int[,] A, int n)
        {
            Stopwatch time = new Stopwatch();
            sk1 = 0;
            time.Start();
            getMinCostPath1(A, n - 1, 0, 0, n - 1);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", n*n);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk1);

        }

        public static void Test2(int[,] A, int n)
        {
            Stopwatch time = new Stopwatch();
            sk2 = 0;
            time.Start();
            minCost(A, n - 1);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", n * n);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk2);

        }

        public static int getMinCostPath1(int[,] A, int start_row, int start_col, int end_row, int end_col)
        {
            sk1++;
            if (start_row < end_row || start_col > end_col)                                      // c1 | 1
            {
                sk1++;
                return 999999;                                                                   // c2 | 1
            }
            sk1++;
            if (start_row == end_row && start_col == end_col)                                    // c3 | 1
            {
                sk1++;
                return A[start_row, start_col];                                                  // c4 | 1
            }
            sk1+=3;
            //Recursive Calls
            int x = getMinCostPath1(A, start_row, start_col + 1, end_row, end_col);              // T(m, n + 1) | 1
            int y = getMinCostPath1(A, start_row - 1, start_col, end_row, end_col);              // T(m - 1, n) | 1
            int minimum = Math.Min(x, y);                                                        // c5 | 1
            sk1++;
            return A[start_row, start_col] + minimum;                                            // c6 | 1

        }
        // T(n) = constanta, jei tenkinama nors viena if salyga 
        // T(n) = T(m, n + 1) + T(m - 1, n) + c1 + c3 + c5 + c6, kitais atvejais

        public static int minCost(int[,] A, int n)
        {
            sk2++;
            int[,] tc = new int[n + 1,n + 1];                                                    // c1 | 1
            sk2++;
            tc[n,0] =  A[n,0];                                                                   // c2 | 1
            sk2++;
            /* Initialize first column of total cost(tc) array
             */
            for (int i = n-1; i >= 0; i--)                                                       // c3 | n + 1
            {
                sk2++;
                tc[i,0] = tc[i + 1,0] + A[i,0];                                                  // c4 | n
                sk2++;
            }
            sk2++;
            /* Initialize first row of tc array */
            for (int j = 1; j <= n; j++)                                                         // c5 | n + 1
            {
                sk2++;
                tc[n,j] = tc[n,j - 1] + A[n,j];                                                  // c6 | n
                sk2++;
            }
            sk2++;
            /* Construct rest of the tc array */
            for (int i = n-1; i >= 0; i--)                                                       // c7 | n + 1
            {
                sk2++;
                for (int j = 1; j <= n; j++)                                                     // c8 | (n + 1) * n
                {
                    sk2++;
                    tc[i,j] = Math.Min(tc[i + 1,j], tc[i,j - 1]) + A[i,j];                       // c9 | 3*n*n
                    sk2++;
                }
                sk2++;
            }
            sk2++;
            return tc[0,n];                                                                      // c10 | 1
        }
        // T(n) = n^2*(c8 + 3*c9) + n*(c3 + c4 + c5 + c6 + c7 + c8) + c1 + c2 + c3 + c5 + c7 + c10
    }
}
