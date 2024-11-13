using BenchmarkDotNet.Running;
using System.Diagnostics;

internal class Program
{
    private static int sk;
    private static void Main(string[] args)
    {
        int[] a = new int[0];
        Console.WriteLine("Pirmoji rekurentine lygtis: ");
        a = new int[16];
        Test1(a);
        a = new int[32];
        Test1(a);
        a = new int[64];
        Test1(a);
        a = new int[100];
        Test1(a);
        a = new int[256];
        Test1(a);
        Console.WriteLine();

        //Console.WriteLine("Antroji rekurentine lygtis: ");
        //a = new int[16];
        //Test2(a);
        //a = new int[32];
        //Test2(a);
        //a = new int[64];
        //Test2(a);
        //a = new int[128];
        //Test2(a);
        //a = new int[256];
        //Test2(a);
        Console.WriteLine();

        //Console.WriteLine("Trecioji rekurentine lygtis: ");
        //a = new int[16];
        //Test3(a);
        //a = new int[32];
        //Test3(a);
        //a = new int[64];
        //Test3(a);
        //a = new int[128];
        //Test3(a);

    }

    public static void Test1(int[] a)
    {
        Stopwatch time = new Stopwatch();
        sk = 0;
        time.Start();
        R1(a, a.Length);
        time.Stop();
        Console.WriteLine("Duomenu kiekis: {0}", a.Length);
        Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMicroseconds);
        Console.WriteLine("Iterations: {0}", sk);

    }
    public static void Test2(int[] a)
    {
        Stopwatch time = new Stopwatch();
        sk = 0;
        time.Start();
        R2(a, a.Length);
        time.Stop();
        Console.WriteLine("Duomenu kiekis: {0}", a.Length);
        Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMicroseconds);
        Console.WriteLine("Iterations: {0}", sk);
    }
    public static void Test3(int[] a)
    {
        Stopwatch time = new Stopwatch();
        sk = 0;
        time.Start();
        R3(a, a.Length);
        time.Stop();
        Console.WriteLine("Duomenu kiekis: {0}", a.Length);
        Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMicroseconds);
        Console.WriteLine("Iterations: {0}", sk);
    }

    //T(n) = 2*T(n/9)+n^5
    public static void R1(int[] a, int n)
                                                       //Laikas | Kartai
    {
        if (n < 9)                                     //c1 | 1
        {
            return;                                    //c2 | 1
        }

        for (int i = 0; i < n; i++)                    //c3 | n
            for (int j = 0; j < n; j++)                //c4 | n
                for (int z = 0; z < n; z++)            //c5 | n
                    for (int l = 0; l < n; l++)        //c6 | n
                        for (int x = 0; x < n; x++)    //c7 | n
                        {
                            sk++;                      //c8 | n
                        }

        R1(a, n / 9);                                  //T(n/9) | 1
        R1(a, n / 9);                                  //T(n/9) | 1
    }

    // T(n) = c1 + c2, n < 9
    // T(n) = 2*T(n/9) + c1 + c3*n*c4*n*c5*n*c6*n*n(c7+c8), n > 9


    //T(n) = T(n/7) + T(n/9) + n^3
    public static void R2(int[] a, int n)
                                                    //Laikas | Kartai
    {
        if (n < 9)                                  //c1 | 1
        {   
            return;                                 //c2 | 1
        }

        for (int i = 0; i < n; i++)                 //c3 | n
            for (int j = 0; j < n; j++)             //c4 | n
                for (int z = 0; z < n; z++)         //c5 | n
                {
                    sk++;                           //c6 | n
                }

        R2(a, n / 7);                               //T(n/7) | 1
        R2(a, n / 9);                               //T(n/9) | 1
    }

    // T(n) = c1 + c2, n < 9
    // T(n) = T(n/7) + T(n/9) + c1 + c3*n*c4*n*n(c5+c6), n > 9 


    //T(n) = T(n - 8) + T(n - 2) + n
    public static void R3(int[] a, int n)
                                                    //Laikas | Kartai
    {
        if (n < 0)                                  //c1 | 1
        {
            return;                                 //c2 | 1
        }

        for (int i = 0; i < n; i++)                 //c3 | n
        { 
            sk++;                                   //c4 | n
        }       

        R3(a, n - 8);                               //T(n - 8) | 1
        R3(a, n - 2);                               //T(n - 2) | 1

    }

    // T(n) = c1 + c2, n < 0
    // T(n) = T(n - 8) + T(n - 2) + c1 + n(c3+c4), n > 0


}