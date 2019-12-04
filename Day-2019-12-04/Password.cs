using System;
using System.Linq;

namespace Day_2019_12_04
{
    public static class Password
    {
        public static bool IsCorrectType1(int[] digits)
        {
            var adjacentFound = false;
            var previousDigit = 0;
            foreach (var digit in digits)
            {
                if (digit < previousDigit)
                    return false;
                if (digit == previousDigit)
                    adjacentFound = true;
                previousDigit = digit;
            }
            return adjacentFound;
        }

        public static bool IsCorrectType2(int[] digits)
        {
            var adjacentFound = false;
            var sameDigitsCount = 1;
            var previousDigit = 0;
            foreach (var digit in digits)
            {
                if (digit < previousDigit)
                    return false;
                if (digit == previousDigit)
                {
                    sameDigitsCount += 1;
                }
                else
                {
                    if (sameDigitsCount == 2)
                        adjacentFound = true;
                    sameDigitsCount = 1;
                }
                previousDigit = digit;
            }
            return adjacentFound || sameDigitsCount == 2;
        }
    }
}