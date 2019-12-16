using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_14
{
    public class Reaction : IReaction
    {
        public Reaction(IEnumerable<IChemical> input, IChemical output)
        {
            Input = input;
            Output = output;
        }

        public IEnumerable<IChemical> Input { get; }
        public IChemical Output { get; }

        private bool Equals(Reaction other)
        {
            return Input.SequenceEqual(other.Input) && Equals(Output, other.Output);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Reaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Input != null ? Input.GetHashCode() : 0) * 397) ^ (Output != null ? Output.GetHashCode() : 0);
            }
        }
    }
}