using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = RemoveSpecialCharacters(input);
            Console.WriteLine(result);
        }

        //public static string RemoveSpecialCharacters(string input)
        //{
        //    return String.Concat(input.Where(x => Char.IsLetterOrDigit(x) || x == ' ' || x == '-' || x == '_'));
        //}

        //public static string RemoveSpecialCharacters(string input)
        //{
        //    string[] a = input.Split(new char[24] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '.', '[', ']', '{', '}', '<', '>', ',', '`', '~', '|', '+', '=', '?' });
        //    string res = "";
        //    for (int i = 0; i < a.Length; i++) res += a[i];
        //    return res;
        //}

        public static string RemoveSpecialCharacters(string input)
        {
            string text = "";
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || c == '_' || c == ' ' || c == '-')
                {
                    text += c;
                }
            }
            return text;
        }
    }

    
}
