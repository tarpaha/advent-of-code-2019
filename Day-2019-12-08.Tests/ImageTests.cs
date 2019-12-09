using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_08.Tests
{
    public class ImageTests
    {
        [TestCase("123456789012", 3, 2, 2)]
        public void CreationTest(string dataStr, int width, int height, int layers)
        {
            var data = dataStr.Select(ch => ch - '0').ToArray();
            var image = new Image(data, width, height);
            Assert.That(image.Width, Is.EqualTo(width));
            Assert.That(image.Height, Is.EqualTo(height));
            Assert.That(image.LayersCount, Is.EqualTo(layers));
        }

        [Test]
        public void TestNumDigitsInLayer()
        {
            const int layersCount = 3;
            const int width = 2;
            const int height = 2;
            
            var data = new List<int>();
            for (var i = 0; i < layersCount; i++)
            {
                data.AddRange(Enumerable.Repeat(i, width * height));
            }
            
            var image = new Image(data.ToArray(), width, height);

            for (var layerId = 0; layerId < layersCount; layerId++)
            {
                Assert.That(image.GetNumDigitsInLayer(layerId, layerId), Is.EqualTo(width * height));
            }
        }
    }
}