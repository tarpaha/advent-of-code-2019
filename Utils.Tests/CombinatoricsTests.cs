using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Tests
{
    public class CombinatoricsTests
    {
        private static IEnumerable<TestCaseData> PermuteTestCases
        {
            get
            {
                yield return new TestCaseData(1, new [] { new [] {0} });
                yield return new TestCaseData(2, new [] { new [] {0, 1}, new [] {1,0} });
                yield return new TestCaseData(3, new []
                {
                    new [] {0, 1, 2}, new [] {0, 2, 1},
                    new [] {1, 0, 2}, new [] {1, 2, 0},
                    new [] {2, 1, 0}, new [] {2, 0, 1}
                });
            }
        }
        
        [TestCaseSource("PermuteTestCases")]
        public void PermuteTest(int n, int[][] resultPermutations)
        {
            var collection = Enumerable.Range(0, n);
            var permutations = Combinatorics
                .Permute(collection)
                .Select(c => c.ToArray())
                .ToArray();
            Assert.That(permutations.Count, Is.EqualTo(resultPermutations.Length));
            foreach (var resultPermutation in resultPermutations)
            {
                Assert.That(permutations.Any(p => p.SequenceEqual(resultPermutation)), Is.True);
            }
        }
    }
}