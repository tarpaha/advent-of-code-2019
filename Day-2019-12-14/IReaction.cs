using System.Collections.Generic;

namespace Day_2019_12_14
{
    public interface IReaction
    {
        IEnumerable<IChemical> Input { get; }
        IChemical Output { get; }
    }
}