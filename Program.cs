//Евдокимов Семён Петрович
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Program
    {
        
        static string Min(string[] nums)
        {
            if (int.Parse(nums[0]) < int.Parse(nums[1]) && int.Parse(nums[0]) < int.Parse(nums[2])) return $"Минимальным является первое число равное {nums[0]}"; 
            else if (int.Parse(nums[1]) < int.Parse(nums[0]) && int.Parse(nums[1]) < int.Parse(nums[2])) return $"Минимальным является второе число равное {nums[1]}"; 
            else if (int.Parse(nums[2]) < int.Parse(nums[0]) && int.Parse(nums[2]) < int.Parse(nums[1])) return $"Минимальным является третье число равное {nums[2]}";
            else return "Нет одназначно минимального числа";
        }
        
        static int NumberCount(int num)
        {
            int i = 0;
            while (num > 0)
            {
                num /= 10;
                i++;
            }
            return i;
        }

        static bool Auth(string login, string password)
        {
            if (login == "root" && password == "GeekBrains") return true;
            else return false;
        }

        static void BodyMassIndex(double weight, double height)
        {
            double index = weight / (height * height);
            if (index >= 25)
            {
                Console.WriteLine($"Вам нужно похудеть на {weight - (25 * (height * height))} килограмм");
            }
            else if (index < 18.5)
            {
                Console.WriteLine($"Вам нужно набрать {(18.5 * (height * height)) - weight} килограмм");
            }
            else
            {
                Console.WriteLine($"Всё в норме");
            }
        }

        static int SumNumbers(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += (n % 10);
                n /= 10;
            }
            return sum;
        }

        static string Recurse(int a, int b, int s = 0)
        {
            Console.WriteLine(a);
            s += a;
            if (a < b) return Recurse(a + 1, b, s);
            else return $"сумма всех членов в диапазоне от a до b равна {s}";
        }
        static void Main(string[] args)
        {
            //1. Написать метод, возвращающий минимальное из трёх чисел.
            System.Console.Write("Введите 3 числа разделенные пробелами: ");
            string[] nums = System.Console.ReadLine().Split(' ');
            System.Console.Clear();
            System.Console.WriteLine(Min(nums));
            System.Console.ReadLine();
            System.Console.Clear();

            //2. Написать метод подсчета количества цифр числа.
            Console.Write("Введите число для подсчета цифр: ");
            int num = int.Parse(Console.ReadLine());
            System.Console.Clear();
            System.Console.WriteLine($"Количество цифр в введенном числе равно {NumberCount(num)}");
            System.Console.ReadLine();
            System.Console.Clear();

            //3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
            int Number, Sum = 0;
            do
            {
                Console.Write("Введите число: ");
                Number = int.Parse(Console.ReadLine());
                if (Number % 2 == 1)
                {
                    Sum += Number;
                }

            } while (Number != 0);

            Console.Write($"Сумма нечетных положительных чисел равна {Sum}");
            System.Console.ReadLine();
            System.Console.Clear();


            //4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
            //На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
            //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
            //С помощью цикла do while ограничить ввод пароля тремя попытками.

            bool authorizate = false;

            while (authorizate == false)
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                System.Console.Clear();
                Console.Write("Введите пароль: ");

                for (int i = 0; i < 3; i++)
                {
                    string password = Console.ReadLine();
                    System.Console.Clear();
                    if (Auth(login, password) == true)
                    {
                        authorizate = true;
                        break;
                    }
                    else
                    {
                        if (i < 2) Console.Write("Пароль не подходит \nВведите пароль: ");
                        else
                        {
                            Console.Write("Вы исчерпали количество попыток для повтора нажмите Enter");
                            System.Console.ReadLine();
                            System.Console.Clear();
                        }
                    }    
                }
                System.Console.Clear();
            }
            Console.Write("Вы успешно вошли!");
            System.Console.ReadLine();
            System.Console.Clear();


            //а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

            Console.Write("Введите свой вес в килограммах: ");
            double weight = double.Parse(Console.ReadLine());
            System.Console.Clear();
            Console.Write("Введите свой рост в метрах: ");
            double height = double.Parse(Console.ReadLine());
            System.Console.Clear();
            BodyMassIndex(weight, height);
            System.Console.ReadLine();
            System.Console.Clear();


            //6. * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
            //«Хорошим» называется число, которое делится на сумму своих цифр.
            //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

            Console.Write("Пожалуйста подождите идет подсчет количества чисел харшад... ");
            int j = 0;
            DateTime startdate = DateTime.Now;
            for (int i = 1; i <= 1000000000; i++)
            {
                if (i % SumNumbers(i) == 0) j++;
            }
            DateTime endtime = DateTime.Now;
            TimeSpan worktime = endtime.Subtract(startdate);
            System.Console.Clear();
            Console.Write($"В 1 000 000 000 найдено {j} 'хороших' чисел за {worktime.Hours} часов {worktime.Minutes} минут {worktime.Seconds} секунд и {worktime.Milliseconds} милисекунд");
            System.Console.ReadLine();
            System.Console.Clear();


            //7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).
            //   б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
            int a, b, s = 0;
            while (true)
            {
                Console.Write("Введите a: ");
                a = int.Parse(Console.ReadLine());
                System.Console.Clear();
                Console.Write("Введите b: ");
                b = int.Parse(Console.ReadLine());
                System.Console.Clear();
                if (a < b) break;
                else Console.Write("a должно быть меньше b");
            }
            System.Console.WriteLine(Recurse(a, b, s));
            System.Console.ReadLine();
            System.Console.Clear();

        }
    }
}
