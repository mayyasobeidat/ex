using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        public static string featuredProduct(List<string> products)
        {
            string[] prod1 = products.ToArray();
            string[] prod = new string[prod1.Length];
            int[] prodQun = new int[prod1.Length];
            int index = 0;
            for (int i = 0; i < prod1.Length - 1; i++)
            {
                int c = 1;
                for (int j = i + 1; j < prod1.Length; j++)
                {
                    if (prod1[i] == prod1[j])
                    {
                        c++;
                    }
                }
                bool ex = false;
                if (c > 1)
                {
                    for (int h = 1 + i; h < prod1.Length; h++)
                    {
                        if (prod1[i] == prod[h])
                        {
                            ex = true;
                            break;
                        }
                    }
                    if (ex == false)
                    {
                        prod[index] = prod1[i];
                        prodQun[index] = c;
                        index++;
                    }
                }
            }
            int max = 0;
            for (int i = 0; i < prodQun.Length; i++)
            {
                if (prodQun[i] > max)
                {
                    max = prodQun[i];
                }
            }
            int leng = 0;
            for (int i = 0; i < prodQun.Length; i++)
            {
                if (prodQun[i] == max)
                {
                    leng++;
                }

            }

            int g = 0;
            string[] finalProduct = new string[leng];

            for (int i = 0; i < prodQun.Length; i++)
            {
                if (prodQun[i] == max)
                {
                    finalProduct[g] = prod[i];
                    g++;
                }
            }
            for (int i = 0; i < finalProduct.Length - 1; i++)
            {
                int al = finalProduct[i].Length;
                int a2 = finalProduct[i + 1].Length;
                int n = 0;
                if (al < a2)
                {
                    n = al;
                }
                else
                {
                    n = a2;
                }
                for (int j = 0; j<n; j++)
                {
                    if (finalProduct[i][j] > finalProduct[i + 1][j])
                    {
                        string temp = finalProduct[i];
                        finalProduct[i] = finalProduct[i + 1];
                        finalProduct[i + 1] = temp;
                        break;
                    }
                }
            }
            return finalProduct[finalProduct.Length - 1];
        }






        //static void Main(string[] args)
        //{
        //    List<string> products = new List<string>() { "Apple", "Banana", "Apple", "Orange", "Banana", "Grapes" };

        //    string featured = featuredProduct(products);
        //    Console.WriteLine("Featured product: " + featured);
        //}

        public static List<(string Product, int Count)> FindRepeatedProducts(List<string> products)
        {
            var productCounts = products.GroupBy(p => p)
                                        .Select(g => (Product: g.Key, Count: g.Count()))
                                        .Where(p => p.Count > 1)
                                        .OrderBy(p => p.Product)
                                        .ToList();

            return productCounts;
        }

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

            List<(string Product, int Count)> repeatedProducts = FindRepeatedProducts(products);

            foreach (var product in repeatedProducts)
            {
                Console.WriteLine($"Product: {product.Product}, Count: {product.Count}");
            }

            Console.ReadLine();
        }


    }
}
