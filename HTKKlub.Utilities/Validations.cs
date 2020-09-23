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
        /// <param name="input"></param>
        /// <returns></returns>
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

        #region Number Validation Methods
        /// <summary>
        /// Checks if a int is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsIntNegative(int number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Checks if a double is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsDoubleNegative(double number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Checks if a float is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsFloatNegative(float number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Checks if a decimal is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsDecimalNegative(decimal number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }
        #endregion
    }

}
