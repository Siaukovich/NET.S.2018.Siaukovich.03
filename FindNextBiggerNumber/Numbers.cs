namespace Numbers
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class with method to find next bigger number.
    /// </summary>
    public static class Numbers
    {
        /// <summary>
        /// Finds the number, that is consist only of digits of the passed number
        /// and is the smallest of larger numbers.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="(int answer, long elapsedMilliseconds)"/>.
        /// Returns a tuple which contains the answer and the time that was taken to calculate it.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if number is less or equal to zero.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Thrown if number doesn't fit in Int32 value.
        /// </exception>
        public static (int answer, long elapsedMilliseconds) FindNextBiggerNumber(int number)
        {
            Stopwatch sw = Stopwatch.StartNew();
            
            ThrowForNonpositiveNumber(number);

            string strNumber = number.ToString();

            int index = GetBreakIndex(strNumber);
            if (index == -1)
            {
                sw.Stop();
                return (-1, sw.ElapsedMilliseconds);
            }

            char leftest = strNumber[index];

            QsortSubstring(ref strNumber, index + 1, strNumber.Length - 1);
            SwapWithLowest(ref strNumber, index, leftest);

            ThrowForIntegerOverflow(strNumber);

            return (int.Parse(strNumber), sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Finds index of the last element which is 
        /// followed by the element greater than it.
        /// </summary>
        /// <param name="strNumber">
        /// Number as string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// Index of the last element which is 
        /// followed by the element greater than it.
        /// -1 if no such element.
        /// </returns>
        private static int GetBreakIndex(string strNumber)
        {
            for (int i = strNumber.Length - 1; i > 0; i--)
            {
                if (strNumber[i - 1] < strNumber[i])
                {
                    return i - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Swaps last element which is 
        /// followed by the element greater than it
        /// with the least element that is greater than and 
        /// that is located from index to the end of string number.
        /// </summary>
        /// <param name="strNumber">
        /// Number as string.
        /// </param>
        /// <param name="index">
        /// Start index.
        /// </param>
        /// <param name="leftest">
        /// Last element which is 
        /// followed by the element greater than it.
        /// </param>
        private static void SwapWithLowest(ref string strNumber, int index, char leftest)
        {
            for (int i = index; i < strNumber.Length; ++i)
            {
                if (leftest < strNumber[i])
                {
                    StringSwap(ref strNumber, index, i);
                    break;
                }
            }
        }

        /// <summary>
        /// Method for sorting substring.
        /// </summary>
        /// <param name="strNumber">
        /// String which substring that needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left index of sub-string.
        /// </param>
        /// <param name="right">
        /// Right index of sub-string.
        /// </param>
        private static void QsortSubstring(ref string strNumber, int left, int right)
        {
            if (left > right)
            {
                return;
            }

            int randomPivotIndex = (left + right) / 2;
            int pivotIndex = Partition(ref strNumber, left, right, randomPivotIndex);

            QsortSubstring(ref strNumber, left, pivotIndex - 1);
            QsortSubstring(ref strNumber, pivotIndex + 1, right);
        }

        /// <summary>
        /// Rearranges elements in array in the way that elements that are larger than 
        /// the pivot are in the right side of it and elements that are lower that the
        /// pivot are in the left side of it.
        /// </summary>
        /// <param name="strNumber">
        /// String which substring that needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left index of sub-string.
        /// </param>
        /// <param name="right">
        /// Right index of sub-string.
        /// </param>
        /// <param name="pivotIndex">
        /// The pivot element index.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int Partition(ref string strNumber, int left, int right, int pivotIndex)
        {
            int pivot = strNumber[pivotIndex];
            StringSwap(ref strNumber, pivotIndex, right);
            int swapPosition = left;

            for (int i = left; i < right; ++i)
            {
                if (strNumber[i] < pivot)
                {
                    StringSwap(ref strNumber, i, swapPosition);
                    swapPosition++;
                }
            }

            StringSwap(ref strNumber, swapPosition, right);

            return swapPosition;
        }

        /// <summary>
        /// Swaps two elements in passed string.
        /// </summary>
        /// <param name="str">
        /// String that needs to be modified.
        /// </param>
        /// <param name="indexOne">
        /// Index of the first element.
        /// </param>
        /// <param name="indexTwo">
        /// Index of the second element..
        /// </param>
        private static void StringSwap(ref string str, int indexOne, int indexTwo)
        {
            char[] chars = str.ToCharArray();
            Swap(ref chars[indexOne], ref chars[indexTwo]);
            str = new string(chars);
        }

        /// <summary>
        /// Swaps two char elements.
        /// </summary>
        /// <param name="a">
        /// First element.
        /// </param>
        /// <param name="b">
        /// Second element.
        /// </param>
        private static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Throw for non-positive number.
        /// </summary>
        /// <param name="number">
        /// Number that needs to be validated.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if number is less or equal to zero.
        /// </exception>
        private static void ThrowForNonpositiveNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"{nameof(number)} must have positive value.");
            }
        }

        /// <summary>
        /// Throw for integer overflow.
        /// </summary>
        /// <param name="strNumber">
        /// Number as string.
        /// </param>
        /// <exception cref="OverflowException">
        /// Thrown if number doesn't fit in Int32 value.
        /// </exception>
        private static void ThrowForIntegerOverflow(string strNumber)
        {
            if (!int.TryParse(strNumber, out int _))
            {
                throw new OverflowException("Next bigger number overflows Int32.");
            }
        }
    }
}
