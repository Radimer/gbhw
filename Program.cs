using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    struct ComplexStructure
    {
        public double im;
        public double re;
        public ComplexStructure Plus(ComplexStructure x)
        {
            ComplexStructure y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public ComplexStructure Minus(ComplexStructure x)
        {
            ComplexStructure y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public ComplexStructure Multi(ComplexStructure x)
        {
            ComplexStructure y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public new string ToString()
        {
            if (im == -1 && re != 0) return $"{re}-i";
            else if (im == 1 && re != 0) return $"{re}+i";
            else if (im == -1 && re == 0) return $"-i";
            else if (im == 1 && re == 0) return $"+i";
            else if (im > 0 && re != 0) return $"{re}+{im}i";
            else if (im < 0 && re != 0) return $"{re}{im}i";
            else if (im == 0 && re != 0) return $"{re}";
            else if (im == 0 && re == 0) return $"0";
            else return $"{im}i";
        }
    }

    class ComplexClass
    {
        public double im;
        public double re;

        public ComplexClass Plus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }
        public ComplexClass Minus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = im - x2.im;
            x3.re = re - x2.re;
            return x3;
        }
        public ComplexClass Multi(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = re * x2.im + im * x2.re;
            x3.re = re * x2.re - im * x2.im;
            return x3;
        }
        public double Im
        {
            get { return im; }
            set { im = value; }
        }
        public double Re
        {
            get { return re; }
            set { re = value; }
        }
        public new string ToString()
        {
            if (im == -1 && re != 0) return $"{re}-i";
            else if (im == 1 && re != 0) return $"{re}+i";
            else if (im == -1 && re == 0) return $"-i";
            else if (im == 1 && re == 0) return $"+i";
            else if (im > 0 && re != 0) return $"{re}+{im}i";
            else if (im < 0 && re != 0) return $"{re}{im}i";
            else if (im == 0 && re != 0) return $"{re}";
            else if (im == 0 && re == 0) return $"0";
            else return $"{im}i";
        }
    }

    class RatioClass
    {
        public int numerator;
        public int denominator;

        public RatioClass Plus(RatioClass x)
        {
            RatioClass y = new RatioClass();
            y.numerator = (numerator * x.denominator) + (x.numerator * denominator);
            y.denominator = denominator * x.denominator;
            return y;
        }

        public RatioClass Minus(RatioClass x)
        {
            RatioClass y = new RatioClass();
            y.numerator = (numerator * x.denominator) - (x.numerator * denominator);
            y.denominator = denominator * x.denominator;
            return y;
        }
        public RatioClass Multi(RatioClass x)
        {
            RatioClass y = new RatioClass();
            y.numerator = numerator * x.numerator;
            y.denominator = denominator * x.denominator;
            return y;
        }
        public RatioClass Divide(RatioClass x)
        {
            RatioClass y = new RatioClass();
            y.numerator = numerator * x.denominator;
            y.denominator = denominator * x.numerator;
            return y;
        }
        public string Simplification()
        {
            return $"{numerator / GreatestCommonDivisor()}/{denominator / GreatestCommonDivisor()}";
        }
        public int GreatestCommonDivisor()
        {
            List<int> GCD = new List<int>();
            GCD.Add(numerator > denominator ? numerator : denominator);
            GCD.Add(numerator > denominator ? denominator : numerator);
            int i = 0;
            do
            {
                GCD.Add(GCD[i] % GCD[i + 1]);
                i++;
            }
            while (GCD[GCD.Count - 1] != 0);
            return GCD[GCD.Count - 2];
        }
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }

        }
        public int Denumerator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                else denominator = value;
            }

        }
        public double Decimal
        {
            get { return Convert.ToDouble(numerator) / Convert.ToDouble(denominator); }
        }
        public new string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }
    internal class Program
    {
        public static int SumOddPositive()
        {
            int sum = 0;
            int num;
            
            do
            {
                Console.WriteLine("Вводите числа через Enter для завершение введите 0");
                
                if (int.TryParse(Console.ReadLine(), out num) == true)
                {
                    if (num % 2 == 1)
                    {
                        sum += num;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели некоректное число, для продолжения нажмите Enter");
                    num = num + 1;
                    Console.ReadLine();
                }
                Console.Clear();
            }
            while (num != 0);
            return sum;
        }
        static void Main(string[] args)
        {
            Console.Title = "Lesson3";
            while(true)
            {
                Console.WriteLine("Введите номер задания:");
                int selectTask = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (selectTask)
                {
                    case 1:
                        Console.WriteLine("Введите структура или класс");
                        string selectstructorclass = Console.ReadLine();
                        Console.Clear();
                        switch (selectstructorclass)
                        {
                            case "структура":
                                Console.WriteLine("Введите вещественную и мнимую часть первого комплексного числа через пробел:");
                                string[] firstStructComplex = System.Console.ReadLine().Split(' ');
                                Console.Clear();
                                Console.WriteLine("Введите вещественную и мнимую часть второго комплексного числа через пробел:");
                                string[] secondStructComplex = System.Console.ReadLine().Split(' ');
                                Console.Clear();

                                ComplexStructure complexStruct1;
                                complexStruct1.re = double.Parse(firstStructComplex[0]);
                                complexStruct1.im = double.Parse(firstStructComplex[1]);

                                ComplexStructure complexStruct2;
                                complexStruct2.re = double.Parse(secondStructComplex[0]);
                                complexStruct2.im = double.Parse(secondStructComplex[1]);

                                ComplexStructure resultStructureMinus = complexStruct1.Minus(complexStruct2);
                                Console.WriteLine($"Разница введеных комлексных чисел равна {resultStructureMinus.ToString()}");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "класс":
                                Console.WriteLine("Введите вещественную и мнимую часть первого комплексного числа через пробел:");
                                string[] firstClassComplex = System.Console.ReadLine().Split(' ');
                                Console.Clear();
                                Console.WriteLine("Введите вещественную и мнимую часть второго комплексного числа через пробел:");
                                string[] secondClassComplex = System.Console.ReadLine().Split(' ');
                                Console.Clear();

                                ComplexClass complexClass1 = new ComplexClass
                                {
                                    re = double.Parse(firstClassComplex[0]),
                                    im = double.Parse(firstClassComplex[1])
                                };

                                ComplexClass complexClass2 = new ComplexClass
                                {
                                    re = double.Parse(secondClassComplex[0]),
                                    im = double.Parse(secondClassComplex[1])
                                };

                                Console.WriteLine("Введите номер действия которое вы хотите произвести.\n1.Сложить\n2.Вычесть\n3.Умножить\n");
                                int selectActionComplex = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (selectActionComplex)
                                {
                                    case 1:
                                        ComplexClass resultClassPlus = complexClass1.Plus(complexClass2);
                                        Console.WriteLine($"Сумма введеных комлексных чисел равна {resultClassPlus.ToString()}");
                                        break;
                                    case 2:
                                        ComplexClass resultClassMinus = complexClass1.Minus(complexClass2);
                                        Console.WriteLine($"Разница введеных комлексных чисел равна {resultClassMinus.ToString()}");
                                        break;
                                    case 3:
                                        ComplexClass resultClassMulti = complexClass1.Multi(complexClass2);
                                        Console.WriteLine($"Произведение введеных комлексных чисел равна {resultClassMulti.ToString()}");
                                        break;
                                }
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Сумма введеных нечетных положительных чисел равна {SumOddPositive()}");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Введите первую дробь:");
                        string[] firstRatio = System.Console.ReadLine().Split('/');
                        Console.Clear();
                        Console.WriteLine("Введите вторую дробь:");
                        string[] secondRatio = System.Console.ReadLine().Split('/');
                        Console.Clear();

                        RatioClass Ratio1 = new RatioClass
                        {
                            Numerator = int.Parse(firstRatio[0]),
                            Denumerator = int.Parse(firstRatio[1])
                        };

                        RatioClass Ratio2 = new RatioClass
                        {
                            Numerator = int.Parse(secondRatio[0]),
                            Denumerator = int.Parse(secondRatio[1])
                        };

                        Console.WriteLine("Введите номер действия которое вы хотите произвести.\n1.Сложить\n2.Вычесть\n3.Умножить\n4.Делить\n");
                        int selectActionRatio = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (selectActionRatio)
                        {
                            case 1:
                                RatioClass resultRatioPlus = Ratio1.Plus(Ratio2);
                                Console.WriteLine($"Сумма дробей равна {resultRatioPlus.ToString()} упрощенная дробь {resultRatioPlus.Simplification()} в десятичном виде {resultRatioPlus.Decimal}");
                                break;
                            case 2:
                                RatioClass resultRatioMinus = Ratio1.Minus(Ratio2);
                                Console.WriteLine($"Сумма дробей равна {resultRatioMinus.ToString()} упрощенная дробь {resultRatioMinus.Simplification()} в десятичном виде {resultRatioMinus.Decimal}");
                                break;
                            case 3:
                                RatioClass resultRatioMulti = Ratio1.Multi(Ratio2);
                                Console.WriteLine($"Сумма дробей равна {resultRatioMulti.ToString()} упрощенная дробь {resultRatioMulti.Simplification()} в десятичном виде {resultRatioMulti.Decimal}");
                                break;
                            case 4:
                                RatioClass resultRatioDivide = Ratio1.Divide(Ratio2);
                                Console.WriteLine($"Сумма дробей равна {resultRatioDivide.ToString()} упрощенная дробь {resultRatioDivide.Simplification()} в десятичном виде {resultRatioDivide.Decimal}");
                                break;
                        }
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
