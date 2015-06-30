using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RomanNumeral
{
    [TestFixture]
    public class Given_I_want_to_convert_from_a_roman_numeral
    {
        private static readonly RomanNumerator Converter = new RomanNumerator();

        public class When_I_have_a_value_corresponding_to_a_simple_roman_numeral
        {
            
            [TestCase("I", 1)]
            [TestCase("V", 5)]
            [TestCase("X", 10)]
            [TestCase("L", 50)]
            [TestCase("C", 100)]
            [TestCase("D", 500)]
            [TestCase("M", 1000)]
            public void Then_the_expected_value_is_returned(string expectedResult, int numeric)
            {
                Assert.AreEqual(expectedResult, Converter.ConvertTo(numeric));
            }
        }
    }

    [TestFixture]
    public class Given_I_want_to_convert_a_roman_numeral
    {
        private static readonly RomanNumerator Converter = new RomanNumerator();

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
                Assert.AreEqual(expectedResult, Converter.ConvertFrom(romanNumeral));
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
            public void Then_value_is_incremented_by_the_prescribed_amount(int expectedResult, string romanNumeral)
            {
                Assert.AreEqual(expectedResult, Converter.ConvertFrom(romanNumeral));
            }
        }

        public class When_I_have_a_roman_numeral_post_fixed_by_a_multiple_roman_numeral_less_than_or_equal_to_the_proceeding_numeral
        {
            [TestCase(3, "III")]
            [TestCase(7, "VII")]
            [TestCase(16, "XVI")]
            [TestCase(25, "XXV")]
            [TestCase(75, "LXXV")]
            [TestCase(76, "LXXVI")]
            public void Then_value_is_incremented_by_the_prescribed_amount(int expectedResult, string romanNumeral)
            {
                Assert.AreEqual(expectedResult, Converter.ConvertFrom(romanNumeral));
            }
        }

        public class When_I_have_a_roman_numeral_that_is_prefixed_by_a_single_numeral_less_than_the_trailing_numeral
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
            public void Then_the_value_of_the_first_is_decremented_by_the_required_amount(int expectedResult, string romanNumeral)
            {
                Assert.AreEqual(expectedResult, Converter.ConvertFrom(romanNumeral));
            }
        }

        public class When_I_have_an_assorted_selection_of_roman_numerals
        {
            [TestCase(1954, "MCMLIV")]
            [TestCase(1990, "MCMXC")]
            [TestCase(2014, "MMXIV")]
            public void Then_they_are_converted_correctly(int expectedResult, string romanNumeral)
            {
                var actualResult = new RomanNumerator().ConvertFrom(romanNumeral);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }

    public class RomanNumerator
    {
        private class NumeralMapping
        {
            public readonly char Numeral;
            public readonly int Numeric;

            public NumeralMapping(char numeral, int numeric)
            {
                Numeral = numeral;
                Numeric = numeric;
            }
        }

        private readonly IList<NumeralMapping> _romanNumerialMapping = new List<NumeralMapping>
        {
            new NumeralMapping('I',1),
            new NumeralMapping('V',5),
            new NumeralMapping('X',10),
            new NumeralMapping('L',50),
            new NumeralMapping('C',100),
            new NumeralMapping('D',500),
            new NumeralMapping('M',1000),
        };

        public int ConvertFrom(string romanNumeral)
        {
            var sum = 0;
            for (var i = romanNumeral.Length - 1; i >= 0; i--)
            {
                var numericValue = _romanNumerialMapping.Single(item => item.Numeral.Equals(romanNumeral[i])).Numeric;
                sum = IsNotRightmostNumeral(romanNumeral, i) && IsSmallerThanNumeralToRight(romanNumeral, i, numericValue)
                    ? sum - numericValue
                    : sum + numericValue;
            }
            return sum;
        }


        private bool IsSmallerThanNumeralToRight(string romanNumeral, int index, int numericValue)
        {
            var previousNumeralValue = _romanNumerialMapping.Single(item => item.Numeral.Equals(romanNumeral[index + 1])).Numeric;
            var decrementValue = previousNumeralValue > numericValue;
            return decrementValue;
        }

        private static bool IsNotRightmostNumeral(string romanNumeral, int i)
        {
            return i != romanNumeral.Length - 1;
        }

        public string ConvertTo(int numeric)
        {
            return _romanNumerialMapping.Single(i => i.Numeric.Equals(numeric)).Numeral.ToString();
        }
    }
}
