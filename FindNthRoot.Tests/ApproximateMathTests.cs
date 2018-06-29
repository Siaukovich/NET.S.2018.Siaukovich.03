namespace ApproximateMath.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Class for testing ApproximateMath class.
    /// </summary>
    [TestFixture]
    public class ApproximateMathTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        [TestCase(100.500, 4, 0.001, 3.166)]
        [TestCase(100000.500, 4, 0.00001, 17.782816)]
        [TestCase(100000500, 4, 0.000001, 100.000125)]
        [TestCase(99999999, 1500, 0.000000001, 1.012356168)]
        [TestCase(-123213, 13, 0.0001, -2.4637)]
        [TestCase(-12321323, 133, 0.000001, -1.130611)]
        public void FindNthRoot_ValidInput_ValidResult(double value, int power, double epsilon, double expected)
        {
            double actual = ApproximateMath.FindNthRoot(value, power, epsilon);
            Assert.AreEqual(expected, actual, epsilon);
        }

        [Test]
        public void FindNthRoot_NumberLessThanZeroPowerIsEven_ThrowsArgumentException()
        {
            double number = -2;
            int power = 2;
            double epsilon = 0.1f;
            Assert.Throws<ArgumentException>(() => ApproximateMath.FindNthRoot(number, power, epsilon));
        }

        [Test]
        public void FindNthRoot_PowerLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            double number = 2;
            int power = -2;
            double epsilon = 0.1f;
            Assert.Throws<ArgumentOutOfRangeException>(() => ApproximateMath.FindNthRoot(number, power, epsilon));
        }

        [Test]
        public void FindNthRoot_EpsilonLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            double number = 2;
            int power = 2;
            double epsilon = -0.1f;
            Assert.Throws<ArgumentOutOfRangeException>(() => ApproximateMath.FindNthRoot(number, power, epsilon));
        }
    }
}
