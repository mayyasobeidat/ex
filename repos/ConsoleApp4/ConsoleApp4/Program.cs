using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{

    class Program
    {
        static void Main(string[] args)
        {
            string password = "512789436"; // كلمة المرور

            int totalTime = CalculatePasswordTime(password);

            Console.WriteLine("Total time to type the password: " + totalTime + " seconds");

        }

        static int CalculatePasswordTime(string password)
        {
            int totalTime = 0;
            char previousChar = '\0';

            foreach (char currentChar in password)
            {
                if (previousChar != '\0')
                {
                    int previousNumber = int.Parse(previousChar.ToString());
                    int currentNumber = int.Parse(currentChar.ToString());

                    int diffX = Math.Abs((previousNumber - 1) % 3 - (currentNumber - 1) % 3);
                    int diffY = Math.Abs((previousNumber - 1) / 3 - (currentNumber - 1) / 3);

                    int diff = Math.Max(diffX, diffY);
                    totalTime += diff;
                }

                totalTime++; // لكل حرف يتم كتابته يستغرق ثانية واحدة

                previousChar = currentChar;
            }

            return totalTime;
        }
    }

}
