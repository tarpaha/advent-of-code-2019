using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_16
{
    public static class FFT
    {
        public static int[] Process(int[] signal, int phases)
        {
            var patterns = Enumerable
                .Range(1, signal.Length)
                .Select(position => Pattern.Generate(signal.Length, position))
                .ToArray();

            for (var i = 0; i < phases; i++)
                signal = ProcessOnePhase(signal, patterns);

            return signal;
        }
        
        private static int[] ProcessOnePhase(int[] signal, int[][] patterns)
        {
            return Enumerable
                .Range(1, signal.Length)
                .ToList()
                .AsParallel()
                .Select(position => Multiply(signal, patterns[position - 1]))
                .Select(LastDigit)
                .ToArray();
        }

        private static int Multiply(IReadOnlyList<int> signal, IReadOnlyList<int> pattern)
        {
            return signal.Select((t, i) => t * pattern[i]).Sum();
        }
        
        private static int LastDigit(int number)
        {
            var digit = number % 10;
            if(digit < 0)
                digit = -digit;
            return digit;
        }
    }
}