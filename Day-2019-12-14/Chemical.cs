namespace Day_2019_12_14
{
    public class Chemical : IChemical
    {
        public string Name { get; }
        public int Amount { get; }

        public Chemical(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        private bool Equals(Chemical other)
        {
            return Name == other.Name && Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Chemical) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ Amount;
            }
        }

        public override string ToString()
        {
            return $"{Amount} {Name}";
        }
    }
}