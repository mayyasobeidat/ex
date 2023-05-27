using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> products = new List<string>()
        {
            "Productx",
            "Productxxxx",
            "Productx",
            "Productx",
            "Productxxx",
            "Productx",
            "Productxxx",
            "Productxxxx",
            "Product",
            "Productx"
        };

            string frequentProduct = FindFrequentProduct(products);
            int occurrences = CountOccurrences(products, frequentProduct);

            Console.WriteLine($"The most frequent product is '{frequentProduct}' with {occurrences} occurrences.");

            Console.WriteLine("Products that occurred once:");
            List<string> onceOccurringProducts = GetOnceOccurringProducts(products);
            foreach (string product in onceOccurringProducts)
            {
                Console.WriteLine($"{product} occurred once.");
            }

            string largestProduct = FindLargestProduct(products);
            Console.WriteLine($"The largest product name is '{largestProduct}'.");

            Console.ReadLine();
        }

        public static string FindFrequentProduct(List<string> products)
        {
            var productCounts = products.GroupBy(p => p)
                                        .Select(g => new { Product = g.Key, Count = g.Count() });

            var maxCount = productCounts.Max(p => p.Count);

            var frequentProduct = productCounts.Where(p => p.Count == maxCount)
                                                .Select(p => p.Product)
                                                .OrderBy(p => p)
                                                .FirstOrDefault();

            return frequentProduct;
        }

        public static int CountOccurrences(List<string> products, string product)
        {
            return products.Count(p => p == product);
        }

        public static List<string> GetOnceOccurringProducts(List<string> products)
        {
            var productCounts = products.GroupBy(p => p)
                                        .Select(g => new { Product = g.Key, Count = g.Count() });

            var onceOccurringProducts = productCounts.Where(p => p.Count == 1)
                                                    .Select(p => p.Product)
                                                    .ToList();

            return onceOccurringProducts;
        }

        public static string FindLargestProduct(List<string> products)
        {
            var largestProduct = products.OrderByDescending(p => p.Length)
                                        .ThenBy(p => p)
                                        .FirstOrDefault();

            return largestProduct;
        }
    }
}
