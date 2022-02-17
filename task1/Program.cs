using System;

public delegate double Fun(double a, double x);

class Program
{
    public static void Table(Fun F, double a, double x, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }

    public static double MyFunc(double x)
    {
        return x * x * x;
    }

    public static double FunctionOne(double a, double x)
    {
        return a * x * x;
    }

    public static double FunctionTwo(double a, double x)
    {
        return a * Math.Sin(x);
    }

    static void Main()
    {
        Console.Title = "Таблица функций a*x^2 и a*sin(x)";

        Console.WriteLine("Введите a, x и b через пробел:");
        string[] insert = Console.ReadLine().Split(' ');
        double a = double.Parse(insert[0]);
        double x = double.Parse(insert[1]);
        double b = double.Parse(insert[2]);

        Console.WriteLine("Функция a*x^2");
        Table(new Fun(FunctionOne), a, x, b);
        Console.WriteLine("Функция a*sin(x)");
        Table(new Fun(FunctionTwo), a, x, b);


        Console.ReadLine();
    }
}
