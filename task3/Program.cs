/*
Евдокимов Семён Петрович
3. Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Program
    {
        
        static bool Compare(char[] firstString, char[] secondString)

        {
            int count = 0;
            for (int i = 0; i < firstString.Length; i++)
            {
                int index = Array.IndexOf(secondString, firstString[i]);
                secondString = secondString.Where((val, idx) => idx != index).ToArray();
                count++;
            }
            if (secondString.Length == 0 && count == firstString.Length) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            Console.Title = "является ли слвоо перестановкой другого слова";
            Console.WriteLine("Введите первое слово");
            char[] firstString = Console.ReadLine().ToCharArray();

            Console.WriteLine("Введите второе слово");
            char[] secondString = Console.ReadLine().ToCharArray();
            Console.Clear();

            Console.WriteLine(Compare(firstString, secondString));
            Console.ReadLine();
        }

    }
}
