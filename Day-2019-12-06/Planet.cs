using System.Collections.Generic;

namespace Day_2019_12_06
{
    public class Planet
    {
        private readonly string _name;

        private Planet _parent;
        private readonly List<Planet> _children = new List<Planet>();

        public string Name => _name;
        public Planet Parent => _parent;
        public IEnumerable<Planet> Children => _children;

        public Planet(string name)
        {
            _name = name;
        }

        public void AddChild(Planet child)
        {
            _children.Add(child);
            child._parent = this;
        }

        public override string ToString()
        {
            return $"{_name}";
        }
    }
}