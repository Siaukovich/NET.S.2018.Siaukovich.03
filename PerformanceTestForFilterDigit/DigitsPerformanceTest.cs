#define DEBUG

namespace PerformanceTestForFilterDigit
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using FilterDigits;

    using NUnit.Framework;

    [TestFixture]
    public class DigitsPerformanceTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            var listener = new DelimitedListTraceListener(@"PerformanceOutput.log");
            Debug.Listeners.Add(listener);
        }

        [Test]
        public void FilterDigitNumber_PerformanceTest()
        {
            var rng = new Random(0);
            int[] array = Enumerable.Repeat(0, 10000000)
                                    .Select(v => rng.Next())
                                    .ToArray();

            var sw = new Stopwatch();
            sw.Start();

            for (int digit = 0; digit < 10; digit++)
            {
                Digits.FilterDigits(array, digit);
            }

            sw.Stop();

            SaveResultToLog(sw.ElapsedMilliseconds);
        }

        [Test]
        public void FilterDigitString_PerformanceTest()
        {
            var rng = new Random(0);
            int[] array = Enumerable.Repeat(0, 10000000)
                                    .Select(v => rng.Next())
                                    .ToArray();

            var sw = new Stopwatch();
            sw.Start();

            for (int digit = 0; digit < 10; digit++)
            {
                Digits.FilterDigits(array, digit);
            }

            sw.Stop();

            SaveResultToLog(sw.ElapsedMilliseconds);
        }

        private static void SaveResultToLog(long time)
        {
            Debug.WriteLine($"Filtering digits 10 times with ints in {time} ms.");
            Debug.Flush();
        }
    }
}
