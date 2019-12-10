using System;
using System.Collections.Generic;

namespace Day_2019_12_10
{
    public static class Reader
    {
        public static IEnumerable<IPlanet> Read(string data)
        {
            var planets = new List<IPlanet>();
            var lines = data.Split(new [] { "|", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var ch = line[x];
                    if(ch == '.')
                        continue;
                    planets.Add(new Planet(x, y, ch.ToString()));
                }
            }
            return planets;
        }
    }
}