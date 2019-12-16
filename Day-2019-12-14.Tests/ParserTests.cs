using System.Collections.Generic;
using NUnit.Framework;

namespace Day_2019_12_14.Tests
{
    public class Tests
    {
        private static IEnumerable<TestCaseData> ParserChemicalTestCases
        {
            get
            {
                yield return new TestCaseData("10 ORE", new Chemical("ORE", 10));
                yield return new TestCaseData("5 FUEL", new Chemical("FUEL", 5));
            }
        }

        [TestCaseSource("ParserChemicalTestCases")]
        public void ParseChemicalTest(string data, IChemical chemical)
        {
            var parsed = Parser.ParseChemical(data);
            Assert.That(parsed, Is.EqualTo(chemical));
        }

        private static IEnumerable<TestCaseData> ParseReactionTestCases
        {
            get
            {
                yield return new TestCaseData("10 ORE => 10 A", new[] { new Chemical("ORE", 10) }, new Chemical("A", 10));
                yield return new TestCaseData(
                    "2 AB, 3 BC, 4 CA => 1 FUEL",
                    new[]
                    {
                        new Chemical("AB", 2),
                        new Chemical("BC", 3),
                        new Chemical("CA", 4)
                    },
                    new Chemical("FUEL", 1));
            }
        }
        
        [TestCaseSource("ParseReactionTestCases")]
        public void ParseReactionTest(string data, IChemical[] input, IChemical output)
        {
            var reaction = Parser.ParseReaction(data);
            Assert.That(reaction.Input, Is.EquivalentTo(input));
            Assert.That(reaction.Output, Is.EqualTo(output));
        }
        
        private static IEnumerable<TestCaseData> ParseTestCases
        {
            get
            {
                yield return new TestCaseData("10 ORE => 10 A|4 CA, 2 AB => 1 FUEL", new[]
                {
                    new Reaction(new [] { new Chemical("ORE", 10)  }, new Chemical("A", 10)),
                    new Reaction(new [] { new Chemical("CA", 4), new Chemical("AB", 2) }, new Chemical("FUEL", 1))
                });
            }
        }
        
        [TestCaseSource("ParseTestCases")]
        public void ParseTest(string data, IReaction[] reactions)
        {
            var parsed = Parser.Parse(data);
            Assert.That(parsed, Is.EquivalentTo(reactions));
        }
    }
}