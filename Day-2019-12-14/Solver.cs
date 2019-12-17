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
            var requiredChemicals = new List<(string name, int amount)>();
            var waste = new Dictionary<string, int>();
            
            requiredChemicals.Add((Fuel, 1));

            var ore = 0;
            while(requiredChemicals.Count > 0)
            {
                var requiredChemical = requiredChemicals[0];
                requiredChemicals.RemoveAt(0);

                if (waste.ContainsKey(requiredChemical.name) && waste[requiredChemical.name] >= requiredChemical.amount)
                {
                    waste[requiredChemical.name] -= requiredChemical.amount;
                    continue;
                }
                
                var requiredReaction = reactions.First(reaction => reaction.Output.Name == requiredChemical.name);

                foreach (var inputChemical in requiredReaction.Input)
                {
                    if (inputChemical.Name == Ore)
                        ore += inputChemical.Amount;
                    else
                        requiredChemicals.Add((inputChemical.Name, inputChemical.Amount));
                }

                var outputFromReaction = requiredReaction.Output.Amount;
                if (requiredChemical.amount > outputFromReaction)
                {
                    requiredChemicals.Add((requiredChemical.name, requiredChemical.amount - outputFromReaction));
                }
                else if (requiredChemical.amount < outputFromReaction)
                {
                    waste.TryGetValue(requiredChemical.name, out var wasteAmount);
                    waste[requiredChemical.name] = wasteAmount + outputFromReaction - requiredChemical.amount;
                }
            }
            return ore;
        }
    }
}