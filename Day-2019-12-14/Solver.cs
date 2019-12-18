using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_14
{
    public static class Solver
    {
        private const string Fuel = "FUEL";
        private const string Ore = "ORE";
        
        public static long CalculateOreAmountForOneFuel(IEnumerable<IReaction> reactions)
        {
            var reactionsDict = reactions.ToDictionary(reaction => reaction.Output.Name, reaction => reaction);
            
            var requiredChemicals = new List<(string name, long amount)>();
            var waste = new Dictionary<string, long>();
            
            requiredChemicals.Add((Fuel, 1));

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
    }
}