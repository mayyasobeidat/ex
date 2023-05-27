using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> arr = new List<int> { 2, 1, 2, 3, 4, 5, 2, 9 };
            int result = Operations(arr);
            Console.WriteLine("Coun operations: " + result);
        }
        public static int Operations(List<int> arr)
        {
            int[] numbers = arr.ToArray();
            char[] LH = new char[numbers.Length];
            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                LH[i] = 'L';
                if (i == numbers.Length - 1) { break; }
                LH[1] = 'H';
            }


            for (int i = 0; i < LH.Length; i++)
            {
                Console.WriteLine(LH[i]);
            }

            int c = 0;
            object[] narr = new object[numbers.Length];
            narr[0] = arr[0];
            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                if (LH[1] == 'L')
                {
                    if (numbers[i] >= numbers[i - 1])
                    {
                        narr[i] = '-';
                        c++;
                        if (i == numbers.Length - 1) { break; }
                        else
                        {
                            i++;
                            narr[i] = numbers[i];
                        }
                    }
                    else
                    {
                        narr[i] = numbers[i];
                    }
                }
                else
                {
                    if (numbers[i] < numbers[i - 1])
                    {
                        narr[i] = '+';
                        if (i == numbers.Length - 1) { break; }
                        else
                        {
                            i++;
                            narr[i] = numbers[i];
                        }
                        c++;
                    }
                    else
                        narr[i] = numbers[i];
                }
            }

            for (int i = 0; i < narr.Length; i++)
            {
                Console.WriteLine(narr[i]);
            }
            return c;
        }

    }
}
