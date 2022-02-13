/*
Евдокимов Семён Петрович
2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{

    static class Message
    {
        static public string WordLengthLessNum(string message, int n)
        {
            string[] words = message.Split(' ');
            for(int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > n) words[i] = null;
            }
            words = words.Where(word => word != null).ToArray();
            return string.Join(" ", words);
        }

        static public string DelWordIfEndingChar(string message, string c)
        {
            string[] words = message.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Substring(words[i].Length - 1) == c) words[i] = null;
            }
            words = words.Where(word => word != null).ToArray();
            return string.Join(" ", words);
        }

        static public string FirstLongestWord(string message)
        {
            string[] words = message.Split(' ');
            int length = 0;
            int n = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > length)
                {
                    length = words[i].Length;
                    n = i;
                }
            }
            return words[n];
        }

        static public string LongestWords(string message)
        {
            string[] words = message.Split(' ');
            int length = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > length) length = words[i].Length;
            }
            words = words.Where(word => word.Length == length).ToArray();
            return string.Join(" ", words);
        }

        static public string LongestWordsStringBuilder(string message)
        {
            StringBuilder sb  = new StringBuilder("");
            string[] words = message.Split(' ');
            int length = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > length) length = words[i].Length;
            }
            words = words.Where(word => word.Length == length).ToArray();
            foreach (string word in words)
            {
                sb.Append(word);
                sb.Append(" ");
            }
            return string.Join(" ", words);
        }
        
        static public string Frequence(string[] message, string text)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in message)
            {
                int count = 0;
                foreach (string word2 in source)
                    if (word.ToLowerInvariant() == word2.ToLowerInvariant()) count++;

                wordCount.Add(word, count);
            }
            string output = "";

            foreach (KeyValuePair<string, int> kv in wordCount)
                output = output + " " + kv.Key.ToString() + ":" + kv.Value.ToString();
            return output;
        }
        

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.Title = "Статический класс для обработки сообщений";
            Console.WriteLine("Введите сообщение");
            string insertString1 = Console.ReadLine();
            Console.WriteLine("Введите максимальное число букв в слове");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Message.WordLengthLessNum(insertString1, n));
            Console.ReadLine();
            */

            /*
            Console.WriteLine("Введите сообщение");
            string insertString2 = Console.ReadLine();
            Console.WriteLine("Введите символ на который оканчивается слово");
            string c = Console.ReadLine();
            Console.WriteLine(Message.DelWordIfEndingChar(insertString2, c));
            Console.ReadLine();
            */

            /*
            Console.WriteLine("Введите сообщение");
            string insertString3 = Console.ReadLine();
            Console.WriteLine(Message.LongestWord(insertString3));
            Console.ReadLine();
            */

            /*
            Console.WriteLine("Введите сообщение");
            string insertString4 = Console.ReadLine();
            Console.WriteLine(Message.LongestWordsStringBuilder(insertString4));
            Console.ReadLine();
            */

            Console.WriteLine("Введите слова для поиска через пробел");
            string[] insertString5 = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите тескст");
            string text = Console.ReadLine();
            Console.WriteLine(Message.Frequence(insertString5, text));
            Console.ReadLine();
        }
    }
}
