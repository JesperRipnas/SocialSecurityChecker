using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics.CodeAnalysis;

namespace SocialSecurityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a social security number (YYYYMMDDNNNN): ");
                string userInput = Console.ReadLine();

                bool validLength = InputCheck(userInput);
                bool validYear = YearCheck(userInput);
                bool leapYear = LeapYearCheck(userInput);
                bool validMonth = MonthCheck(userInput);
                bool validDay = DayCheck(userInput, leapYear);
                bool validLastFour = LastFourCheck(userInput);
                bool validControlNumber = ControlNumberCheck(userInput);

                if (validLength && validYear && validMonth && validDay && validLastFour)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Social security number {userInput} is correct!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Social security number {userInput} is not correct, please try again!\n");
                    Console.ResetColor();
                }
                Debug(validLength, validYear, leapYear, validMonth, validDay, validLastFour, validControlNumber); // REMOVE WITH FINAL RELEASE
                Console.WriteLine("\nPress any key to search again or ctrl+c to quit");
                Console.ReadKey();
            }
        }
        // REMOVE WITH FINAL RELEASE
        static void Debug(bool validLength, bool validYear, bool leapYear, bool validMonth, bool validDay, bool validLastFour, bool validControlNumber)
        {
            Console.WriteLine("\n**********DEBUG**********");
            Console.WriteLine($"Length: {validLength}");
            Console.WriteLine($"Year: {validYear}");
            Console.WriteLine($"Leap Year: {leapYear}");
            Console.WriteLine($"Month: {validMonth}");
            Console.WriteLine($"Day: {validDay}");
            Console.WriteLine($"Last 4: {validLastFour}");
            Console.WriteLine($"Control Number: {validControlNumber}");
            Console.WriteLine("**********DEBUG**********");
            // END OF DEBUG
        }
        static bool InputCheck(string userInput)
        {
            if (userInput.Length == 12)
            {
                return true;
            }
            else if (userInput.Length < 12)
            {
                Console.WriteLine("(!) Too few numbers");
            }
            else if (userInput.Length > 12)
            {
                Console.WriteLine("(!) Too many numbers");
            }
            return false;
        }
        static bool YearCheck(string userInput) 
        {
            try
            {
                int year = Convert.ToInt32(userInput.Substring(0, 4));
                if (year >= 1753 && year <= 2020)
                {
                    return true;
                }
                Console.WriteLine($"(!) Incorrect year ({year})");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in year");
                return false;
            }
        }
        static bool LeapYearCheck(string userInput)
        {
            try
            {
                int year = Convert.ToInt32(userInput.Substring(0, 4));
                if (year % 400 == 0)
                {
                    return true;
                }
                else if (year % 100 == 0)
                {
                    return false;
                }
                else if (year % 4 == 0)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }
        static bool MonthCheck(string userInput) 
        {
            try
            {
                int month = Convert.ToInt32(userInput.Substring(4, 2));
                if (month >= 1 && month <= 12)
                {
                    return true;
                }
                Console.WriteLine($"(!) Incorrect month ({month})");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in month");
                return false;
            }
        }
        static bool DayCheck(string userInput, bool leapYear)
        {
            try
            {
                int month = Convert.ToInt32(userInput.Substring(4, 2));
                int day = Convert.ToInt32(userInput.Substring(6, 2));
                switch (month)
                {
                    case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                        if (day >= 1 && day <= 31)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"(!) Incorrect day ({day})");
                        }
                        break;
                    case 4: case 6: case 9: case 11:
                        if (day >= 1 && day <= 30)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        if (leapYear)
                        {
                            if (day >= 1 && day <= 29)
                            {
                                return true;
                            }
                        else if (!leapYear)
                            {
                                if (day >= 1 && day <= 28)
                                {
                                    return true;
                                }
                            }
                        }
                        else if (day >= 1 && day <= 28)
                        {
                            return true;
                        }
                        break;
                }
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in day");
                return false;
            }
            return false;
        }
        static bool LastFourCheck(string userInput) 
        {
            try
            {
                int lastFourNumbers = Convert.ToInt32(userInput.Substring(8, 4));
                return true;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in the last four numbers");
            }
            return false;
        }
        // METHOD TO CHECK THE CONTROL DIGIT IN THE SOOCIAL SECURITY NUMBER, USING THE LUHN ALGORITHM
        static bool ControlNumberCheck(string userInput) 
        {
            return false;
        }
    }
}
