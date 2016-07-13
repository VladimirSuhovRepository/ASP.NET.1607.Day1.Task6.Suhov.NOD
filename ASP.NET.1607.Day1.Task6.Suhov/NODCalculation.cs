using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day1.Task6.Suhov
{
    public static class GCD
    {
        private delegate long GCDAlgorithm(long a, long b);

        #region Public Methods

        #region Euclidean
        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="a">The first number </param>
        /// <param name="b">The second number</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean(long a, long b) => Calculate(a, b, EuclideanCalculate);

        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <param name="ticks">The number of timer ticks that have been spent on the calculation</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean(long a, long b, out long ticks) => Calculate(a, b, out ticks, EuclideanCalculate);

        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean(params long[] array) => Calculate(EuclideanCalculate, array);

        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="ticks">The number of timer ticks that have been spent on the calculation</param>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean(out long ticks, params long[] array) => Calculate(EuclideanCalculate, out ticks, array);
        #endregion

        #region Stein
        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(long a, long b) => Calculate(a, b, SteinCalculate);

        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <param name="ticks">The number of timer ticks that have been spent on the calculation</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(long a, long b, out long ticks) => Calculate(a, b, out ticks, SteinCalculate);

        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm
        /// </summary>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(params long[] array) => Calculate(SteinCalculate, array);

        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm
        /// </summary>
        /// <param name="ticks">The number of timer ticks that have been spent on the calculation</param>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(out long ticks, params long[] array) => Calculate(SteinCalculate, out ticks, array);
        #endregion

        #endregion

        #region Private Methods
        private static long Calculate(GCDAlgorithm algorithm, out long ticks, params long[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            long result = 0;
            ticks = 0;
            foreach (long element in array)
            {
                long t;
                result = Calculate(result, element, out t, algorithm);
                ticks += t;
            }
            return result;
        }

        private static long Calculate(long a, long b, GCDAlgorithm algorithm)
        {
            if (a < 0)
                a *= -1;
            if (b < 0)
                b *= -1;
            if (a == b)
                return b;
            if (a == 0)
                return b;

            return b == 0 ? a : algorithm(a, b);
        }

        private static long Calculate(long a, long b, out long ticks, GCDAlgorithm algorithm)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            long result = Calculate(a, b, algorithm);
            timer.Stop();
            ticks = timer.ElapsedTicks;
            return result;
        }

        private static long Calculate(GCDAlgorithm algorithm, params long[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            return array.Aggregate<long, long>(0, (a, b) => Calculate(a, b, algorithm));
        }

        private static long EuclideanCalculate(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static long SteinCalculate(long a, long b)
        {
            int shift;
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }
            while ((a & 1) == 0)
                a >>= 1;
            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                {
                    long t = b;
                    b = a;
                    a = t;
                }
                b = b - a;
            } while (b != 0);
            return a << shift;
        }
        #endregion
    }

}
