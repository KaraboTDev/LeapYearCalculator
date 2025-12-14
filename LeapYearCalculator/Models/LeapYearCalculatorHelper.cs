namespace LeapYearCalculator.Models
{
    // Helper class containing leap year logic
    public static class LeapYearCalculatorHelper
    {
        // Method that determines if a given year is a leap year.
        // Input: year as an integer
        // Output: true if leap year, false otherwise
        public static bool IsLeapYear(int year)
        {
            // Rule:
            // - If year is divisible by 400 -> leap year
            // - Else if year is divisible by 100 -> NOT a leap year
            // - Else if year is divisible by 4 -> leap year
            // - Else -> NOT a leap year

            if (year % 400 == 0)
            {
                return true;
            }

            if (year % 100 == 0)
            {
                return false;
            }

            if (year % 4 == 0)
            {
                return true;
            }

            return false;
        }
    }
}