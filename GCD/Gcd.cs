namespace GCD
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class that contains methods for finding Greatest Common Divisor of two or more numbers.
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

            return GetGcd(EuclidGcd, first, second);
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

            return GetGcd(EuclidGcd, first, second, third);
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of many numbers.
        /// </summary>
        /// <param name="numbers">
        /// Numbers which GCD needs to be found.
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
        public static int Euclid(params int[] numbers)
        {
            ThrowForInvalidParameters(numbers);

            return GetGcd(EuclidGcd, numbers);
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
            // No parameters validation because they are inside of Euclid method below.
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
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();

            int gcd = Euclid(first, second, third);

            return (gcd, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Euclidean algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
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
        public static (int gcd, long elapsedMillisecond) TimedEuclid(params int[] numbers)
        {
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();

            int answer = Euclid(numbers);

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
            // No parameters validation because they are inside of Euclid method below.
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
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();

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
        public static int TimedEuclid(out long elapsedTime,  params int[] numbers)
        {
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();

            int answer = Euclid(numbers);

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

            return GetGcd(BinaryGcd, first, second);
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

            return GetGcd(BinaryGcd, first, second, third);
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
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
        public static int Binary(params int[] numbers)
        {
            ThrowForInvalidParameters(numbers);

            return GetGcd(BinaryGcd, numbers);
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
            // No parameters validation because they are inside of Binary method below.
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
            // No parameters validation because they are inside of Binary method below.
            Stopwatch sw = Stopwatch.StartNew();
            int gcd = Binary(first, second, third);

            return (gcd, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of three or more numbers.
        /// </summary>
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
        public static (int gcd, long elapsedMillisecond) TimedBinary(params int[] numbers)
        {
            // No parameters validation because they are inside of Binary method below.
            Stopwatch sw = Stopwatch.StartNew();
            int answer = Binary(numbers);

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
            // No parameters validation because they are inside of Binary method below.

            Stopwatch sw = Stopwatch.StartNew();
            int answer = Binary(first, second);
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
            // No parameters validation because they are inside of Binary method below.
            Stopwatch sw = Stopwatch.StartNew();

            int gcd = Binary(first, second, third);

            elapsedTime = sw.ElapsedMilliseconds;

            return gcd;
        }

        /// <summary>
        /// Binary algorithm for finding greatest common divisor of many numbers.
        /// </summary>
        /// <param name="elapsedTime">
        /// Time taken by calculations in milliseconds.
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
        /// GCD of all passed numbers.
        /// </returns>
        public static int TimedBinary(out long elapsedTime, params int[] numbers)
        {
            // No parameters validation because they are inside of Euclid method below.
            Stopwatch sw = Stopwatch.StartNew();
            int gcd = Binary(numbers);
            elapsedTime = sw.ElapsedMilliseconds;

            return gcd;
        }

        #endregion

        #endregion

        #region Private methods

        /// <summary>
        /// Calculates GCD of two numbers using provided algorithm.
        /// </summary>
        /// <param name="gcdAlgorithm">
        /// Algorithm for calculating GCD of two numbers.
        /// </param>
        /// <param name="first">
        /// First number.
        /// </param>
        /// <param name="second">
        /// Second number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of two numbers.
        /// </returns>
        private static int GetGcd(Func<int, int, int> gcdAlgorithm, int first, int second) =>
            gcdAlgorithm(first, second);


        /// <summary>
        /// Calculates GCD of three numbers using provided algorithm.
        /// </summary>
        /// <param name="gcdAlgorithm">
        /// Algorithm for calculating GCD of two numbers.
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
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of three numbers.
        /// </returns>
        private static int GetGcd(Func<int, int, int> gcdAlgorithm, int first, int second, int third)
        {
            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            int gcd = gcdAlgorithm(first, second);
            return gcdAlgorithm(gcd, third);
        }

        /// <summary>
        /// Calculates GCD of all passed numbers using provided algorithm.
        /// </summary>
        /// <param name="gcdAlgorithm">
        /// Algorithm for calculating GCD of two numbers.
        /// </param>
        /// <param name="values">
        /// Values which GCD needs to be found.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// GCD of all passed numbers.
        /// </returns>
        private static int GetGcd(Func<int, int, int> gcdAlgorithm, params int[] values)
        {
            // Using property: gcd(a, b, c) = gcd(gcd(a, b), c).
            int gcd = gcdAlgorithm(values[0], values[1]);
            for (int i = 2; i < values.Length; i++)
            {
                gcd = gcdAlgorithm(gcd, values[i]);
            }

            return gcd;
        }

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
        /// <param name="third">
        /// Third number.
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
        /// <param name="numbers">
        /// The numbers.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if numbers parameter is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if all parameters are zeros.
        /// </exception>
        private static void ThrowForInvalidParameters(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (Array.TrueForAll(numbers, n => n == 0))
            {
                throw new ArgumentException("Cannot calculate GCD of zeros.");
            }
        }

        #endregion
    }
}
