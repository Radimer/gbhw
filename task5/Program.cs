using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoDimensionalArray;

namespace task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите размерность массива:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("введите нижний порог подсчета суммы:");
            int greater = int.Parse(Console.ReadLine());

            TwoDimArray a = new TwoDimArray(n);

            Console.WriteLine(a.ToString());
            Console.WriteLine($"сумма элементов массива равна:{a.Sum()}");
            Console.WriteLine($"сумма элементов массива больше порога равна:{a.SumGreaterNumber(greater)}");
            Console.WriteLine($"максимальный элекмент {a.Max}");
            Console.WriteLine($"минимальный элекмент {a.Min}");
            int x;
            int y;
            a.MaxCoordinates(out x, out y);
            Console.WriteLine($"координаты максимального элекмента {x},{y}");
            Console.ReadLine();
            string path = "..\\..\\ReadArray.txt";
            Console.WriteLine($"Путь к файлу для чтения{path}");
            Console.WriteLine(TwoDimArray.ReadFile(path).ToString());
            Console.ReadLine();

            string path2 = "..\\..\\WriteArray.txt";
            Console.WriteLine($"Путь к новому файлу {path2}");
            TwoDimArray.WriteFile(path2, a);
        }
    }
}
