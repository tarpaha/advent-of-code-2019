namespace Day_2019_12_01
{
    public class SolutionPart2
    {
        public int CalculateRequiredFuel(int mass)
        {
            var fuel = 0;
            while (true)
            {
                mass = (mass / 3) - 2;
                if (mass <= 0)
                    break;
                fuel += mass;
            }
            return fuel;
        }
    }
}