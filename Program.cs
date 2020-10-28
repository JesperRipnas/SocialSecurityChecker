using System;

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
                string gender = GenderCheck(userInput);
                // RUNS THE INPUT IN EACH METHOD BELOW
                bool validLength = InputCheck(userInput);
                bool validYear = YearCheck(userInput);
                bool leapYear = LeapYearCheck(userInput);
                bool validMonth = MonthCheck(userInput);
                bool validDay = DayCheck(userInput, leapYear);
                bool validLastFour = LastFourCheck(userInput);
                // PRINT OUT BASED ON RETURN OF METHODS + GENDER
                if (validLength && validYear && validMonth && validDay && validLastFour)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Social security number {userInput} is correct!\nGender: {gender}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Social security number {userInput} is not correct, please try again!\n");
                    Console.ResetColor();
                }
                Console.WriteLine("\nPress enter key to search again or ctrl+c to quit");
                Console.ReadKey();
            }
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
        // LEAP YEAR OR NOT
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
        // BASED ON WHAT MONTH USER ENTERED, CHECK IF THE DAY IS IN THE RANGE OF THAT MONTH
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
                            Console.WriteLine($"(!) Incorrect day ({day})");
                        }
                        break;
                    case 2:
                        if (leapYear)
                        {
                            if (day >= 1 && day <= 29)
                            {
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"(!) Incorrect day ({day})");
                            }
                        }
                        else if (!leapYear)
                        {
                            if (day >= 1 && day <= 28)
                            {
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"(!) Incorrect day ({day})");
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
        // SIMPLE CONVERT TO CHECK THAT THE FOUR LAST NUMBERS ARE IN FORM AV NUMBERS
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
        // GENDER CHECK BASED ON THE PENULTIMATE NUMBER IN THE INPUT
        static string GenderCheck(string userInput)
        {
            try
            {
                int penultimateNumber = Convert.ToInt32(userInput.Substring(10, 1));
                if (penultimateNumber % 2 == 0 || penultimateNumber == 0)
                {
                    return "Female";
                }
                else
                {
                    return "Male";
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
