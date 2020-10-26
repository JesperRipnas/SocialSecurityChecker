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
                Console.Write("Ange personnummer (YYYYMMDDNNNN): ");
                string userInput = Console.ReadLine();
                // BOOL VARIABLES CONNECTED TO RETURNS FROM THE METHODS
                bool validLength = InputCheck(userInput);
                bool validYear = YearCheck(userInput);
                bool validMonth = MonthCheck(userInput);
                bool validDay = DayCheck(userInput);
                bool validNumbers = BirthNrCheck(userInput);
                //TROUBLESHOOTING
                Console.WriteLine($"Valid Length: {validLength}");
                Console.WriteLine($"Valid Year: {validYear}");
                Console.WriteLine($"Valid Month: {validMonth}");
                Console.WriteLine($"Valid Day: {validDay}");
                //END OF TROUBLESHOOTING
                if (validLength && validYear && validMonth && validDay)
                {
                    Console.WriteLine("Your social security number is correct!\n");
                }
            }
        }
        // 12 NUMBERS (L2 = 10 OR 12 NUMBERS)
        static bool InputCheck(string userInput)
        {
            int length = Convert.ToInt32(userInput.Length);
            if (length == 12)
            {
                return true;
            }
            else
            {
                Console.WriteLine("(!) Incorrect amount of numbers, please try again!");
                return false;
            }
        }
        // BOOL METHOD TO CHECK THAT THE INPUT YEAR IS BETWEEN 1753 - 2020, ALSO HAVE ERROR HANDLING IF USER INPUTS INCORRECT INPUTS LIKE *"%#¤! OR LETTERS
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
        // BOOL METHOD TO CHECK THAT THE MONTH INPUT IS BETWEEN 1-12 (JAN-DEC), ALSO HAVE ERROR HANDLING IF USER INPUTS INCORRECT INPUTS LIKE *"%#¤! OR LETTERS
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
        // BOOL METHOD TO CHECK THAT THE DAY USER HAS TYPED IS CORRECT VS THE MONTH
        static bool DayCheck(string userInput)
        {
            try
            {
                int month = Convert.ToInt32(userInput.Substring(4, 2));
                int day = Convert.ToInt32(userInput.Substring(6, 2));
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (day >= 1 && day <= 31)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"(!) Incorrect day ({day}), try again!");
                        }
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
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
                        Console.WriteLine("Februari 28/29 dagar | Work in progress");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in day, try again!");
                return false;
            }
            return false;
        }
        static bool BirthNrCheck(string userInput) // NUMBER BETWEEN 0-999
        {
            try
            {
                int numbers = Convert.ToInt32(userInput.Substring(8, 4));
                int lastNumber = Convert.ToInt32(userInput.Substring(10, 1));
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in last four numbers, try again!");
            }
            return false;
        }
        static bool ControlNrCheck() // LUHN ALGORITHM
        {
            return false;
        }
    }
}
