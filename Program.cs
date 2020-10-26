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
                // ASK USER FOR A INPUT AND SAVES IT AS A STRING IN userInput
                Console.Write("Enter a social security number (YYYYMMDDNNNN): ");
                string userInput = Console.ReadLine();
                // BOOL VARIABLES CONNECTED TO RETURNS FROM THE METHODS
                bool validLength = InputCheck(userInput);
                bool validYear = YearCheck(userInput);
                bool validMonth = MonthCheck(userInput);
                bool validDay = DayCheck(userInput);
                bool validNumbers = BirthNrCheck(userInput);
                // IF ALL VARIBLES COMES BACK TRUE BELOW, THE SOCIAL SECURITY NUMBER IS CORRECT
                if (validLength && validYear && validMonth && validDay && validNumbers)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your social security number is correct!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your social security number is not correct!\n");
                    Console.ResetColor();
                }
            }
        }
        // METHOD TO CHECK THAT THE INPUT PROVIDED BY THE USER IS 12 CHARACTERS, IF NOT A ERROR IS DISPLAYED AND USER HAS TO REENTER THE SOCIAL SECURITY NUMBER
        static bool InputCheck(string userInput)
        {
            if (userInput.Length == 12)
            {
                return true;
            }
            else if (userInput.Length < 12)
            {
                Console.WriteLine("(!) Too few numbers, please try again!");
            }
            else if (userInput.Length > 12)
            {
                Console.WriteLine("(!) Too many numbers, please try again!");
            }
            return false;
        }
        // METHOD TO CHECK THAT THE INPUT YEAR IS BETWEEN 1753 - 2020, ALSO HAVE ERROR HANDLING IF USER INPUTS INCORRECT INPUTS LIKE *"%#¤! OR LETTERS
        static bool YearCheck(string userInput) 
        {
            try
            {
                int year = Convert.ToInt32(userInput.Substring(0, 4));
                if (year >= 1753 && year <= 2020)
                {
                    return true;
                }
                Console.WriteLine($"(!) Incorrect year ({year}), try again!");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in year, try again!");
                return false;
            }
        }
        // METHOD TO CHECK THAT THE MONTH INPUT IS BETWEEN 1-12 (JAN-DEC), ALSO HAVE ERROR HANDLING IF USER INPUTS INCORRECT INPUTS LIKE *"%#¤! OR LETTERS
        static bool MonthCheck(string userInput) 
        {
            try
            {
                int month = Convert.ToInt32(userInput.Substring(4, 2));
                if(month >= 1 && month <= 12)
                {
                    return true;
                }
                Console.WriteLine($"(!) Incorrect month ({month}), try again!");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in month, try again!");
                return false;
            }
        }
        // METHOD TO CHECK THAT THE DAY USER HAS TYPED IS CORRECT VS THE MONTH
        static bool DayCheck(string userInput)
        {
            try
            {
                int year = Convert.ToInt32(userInput.Substring(0, 4));
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
                            Console.WriteLine($"(!) Incorrect day ({day}), try again!");
                        }
                        break;
                    case 4: case 6: case 9: case 11:
                        if (day >= 1 && day <= 30)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"(!) Incorrect day number ({day}), try again!");
                        }
                        break;
                    case 2:
                        if (year % 400 == 0)
                        {
                            if (day >= 1 && day <= 29)
                            {
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"(!) Incorrect day number ({day}). {year} is not a leap year, try again!");
                            }
                            return false;
                        }
                        else if (year % 100 == 0)
                        {
                            if(day >= 1 && day <= 28)
                            {
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"(!) Incorrect day number ({day}). {year} is not a leap year, try again!");
                            }
                            return false;
                        }
                        else if (year % 4 == 0)
                        {
                            if(day >= 1 && day <= 29)
                            {
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"(!) Incorrect day number ({day}). {year} is not a leap year, try again!");
                            }
                            return false;
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect amount of days ({day}) in February, not a leap year");
                            return false;
                        }
                }
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in day, try again!");
                return false;
            }
            return false;
        }
        // METHOD TO CHECK IF THE LAST 4 NUMBERS ARE IN THE CORRECT FORM, ALSO CHECKS IF THE 3TH NUMBER IS ODD OR EVEN (ODD = MALE, EVEN = FEMALE, 0 = FEMALE)
        static bool BirthNrCheck(string userInput) 
        {
            try
            {
                int genderNumber = Convert.ToInt32(userInput.Substring(10, 1));
                if (genderNumber % 2 == 0)
                {
                    Console.WriteLine("Gender: Kvinna");
                }
                else
                {
                    Console.WriteLine("Gender: Man");
                }
                return true;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in the last four numbers, try again!");

            }
            return false;
        }
    }
}
