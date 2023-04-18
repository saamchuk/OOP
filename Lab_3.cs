using System;
using System.Windows;

namespace lab_7_oop
{
    public interface VectorTwo
    {
        float length(TwoDimensional first);
        TwoDimensional sum(TwoDimensional first, TwoDimensional second);
        TwoDimensional multiplication(TwoDimensional a, int n);
        float dotProduct(TwoDimensional first, TwoDimensional second);
    }

    public class TwoDimensional: VectorTwo
    {
        static Random rand = new Random();
        public Point vector;

        public TwoDimensional()
        {
            vector.X = rand.Next(20);
            vector.Y = rand.Next(20);
        }
        public TwoDimensional(int x, int y)
        {
            vector.X = x;
            vector.Y = y;
        }
        public string display()
        {
            return ("( " + vector.X + ", " + vector.Y + " )");
        }
        public float length(TwoDimensional first)
        {
            return (float)Math.Sqrt(Math.Pow(first.vector.X, 2) + Math.Pow(first.vector.Y, 2));
        }
        public TwoDimensional sum(TwoDimensional first, TwoDimensional second)
        {
            TwoDimensional c = new TwoDimensional();
            c.vector.X = first.vector.X + second.vector.X;
            c.vector.Y = first.vector.Y + second.vector.Y;
            return c;
        }
        public TwoDimensional multiplication (TwoDimensional a, int n)
        {
            TwoDimensional c = new TwoDimensional();
            c.vector.X = a.vector.X * n;
            c.vector.Y = a.vector.Y * n;
            return c;
        }
        public float dotProduct (TwoDimensional first, TwoDimensional second)
        {
            return (float)((first.vector.X * second.vector.X) + (first.vector.Y * second.vector.Y));
        }
    }
    public interface VectorThree
    {
        float length(ThreeDimensional first);
        ThreeDimensional sum(ThreeDimensional first, ThreeDimensional second);
        ThreeDimensional multiplication(ThreeDimensional a, int n);
        float dotProduct(ThreeDimensional first, ThreeDimensional second);
    }
    public class ThreeDimensional : VectorThree
    {
        static Random rand = new Random();
        int x, y, z;

        public ThreeDimensional()
        {
            x = rand.Next(20);
            y = rand.Next(20);
            z = rand.Next(20);
        }
        public ThreeDimensional(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public string display()
        {
            return ("( " + x + ", " + y + ", " + z + " )");
        }
        public float length(ThreeDimensional first)
        {
            return (float)Math.Sqrt(Math.Pow(first.x, 2) + Math.Pow(first.y, 2) + Math.Pow(first.z, 2));
        }
        public ThreeDimensional sum(ThreeDimensional first, ThreeDimensional second)
        {
            ThreeDimensional c = new ThreeDimensional();
            c.x = first.x + second.x;
            c.y = first.y + second.y;
            c.z = first.z + second.z;
            return c;
        }
        public ThreeDimensional multiplication(ThreeDimensional a, int n)
        {
            ThreeDimensional c = new ThreeDimensional();
            c.x = a.x * n;
            c.y = a.y * n;
            c.z = a.z * n;
            return c;
        }
        public float dotProduct(ThreeDimensional first, ThreeDimensional second)
        {
            return (float)((first.x * second.x) + (first.y * second.y) + (first.z * second.z));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        start: Console.WriteLine("Оберiть простiр: ");
            Console.WriteLine("1. двовимiрний \n" +
                "2. тривимiрний \n" +
                "0. вихiд \n");
            int dimensional = Convert.ToInt32(Console.ReadLine());
            switch (dimensional)
            {
                case 1:
                    TwoDimensional a = new TwoDimensional();
                    TwoDimensional b = new TwoDimensional();
                    TwoDimensional c = new TwoDimensional();
                    Console.WriteLine("Перший вектор: " + a.display());
                    Console.WriteLine("Другий вектор: " + b.display());
                    Console.WriteLine("Довжина першого вектора: " + c.length(a));
                    c = c.sum(a, b);
                    Console.WriteLine("Сума векторiв: " + c.display());
                    c = c.multiplication(a, 5);
                    Console.WriteLine("Множення першого вектора на 5: " + c.display());
                    Console.WriteLine("Скалярний добуток: " + c.dotProduct(a, b));
                    goto start;
                case 2:
                    ThreeDimensional a3 = new ThreeDimensional();
                    ThreeDimensional b3 = new ThreeDimensional();
                    ThreeDimensional c3 = new ThreeDimensional();
                    Console.WriteLine("Перший вектор: " + a3.display());
                    Console.WriteLine("Другий вектор: " + b3.display());
                    Console.WriteLine("Довжина першого вектора: " + c3.length(a3));
                    c3 = c3.sum(a3, b3);
                    Console.WriteLine("Сума векторiв: " + c3.display());
                    c3 = c3.multiplication(a3, 5);
                    Console.WriteLine("Множення першого вектора на 5: " + c3.display());
                    Console.WriteLine("Скалярний добуток: " + c3.dotProduct(a3, b3));
                    goto start;
                case 0:
                    break;
            }
        }
    }
}
