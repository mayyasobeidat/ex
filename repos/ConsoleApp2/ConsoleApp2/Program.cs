using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string sentence = "This is a sample sentence (with numbers 123) and {brackets [123]} []";
            int wordCount = CountWords(sentence);
            Console.WriteLine( "Number of words: " +  wordCount );
        }

        public static int CountWords(string sentence)
        {
            char[] delimiters = { ' ', '(', ')', '{', '}', '[', ']' };
            string[] words = sentence.Split(delimiters);
            int count = 0;

            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word) && !ContainsNumber(word))
                {
                    count++;
                }
            }

            return count;
        }

        public static bool ContainsNumber(string word)
        {
            foreach (char c in word)
            {
                if (Char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
