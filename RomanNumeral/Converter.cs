using NUnit.Framework;

namespace RomanNumeral
{
    public class Given_I_want_to_convert_a_roman_numeral
    {
        public class When_I_have_I
        {
            [Test]
            public void Then_1_is_returned()
            {
                var expectedResult = 1;
                var actualResult = 0;
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
