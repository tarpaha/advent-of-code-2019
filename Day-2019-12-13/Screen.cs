using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_13
{
    public class Screen
    {
        private readonly Dictionary<(int x, int y), int> _tiles = new Dictionary<(int, int), int>();
        
        public int BlockTilesCount => _tiles.Values.Count(v => v == 2);
        
        public void Draw(int x, int y, int tileId)
        {
            _tiles[(x, y)] = tileId;
        }

        public void Clear()
        {
            _tiles.Clear();
        }
    }
}