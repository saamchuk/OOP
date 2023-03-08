using System;

namespace Lab_2
{
    class Program
    {
        static Random rand = new Random();
        static void task1_1()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв вектора: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (number < 0)
            {
                Console.WriteLine("Значення некоректне!");
                number = rand.Next(20);
            }
            int[] arr = inputOne(number, 0, 50);
            Console.WriteLine("Початковий вектор:");
            outputOne(arr);
            int sum = 0;
            foreach (int element in arr) sum += element;
            sum /= arr.Length;
            Console.WriteLine("Середнє арифметичне елементiв вектора: " + sum + "\n");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > sum) arr[i] = 0;
            }
            Console.WriteLine("Результат:");
            outputOne(arr);
        }
        static void task1_2()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв векторiв: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (number < 0)
            {
                Console.WriteLine("Значення некоректне!");
                number = rand.Next(5);
            }
            int[] a = inputOne(number, -5, 5);
            Console.WriteLine("Вектор a: ");
            outputOne(a);
            int[] b = inputOne(number, -5, 5);
            Console.WriteLine("Вектор b: ");
            outputOne(b);
            int[] c = inputOne(number, -5, 5);
            Console.WriteLine("Початковий вектор c: ");
            outputOne(c);
            int scalarProduct = 0;
            for (int i = 0; i < number; i++) scalarProduct += a[i] * b[i];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = (2 * scalarProduct * c[i]) - (3 * b[i]); 
            }
            Console.WriteLine("Отриманий вектор c: ");
            outputOne(c);
        }
        static void task1_3()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв вектора: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (number < 0)
            {
                Console.WriteLine("Значення некоректне!");
                number = rand.Next(20);
            }
            int[] arr = inputOne(number, 0, 50);
            Console.WriteLine("Початковий вектор:");
            outputOne(arr);
            Console.WriteLine("Введiть значення a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть значення b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int l = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= a && arr[i] <= b || arr[i] >= b && arr[i] <= a)
                {
                    arr = deleteElement(arr, i);
                    l++;
                    i--;
                }
            }
            for (int i = arr.Length - l; i < arr.Length; i++) arr[i] = 0;
            Console.WriteLine("Отриманий вектор:");
            outputOne(arr);
        }
        static int[] inputOne (int number, int minValue, int maxValue)
        {
            int[] arr = new int[number];
            for (int i = 0; i < arr.Length; i++) arr[i] = rand.Next(minValue, maxValue);
            return arr;
        }
        static void outputOne(int[] arr)
        {
            int l = 0;
            foreach (int element in arr)
            {
                Console.Write(element + "\t");
                l++;
                if (l == 10)
                {
                    Console.WriteLine();
                    l = 0;
                }
            }
            Console.WriteLine("\n");
        }
        static int[] deleteElement (int[] arr, int n)
        {
            for (int i = n; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            return arr;
        }
        static void task2_1()
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв: ");
            int numberRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпцiв: ");
            int numberColumns = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (numberRows < 0 || numberColumns < 0)
            {
                Console.WriteLine("Значення некоректне!");
                numberRows = rand.Next(20);
                numberColumns = numberRows;
            }
            int[,] arr = inputTwo(numberRows, numberColumns, 0, 40);
            Console.WriteLine("Початкова матриця: ");
            outputTwo(arr);
            Console.WriteLine("Введiть кiлькiсть позицiй для зсуву");
            int k = Convert.ToInt32(Console.ReadLine());
            if (k < 0)
            {
                Console.WriteLine("Значення некоректне!");
                k = rand.Next(numberColumns);
            }
            int element = 0;
            for (int point = 0; point < k; point++)
            {
                for (int i = 0; i < numberRows; i += 2)
                {
                    element = arr[i, numberColumns - 1];
                    for (int j = numberColumns - 1; j > 0; j--)
                        arr[i, j] = arr[i, j - 1];
                    arr[i, 0] = element;
                }
            }
            Console.WriteLine("Утворена матриця: ");
            outputTwo(arr);
        }
        static void task2_2()
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (number < 0)
            {
                Console.WriteLine("Значення некоректне!");
                number = rand.Next(20);
            }
            float[,] arr = inputTwoFloat(number, -10, 10);
            outputTwoFloat(arr);
            Console.WriteLine("\n");
            for (int i = 0; i < number; i++)
            {
                for (int j = i + 1; j < number; j++)
                {
                    check(arr, i);
                    float p = arr[j, i] / arr[i, i];
                    arr[j, i] = 0;
                    for (int k = i + 1; k < number; k++)
                    {
                        arr[j, k] = (float) Math.Round(Convert.ToDouble(arr[j, k] - (arr[i, k] * p)), 1);
                    }
                }
            }
            outputTwoFloat(arr);
        } 
        static void task2_3 ()
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв: ");
            int numberRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпцiв: ");
            int numberColumns = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (numberRows < 0 || numberColumns < 0)
            {
                Console.WriteLine("Значення некоректне!");
                numberRows = rand.Next(20);
                numberColumns = numberRows;
            }
            int[,] arr = inputTwo(numberRows, numberColumns, 0, 20);
            Console.WriteLine("Початкова матриця: ");
            outputTwo(arr);
            Console.WriteLine("Введiть значення: ");
            int point = Convert.ToInt32(Console.ReadLine());
            int l = 0;
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    sum += arr[i, j];
                }
                sum /= arr.GetUpperBound(1) + 1;
                if (sum < point) l++;
            }
            Console.WriteLine("Кiлькiсть рядкiв: " + l);
        }
        static int[,] inputTwo (int numberRows, int numberColumns, int minValue, int maxValue)
        {
            int[,] arr = new int[numberRows, numberColumns];
            for (int i = 0; i < numberRows; i++)
            {
                for (int j = 0; j < numberColumns; j++)
                    arr[i, j] = rand.Next(minValue, maxValue);
            }
            return arr;
        }
        static void outputTwo (int[,] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i ++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        static float[,] inputTwoFloat (int number, int minValue, int maxValue)
        {
            float[,] arr = new float[number, number];
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                    arr[i, j] = rand.Next(minValue, maxValue);
            }
            return arr;
        }
        static void outputTwoFloat(float[,] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        static float[,] update (float[,] arr, int first, int second)
        {
            float element = 0;
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                element = arr[first, i];
                arr[first, i] = arr[second, i];
                arr[second, i] = element;
            }
            return arr;
        }
        static float[,] check (float[,] arr, int first)
        {
            int l = first;
            int point = 1;
            while (point != 0)
            {
                if (arr[first, first] == 0 && l + 1 != arr.GetUpperBound(0) + 1)
                {
                    arr = update(arr, l, first);
                    l++;
                    arr = update(arr, first, l);
                }
                else point = 0;
            }
            return arr;
        }
        static void Main(string[] args)
        {
            start: Console.WriteLine("Оберiть завдання: ");
            Console.WriteLine("1. завдання 1_1 \n" +
                "2. завдання 1_2 \n" +
                "3. завдання 1_3 \n" +
                "4. завдання 2_1 \n" +
                "5. завдання 2_2 \n" +
                "6. завдання 2_3 \n" +
                "0. вихiд \n");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1: 
                    task1_1();
                    goto start;
                case 2:
                    task1_2();
                    goto start;
                case 3:
                    task1_3();
                    goto start;
                case 4:
                    task2_1();
                    goto start;
                case 5:
                    task2_2();
                    goto start;
                case 6:
                    task2_3();
                    goto start;
                case 0:
                    break;
            }
        }
    }
}
