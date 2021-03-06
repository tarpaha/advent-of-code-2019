﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class Mathematics
    {
        public static (int a, int b, int n) ReduceFraction(int a, int b)
        {
            if (a == 0)
                return (0, b > 0 ? 1 : -1, Math.Abs(b));
            if (b == 0)
                return (a > 0 ? 1 : -1, 0, Math.Abs(a));
            
            var n = 1;
            var min = Math.Abs(a) < Math.Abs(b) ? Math.Abs(a) : Math.Abs(b);
            for (var div = 2; div <= min; div++)
            {
                if (a % div == 0 && b % div == 0)
                {
                    n *= div;
                    a /= div;
                    b /= div;
                    min /= div;
                    div = 1;
                }
            }
            return (a, b, n);
        }

        public static int Sign(int v)
        {
            if (v > 0)
                return 1;
            if (v < 0)
                return -1;
            return 0;
        }

        public static long[] Dividers(long v)
        {
            if (v == 1)
                return new long[] { 1 };
            
            var dividers = new List<long>();
            for (var d = 2; d <= v; d++)
            {
                if (v % d == 0)
                {
                    dividers.Add(d);
                    v /= d;
                    d--;
                }
            }
            return dividers.ToArray();
        }

        public static long LeastCommonMultiple(long[] values)
        {
            var max = values.Max();
            var maxDividers = Dividers(max).ToList();

            var otherDividers = values
                .Where(v => v != max)
                .Select(v => Dividers(v).ToList())
                .ToList();

            foreach (var maxDivider in maxDividers)
            {
                foreach (var dividers in otherDividers)
                {
                    dividers.Remove(maxDivider);
                }
            }

            foreach (var dividers in otherDividers)
            {
                maxDividers.AddRange(dividers);
            }
            
            return maxDividers.Aggregate((x, y) => x * y);
        }
    }
}