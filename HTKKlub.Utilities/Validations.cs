using System;

namespace HTKKlub.Utilities
{
    /// <summary>
    /// Class containing static validation methods for encapsulation
    /// </summary>
    public static class Validations
    {
        /// <summary>
        /// Checks if a string is null
        /// </summary>
        public static (bool, string) ValidateIsStringNull(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return (false, "The value cannot be null, or empty");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Checks if a date is before another
        /// </summary>
        /// <param name="input"></param>
        /// <returns>(<see cref="bool"/>, <see cref="string"/>)</returns>
        public static (bool, string) ValidateIsDateBefore(DateTime firstDate, DateTime secondDate)
        {
            if(firstDate == null || secondDate == null)
            {
                return (false, "A date cannot be null");
            }

            int first = Convert.ToInt32(firstDate.ToString("yyyyMMdd"));
            int second = Convert.ToInt32(secondDate.ToString("yyyyMMdd"));

            if(first > second)
            {
                return (true, string.Empty);
            }
            else
            {
                return (false, "The second date was before the first date");
            }
        }

        /// <summary>
        /// Checks if a date is before another
        /// </summary>
        /// <param name="input"></param>
        /// <returns>(<see cref="bool"/>, <see cref="string"/>)</returns>
        public static (bool, string) ValidateIsDateAfter(DateTime firstDate, DateTime secondDate)
        {
            if(firstDate == null || secondDate == null)
            {
                return (false, "A date cannot be null");
            }

            int first = Convert.ToInt32(firstDate.ToString("yyyyMMdd"));
            int second = Convert.ToInt32(secondDate.ToString("yyyyMMdd"));

            if(first < second)
            {
                return (true, string.Empty);
            }
            else
            {
                return (false, "The second date was before the first date");
            }
        }
    }
}