﻿namespace GCD.Tests
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

        [TestCase(54, 24, ExpectedResult = 6)]
        [TestCase(54, -24, ExpectedResult = 6)]
        [TestCase(42, 56, ExpectedResult = 14)]
        [TestCase(252, 105, ExpectedResult = 21)]
        [TestCase(-252, -105, ExpectedResult = 21)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        public int Binary_TwoNonZeroNumbersInput_ValidResult(int a, int b) => Gcd.Binary(a, b);

        [TestCase(18, 24, 36, ExpectedResult = 6)]
        [TestCase(15, 35, 75, ExpectedResult = 5)]
        [TestCase(-15, 35, -75, ExpectedResult = 5)]
        [TestCase(8, 16, 76, 12, ExpectedResult = 4)]
        [TestCase(-8, -16, -76, -12, ExpectedResult = 4)]
        [TestCase(1080, 3768, 5812, 12222, ExpectedResult = 2)]
        [TestCase(423748, 42398, 326714, 21170, ExpectedResult = 58)]
        public int Euclid_MultipleNonZeroNumbersInput_ValidResult(int a, int b, params int[] numbers) => 
            Gcd.Euclid(a, b, numbers);

        [TestCase(18, 24, 36, ExpectedResult = 6)]
        [TestCase(15, 35, 75, ExpectedResult = 5)]
        [TestCase(-15, 35, -75, ExpectedResult = 5)]
        [TestCase(8, 16, 76, 12, ExpectedResult = 4)]
        [TestCase(-8, -16, -76, -12, ExpectedResult = 4)]
        [TestCase(1080, 3768, 5812, 12222, ExpectedResult = 2)]
        [TestCase(423748, 42398, 326714, 21170, ExpectedResult = 58)]
        public int Binary_MultipleNonZeroNumbersInput_ValidResult(int a, int b, params int[] numbers) =>
            Gcd.Binary(a, b, numbers);

        [TestCase(0, 45, -75, ExpectedResult = 15)]
        [TestCase(8, 16, 0, 0, ExpectedResult = 8)]
        [TestCase(0, 0, 5, 10, ExpectedResult = 5)]
        [TestCase(0, 0, 5, ExpectedResult = 5)]
        public int Euclid_InputWithZeros_ValidResult(int a, int b, params int[] numbers) =>
            Gcd.Euclid(a, b, numbers);

        [TestCase(0, 45, -75, ExpectedResult = 15)]
        [TestCase(8, 16, 0, 0, ExpectedResult = 8)]
        [TestCase(0, 0, 5, 10, ExpectedResult = 5)]
        [TestCase(0, 0, 5, ExpectedResult = 5)]
        public int Binary_InputWithZeros_ValidResult(int a, int b, params int[] numbers) =>
            Gcd.Binary(a, b, numbers);

        [TestCase(0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        public void Euclid_AllZeros_ThrowsArgumentException(int a, int b, params int[] numbers) =>
            Assert.Throws<ArgumentException>(() => Gcd.Euclid(a, b, numbers));

        [TestCase(0, 0)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        public void Binary_AllZeros_ThrowsArgumentException(int a, int b, params int[] numbers) =>
            Assert.Throws<ArgumentException>(() => Gcd.Binary(a, b, numbers));

        [Test]
        public void Euclid_NumbersNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => Gcd.Euclid(10, 20, null));

        [Test]
        public void Binary_NumbersNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => Gcd.Binary(10, 20, null));
    }
}
