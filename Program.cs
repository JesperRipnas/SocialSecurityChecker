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
                // BOOL VARIABLES THAT CHANGE BASED ON THE RETURNS FROM THE METHODS
                bool validLength = InputCheck(userInput);
                bool validYear = YearCheck(userInput);
                bool validMonth = MonthCheck(userInput);
                bool validDay = DayCheck(userInput);
                bool validLastFour = LastFourCheck(userInput);
                // IF ALL VARIBLES COMES BACK TRUE BELOW, THE SOCIAL SECURITY NUMBER IS CORRECT, ALSO CHECK THE GENDER BASED ON THE SECOND TO LAST NUMBER. EVEN = FEMALE, ODD = MALE. 
                try
                {
                    int genderNumber = Convert.ToInt32(userInput.Substring(10, 1));
                    if (validLength && validYear && validMonth && validDay && validLastFour)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Social security number {userInput} is correct!");
                        if (genderNumber % 2 == 0)
                        {
                            Console.WriteLine("Gender: Female\n");
                        }
                        else
                        {
                            Console.WriteLine("Gender: Male\n");
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Social security number {userInput} is not correct, please try again!\n");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Social security number {userInput} is not correct, please try again!\n");
                    Console.ResetColor();
                }
                Console.WriteLine("Press any key to search again or ctrl+c to quit");
                Console.ReadKey(); // STOPS THE PROGRAM BASED ON USER REQUEST
                Console.Clear(); // EVERY TIME THE LOOP RESTARTS, IT CLEARS THE CONSOLE
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
                Console.WriteLine("(!) Too few numbers");
            }
            else if (userInput.Length > 12)
            {
                Console.WriteLine("(!) Too many numbers");
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
                Console.WriteLine($"(!) Incorrect year ({year})");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in year");
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
                Console.WriteLine($"(!) Incorrect month ({month})");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in month");
                return false;
            }
        }
        /*
        METHOD THAT CHECKS WHAT MONTH NUMBER USER TYPED AND THEN LOOK UP HOW MANY DAYS THAT MONTH HAS.
        IF USER INPUT (DAY) IS IN THE RANGE OF THAT MONTH, IT RETURNS TRUE OTHERWISE FALSE WITH ERROR */
        static bool DayCheck(string userInput)
        {
            try
            {
                int year = Convert.ToInt32(userInput.Substring(0, 4));
                int month = Convert.ToInt32(userInput.Substring(4, 2));
                int day = Convert.ToInt32(userInput.Substring(6, 2));
                string error = $"(!) Incorrect day ({day})";
                switch (month)
                {
                    case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                        if (day >= 1 && day <= 31)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine(error);
                        }
                        break;
                    case 4: case 6: case 9: case 11:
                        if (day >= 1 && day <= 30)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine(error);
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
                                Console.WriteLine(error);
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
                                Console.WriteLine(error);
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
                                Console.WriteLine(error);
                            }
                            return false;
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
        // METHOD TO CHECK IF THE LAST 4 CHARACTER IS VALID DIGITS BY TRYING TO CONVERT THEM TO INTERGERS
        static bool LastFourCheck(string userInput) 
        {
            try
            {
                int numbers = Convert.ToInt32(userInput.Substring(8, 4));
                return true;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in the last four numbers");
            }
            return false;
        }
    }
}
