using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public struct Account
    {
        public string Login;
        public string Password;

        public Account(string _login, string _password)
        {
            Login = _login;
            Password = _password;
        }

        static public bool Auth(Account insert)
        {
            string[] etalon = ReadDataFromFile();
            if (insert.Login == etalon[0] && insert.Password == etalon[1]) return true;
            else return false;

        }
        static public string[] ReadDataFromFile()
        {
            System.IO.StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader("..\\..\\Auth.txt");
                string[] arr = sr.ReadLine().Split(':');
                sr.Close();
                return arr;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool authorized = false;
            Console.WriteLine("Введите логин:");
            string Login = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите пароль:");
                string Password = Console.ReadLine();
                Account insert = new Account(Login, Password);
                if (Account.Auth(insert) == true)
                {
                    Console.WriteLine("Вы успешно авторизовались!");
                    Console.ReadLine();
                    authorized = true;
                    break;
                }
                
            }
            if (!authorized)
            {
                Console.WriteLine("Вы исчерпали количество попыток!");
                Console.ReadLine();
            }
        }
    }
}
