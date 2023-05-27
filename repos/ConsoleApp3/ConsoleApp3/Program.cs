using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Original array: " + string.Join(", ", array));

            int[] zigzagArray = ConvertToZigZag(array);


            Console.WriteLine("Zigzag array: " + string.Join(", ", zigzagArray));


            Console.ReadLine();
        }

        static int[] ConvertToZigZag(int[] array)
        {
            int n = array.Length;

            // Swap adjacent elements starting from the second element
            for (int i = 1; i < n - 1; i += 2)
            {
                int temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }

            return array;
        }
    }

}
