//using System.Text;
//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;

//[MemoryDiagnoser]
//public class Benchmark
//{
//    public int[] a;

//    [Params(10, 100, 1000, 10000)]
//    public int n;

//    [GlobalSetup]
//    public void Setup()
//    {
//        a = new int[n];
//        int min = 0;
//        int max = 20;
//        Random randNum = new Random();
//        a = Enumerable.Repeat(0, a.Length).Select(i => randNum.Next(min, max)).ToArray();
//    }

//    [Benchmark]
//    public void R1Benchmark()
//    {
//        Program.R1(a, n);
//    }

//    [Benchmark]
//    public void R2Benchmark()
//    {
//        Program.R2(a, n);
//    }

//    [Benchmark]
//    public void R3Benchmark()
//    {
//        Program.R3(a, n);
//    }

//}