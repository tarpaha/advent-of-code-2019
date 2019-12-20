using System.Collections.Generic;

namespace Day_2019_12_16
{
    public static class Pattern
    {
        private static readonly int[] BasePattern = {0, 1, 0, -1};

        public static int[] Generate(int length, int position)
        {
            var pattern = new List<int>(length + 1);
            var basePatternPosition = 0;
            var repeatCount = position;
            for (var patternPosition = 0; patternPosition <= length; patternPosition++)
            {
                pattern.Add(BasePattern[basePatternPosition]);
                if (--repeatCount == 0)
                {
                    if (++basePatternPosition == BasePattern.Length)
                        basePatternPosition = 0;
                    repeatCount = position;
                }
            }
            pattern.RemoveAt(0);
            return pattern.ToArray();
        }
    }
}