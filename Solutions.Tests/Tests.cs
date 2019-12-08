using System.Collections.Generic;
using NUnit.Framework;
using Utils;

namespace Solutions.Tests
{
    public class Tests
    {
        private static IEnumerable<TestCaseData> SolutionsTestCases
        {
            get
            {
                yield return new TestCaseData(new Day_2019_12_01.App.Solution(), 3291760, 4934767);
                yield return new TestCaseData(new Day_2019_12_02.App.Solution(), 3790689, 6533);
                yield return new TestCaseData(new Day_2019_12_03.App.Solution(), 627, 13190);
                yield return new TestCaseData(new Day_2019_12_04.App.Solution(), 2150, 1462);
                yield return new TestCaseData(new Day_2019_12_05.App.Solution(), 15097178, 1558663);
            }
        }

        [TestCaseSource("SolutionsTestCases")]
        public void Test(ISolution solution, int result1, int result2)
        {
            Assert.That(solution.SolvePart1(), Is.EqualTo(result1));
            Assert.That(solution.SolvePart2(), Is.EqualTo(result2));
        }
    }
}