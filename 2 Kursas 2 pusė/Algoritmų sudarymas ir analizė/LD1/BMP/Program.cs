using SimpleREngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Program
    {
        public static int sk;
        static void Main(string[] args)
        {
            Renderer Render = new Renderer("Result", 1000, 1000, 0xFF808080);
            Test(Render, 500, 500, 32, 3);
            Test(Render, 500, 500, 64, 3);
            Test(Render, 500, 500, 128, 3);
            Test(Render, 500, 500, 256, 3);
            Test(Render, 500, 500, 512, 3);
           
        }

        static void RecursiveSquare(Renderer Render, double X, double Y, double Size, uint Iteration)
        {
            if (Iteration == 0)
            {
                Render.DrawFilledSquare(X - (Size * (1d / 2d)), Y - (Size * (1d / 6d)), Size, Size * (1d / 3d));
                Render.DrawFilledSquare(X - (Size * (1d / 6d)), Y - (Size * (1d / 2d)), Size * (1d / 3d), Size);

                return;
            }

            double IterSize = Math.Pow(3, Iteration + 1);
            double NextSize = (Math.Pow(3, Iteration) / IterSize) * Size;

            double Distance = (Size / 2) - (NextSize / 2);

            RecursiveSquare(Render, X, Y, NextSize, Iteration - 1);
            RecursiveSquare(Render, X + Distance, Y, NextSize, Iteration - 1);
            RecursiveSquare(Render, X - Distance, Y, NextSize, Iteration - 1);
            RecursiveSquare(Render, X, Y + Distance, NextSize, Iteration - 1);
            RecursiveSquare(Render, X, Y - Distance, NextSize, Iteration - 1);
        }

        public static void Test(Renderer Render, double X, double Y, double Size, uint Iteration)
        {
            Stopwatch time = new Stopwatch();
            sk = 0;
            time.Start();
            RecursiveSquare(Render, X, Y, Size, Iteration);
            time.Stop();
            Console.WriteLine("Tasku skaicius: {0}", Size);
            Console.WriteLine("Elapsed time: {0} microsec.", time.Elapsed.TotalMicroseconds);
            Console.WriteLine("Iterations: {0}", sk);

        }
    }


}

