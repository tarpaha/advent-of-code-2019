namespace Day_2019_12_10
{
    public class Asteroid : IAsteroid
       {
        public int X { get; }
        public int Y { get; }
        public string Name { get; }

        public Asteroid(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }
    }
}