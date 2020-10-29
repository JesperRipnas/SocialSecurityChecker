using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace SocialSecurityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            while (true)
            {
                Console.Write("Enter a social security number: ");
                string userInput = Console.ReadLine();
                string socialSecurityNumber = ConvertUserInput(userInput);
                string gender = GenderCheck(socialSecurityNumber);
                // METHODS USED
                bool validLength = InputCheck(socialSecurityNumber);
                bool validYear = YearCheck(socialSecurityNumber);
                bool leapYear = LeapYearCheck(socialSecurityNumber);
                bool validMonth = MonthCheck(socialSecurityNumber);
                bool validDay = DayCheck(socialSecurityNumber, leapYear);
                bool validLastFour = LastFourCheck(socialSecurityNumber);
                bool validControlNumber = ControlNumberCheck(socialSecurityNumber);
                // PRINT OUT BASED ON METHOD RETURNS
                if (validLength && validYear && validMonth && validDay && validLastFour && validControlNumber)
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
                Debug(validLength, validYear, leapYear, validMonth, validDay, validLastFour, validControlNumber, gender, socialSecurityNumber); // REMOVE WITH FINAL RELEASE
                Console.WriteLine("\nPress enter key to search again or ctrl+c to quit");
                Console.ReadKey();
            }
        }
        static void Menu()
        {
            Console.WriteLine("Valid inputs");
            Console.WriteLine("YYYYMMDDNNNN");
            Console.WriteLine("YYMMDD-NNNN");
            Console.WriteLine("YYMMDD+NNNN\n");
        }
        // IF USER INPUT IS < 12, REMOVE THE SYMBOL (-/+) & CONVERTS IT TO A 12 DIGIT NUMBER.
        static string ConvertUserInput(string userInput)
        {
            try
            {
                if (userInput.Length == 12)
                {
                    return userInput;
                }
                else if (userInput.Length == 11)
                {
                    string trimmedSSN = userInput.Remove(6, 1); // REMOVE -/+
                    if (userInput.Substring(6, 1) == "-")
                    {
                        // BORN AFTER 2000
                        if (Convert.ToInt32(userInput.Substring(0, 2)) <= 20)
                        {
                            return "20" + trimmedSSN;
                        }
                        // BORN BEFORE 2000
                        else
                        {
                            return "19" + trimmedSSN;
                        }
                    }
                    // OVER 100 YEARS OF AGE
                    else if (userInput.Substring(6, 1) == "+")
                    {
                        return "19" + trimmedSSN;
                    }
                }
                return userInput;
            }
            catch
            {
                Console.WriteLine("(!) Not a valid input");
                return "";
            }
        }
        // REMOVE WITH FINAL RELEASE
        static void Debug(bool validLength, bool validYear, bool leapYear, bool validMonth, bool validDay, bool validLastFour, bool validControlNumber, string gender, string socialSecurityNumber)
        {
            Console.WriteLine("\n**********DEBUG**********");
            Console.WriteLine($"12 Digit: {socialSecurityNumber}");
            Console.WriteLine($"Length: {validLength}");
            Console.WriteLine($"Year: {validYear}");
            Console.WriteLine($"Leap Year: {leapYear}");
            Console.WriteLine($"Month: {validMonth}");
            Console.WriteLine($"Day: {validDay}");
            Console.WriteLine($"Last 4: {validLastFour}");
            Console.WriteLine($"Control Number: {validControlNumber}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine("**********DEBUG**********");
            // END OF DEBUG
        }
        static bool InputCheck(string socialSecurityNumber)
        {
            if (socialSecurityNumber.Length == 12)
            {
                return true;
            }
            else if (socialSecurityNumber.Length < 12)
            {
                Console.WriteLine("(!) Too few numbers");
            }
            else if (socialSecurityNumber.Length > 12)
            {
                Console.WriteLine("(!) Too many numbers");
            }
            return false;
        }
        static bool YearCheck(string socialSecurityNumber)
        {
            try
            {
                int year = Convert.ToInt32(socialSecurityNumber.Substring(0, 4));
                if (year >= 1753 && year <= 2020)
                {
                    return true;
                }
                Console.WriteLine($"(!) Not a valid year");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in year");
                return false;
            }
        }
        static bool LeapYearCheck(string socialSecurityNumber)
        {
            try
            {
                int year = Convert.ToInt32(socialSecurityNumber.Substring(0, 4));
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
        static bool MonthCheck(string socialSecurityNumber)
        {
            try
            {
                int month = Convert.ToInt32(socialSecurityNumber.Substring(4, 2));
                if (month >= 1 && month <= 12)
                {
                    return true;
                }
                Console.WriteLine($"(!) Not a valid month");
                return false;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in month");
                return false;
            }
        }
        static bool DayCheck(string socialSecurityNumber, bool leapYear)
        {
            try
            {
                int month = Convert.ToInt32(socialSecurityNumber.Substring(4, 2));
                int day = Convert.ToInt32(socialSecurityNumber.Substring(6, 2));
                // CHECK IF THE DAY IS IN THE RANGE OF MONTH USER PROVIDED
                switch (month)
                {
                    case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                        if (day >= 1 && day <= 31)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"(!) Not a valid day");
                        }
                        break;
                    case 4: case 6: case 9: case 11:
                        if (day >= 1 && day <= 30)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"(!) Not a valid day");
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
                                Console.WriteLine($"(!) Not a valid day");
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
                                Console.WriteLine($"(!) Not a valid day");
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
        static bool LastFourCheck(string socialSecurityNumber)
        {
            try
            {
                int lastFourNumbers = Convert.ToInt32(socialSecurityNumber.Substring(8, 4));
                return true;
            }
            catch
            {
                Console.WriteLine("(!) incorrect character(s) in the last four digits");
            }
            return false;
        }
        static string GenderCheck(string socialSecurityNumber)
        {
            try
            {
                int penultimateNumber = Convert.ToInt32(socialSecurityNumber.Substring(10, 1));
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
        // VERIFYING CONTROL NUMBER WITH LUHN ALGORITHM
        static bool ControlNumberCheck(string socialSecurityNumber)
        {
            try
            {
                int controlNumber = Convert.ToInt32(socialSecurityNumber.Substring(11, 1)); // CONTROL NUMBER
                string trimmed = socialSecurityNumber.Substring(2, 9); // TRIM STRING INTO 9 DIGITS WITHOUT 19/20 AT START AND -/+
                int[] numbers = new int[trimmed.Length];
                int sum = 0;
                int number = 0;
                // FILL THE ARRAY WITH EACH NUMBER FROM TRIMMED INPUT
                for (int i = 0; i < trimmed.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(trimmed.Substring(i, 1));
                }
                // ALGORITHM
                for (int i = 0; i < trimmed.Length; i++)
                {
                    if (i % 2 == 0) // EVEN INDEX GETS MULIPLIED WITH 2, ODD WITH 1
                    {
                        number = numbers[i] * 2;
                        if (number >= 10) // IF SUM OF MULTIPLYING ADDS UP TO 10 OR MORE, SPLIT NUMBER INTO TWO DIGITS. ADD EACH NUMBER INTO THE TOTAL SUM
                        {
                            sum += Convert.ToInt32(number.ToString()[0].ToString());
                            sum += Convert.ToInt32(number.ToString()[1].ToString());
                        }
                        else
                        {
                            sum += Convert.ToInt32(number.ToString()[0].ToString());
                        }
                    }
                    else
                    {
                        sum += numbers[i] * 1;
                    }
                }
                int numberOfSum = (10 - (sum % 10)) % 10;
                // CHECKING IF THE RESULT IS THE SAME AS THE CONTROL NUMBER INPUT FROM USER
                if (numberOfSum == controlNumber)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("(!) Not a valid control number");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
