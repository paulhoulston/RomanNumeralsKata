﻿using NUnit.Framework;

namespace RomanNumeral
{
    public class Given_I_want_to_convert_a_roman_numeral
    {
        public class When_I_have_a_simple_roman_numeral
        {
            [Test]
            [TestCase(1, "I")]
            [TestCase(5, "V")]
            [TestCase(10, "X")]
            [TestCase(50, "L")]
            [TestCase(100, "C")]
            [TestCase(500, "D")]
            [TestCase(1000, "M")]
            public void Then_the_corresponding_integer_value_is_returned(int expectedResult, string romanNumeral)
            {
                var actualResult = new RomanNumerator().ConvertFrom("I");
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }

    public class RomanNumerator
    {
        public int ConvertFrom(string romanNumeral)
        {
            return 1;
        }
    }
}
