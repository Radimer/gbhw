/*
Евдокимов Семён Петрович
4. *Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:

<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:

Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task4
{
    internal class Program
    {

        static int InsertNumber()
        {
            int N;
            while (true)
            {
                Console.WriteLine("Введите количество учеников, которое не меньше 10, но не превосходит 100");
                N = int.Parse(Console.ReadLine());
                if (N >= 10 && N <= 100) break;
                else continue;
            }
               
            
            return N;
        }
        static string[] InsertData(int N)
        {
            Regex regex = new Regex(@"^[А-Я][а-я]{0,19}\s[А-Я][а-я]{0,14}\s[1-5]\s[1-5]\s[1-5]");
            string[] students = new string[N];
            for (int i = 0; i < N; i++)
            {
                string InsertString;
                while (true)
                {
                    Console.WriteLine("Введите данные об Ученике в формате Фамилия Имя оценки через пробелы");
                    InsertString = Console.ReadLine();
                    Console.Clear();
                    if (!regex.IsMatch(InsertString))
                        {
                        Console.WriteLine("Вы ввели неверные данные");
                        continue;
                        }
                    else break;
                }
                students[i] = InsertString;
            }
            return students;
        }

        static List<string> BaddestStudents(string[] insert)
        {
            double[] avg = new double[insert.Length];
            for (int i = 0; i < insert.Length; i++)
            {
                string[] element = insert[i].Split(' ');
                avg[i] = (double.Parse(element[2]) + double.Parse(element[3]) + double.Parse(element[4])) / 3;
            }
            double[] avgs = avg.Distinct().ToArray();
            Array.Sort(avgs);


            List<string> output = new List<string>();
            for (int i = 0; i < insert.Length; i++)
            {
                string[] element = insert[i].Split(' ');
                double tmp = (double.Parse(element[2]) + double.Parse(element[3]) + double.Parse(element[4])) / 3;
                if (tmp == avgs[0] || tmp == avgs[1] || tmp == avgs[2]) output.Add(insert[i]);
            }
            return output;
        }

            
        static void Main(string[] args)
        {
            BaddestStudents(InsertData(InsertNumber())).ForEach(Console.WriteLine);
            Console.ReadLine();
            

        }
    }
}
