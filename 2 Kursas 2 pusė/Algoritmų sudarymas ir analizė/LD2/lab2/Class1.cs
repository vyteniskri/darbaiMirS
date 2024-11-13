using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Class1
    {
        private static int sk1;
        private static int sk2;
        public static void Main(string[] args)
        {
            int[] arr = new int[0];
            long n = 0;
            Console.WriteLine("Pirmoji lygtis: ");
            arr = new int[16];
            arr[0] = 1;
            Test1(arr);
            arr = new int[32];
            arr[0] = 1;
            Test1(arr);
            arr = new int[64];
            arr[0] = 1;
            Test1(arr);
            arr = new int[100];
            arr[0] = 1;
            Test1(arr);
            arr = new int[256];
            arr[0] = 1;
            Test1(arr);
            Console.WriteLine();

            //Console.WriteLine("Antroji lygtis: ");
            //n = 2;
            //arr = new int[16];
            //arr[0] = -1;
            //Test2(n, arr);
            //n = 4;
            //arr = new int[32];
            //arr[0] = -1;
            //Test2(n, arr);
            //n = 8;
            //arr = new int[64];
            //arr[0] = -1;
            //Test2(n, arr);
            //n = 16;
            //arr = new int[100];
            //arr[0] = -1;
            //Test2(n, arr);
            //n = 32;
            //arr = new int[256];
            //arr[0] = -1;
            //Test2(n, arr);
            //n = 36;
            //arr = new int[300];
            //arr[0] = -1;
            //Test2(n, arr);
            //Console.WriteLine();
        }

        public static void Test1(int[] arr)
        {
            Stopwatch time = new Stopwatch();
            sk1 = 0;
            time.Start();
            methodToAnalysis1(arr);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", arr.Length);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk1);

        }

        public static void Test2(long n, int[] arr)
        {
            Stopwatch time = new Stopwatch();
            sk2 = 0;
            time.Start();
            methodToAnalysis2(n, arr);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0} ir n reiksme: {1}", arr.Length, n);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk2);

        }

        public static long methodToAnalysis1(int[] arr)
        {
            sk1++;
            long n = arr.Length;                    //            c1 | 1
            sk1++;
            long k = n;                             //            c2 | 1
            sk1++;
            for (int i = 0; i < n * 2 * n; i++)     //            c3 | 2*n*n + 1
            {
                sk1++;
                if (arr[0] > 0)                     //            c4 | 1
                {
                    sk1++;
                    for (int j = 0; j < n / 2; j++) //            c5 | (n/2 + 1) * 2*n*n
                    {
                        sk1++;
                        k -= 2;                     //            c6 | 1*n*n*n 
                        sk1++;
                    }

                }
                sk1++;
            }
            sk1++;
            return k;                               //            c7 | 1
        }
        // T(n) = n^3*(c5 + c6) + 2*n^2*(c3 + c5) + c1 + c2 + c3 + c4 + c7              , kai arr[0] > 0
        // T(n) = c1 + c2 + c3*(2*n^2 + 1) + c4 + c7 = 2*n^2*c3 + c1 + c2 + c3 + c4 + c7, kai arr[0] <= 0

        public static long methodToAnalysis2(long n, int[] arr)
        {
            sk2++;
            long k = 0;                             //            c1 | 1    
            sk2++;
            for (int i = 0; i < n; i++)             //            c2 | n + 1
            {
                sk2++;
                k += k;                             //            c3 | n
                sk2++;
                k += FF9(i, arr);                   //    (c4 + f(n))| n
                sk2++;
            }
            sk2++;
            k += FF9(n, arr);                       //      c5 + f(n) | 1
            sk2++;
            k += FF9(n / 2, arr);                   //    c6 + f(n/2) | 1
            sk2++;
            return k;                               //             c7 | 1

        }
        // T(n) = f(n)*(n + 1) + f(n/2) + n*(c2 + c3 + c4) + c1 + c2 + c5 + c6 + c7

        public static long FF9(long n, int[] arr)
        {
            sk2++;
            if (n > 1 && arr.Length > n && arr[0] < 0)                      //         c1 | 1
            {
                sk2++;
                return FF9(n - 2, arr) + FF9(n - 1, arr) + FF9(n / n, arr); //         f(n-2) + f(n-1) + f(1) + c2 | 1

            }
            sk2++;
            return n;                                                       //         c3 | 1

        }
        // f(n) = c1 + c2                              , kai n <= 1 arba arr.Length <= n arba arr[0] >= 0 
        // f(n) = f(n-2) + f(n-1) + f(1) + c1 + c2 + c3, kai n > 1 ir arr.Length > n ir arr[0] < 0
    }
}
