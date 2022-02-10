using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    static class StaticClass
    {
        static public int CountPair(int[] arr)
        {
            if (arr == null)
            {
                return 0;
            }
            else
            {
                int count = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] % 3 == 0 && arr[i + 1] % 3 != 0 && arr[i] != 0 || arr[i] % 3 != 0 && arr[i + 1] % 3 == 0 && arr[i + 1] != 0) count++;
                }
                return count;
            }
            
        }

        static public int[] ReadArrayFromFile(string path)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);
                int lines = 0;
                while (sr.ReadLine() != null) lines++;
                sr.Close();
                int[] arr = new int[lines];
                sr = new StreamReader(path);
                for (int i = 0; i < lines; i++)
                {
                    arr[i] = int.Parse(sr.ReadLine());
                }
                sr.Close();
                return arr;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("Введите размер массива");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i<arr.Length; i++)
            {
                arr[i] = random.Next(0,100);
            }
            Console.WriteLine($"количество пар в массиве равно {StaticClass.CountPair(arr)}");
            Console.WriteLine("Введите путь до файла с массивом (Пример:   ..\\..\\MyArray.txt   )");
            string path = Console.ReadLine();
            Console.WriteLine($"количество пар в массиве равно {StaticClass.CountPair(StaticClass.ReadArrayFromFile(path))}");
            Console.ReadKey();
        }
    }
}
