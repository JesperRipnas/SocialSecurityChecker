using System;

namespace SocialSecurityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a social security number: ");
                // FÖR NIVÅ 2:
                // MÅSTE KONVERTERA ALLA PERSONNUMMER MED 10 SIFFROR TILL 12 (ENKLAST PGA REDAN ANVÄND KOD)
                // LÄGGA TILL LUHN ALGORITMEN
                // KONTROLLERA FELHANTEIRNG
                // KOMMENTARER
                string userInput = Console.ReadLine();
                string socialSecurityNumber = ConvertUserInput(userInput);
                string gender = GenderCheck(socialSecurityNumber);

                bool validLength = InputCheck(socialSecurityNumber);
                bool validYear = YearCheck(socialSecurityNumber);
                bool leapYear = LeapYearCheck(socialSecurityNumber);
                bool validMonth = MonthCheck(socialSecurityNumber);
                bool validDay = DayCheck(socialSecurityNumber, leapYear);
                bool validLastFour = LastFourCheck(socialSecurityNumber);
                bool validControlNumber = ControlNumberCheck(socialSecurityNumber);

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
                Debug(validLength, validYear, leapYear, validMonth, validDay, validLastFour, validControlNumber, gender, socialSecurityNumber); // REMOVE WITH FINAL RELEASE
                Console.WriteLine("\nPress enter key to search again or ctrl+c to quit");
                Console.ReadKey();
            }
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
                    string trimmedSSN = userInput.Remove(6, 1); // REMOVES -
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
        // METHOD TO CHECK THE CONTROL DIGIT IN THE SOOCIAL SECURITY NUMBER, USING THE LUHN ALGORITHM
        static bool ControlNumberCheck(string socialSecurityNumber)
        {
            return false;
        }
    }
}
