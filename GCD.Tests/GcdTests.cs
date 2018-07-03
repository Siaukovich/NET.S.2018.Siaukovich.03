namespace GCD.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class GcdTests
    {
        [TestCase(54, 24, ExpectedResult = 6)]
        [TestCase(54, -24, ExpectedResult = 6)]
        [TestCase(42, 56, ExpectedResult = 14)]
        [TestCase(252, 105, ExpectedResult = 21)]
        [TestCase(-252, -105, ExpectedResult = 21)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        public int Euclid_TwoNonZeroNumbersInput_ValidResult(int a, int b) => Gcd.Euclid(a, b);

        [TestCase(18, 24, 36, ExpectedResult = 6)]
        [TestCase(15, 35, 75, ExpectedResult = 5)]
        [TestCase(-15, 35, -75, ExpectedResult = 5)]
        [TestCase(8, 16, 76, 12, ExpectedResult = 4)]
        [TestCase(-8, -16, -76, -12, ExpectedResult = 4)]
        [TestCase(1080, 3768, 5812, 12222, ExpectedResult = 2)]
        [TestCase(423748, 42398, 326714, 21170, ExpectedResult = 58)]
        public int Euclid_MultipleNonZeroNumbersInput_ValidResult(int a, int b, params int[] numbers) => 
            Gcd.Euclid(a, b, numbers);

        [TestCase(0, 0)]
        [TestCase(50, 110, 20, 0, 30, 0)]
        [TestCase(0, 110, 20, 0, 30, 10)]
        public void Euclid_TwoZeros_ThrowsArgumentException(int a, int b, params int[] numbers) =>
            Assert.Throws<ArgumentException>(() => Gcd.Euclid(a, b, numbers));

        [Test]
        public void Euclid_NumbersNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentException>(() => Gcd.Euclid(0, 0, null));
    }
}
