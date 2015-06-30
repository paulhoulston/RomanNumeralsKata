using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

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
                var actualResult = new RomanNumerator().ConvertFrom(romanNumeral);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }

    public class RomanNumerator
    {
        private readonly IDictionary<string, int> _romanNumeralLookup = new Dictionary<string, int>
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        public int ConvertFrom(string romanNumeral)
        {
            return _romanNumeralLookup[romanNumeral];
        }
    }
}
