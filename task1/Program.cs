using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Type type = typeof(DateTime);
            foreach (var propertie in type.GetProperties())
                Console.WriteLine(propertie.Name);
            Console.ReadKey();
        }
    }
}
