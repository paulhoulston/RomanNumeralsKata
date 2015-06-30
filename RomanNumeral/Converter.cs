using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RomanNumeral
{
    public class Given_I_want_to_convert_a_roman_numeral
    {
        public class When_I_have_a_simple_roman_numeral
        {
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

        public class When_I_have_a_roman_numeral_post_fixed_by_a_single_roman_numeral_less_than_or_equal_to_the_first_numeral
        {
            [TestCase(2, "II")]
            [TestCase(6, "VI")]
            [TestCase(11, "XI")]
            [TestCase(20, "XX")]
            [TestCase(51, "LI")]
            [TestCase(60, "LX")]
            [TestCase(101, "CI")]
            [TestCase(150, "CL")]
            [TestCase(200, "CC")]
            [TestCase(501, "DI")]
            [TestCase(600, "DC")]
            [TestCase(1001, "MI")]
            [TestCase(1010, "MX")]
            [TestCase(2000, "MM")]
            public void Then_the_value_is_one_more_than_the_first_numeral(int expectedResult, string romanNumeral)
            {
                var actualResult = new RomanNumerator().ConvertFrom(romanNumeral);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        public class When_I_have_a_roman_numeral_that_is_prefixed_by_a_single_numeral_less_than_the_first_numeral
        {
            [TestCase(4, "IV")]
            [TestCase(9, "IX")]
            [TestCase(5, "VX")]
            [TestCase(40, "XL")]
            [TestCase(49, "IL")]
            [TestCase(99, "IC")]
            [TestCase(50, "LC")]
            [TestCase(499, "ID")]
            [TestCase(400, "CD")]
            [TestCase(999, "IM")]
            [TestCase(900, "CM")]
            public void Then_the_value_of_the_first_is_decremented_by_one(int expectedResult, string romanNumeral)
            {
                var actualResult = new RomanNumerator().ConvertFrom(romanNumeral);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }

    public class RomanNumerator
    {
        private readonly IDictionary<char, int> _romanNumeralLookup = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public int ConvertFrom(string romanNumeral)
        {
            var sum = 0;
            for (var i = 0; i < romanNumeral.Length; i++)
            {
                var numeralValue = _romanNumeralLookup[romanNumeral[i]];
                sum += numeralValue;

                if (i < romanNumeral.Length - 1 && _romanNumeralLookup[romanNumeral[i + 1]] > numeralValue)
                {
                    sum *= -1;
                }
            }

            return sum;
        }
    }
}
