namespace GCD
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class that contains methods for finding gcd of two or more numbers.
    /// </summary>
    public static class Gcd
    {
        #region Public methods

        #region Euclidean Algorithm

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of two numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// <exception cref="ArgumentException">
        /// Thrown if both passed parameters are zeros.
        /// </exception>
        /// GCD of passed numbers.
        /// </returns>
        public static int Euclid(int first, int second)
        {
            ThrowForInvalidParameters(first, second);

            return EuclidGcd(first, second);
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of three numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// GCD of passed numbers.
        /// </returns>
        public static int Euclid(int first, int second, int third)
        {
            ThrowForInvalidParameters(first, second, third);

            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            int gcd = EuclidGcd(first, second);
            return EuclidGcd(gcd, third);
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <param name="numbers">
        /// For additional numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if passed parameters are all equal to zero.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of all passed numbers.
        /// </returns>
        public static int Euclid(int first, int second, int third, params int[] numbers)
        {
            ThrowForInvalidParameters(first, second, third, numbers);

            int gcd = Euclid(first, second, third);

            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            foreach (int number in numbers)
            {
                if (number != 0)
                {
                    gcd = EuclidGcd(gcd, number);
                }
            }

            return gcd;
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of two numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if both passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="(int gcd, long elapsedMillisecond)"/>.
        /// Tuple which first element is GCD of passed parameters, 
        /// second element is time taken by calculations in milliseconds.
        /// </returns>
        public static (int gcd, long elapsedMillisecond) TimedEuclid(int first, int second)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();
            int answer = EuclidGcd(first, second);

            return (answer, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of three numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="(int gcd, long elapsedMillisecond)"/>.
        /// Tuple which first element is GCD of passed parameters, 
        /// second element is time taken by calculations in milliseconds.
        /// </returns>
        public static (int gcd, long elapsedMillisecond) TimedEuclid(int first, int second, int third)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();

            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            int gcd = Euclid(first, second, third);

            return (gcd, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <param name="numbers">
        /// For additional numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        /// <returns>
        /// The <see cref="(int gcd, long elapsedMillisecond)"/>.
        /// Tuple which first element is GCD of passed parameters, 
        /// second element is time taken by calculations in milliseconds.
        /// </returns>
        public static (int gcd, long elapsedMillisecond) TimedEuclid(int first, int second, int third, params int[] numbers)
        {
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();
            int answer = Euclid(first, second, third, numbers);

            return (answer, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of two numbers.
        /// </summary>
        /// <param name="elapsedTime">
        /// Time taken by calculations in milliseconds.
        /// </param>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if both passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of two numbers.
        /// </returns>
        public static int TimedEuclid(out long elapsedTime, int first, int second)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();
            int answer = EuclidGcd(first, second);
            elapsedTime = sw.ElapsedMilliseconds;

            return answer;
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of three numbers.
        /// </summary>
        /// <param name="elapsedTime">
        /// Time taken by calculations in milliseconds.
        /// </param>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of three numbers.
        /// </returns>
        public static int TimedEuclid(out long elapsedTime, int first, int second, int third)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();

            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            int gcd = Euclid(first, second, third);

            elapsedTime = sw.ElapsedMilliseconds;

            return gcd;
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
        /// <param name="elapsedTime">
        /// Time taken by calculations in milliseconds.
        /// </param>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <param name="numbers">
        /// For additional numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of two numbers.
        /// </returns>
        public static int TimedEuclid(out long elapsedTime, int first, int second, int third, params int[] numbers)
        {
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();
            int answer = Euclid(first, second, third, numbers);
            elapsedTime = sw.ElapsedMilliseconds;

            return answer;
        }

        #endregion

        #region Binary Algorithm

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of two numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if both passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of passed numbers.
        /// </returns>
        public static int Binary(int first, int second)
        {
            ThrowForInvalidParameters(first, second);

            return BinaryGcd(first, second);
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of three numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of all passed numbers.
        /// </returns>
        public static int Binary(int first, int second, int third)
        {
            ThrowForInvalidParameters(first, second, third);

            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            int gcd = BinaryGcd(first, second);
            return BinaryGcd(gcd, third);
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <param name="numbers">
        /// For additional numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of all passed numbers.
        /// </returns>
        public static int Binary(int first, int second, int third, params int[] numbers)
        {
            ThrowForInvalidParameters(first, second, third, numbers);

            int gcd = Binary(first, second, third);

            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            foreach (int number in numbers)
            {
                if (number != 0)
                {
                    gcd = BinaryGcd(gcd, number);
                }
            }

            return gcd;
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of two numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if both passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="(int gcd, long elapsedMillisecond)"/>.
        /// Tuple which first element is GCD of passed parameters, 
        /// second element is time taken by calculations in milliseconds.
        /// </returns>
        public static (int gcd, long elapsedMillisecond) TimedBinary(int first, int second)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();
            int answer = BinaryGcd(first, second);

            return (answer, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of two numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="(int gcd, long elapsedMillisecond)"/>.
        /// Tuple which first element is GCD of passed parameters, 
        /// second element is time taken by calculations in milliseconds.
        /// </returns>
        public static (int gcd, long elapsedMillisecond) TimedBinary(int first, int second, int third)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();
            int gcd = BinaryGcd(first, second);
            gcd = BinaryGcd(gcd, third);

            return (gcd, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <param name="numbers">
        /// For additional numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if passed parameters contain two zero values.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        /// <returns>
        /// The <see cref="(int gcd, long elapsedMillisecond)"/>.
        /// Tuple which first element is GCD of passed parameters, 
        /// second element is time taken by calculations in milliseconds.
        /// </returns>
        public static (int gcd, long elapsedMillisecond) TimedBinary(int first, int second, int third, params int[] numbers)
        {
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();
            int answer = Binary(first, second, third, numbers);

            return (answer, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of two numbers.
        /// </summary>
        /// <param name="elapsedTime">
        /// Time taken by calculations in milliseconds.
        /// </param>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if both passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of two numbers.
        /// </returns>
        public static int TimedBinary(out long elapsedTime, int first, int second)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();
            int answer = BinaryGcd(first, second);
            elapsedTime = sw.ElapsedMilliseconds;

            return answer;
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of three numbers.
        /// </summary>
        /// <param name="elapsedTime">
        /// Time taken by calculations in milliseconds.
        /// </param>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if both passed parameters are zeros.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of two numbers.
        /// </returns>
        public static int TimedBinary(out long elapsedTime, int first, int second, int third)
        {
            ThrowForInvalidParameters(first, second);

            Stopwatch sw = Stopwatch.StartNew();

            int gcd = Binary(first, second, third);

            elapsedTime = sw.ElapsedMilliseconds;

            return gcd;
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
        /// <param name="elapsedTime">
        /// Time taken by calculations in milliseconds.
        /// </param>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <param name="numbers">
        /// For additional numbers.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if passed parameters contain two zero values.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed params argument is null.
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of two numbers.
        /// </returns>
        public static int TimedBinary(out long elapsedTime, int first, int second, int third, params int[] numbers)
        {
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();
            int gcd = Binary(first, second, third, numbers);
            elapsedTime = sw.ElapsedMilliseconds;

            return gcd;
        }

        #endregion

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
        /// Binary algorithm for finding GCD of two numbers.
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
        private static int BinaryGcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a < b)
            {
                Swap(ref a, ref b);
            }

            int shift;

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            for (shift = 0; ((a | b) & 1) == 0; shift++)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    Swap(ref a, ref b);
                }

                b -= a;
            }
            while (b != 0);

            return a << shift;
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
        /// <exception cref="ArgumentException">
        /// Thrown if both parameters are zeros.
        /// </exception>
        private static void ThrowForInvalidParameters(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Cannot calculate GCD of two zeros.");
            }
        }

        /// <summary>
        /// Checks input parameters and throws 
        /// exceptions if they are all equal to zero.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if all parameters are zeros.
        /// </exception>
        private static void ThrowForInvalidParameters(int first, int second, int third)
        {
            if (first == 0 && second == 0 && third == 0)
            {
                throw new ArgumentException("Cannot calculate GCD of three zeros.");
            }
        }

        /// <summary>
        /// Checks input parameters and throws 
        /// exceptions if they are all equal to zero.
        /// </summary>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <param name="third">
        /// Third number.
        /// </param>
        /// <param name="numbers">
        /// The numbers.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if numbers parameter is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if all parameters are zeros.
        /// </exception>
        private static void ThrowForInvalidParameters(int first, int second, int third, int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (first == 0 && second == 0 && third == 0 && Array.TrueForAll(numbers, v => v == 0))
            {
                throw new ArgumentException("Cannot calculate GCD of three zeros.");
            }
        }

        #endregion
    }
}
