using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab3
{
    public class struk
    {
        public char[,] b;
        public int[,] c;

        public struk(int XLenght, int YLenght)
        {
            b = new char[XLenght, YLenght];
            c = new int[XLenght, YLenght];
        }
    }


    internal class Class1
    {
        private static long sk1;
        private static long sk2;

        public static void Main(string[] args)
        {
            char[] X = new char[0];
            char[] Y = new char[0];
            Console.WriteLine("Rekursinis sprendimas");
            X = new char[2] { 'a', 'b' };
            Y = new char[2] { 'b', 'a' };
            Test1(X, Y);
            X = new char[4] { 'a', 'a', 'b', 'b' };
            Y = new char[4] { 'b', 'b', 'a', 'a' };
            Test1(X, Y);
            X = new char[8] { 'a', 'b', 'a', 'a', 'b', 'b', 'b', 'a' };
            Y = new char[8] { 'a', 'b', 'b', 'b', 'a', 'a', 'b', 'a' };
            Test1(X, Y);
            X = new char[16] { 'a', 'b', 'b', 'a', 'a', 'b', 'a', 'a', 'b', 'b', 'b', 'a', 'a', 'a', 'b', 'a' };
            Y = new char[16] { 'a', 'b', 'a', 'a', 'a', 'b', 'b', 'b', 'a', 'b', 'a', 'a', 'b', 'a', 'b', 'a' };
            Test1(X, Y);
            X = new char[32] { 'b', 'a', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'a', 'b', 'b', 'b', 'b', 'a', 'a', 'a', 'a', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'b', 'b', 'a', 'b', 'a', 'a', 'b' };
            Y = new char[32] { 'b', 'a', 'a', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'b', 'a', 'b', 'a', 'a', 'a', 'a', 'b', 'b', 'b', 'b', 'a', 'a', 'a', 'a', 'b', 'a', 'b' };
            Test1(X, Y);
            Console.WriteLine();

            //Console.WriteLine("Dinaminis sprendimas");
            //X = new char[2] { 'a', 'b' };
            //Y = new char[2] { 'b', 'a' };
            //Test2(X, Y);
            //X = new char[4] { 'a', 'a', 'b', 'b' };
            //Y = new char[4] { 'b', 'b', 'a', 'a' };
            //Test2(X, Y);
            //X = new char[8] { 'a', 'b', 'a', 'a', 'b', 'b', 'b', 'a' };
            //Y = new char[8] { 'a', 'b', 'b', 'b', 'a', 'a', 'b', 'a' };
            //Test2(X, Y);
            //X = new char[16] { 'a', 'b', 'b', 'a', 'a', 'b', 'a', 'a', 'b', 'b', 'b', 'a', 'a', 'a', 'b', 'a' };
            //Y = new char[16] { 'a', 'b', 'a', 'a', 'a', 'b', 'b', 'b', 'a', 'b', 'a', 'a', 'b', 'a', 'b', 'a' };
            //Test2(X, Y);
            //X = new char[32] { 'b', 'a', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'a', 'b', 'b', 'b', 'b', 'a', 'a', 'a', 'a', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'b', 'b', 'a', 'b', 'a', 'a', 'b' };
            //Y = new char[32] { 'b', 'a', 'a', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'b', 'b', 'a', 'a', 'b', 'a', 'b', 'a', 'a', 'a', 'a', 'b', 'b', 'b', 'b', 'a', 'a', 'a', 'a', 'b', 'a', 'b' };
            //Test2(X, Y);
            //Console.WriteLine();

            ////Testavimui
            //char[] X = new char[6];
            //char[] Y = new char[6];
            //Y[1] = 'a';
            //Y[2] = 'b';
            //Y[3] = 'a';
            //Y[4] = 'a';
            //Y[5] = 'b';
            //int ii = 1;
            //for (int i = Y.Length - 1; i > 0; i--)
            //{
            //    X[ii] = Y[i];
            //    ii++;
            //}

            ////Rekursinis
            //String rec = RecursiveLCS(X, Y, X.Length, Y.Length);
            //Console.WriteLine(rec);

            ////Dinaminis
            //struk S = DinamicalLCSLenght(X, Y);
            //DinamicalPrintLCS(S.b, X, X.Length - 1, Y.Length - 1);
        }

        public static void Test1(char[] X, char[] Y)
        {
            Stopwatch time = new Stopwatch();
            sk1 = 0;
            time.Start();
            RecursiveLCS(X, Y, X.Length, Y.Length);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", X.Length * Y.Length);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk1);
        }

        public static void Test2(char[] X, char[] Y)
        {
            Stopwatch time = new Stopwatch();
            sk2 = 0;
            time.Start();
            struk S = DinamicalLCSLenght(X, Y);
            DinamicalPrintLCS(S.b, X, X.Length - 1, Y.Length - 1);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", X.Length * Y.Length);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk2);
        }

        public static String RecursiveLCS(char[] X, char[] Y, int m, int n)
        {
            sk1++;
            if (m == 0 || n == 0)                                                            // c1 | 1
            {
                sk1++;
                return "";                                                                  // c2 | 1
            }
            sk1++;
            if (X[m - 1] == Y[n - 1])                                                       // c3 | 1
            {
                sk1++;
                return RecursiveLCS(X, Y, m - 1, n - 1) + X[m-1];                           // T(m - 1, n - 1) + c4 | 1 
            }
            sk1++;
            return maxByLenght(RecursiveLCS(X, Y, m, n - 1), RecursiveLCS(X, Y, m - 1, n)); // T(m, n - 1) + T(m - 1, n) | 1
        }
        // T(n) = konstanta, jei m = 0 arba n = 0
        // T(n) = T(m - 1, n - 1) + c1 + c3 + c4, m > 0 ir n > 0, Xm = Yn
        // T(n) = T(m, n - 1) + T(m - 1, n) + c1 + c3, kitais atvejais


        private static String maxByLenght(String a, String b)
        {
            sk1++;
            return a.Length > b.Length ? a : b;              // c1 | 1
        }

        public static struk DinamicalLCSLenght(char[] X, char[] Y)
        {
            sk2+=3;
            int m = X.Length;                                       // c1 | 1
            int n = Y.Length;                                       // c2 | 1

            struk s = new struk(m, n);                              // c3 | 1
            sk2++;
            for (int i = 1; i < m; i++)                             // c4 | n + 1
            {
                sk2++;
                s.c[i, 0] = 0;                                      // c5 | n
                sk2++;
            }
            sk2++;
            for (int j = 0; j < n; j++)                             // c6 | n + 1
            {
                sk2++;
                s.c[0,j] = 0;                                       // c7 | n
                sk2++;
            }
            sk2++;
            for (int i = 1; i < m; i++)                             // c8 | n + 1
            {
                sk2++;
                for (int j = 1; j < n; j++)                         // c9 | n * (n + 1)
                {
                    sk2+=3;
                    if (Y[i] == X[j])                               // c10 | n*n
                    {
                        sk2+=3;
                        s.c[i, j] = s.c[i - 1, j - 1] + 1;          // c11 | n*n
                        s.b[i, j] = '\\';                           // c12 | n*n

                    }
                    else if (s.c[i - 1, j] >= s.c[i, j - 1])        // c13 | n*n
                    {
                        sk2+=3;
                        s.c[i, j] = s.c[i - 1, j];                  // c14 | n*n                  
                        s.b[i, j] = '|';                            // c15 | n*n
                        
                    }       
                    else                                            // c16 | n*n
                    {
                        sk2 += 3;
                        s.c[i, j] = s.c[i, j - 1];                  // c17 | n*n
                        s.b[i, j] = '-';                            // c18 | n*n
                      
                    }
                    sk2++;
                }
                sk2++;
            }
            sk2++;
            return s;                                               // c19 | 1
        }
        // T(n) = c1 + c2 + c3 + c4*n + c4 + c5*n + c6*n + c6 + c7*n + c8*n + c8 + c9*n^2 + c9*n + c10*n^2 .. = n^2 + n + C 

        public static void DinamicalPrintLCS(char[,] b, char[] X, int i, int j)
        {
            sk2 += 4;
            if (i == 0 || j == 0)                                   // c1 | 1
            {
                sk2++;
                return;                                             // c2 | 1
            }
            if (b[i, j] == '\\')                                    // c3 | 1
            {
                sk2+=2;
                DinamicalPrintLCS(b, X, i - 1, j - 1);              // T(i - 1, j - 1) | 1
                Console.Write(X[j]);                                // c4 | 1
            }
            else if (b[i, j] == '|')                                // c5 | 1
            {
                sk2++;
                DinamicalPrintLCS(b, X, i - 1, j);                  // T(i - 1, j) | 1
            }
            else                                                    // c6 | 1 
            {
                sk2++;
                DinamicalPrintLCS(b, X, i, j - 1);                  // T(i, j - 1) | 1
            }
        }
        // T(n) = konstanta, jei i = 0 arba j = 0
        // T(n) = T(i - 1, j - 1) + c1 + c3 + c4 , jei b[i, j] == '\\' ir i,j > 0
        // T(n) = T(i - 1, j) + c1 + c3 + c5, jei b[i, j] == '|' ir i,j > 0
        // T(n) = T(i, j - 1) + c1 + c3 + c5 + c6, kitais atvejais
        // T(n) = O(1) - atvejis iš viršaus
        // Kadangi šis rekursinis metodas veiks tol kol i,j > 0, o jie iš pradžių yra lygūs n, todėl T(n) = O(n + n) - atvejis iš apačios
    }
}
