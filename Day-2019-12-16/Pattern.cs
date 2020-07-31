using System.Collections.Generic;

namespace Day_2019_12_16
{
    public static class Pattern
    {
        private static readonly int[] BasePattern = {0, 1, 0, -1};

        public static IEnumerable<int> Generator(int length, int position)
        {
            var basePatternPosition = 0;
            var repeatCount = position;
            var skipOne = true;
            for (var patternPosition = 0; patternPosition <= length; patternPosition++)
            {
                if(skipOne)
                    skipOne = false;
                else
                    yield return BasePattern[basePatternPosition];
                if (--repeatCount == 0)
                {
                    if (++basePatternPosition == BasePattern.Length)
                        basePatternPosition = 0;
                    repeatCount = position;
                }
            }
        }
    }
}