namespace ApproximateMath
{
    using System;

    /// <summary>
    /// Set of math functions that calculate desirable result with some given accuracy.
    /// </summary>
    public static class ApproximateMath
    {
        /// <summary>
        /// Calculates the Nth root by Newton's method with given accuracy.
        /// </summary>
        /// <param name="number">
        /// Number, which root will be calculated.
        /// </param>\
        /// <param name="rootPower">
        /// Nth root.
        /// </param>
        /// <param name="epsilon">
        /// Calculation accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// Returns the Nth root of given value calculated with given accuracy.
        /// </returns>
        public static double FindNthRoot(double number, int rootPower, double epsilon)
        {
            ThrowForInvalidParameters(number, rootPower, epsilon);

            double currentApproximation = number;
            double previousApproximation;
            while (true)
            {
                previousApproximation = currentApproximation;
                currentApproximation = GetNextApproximation(number, rootPower, currentApproximation);

                if (Math.Abs(currentApproximation - previousApproximation) < epsilon)
                {
                    return currentApproximation;
                }

            }
        }

        /// <summary>
        /// Calculates value of the next approximation.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="rootPower">
        /// Root power.
        /// </param>
        /// <param name="previousApproximation">
        /// Previous approximation.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// Next approximation given by Newton's formula.
        /// </returns>
        private static double GetNextApproximation(double number, int rootPower, double previousApproximation)
        {
            double leftPart = (rootPower - 1) * previousApproximation;
            double rightPart = number / Math.Pow(previousApproximation, rootPower - 1);
            double sum = leftPart + rightPart;
            return sum / rootPower;
        }

        /// <summary>
        /// Validated passed parameters.
        /// </summary>
        /// <param name="number">
        /// Number which root will be calculated.
        /// </param>
        /// <param name="rootPower">
        /// Root power.
        /// </param>
        /// <param name="epsilon">
        /// Given accuracy.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when number &lt; 0 root power is even. 
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown in two cases: when epsilon &lt; 0 or root power &lt; 0.
        /// </exception>
        private static void ThrowForInvalidParameters(double number, int rootPower, double epsilon)
        {
            if (number < 0 && rootPower % 2 == 0)
            {
                throw new ArgumentException("Impossible to calculate Nth root of negative value if N is even.");
            }

            if (epsilon < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(epsilon), "Accuracy can not be less than 0.");
            }

            if (rootPower <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rootPower), "Roots power can not be less than 1.");
            }
        }
    }
}
