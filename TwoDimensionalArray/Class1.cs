using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDimensionalArray
{
    public class TwoDimArray
    {
        public int[,] a;

        public TwoDimArray(int i, int j)
        {
            a = new int[i, j];
        }
           
        public TwoDimArray(int n)
        {
            a = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(0,100);
        }


        public int Sum()
        {
            int sum = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    sum += a[i, j];
                }
            }
            return sum;
        }

        public int SumGreaterNumber(int number)
        {
            int sum = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j]>number) sum += a[i, j];
                }
            }
            return sum;
        }

        public void MaxCoordinates(out int x, out int y)
        {
            int max = a[0, 0];
            x = y = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                        x = i;
                        y = j;
                    }
        }

        public static TwoDimArray ReadFile(string path)
        {
            System.IO.StreamReader sr;
            int i = 0, j = 0;
            try
            {
                string line ="";
                sr = new System.IO.StreamReader(path);
                while (line != null)
                {
                    
                    line = sr.ReadLine();
                    if (line != null) 
                    {
                        j = line.Split(' ').Length;
                        i++;
                    }
                    else break;
                    
                }
                sr.Close();
                sr = new System.IO.StreamReader(path);
                TwoDimArray arr = new TwoDimArray(i,j);
                string varline = sr.ReadLine();
                int h = 0;
                do
                {
                    
                    string[] cv = varline.Split(' ');
                    for (int k = 0; k < cv.Length; k++)
                    {
                        arr.a[h, k] = int.Parse(cv[k]);
                    }
                    varline = sr.ReadLine();
                    h++;
                }
                while (varline != null);
          
                sr.Close();
                return arr;

            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static void WriteFile(string path, TwoDimArray a)
        {
            try
            {
                string lines = a.ToString();
                System.IO.File.WriteAllText(@path, lines);
            }
            catch (Exception err) 
            {
                Console.WriteLine(err.Message);
            }

        }

        public int Min
        {
            get
            {
                int min = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] < min) min = a[i, j];
                return min;
            }
        }
        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > max) max = a[i, j];
                return max;
            }
        }


        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    s += a[i, j] + " ";
                s += "\n"; 

            }
            return s;
        }
    }

}
