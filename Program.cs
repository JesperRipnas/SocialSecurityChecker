using System;

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
             */

        static bool InputCheck() // 10 OR 12 NUMBERS (L2 = ERROR HANDLING)
            {
                return false;
            }
        static bool YearCheck() // BETWEEN 1753 - 2020
            {
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
}
