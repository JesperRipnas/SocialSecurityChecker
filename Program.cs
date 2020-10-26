using System;
using System.Diagnostics.CodeAnalysis;

namespace SocialSecurityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Validera Personnummer (yyyymmnnnc)
                Check correct amount of numbers
                Year 1753 - 2020
                Month 1-12
                Validate that each month has the correct amount of days
                Birthnumber (nnn) should be between 0-999
                Check gender (if 0 = women)
                Program should display if the social security number is correct + gender
                Check leap year

                * control number (c) will be calculated with Luhn-algoritm
                * User can enter either 10 or 12 numbers
                * error handling (incorrect input)
                * 
                string year = userInput.Substring(0, 4);
                string month = userInput.Substring(4, 2);
                string day = userInput.Substring(6, 2);
                string birthNumber = userInput.Substring(8, 3);

                Console.WriteLine(year);
                Console.WriteLine(month);
                Console.WriteLine(day);
                Console.WriteLine(birthNumber);
             */
            while (true)
            {
                Console.Write("Ange personnummer (YYYYMMNNNN): ");
                string userInput = Console.ReadLine();

                bool validLength = InputCheck(userInput);
                bool validYear = YearCheck(userInput);

                if (validLength && validYear)
                {
                    Console.WriteLine("Your social security number is correct!");
                }
            }
        }
        static bool InputCheck(string userInput) // 12 NUMBERS (L2 = 10 OR 12 NUMBERS | ERROR HANDLING)
        {
            int length = userInput.Length;
            if (length == 12)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect amount of numbers, please try again!");
                return false;
            }
        }
        static bool YearCheck(string userInput) // BETWEEN 1753 - 2020
        {
            int year = Convert.ToInt32(userInput.Substring(0, 4));
            if (year >= 1753 && year <= 2020)
            {
                return true;
            }
            Console.WriteLine("Incorrect year, try again!");
            return false;
        }
        static bool MonthCheck() // AMOUNT OF DAYS + LEAP YEAR CHECK
        {
            return false;
        }
        static bool BirthNrCheck() // NUMBER BETWEEN 0-999
        {
            return false;
        }
        static bool ControlNrCheck() // LUHN ALGORITHM
        {
            return false;
        }
    }
}
