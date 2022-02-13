using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hw5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Проверка кооретного пароля";


            Console.WriteLine(@"Введите пароль соответствующий следуюшим параметрам 
    1.Длинна строки от 2 до 10 символов
    2.Сожержит толко буквы латинского алфавита или цифры
    3.Цифра не должна быть первым символом");
            char[] inputString = Console.ReadLine().ToCharArray();

            bool[] condition = { true, true, true };

            if (2 > inputString.Length || inputString.Length > 10) condition[0] = false;

            int asciiFirst = inputString[0];
            if (asciiFirst < 65 || asciiFirst > 90 && asciiFirst < 97 || asciiFirst > 122) condition[2] = false;

            for (int i = 0; i < inputString.Length; i++)
            {
                int asciin = inputString[i];
                if ((asciin < 48 || asciin > 58 && asciin < 65 || (asciin > 90 && asciin < 97) || asciin > 122)) condition[1] = false;
            }

            if (condition[0] && condition[1] && condition[2]) Console.WriteLine($"Введенный пароль соответствует всем условиям");
            else Console.WriteLine($"Введенный пароль не соответствует{(condition[0] ? "" : " первому")}{(condition[1] ? "" : " второму")}{(condition[2] ? "" : " третьему")} условиям");
            Console.ReadLine();
            Console.Clear();


            Regex myReg = new Regex(@"^[A-Za-z][A-Za-z0-9]{1,9}");
            Console.WriteLine(@"Введите пароль соответствующий следуюшим параметрам 
    1.Длинна строки от 2 до 10 символов
    2.Сожержит толко буквы латинского алфавита или цифры
    3.Цифра не должна быть первым символом");
            string inputString2 = Console.ReadLine();
            if (myReg.IsMatch(inputString2)) Console.WriteLine($"Введенный пароль соответствует всем условиям");
            else Console.WriteLine($"Введенный пароль не соответствует условиям");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
