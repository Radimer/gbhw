using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Program
    {
        static int[] GenerateArray()
        {
            int[] array = new int[20];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
            return array;
        }
        static void PrintArray(int[] arr)
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"{arr[i]}");
                }
            }

        }
        static int CountPair(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 && arr[i + 1] % 3 != 0 && arr[i] != 0 || arr[i] % 3 != 0 && arr[i + 1] % 3 == 0 && arr[i + 1] != 0) count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"количество пар равно {CountPair(GenerateArray())}");
            Console.ReadLine();
        }
    }
}
