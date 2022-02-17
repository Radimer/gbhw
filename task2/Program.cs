using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DoubleBinary
{
    class Program
    {
        public delegate double Fun(double x);
        
        public static double Sin(double x)
        {
            return Math.Sin(x);
        }
        public static double Cos(double x)
        {
            return Math.Cos(x);
        }
        public static double Tan(double x)
        {
            return Math.Tan(x);
        }
        public static double Ctan(double x)
        {
            return 1/Math.Tan(x);
        }
        public static double Ln(double x)
        {
            return 1 / Math.Log(x);
        }
        public static double Extend(double x)
        {
            return 1 / Math.Exp(x);
        }
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * x * x + x * x;
        }

        public static double F3(double x)
        {
            return -x * -x * -x * -x;
        }

        public static void SaveFunc(string fileName, Fun F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
 
            double x = a;
            
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;
            }

            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double[] ReadValues = new double[fs.Length / sizeof(double)];
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                ReadValues[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return ReadValues;
        }
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^[1-9]");
            int func;
            double minSection, maxSection,x,h,min;
            while (true)
            {
                Console.WriteLine("Выберите функцию из нижеуказанных");
                Console.WriteLine("1. Sin(x)");
                Console.WriteLine("2. Cos(x)");
                Console.WriteLine("3. Tan(x)");
                Console.WriteLine("4. Ctan(x)");
                Console.WriteLine("5. Ln(x)");
                Console.WriteLine("6. Exp(x)");
                Console.WriteLine("7. x^2-50*x+10");
                Console.WriteLine("8. x^3+x^2");
                Console.WriteLine("9. -x^4");

                string selectFunction = Console.ReadLine();
                Console.Clear();
                if (regex.IsMatch(selectFunction))
                {
                    func = int.Parse(selectFunction);
                    break;
                }
                else Console.WriteLine("Введите корректную цифру");
            }

            while (true)
            {
                Console.WriteLine("Введите через пробел отрезок на котором искать минимум функции");
                string[] section = Console.ReadLine().Split(' ');
                Console.Clear();
                if (double.TryParse(section[0],out minSection)==true && double.TryParse(section[1], out maxSection) == true) break;
                else Console.WriteLine("Введите корректный отрезок");
            }

            while (true)
            {
                Console.WriteLine("Введите x");
                if (double.TryParse(Console.ReadLine(), out x)) break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введите корректный х");
                }
            }
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Введите шаг");
                if (double.TryParse(Console.ReadLine(), out h)) break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введите корректный шаг");
                }
            }
            Console.Clear();

            switch (func)
            {
                case 1:
                    SaveFunc("data.bin", new Fun(Sin), minSection, maxSection, h);
                    break;
                case 2:
                    SaveFunc("data.bin", new Fun(Cos), minSection, maxSection, h);
                    break;
                case 3:
                    SaveFunc("data.bin", new Fun(Tan), minSection, maxSection, h);
                    break;
                case 4:
                    SaveFunc("data.bin", new Fun(Ctan), minSection, maxSection, h);
                    break;
                case 5:
                    SaveFunc("data.bin", new Fun(Ln), minSection, maxSection, h);
                    break;
                case 6:
                    SaveFunc("data.bin", new Fun(Extend), minSection, maxSection, h);
                    break;
                case 7:
                    SaveFunc("data.bin", new Fun(F1), minSection, maxSection, h);
                    break;
                case 8:
                    SaveFunc("data.bin", new Fun(F2), minSection, maxSection, h);
                    break;
                case 9:
                    SaveFunc("data.bin", new Fun(F3), minSection, maxSection, h);
                    break;
            }
            Console.WriteLine($"Значения функции на отрезке от {minSection} до {maxSection} с шагом {h}\n");
            foreach (double val in Load("data.bin", out min)) Console.WriteLine(val);
            Console.WriteLine($"\nМинимум функции на отрезке от {minSection} до {maxSection} равен {min}");
            Console.ReadKey();
        }
    }
}
