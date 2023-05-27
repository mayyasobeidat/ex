using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>()
        {
            "Apple",
            "Banana",
            "Orange",
            "Apple",
            "Grapes",
            "Watermelon",
            "Strawberry",
            "Mango",
            "Banana",
            "Pineapple"
        };

            string mostFrequentProduct = FindMostFrequentProduct(products);
            string largestNameProduct = FindLargestNameProduct(products);

            Console.WriteLine("Most frequent product: " + mostFrequentProduct);
            Console.WriteLine("Product with the largest name: " + largestNameProduct);

            Console.ReadLine();
        }

        static string FindMostFrequentProduct(List<string> products)
        {
            var frequencyCount = products.GroupBy(p => p)
                                         .OrderByDescending(g => g.Count());
            return frequencyCount.First().Key;
        }

        static string FindLargestNameProduct(List<string> products)
        {
            return products.OrderBy(p => p.Length)
                           .Last();
        }
    }
}
