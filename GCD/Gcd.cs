namespace GCD
{
    using System;
    using System.Security.Policy;

    /// <summary>
    /// Class that contains methods for finding gcd of two or more numbers.
    /// </summary>
    public static class Gcd
    {
        #region Public methods

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of two or more numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="numbers">
        /// For additional numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// Thrown if passed parameters contains two zero values.
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of all passed numbers.
        /// </returns>
        public static int Euclid(int first, int second, params int[] numbers)
        {
            ThrowForInvalidParameters(first, second, numbers);

            int gcd = EuclidGcd(first, second);
            foreach (int number in numbers)
            {
                // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
                gcd = EuclidGcd(gcd, number);
            }

            return gcd;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Euclidean algorithm for finding GCD of two numbers.
        /// </summary>
        /// <param name="a">
        /// First number.
        /// </param>
        /// <param name="b">
        /// Second number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of two passed numbers.
        /// </returns>
        private static int EuclidGcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a < b)
            {
                Swap(ref a, ref b);
            }

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        /// <summary>
        /// Swaps two values.
        /// </summary>
        /// <param name="a">
        /// First number.
        /// </param>
        /// <param name="b">
        /// Second number.
        /// </param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Checks input parameters and 
        /// throws exceptions if they are not valid.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="numbers">
        /// Other numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// Thrown if passed parameters contains two zero values.
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        private static void ThrowForInvalidParameters(int first, int second, int[] numbers)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Cannot calculate gcd of two zeros.");
            }

            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (ParametersContainTwoZeros())
            {
                throw new ArgumentException("Cannot calculate gcd of two zeros.");
            }

            bool ParametersContainTwoZeros()
            {
                int zeroCount = 0;

                // Because we have already checked 
                // condition (first == 0 && second == 0) before, 
                // only one of these parameters can be equal to zero.
                if (first == 0 || second == 0)
                {
                    zeroCount++;
                }

                foreach (int number in numbers)
                {
                    if (number != 0)
                    {
                        continue;
                    }

                    zeroCount++;
                    if (zeroCount == 2)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion
    }
}
