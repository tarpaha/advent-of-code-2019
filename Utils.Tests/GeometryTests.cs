using System.Collections.Generic;
using NUnit.Framework;

namespace Utils.Tests
{
    public class GeometryTests
    {
        private static IEnumerable<TestCaseData> GeometryIntersectTestCases
        {
            get
            {
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Segment2(0, 3, 0, 1), false, new Vector2(0, 0));
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Segment2(0, 2, 0, 0), true, new Vector2(0, 0));
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Segment2(2, 2, 2, 0), true, new Vector2(2, 0));
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Segment2(1, 1, 1, -1), true, new Vector2(1, 0));
                yield return new TestCaseData(new Segment2(2, 5, 2, 1), new Segment2(3, 4, -2, 4), true, new Vector2(2, 4));
            }
        }

        [TestCaseSource("GeometryIntersectTestCases")]
        public void TestIntersect(Segment2 s1, Segment2 s2, bool intersected, Vector2 intersection)
        {
            var intersectionResult = Geometry.Intersect(s1, s2, out var intersectionPosition);
            Assert.That(intersectionResult, Is.EqualTo(intersected));
            if(intersected)
                Assert.That(intersectionPosition, Is.EqualTo(intersection));
        }
        
        private static IEnumerable<TestCaseData> GeometryDistantFromSegmentStartTestCases
        {
            get
            {
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Vector2(0, 0), 0);
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Vector2(2, 0), 2);
                yield return new TestCaseData(new Segment2(2, 0, 0, 0), new Vector2(2, 0), 0);
                yield return new TestCaseData(new Segment2(0, 0, 3, 0), new Vector2(1, 0), 1);
                yield return new TestCaseData(new Segment2(3, 0, 0, 0), new Vector2(1, 0), 2);
                
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Vector2(3, 0), -1);
                yield return new TestCaseData(new Segment2(0, 0, 2, 0), new Vector2(1, 1), -1);
                
                yield return new TestCaseData(new Segment2(0, 0, 0, 2), new Vector2(0, 0), 0);
                yield return new TestCaseData(new Segment2(0, 0, 0, 2), new Vector2(0, 2), 2);
                yield return new TestCaseData(new Segment2(0, 2, 0, 0), new Vector2(0, 2), 0);
                yield return new TestCaseData(new Segment2(0, 0, 0, 3), new Vector2(0, 1), 1);
                yield return new TestCaseData(new Segment2(0, 3, 0, 0), new Vector2(0, 1), 2);
                
                yield return new TestCaseData(new Segment2(0, 0, 0, 2), new Vector2(0, 3), -1);
                yield return new TestCaseData(new Segment2(0, 0, 0, 2), new Vector2(1, 1), -1);
            }
        }

        [TestCaseSource("GeometryDistantFromSegmentStartTestCases")]
        public void TestDistantFromSegmentStart(Segment2 s, Vector2 p, int distance)
        {
            Assert.That(Geometry.DistanceFromSegmentStart(s, p), Is.EqualTo(distance));
        }
    }
}