using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_antra_dalis
{
    internal class Class1
    {
        private static int sk1;
        private static int sk2;
        public static void Main(string[] args)
        {
            var random = new Random();
            //Console.WriteLine("Pirmoji lygtis: ");
            //Console.WriteLine("Be lygiagretumo: ");
            //var arr = Enumerable.Range(0, 16).Select(i => random.Next(0, 16)).ToArray();
            //Test1Normal(arr);
            //arr = Enumerable.Range(0, 32).Select(i => random.Next(0, 32)).ToArray();
            //Test1Normal(arr);
            //arr = Enumerable.Range(0, 64).Select(i => random.Next(0, 64)).ToArray();
            //Test1Normal(arr);
            //arr = Enumerable.Range(0, 128).Select(i => random.Next(0, 128)).ToArray();
            //Test1Normal(arr);
            //arr = Enumerable.Range(0, 256).Select(i => random.Next(0, 256)).ToArray();
            //Test1Normal(arr);
            //Console.WriteLine();
            //Console.WriteLine("Su lygiagretumu: ");
            //arr = Enumerable.Range(0, 16).Select(i => random.Next(0, 16)).ToArray();
            //Test1Parallel(arr);
            //arr = Enumerable.Range(0, 32).Select(i => random.Next(0, 32)).ToArray();
            //Test1Parallel(arr);
            //arr = Enumerable.Range(0, 64).Select(i => random.Next(0, 64)).ToArray();
            //Test1Parallel(arr);
            //arr = Enumerable.Range(0, 128).Select(i => random.Next(0, 128)).ToArray();
            //Test1Parallel(arr);
            //arr = Enumerable.Range(0, 256).Select(i => random.Next(0, 256)).ToArray();
            //Test1Parallel(arr);


            Console.WriteLine("Antroji lygtis: ");
            Console.WriteLine("Be lygiagretumo: ");
            int n = 8;
            var arr = Enumerable.Range(0, 16).Select(i => random.Next(0, 16)).ToArray();
            Test2Normal(n, arr);
            n = 16;
            arr = Enumerable.Range(0, 32).Select(i => random.Next(0, 32)).ToArray();
            Test2Normal(n, arr);
            n = 32;
            arr = Enumerable.Range(0, 64).Select(i => random.Next(0, 64)).ToArray();
            Test2Normal(n, arr);
            n = 40;
            arr = Enumerable.Range(0, 128).Select(i => random.Next(0, 128)).ToArray();
            Test2Normal(n, arr);
            Console.WriteLine();
            Console.WriteLine("Su lygiagretumu: ");
            n = 8;
            arr = Enumerable.Range(0, 16).Select(i => random.Next(0, 16)).ToArray();
            Test2Parallel(n, arr);
            n = 16;
            arr = Enumerable.Range(0, 32).Select(i => random.Next(0, 32)).ToArray();
            Test2Parallel(n, arr);
            n = 32;
            arr = Enumerable.Range(0, 64).Select(i => random.Next(0, 64)).ToArray();
            Test2Parallel(n, arr);
            n = 40;
            arr = Enumerable.Range(0, 128).Select(i => random.Next(0, 128)).ToArray();
            Test2Parallel(n, arr);


        }

        public static void Test1Normal(int[] arr)
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

        public static void Test1Parallel(int[] arr)
        {
            Stopwatch time = new Stopwatch();
            sk1 = 0;
            time.Start();
            ParallelmethodToAnalysis1(arr);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", arr.Length);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk1);
        }

        public static void Test2Normal(int n, int[] arr)
        {
            Stopwatch time = new Stopwatch();
            sk2 = 0;
            time.Start();
            methodToAnalysis2(n, arr);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", arr.Length);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk2);
        }

        public static void Test2Parallel(int n, int[] arr)
        {
            Stopwatch time = new Stopwatch();
            sk2 = 0;
            time.Start();
            ParallelmethodToAnalysis2(n, arr);
            time.Stop();
            Console.WriteLine("Duomenu kiekis: {0}", arr.Length);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMilliseconds);
            Console.WriteLine("Veiksmu skaicius: {0}", sk2);
        }

        public static long methodToAnalysis1(int[] arr)
        {
            sk1++;
            long n = arr.Length;                    // c1 | 1
            sk1++;
            long k = n;                             // c2 | 1
            sk1++;
            if (arr[0] > 0)                         // c3 | 1
            {
                sk1++;
                for (int i = 0; i < n; i++)         // c4 | n + 1
                {
                    sk1++;
                    for (int j = 0; j < n; j++)     // c5 | (n + 1) * n
                    {
                        sk1++;
                        k -= 2;                     // c6 | n * n 
                        sk1++;
                    }
                    sk1++;
                }
                
            }
            sk1++;
            return k;                               // c7 | 1
        }
        // T(n) = konstanta, jei arr[0] <= 0
        // T(n) = n^2 * (c5 + c6) + n * (c4 + c5) + c4 + c1 + c2 + c3 , jei arr[0] > 0

        public static long ParallelmethodToAnalysis1(int[] arr)
        {
            object monitor = new object();          // c1 | 1
            sk1++;
            long n = arr.Length;                    // c2 | 1
            sk1++;
            long k = n;                             // c3 | 1
            sk1++;
            if (arr[0] > 0)                         // c4 | 1
            {
                sk1++;
                Parallel.For(0, n, i =>             // c5 | 1
                {
                    sk1++;
                    Parallel.For(0, n, j =>         // c6 | 1
                    {
                        sk1++;
                        lock (monitor) k -= 2;      // c7 | 1
                        sk1++;
                    });
                    sk1++;
                });
                
            }
            sk1++;
            return k;                               // c8 | 1
        }
        // T(n) = konstanta


        public static long methodToAnalysis2(int n, int[] arr)
        {
            sk2++;
            long k = 0;                             // c1 | 1
            sk2++;
            Random randNum = new Random();          // c2 | 1
            sk2++;
            for (int i = 0; i < n; i++)             // c3 | n + 1
            {
                sk2++;
                k += arr[i] + FF3(i, arr);          // (c4 + f(n)) | n
                sk2++;
            }
            sk2++;
            return k;                               // c5 | 1
           
        }
        // T(n) = n*(c3 + c4 + konstanta) + c1 + c2 + c3 + c5, kai FF3() metodo rezultatas lygus konstantai
        // T(n) = 2^n*n + n*(c3 + c4) + c1 + c2 + c3 + c5, kitais atvejais


        public static long FF3(int n, int[] arr)
        {
            sk2++;
            if (n > 0 && arr.Length > n && arr[n] > 0)      // c1 | 1
            {
                sk2++;
                return FF3(n - 1, arr) + FF3(n - 3, arr);   // c2 + f(n - 1) + f(n - 3) | 1

            }
            sk2++;
            return n;                                       // c3 | 1

        }
        // f(n) = konstanta, kai n <=0, arr.Length <= n ir arr[n] <=0
        // f(n) = f(n - 1) + f(n - 3) + c1 + c2 + c3, kitais atvejais

        public static long ParallelmethodToAnalysis2(int n, int[] arr)
        {
            object monitor = new object();          // c1 | 1
            sk2++;
            long k = 0;                             // c2 | 1
            sk2++;
            Random randNum = new Random();          // c3 | 1
            sk2++;
            Parallel.For(0, n, i =>                 // c4 | 1
            {
                sk2++;
                lock (monitor) k += arr[i] + ParallelFF3(i, arr);  // (c5 + f(n)) | 1
                sk2++;
            });
            sk2++;
            return k;                               // c6 | 1

        }
        // T(n) = konstanta + c1 + c2 + c3 + c4 + c5 + c6, kai FF3() metodo rezultatas lygus konstantai
        // T(n) = 2^n + c1 + c2 + c3 + c4 + c5 + c6, kitais atvejais


        public static long ParallelFF3(int n, int[] arr)
        {
            sk2++;
            if (n > 0 && arr.Length > n && arr[n] > 0)                                                                         // c1 | 1
            {
                sk2+=5;
                Task<long> task = Task<long>.Factory.StartNew((local_n) => { return ParallelFF3((int)local_n - 1, arr); }, n); // f(n - 1)  | 1
                long y = ParallelFF3(n - 3, arr);                                                                              // f(n - 3)  | 1
                Task.WaitAll(task);                                                                                            // c2 | 1
                long x = task.Result;                                                                                          // c3 | 1
                return x + y;                                                                                                  // c4 | 1

            }
            sk2++;
            return n;                                       // c5 | 1

        }
        // f(n) = konstanta, kai n <=0, arr.Length <= n ir arr[n] <=0
        // f(n) = f(n - 1) + f(n - 3) + c1 + c2 + c3 + c4 + c5, kitais atvejais
    }
}
