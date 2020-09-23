using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text;

namespace HTKKlub.MSTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateIsStringNullTest()
        {
            string input = "";
            Assert.IsNotNull(input);
        }

        /// <summary>
        /// Checks if the reservation start date is before the end date
        /// </summary>
        /// <param name="input"></param>
        /// <returns>(<see cref="bool"/>, <see cref="string"/>)</returns>
        [TestMethod]
        public void ValidateReservationDatesTest()
        {
            DateTime firstDate = new DateTime(2010 - 01 - 01);
            DateTime secondDate = new DateTime(2010 - 01 - 02);

            int first = Convert.ToInt32(firstDate.ToString("yyyyMMdd"));
            int second = Convert.ToInt32(secondDate.ToString("yyyyMMdd"));

            Assert.IsTrue(first > second);
        }
    }
}
