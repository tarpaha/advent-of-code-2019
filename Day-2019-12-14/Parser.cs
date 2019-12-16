using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_14
{
    public static class Parser
    {
        public static IChemical ParseChemical(string data)
        {
            var amountName = data.Split(' ');
            return new Chemical(amountName[1], int.Parse(amountName[0]));
        }
        
        public static IReaction ParseReaction(string data)
        {
            var inputOutput = data.Split(new [] {"=>"}, StringSplitOptions.None);
            
            var input = inputOutput[0].Trim()
                .Split(',')
                .Select(chemicalString => ParseChemical(chemicalString.Trim()));
            var output = ParseChemical(inputOutput[1].Trim());
            
            return new Reaction(input, output);
        }

        public static IEnumerable<IReaction> Parse(string data)
        {
            return data
                .Split(new []{ Environment.NewLine, "|"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseReaction);
        }
    }
}