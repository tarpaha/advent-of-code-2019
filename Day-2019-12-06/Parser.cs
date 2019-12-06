using System.Collections.Generic;

namespace Day_2019_12_06
{
    public static class Parser
    {
        public static IEnumerable<Planet> Parse(IEnumerable<string> data)
        {
            var planets = new Dictionary<string, Planet>();
            foreach (var record in data)
            {
                var pair = record.Split(')');
                AddPlanet(planets, pair[0]);
                AddPlanet(planets, pair[1]);
                AddLink(planets, pair[0], pair[1]);
            }
            return planets.Values;
        }

        private static void AddPlanet(IDictionary<string, Planet> planets, string planetName)
        {
            if(!planets.ContainsKey(planetName))
                planets.Add(planetName, new Planet(planetName));
        }
        
        private static void AddLink(IReadOnlyDictionary<string, Planet> planets, string parent, string child)
        {
            planets[parent].AddChild(planets[child]);
        }
    }
}