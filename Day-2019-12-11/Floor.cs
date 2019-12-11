using System.Collections.Generic;
using Utils;

namespace Day_2019_12_11
{
    public class Floor
    {
        private readonly Dictionary<Vector2, long> _panels = new Dictionary<Vector2, long>();

        public int PaintedPanelsCount => _panels.Count;
        
        public long GetColor(Vector2 position)
        {
            return _panels.TryGetValue(position, out var color) ? color : 0;
        }

        public void Paint(Vector2 position, long color)
        {
            _panels[position] = color;
        }
    }
}