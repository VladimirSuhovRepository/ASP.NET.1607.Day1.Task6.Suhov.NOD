using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day1.Task6.Suhov.Tests
{
    [TestFixture]
    public class NODCalculationTest
    {
        [TestCase(0, 10, Result = 10), TestCase(10, 0, Result = 10)]
        [TestCase(0, 0, Result = 0), TestCase(8, 8, Result = 8)]
        [TestCase(30, 15, Result = 15), TestCase(30, 45, Result = 15)]
        [TestCase(7, 19, Result = 1), TestCase(-30, 45, Result = 15)]
        [TestCase(-3, -9, Result = 3), TestCase(95, 25, Result = 5)]
       
        public long Euclidean_TwoParameters_Test(long a, long b)
        {
            long ticks;

            long result = GCD.Euclidean(a, b, out ticks);
            Debug.WriteLine($"Total ellapsed time: {ticks}");
            return result;
        }

        [TestCase(0, 10, 0, Result = 10), TestCase(27, 9, 54, Result = 9)]
        [TestCase(30, 15, 45, Result = 15), TestCase(54, 108, 27, Result = 27)]
        [TestCase(17, 81, 112, Result = 1)]
        [TestCase(30, 15, 90, 45, 135, Result = 15), TestCase(1, 3, 5, 7, 9, 11, 13, 15, Result = 1)]
        [TestCase(81, 1, 123, 89346, 2893, 39847, Result = 1), TestCase(750, 450, 325, 1025, 25, 3250, 50, 115, Result = 5)]
        public long Euclidean_Params_Test(params long[] array)
        {
            long ticks;

            long result = GCD.Euclidean(out ticks, array);
            Debug.WriteLine($"Total ellapsed time: {ticks}");
            return result;
        }

        [TestCase(0, 10, Result = 10), TestCase(10, 0, Result = 10)]
        [TestCase(0, 0, Result = 0), TestCase(8, 8, Result = 8)]
        [TestCase(30, 15, Result = 15), TestCase(30, 45, Result = 15)]
        [TestCase(7, 19, Result = 1), TestCase(-30, 45, Result = 15)]
        [TestCase(-3, -9, Result = 3), TestCase(95, 25, Result = 5)]
        public long Stein_TwoParameters_Test(long a, long b)
        {
            long ticks;

            long result = GCD.Stein(a, b, out ticks);
            Debug.WriteLine($"Total ellapsed time: {ticks}");
            return result;
        }

        [TestCase(0, 10, 0, Result = 10), TestCase(27, 9, 54, Result = 9)]
        [TestCase(30, 15, 45, Result = 15), TestCase(54, 108, 27, Result = 27)]
        [TestCase(17, 81, 112, Result = 1)]
        [TestCase(30, 15, 90, 45, 135, Result = 15), TestCase(1, 3, 5, 7, 9, 11, 13, 15, Result = 1)]
        [TestCase(81, 1, 123, 89346, 2893, 39847, Result = 1), TestCase(750, 450, 325, 1025, 25, 3250, 50, 115, Result = 5)]
        public long Stein_Params_Test(params long[] array)
        {
            long ticks;

            long result = GCD.Stein(out ticks, array);
            Debug.WriteLine($"Total ellapsed time: {ticks}");
            return result;
        }

    }
}
