using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_14
{
    public static class Solver
    {
        private const string Fuel = "FUEL";
        private const string Ore = "ORE";
        
        public static long CalculateOreAmountForFuel(IEnumerable<IReaction> reactions, long fuelAmount = 1)
        {
            var reactionsDict = reactions.ToDictionary(reaction => reaction.Output.Name, reaction => reaction);
            
            var requiredChemicals = new List<(string name, long amount)>();
            var waste = new Dictionary<string, long>();
            
            requiredChemicals.Add((Fuel, fuelAmount));

            var ore = 0L;
            while(requiredChemicals.Count > 0)
            {
                var (requiredChemicalName, requiredChemicalAmount) = requiredChemicals[0];
                requiredChemicals.RemoveAt(0);

                waste.TryGetValue(requiredChemicalName, out var wasteAmount);
                if (wasteAmount > 0)
                {
                    var useFromWaste = wasteAmount < requiredChemicalAmount
                        ? wasteAmount
                        : requiredChemicalAmount;
                    waste[requiredChemicalName] = wasteAmount - useFromWaste;
                    requiredChemicalAmount -= useFromWaste;
                    if(requiredChemicalAmount == 0)
                        continue;
                }

                var requiredReaction = reactionsDict[requiredChemicalName];
                var requiredReactionTimes = requiredChemicalAmount / requiredReaction.Output.Amount;
                if (requiredChemicalAmount % requiredReaction.Output.Amount > 0)
                    requiredReactionTimes += 1;

                foreach (var inputChemical in requiredReaction.Input)
                {
                    if (inputChemical.Name == Ore)
                        ore += requiredReactionTimes * inputChemical.Amount;
                    else
                        requiredChemicals.Add((inputChemical.Name, requiredReactionTimes * inputChemical.Amount));
                }

                var outputFromReaction = requiredReactionTimes * requiredReaction.Output.Amount;
                if (requiredChemicalAmount > outputFromReaction)
                {
                    requiredChemicals.Add((requiredChemicalName, requiredChemicalAmount - outputFromReaction));
                }
                else if (requiredChemicalAmount < outputFromReaction)
                {
                    waste.TryGetValue(requiredChemicalName, out wasteAmount);
                    waste[requiredChemicalName] = wasteAmount + outputFromReaction - requiredChemicalAmount;
                }
            }
            return ore;
        }

        private const long Trillion = 1000000000000L;
        public static long CalculateFuelAmountForTrillionOre(IEnumerable<IReaction> reactions)
        {
            var reactionsList = new List<IReaction>(reactions);
            var orePerOneFuel = CalculateOreAmountForFuel(reactionsList);

            var left = Trillion / orePerOneFuel;
            var right = left * 2;

            while (left < right - 1)
            {
                var fuel = (left + right) / 2;
                var ore = CalculateOreAmountForFuel(reactionsList, fuel);
                if (ore > Trillion)
                    right = fuel;
                else if (ore < Trillion)
                    left = fuel;
                else break;
            }
            
            return left;
        }
    }
}