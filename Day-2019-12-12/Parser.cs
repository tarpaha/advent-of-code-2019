using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_12
{
    public static class Parser
    {
        public static IEnumerable<Vector3> ParsePoints(string data)
        {
            return data
                .Split(new[] {Environment.NewLine, "|"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(ParsePoint);
        }

        private static Vector3 ParsePoint(string data)
        {
            var coords = data.Replace(" ", "").Split(new[] {",", " ", "<", ">"}, StringSplitOptions.RemoveEmptyEntries);
            return new Vector3(
                ParseCoordinate(coords[0]),
                ParseCoordinate(coords[1]),
                ParseCoordinate(coords[2]));
        }

        private static int ParseCoordinate(string data)
        {
            return int.Parse(data.Split('=')[1]);
        }
    }
}