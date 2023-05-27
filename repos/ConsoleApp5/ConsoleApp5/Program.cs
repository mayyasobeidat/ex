using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string sentence = "I am searching for Nemo in the ocean";
            string sentence = Console.ReadLine();
            string result = FindNemo(sentence);
            Console.WriteLine(result);
            
        }

        //public static string FindNemo(string sentence)
        //{
        //    var index = Array.IndexOf(sentence.Split(' '), "Nemo");
        //    if (index < 0) return "I can't find Nemo :(";
        //    return $"I found Nemo at {index + 1}!";
        //}

        public static string FindNemo(string sentence)
        {
            string[] arr = sentence.Split();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "Nemo")
                {
                    return "I found Nemo at " + (i + 1) + "!";
                }
            }
            return "I can't find Nemo :(";
        }
    }
    
}
