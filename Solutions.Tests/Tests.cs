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
                yield return new TestCaseData(new Day_2019_12_06.App.Solution(), 234446, 385);
                yield return new TestCaseData(new Day_2019_12_07.App.Solution(), 366376, 21596786);
                yield return new TestCaseData(new Day_2019_12_08.App.Solution(), 1485, "111001000001100100101111010010100001001010100100001001010000100101100011100111001000011110101001000010100100001001010100100001001011110100101001010000");
                yield return new TestCaseData(new Day_2019_12_09.App.Solution(), 2955820355, 46643);
            }
        }

        [TestCaseSource("SolutionsTestCases")]
        public void Test(ISolution solution, object result1, object result2)
        {
            if(result1 != null)
                Assert.That(solution.SolvePart1(), Is.EqualTo(result1));
            if(result2 != null)
                Assert.That(solution.SolvePart2(), Is.EqualTo(result2));
        }
    }
}