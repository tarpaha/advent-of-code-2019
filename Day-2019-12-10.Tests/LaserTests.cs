using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_10.Tests
{
    public class LaserTests
    {
        private const string Data = @"
.#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##
"; 
        
        [TestCase(1, 11, 12)]
        [TestCase(2, 12, 1)]
        [TestCase(3, 12, 2)]
        [TestCase(10, 12, 8)]
        [TestCase(20, 16, 0)]
        [TestCase(50, 16, 9)]
        [TestCase(100, 10, 16)]
        [TestCase(199, 9, 6)]
        [TestCase(200, 8, 2)]
        [TestCase(201, 10, 9)]
        [TestCase(299, 11, 1)]
        public void Test(int n, int x, int y)
        {
            var asteroids = Reader.Read(Data).ToList();
            var bestAsteroid = Visibility.GetMostVisibleCount(asteroids).asteroid;
            var nthDestroyedAsteroid = Laser.GetNthDestroyedAsteroid(n, bestAsteroid, asteroids); 
            Assert.That((nthDestroyedAsteroid.X, nthDestroyedAsteroid.Y) , Is.EqualTo((x, y)));
        }
    }
}