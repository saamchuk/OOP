using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_8
{

    class Program
    {
        static int arrayWay (string text)
        {
            char[] symbols = text.ToCharArray();
            int number = 0;
            foreach (char letter in symbols)
            {
                if (char.IsUpper(letter)) number++;
            }
            return number;
        } 
        static int listWay (string text)
        {
            List<char> list = new List<char>();
            list.AddRange(text);
            int number = 0;
            foreach (char letter in list)
            {
                if (char.IsUpper(letter)) number++;
            }
            return number;
        }
        static void Main(string[] args)
        {
            string path = @"E:\4 semester\ооп\text.txt";
            start:  Console.WriteLine("1. Додати текст");
            Console.WriteLine("2. Вивест вмiст файлу");
            Console.WriteLine("3. Очистити файл");
            Console.WriteLine("4. Кiлькiсть прописних лiтер у файлi");
            Console.WriteLine("0. Вихiд");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (n)
            {
                case 1:
                    Console.WriteLine("Введiть текст:");
                    string addText = Console.ReadLine();
                    File.AppendAllText(path, addText);
                    Console.WriteLine();
                    goto start;
                case 2:
                    Console.WriteLine(File.ReadAllText(path));
                    Console.WriteLine();
                    goto start;
                case 3:
                    File.WriteAllText(path, "");
                    goto start;
                case 4:
                    string text = File.ReadAllText(path);
                    Console.WriteLine("За допомогою масиву символiв");
                    Console.WriteLine(arrayWay(text));
                    Console.WriteLine();
                    Console.WriteLine("За допомогою колекцii List<T>");
                    Console.WriteLine(listWay(text));
                    Console.WriteLine();
                    goto start;
                case 0:
                    break;
            }
        }
    }
}
