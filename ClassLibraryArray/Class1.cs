using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryArray
{
    public class SingleArray
    {
        int[] a;

        public  SingleArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }

        public SingleArray(int n, int min, int step)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = min + step * i;
        }

        public SingleArray Inverse()
        {
            SingleArray b = new SingleArray(a.Length,0);
            for (int i = 0; i < a.Length; i++)
            {
                b.a[i] = -a[i];
            }
            return b;
        }

        public void Multi(int x)
        {
            for (int i = 0; i < this.a.Length; i++)
            {
                this.a[i] = this.a[i] * x;
            }
        }
        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }

        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max) count++;
                return count;
            }
        }

        public int Length
        {
            get
            {
                return a.Length;
            }
        }

        public Dictionary<int, int> ElementCount
        {
            get
            {
                Dictionary<int, int> keyValueCount = new Dictionary<int, int>();
                foreach (int i in a)
                {
                    if (keyValueCount.ContainsKey(i)) keyValueCount[i] += 1;
                    else keyValueCount.Add(i, 1);
                }
                return keyValueCount;
            }
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++) sum += a[i];
                return sum;
            }
        }

        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }
    }
}
