namespace Day_2019_12_04
{
    public static class Converter
    {
        public static int[] ToSixDigits(int v)
        {
            var result = new int[6];
            for (var i = 5; i >= 0; i--)
            {
                result[i] = v % 10;
                v /= 10;
            }
            return result;
        }
    }
}