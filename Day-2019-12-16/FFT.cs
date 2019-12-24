using System.Linq;

namespace Day_2019_12_16
{
    public static class FFT
    {
        public static int[] Process(int[] signal, int phases)
        {
            for (var i = 0; i < phases; i++)
                signal = ProcessOnePhase(signal);
            return signal;
        }
        
        private static int[] ProcessOnePhase(int[] signal)
        {
            return Enumerable.Range(0, signal.Length).ToList()
                .AsParallel()
                .Select(position =>
                {
                    var index = 0;
                    var sum = Pattern.Generator(signal.Length, position + 1).Sum(n => signal[index++] * n);
                    return LastDigit(sum);
                })
                .ToArray();
        }
        
        private static int LastDigit(int number)
        {
            var digit = number % 10;
            return digit < 0 ? -digit : digit;
        }
    }
}