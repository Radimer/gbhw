using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryArray;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива:");
            int n = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Введите начальный элемент:");
            int begin = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Введите шаг:");
            int step = int.Parse(Console.ReadLine());
            Console.Clear();
            
            SingleArray a = new SingleArray(n, begin, step);
            Console.WriteLine("Ваш массив:");
            Console.WriteLine(a.ToString());
            Console.WriteLine("Сумма элементов массива:");
            Console.WriteLine(a.Sum);
            Console.WriteLine("Массив с инвертированными элементами:");
            Console.WriteLine(a.Inverse());
            Console.WriteLine("Введите множитель для элементов массива:");
            int multi = int.Parse(Console.ReadLine());
            a.Multi(multi);
            Console.WriteLine("Ваш массив умноженный на множитель:");
            Console.WriteLine(a.ToString());
            Console.WriteLine("Количество элементов максимального значения:");
            Console.WriteLine(a.MaxCount);
            Dictionary<int,int> b = a.ElementCount;
            string output = "";
            foreach (KeyValuePair<int, int> kv in b)
                output = output + " " + kv.Key.ToString() +":"+ kv.Value.ToString();
            Console.WriteLine("Количество элементов одинакового значения:");
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
