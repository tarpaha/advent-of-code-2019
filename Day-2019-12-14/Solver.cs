using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_14
{
    public static class Solver
    {
        private const string Fuel = "FUEL";
        private const string Ore = "ORE";
        
        public static int CalculateOreAmountForOneFuel(IEnumerable<IReaction> reactions)
        {
            var reactionsDict = reactions.ToDictionary(reaction => reaction.Output.Name, reaction => reaction);
            
            var requiredChemicals = new List<(string name, int amount)>();
            var waste = new Dictionary<string, int>();
            
            requiredChemicals.Add((Fuel, 1));

            var ore = 0;
            while(requiredChemicals.Count > 0)
            {
                var (requiredChemicalName, requiredChemicalAmount) = requiredChemicals[0];
                requiredChemicals.RemoveAt(0);

                waste.TryGetValue(requiredChemicalName, out var wasteAmount);
                if (wasteAmount >= requiredChemicalAmount)
                {
                    waste[requiredChemicalName] = wasteAmount - requiredChemicalAmount;
                    continue;
                }

                var requiredReaction = reactionsDict[requiredChemicalName];

                foreach (var inputChemical in requiredReaction.Input)
                {
                    if (inputChemical.Name == Ore)
                        ore += inputChemical.Amount;
                    else
                        requiredChemicals.Add((inputChemical.Name, inputChemical.Amount));
                }

                var outputFromReaction = requiredReaction.Output.Amount;
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