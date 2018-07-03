namespace FindNextBiggerNumber.Tests
{
    using System;

    using NUnit.Framework;
    using Numbers;

    [TestFixture]
    public class FindNextBiggerNumberTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(465, ExpectedResult = 546)]
        [TestCase(2543, ExpectedResult = 3245)]
        [TestCase(6345632, ExpectedResult = 6346235)]
        [TestCase(2543, ExpectedResult = 3245)]
        [TestCase(1000010, ExpectedResult = 1000100)]
        public int FindNextBiggerNumber_ValidTests(int number) => Numbers.FindNextBiggerNumber(number).answer;


        [TestCase(10, ExpectedResult = -1)]
        [TestCase(10000, ExpectedResult = -1)]
        [TestCase(111111, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_ValidInput_ReturnsMinusOne(int number) => Numbers.FindNextBiggerNumber(number).answer;


        [TestCase(-1)]
        [TestCase(0)]
        public void FindNextBiggerNumber_NotValidInput_ThrowsArgumentOutOfRangeException(int number) => 
            Assert.Throws<ArgumentOutOfRangeException>(() => Numbers.FindNextBiggerNumber(number));


        [TestCase(int.MaxValue)]
        [TestCase(int.MaxValue - 1)]
        public void FindNextBiggerNumber_NegativeInput_ThrowsOverflowException(int number)
        {
            Assert.Throws<OverflowException>(() => Numbers.FindNextBiggerNumber(number));
        }
    }
}
