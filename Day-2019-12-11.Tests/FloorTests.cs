using System.Linq;
using NUnit.Framework;
using Utils;

namespace Day_2019_12_11.Tests
{
    public class FloorTests
    {
        [TestCase(0, 0)]
        [TestCase(100, 100)]
        public void TestThatDefaultColorIsBlack(int x, int y)
        {
            var floor = new Floor();
            Assert.That(floor.GetColor(new  Vector2(x, y)), Is.EqualTo(0));
        }
        
        [TestCase(0, 0, new [] { 0, 1, 0, 1 }, 1, 1, 1)]
        [TestCase(100, 100, new [] { 1, 1, 1, 0}, 0, 1, 0)]
        public void TestThatPaintingWorks(int x, int y, int[] colors, long finalColor, int panelsCount, int whitePanelsCount)
        {
            var floor = new Floor();
            foreach (var color in colors)
                floor.Paint(new Vector2(x, y), color);
            Assert.That(floor.GetColor(new  Vector2(x, y)), Is.EqualTo(finalColor));
            Assert.That(floor.PaintedPanelsCount, Is.EqualTo(panelsCount));
            Assert.That(floor.WhitePanels.Count(), Is.EqualTo(whitePanelsCount));
        }
    }
}