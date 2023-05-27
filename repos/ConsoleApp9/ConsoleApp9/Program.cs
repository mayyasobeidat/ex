using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void FindZigZagSequence(List<int> a, int n)
        {
            a.Sort();
            int mid = (n + 1) / 2;
            Swap(a, mid, n - 1);

            int st = mid + 1;
            int ed = n - 1;
            while (st <= ed)
            {
                Swap(a, st, ed);
                st = st + 1;
                ed = ed - 1;
            }

            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                    Console.Write(" ");
                Console.Write(a[i]);
            }
            Console.WriteLine();
        }

        static void Swap(List<int> a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        static void Main(string[] args)
        {
            int test_cases;
            if (int.TryParse(Console.ReadLine(), out test_cases))
            {
                for (int cs = 1; cs <= test_cases; cs++)
                {
                    int n;
                    if (int.TryParse(Console.ReadLine(), out n))
                    {
                        List<int> a = new List<int>();
                        string[] input = Console.ReadLine().Split(' ');
                        for (int i = 0; i < n; i++)
                        {
                            int x;
                            if (int.TryParse(input[i], out x))
                                a.Add(x);
                        }
                        FindZigZagSequence(a, n);
                    }
                }
            }
        }

    }
}
