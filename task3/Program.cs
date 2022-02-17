using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name{ get; set; }
    public string Surname { get; set; }
    public string University { get; set; }
    public string Direction { get; set; }
    public string Way { get; set; }
    public int Age { get; set; }
    public int Class { get; set; }
    public int Number { get; set; }
    public string  City { get; set; }

}
class Program
{
    static void Main(string[] args)
    {
        int numOfBachelors = 0;
        int numOfMasters = 0;
        int numOFStudentson5and6Class = 0;
        // Создадим необобщенный список
        IList<Student> list = new List<Student>();
        Dictionary<int, int> awd = new Dictionary<int, int> ();
        // Запомним время в начале обработки данных
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader("..\\..\\students.csv");
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                Student student = new Student();
                student.Name = s[1];
                student.Surname = s[0];
                student.University = s[2];
                student.Direction = s[3];
                student.Way = s[4];
                student.Age = int.Parse(s[5]);
                student.Class = int.Parse(s[6]);
                student.Number = int.Parse(s[7]);
                student.City = s[8];
                list.Add(student);
            }
            catch
            {
            }
        }
        sr.Close();

        foreach (Student student in list)
        {
            if (student.Class == 5 || student.Class == 6) numOFStudentson5and6Class++;
            if (student.Age >= 18 && student.Age <= 20)
            {
                if (awd.ContainsKey(student.Class)) awd[student.Class] += 1;
                else awd[student.Class] = 1;
            }
        }

        IEnumerable<Student> sortedEnumAge = list.OrderBy(x => x.Age);
        IList<Student> sortedListAge = sortedEnumAge.ToList();

        IEnumerable<Student> sortedEnumClassAndAge = list.OrderBy(x => x.Class).ThenBy(x => x.Age);
        IList<Student> sortedListClassAndAge = sortedEnumClassAndAge.ToList();

        Console.WriteLine("---------------------------------------------------------------------------------------");
        Console.WriteLine($"Студентов, учащихся на 5 и 6 курсах = {numOFStudentson5and6Class}");
        Console.WriteLine("---------------------------------------------------------------------------------------");
        Console.WriteLine("Курс | Студентов от 18 до 20 лет");
        foreach (KeyValuePair<int, int> kvp in awd)
        {
            Console.WriteLine("  {0}  |  {1}", kvp.Key, kvp.Value);
        }
        Console.WriteLine("---------------------------------------------------------------------------------------");
        Console.WriteLine("Список сортированный по возрасту студента\n");
        foreach (Student v in sortedListAge) Console.WriteLine($"{v.Name}|{v.Surname}|{v.University}|{v.Direction}|{v.Way}|{v.Age}|{v.Class}|{v.Number}|{v.City}");
        Console.WriteLine("---------------------------------------------------------------------------------------");
        Console.WriteLine("Список сортированный по курсу и возрасту студента\n");
        foreach (Student v in sortedListClassAndAge) Console.WriteLine($"{v.Name}|{v.Surname}|{v.University}|{v.Direction}|{v.Way}|{v.Age}|{v.Class}|{v.Number}|{v.City}");
        Console.WriteLine("---------------------------------------------------------------------------------------");
        Console.WriteLine("Время обработки");
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();
    }
}
