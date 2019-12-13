using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_13
{
    public class Screen
    {
        private readonly Dictionary<Vector2, int> _tiles = new Dictionary<Vector2, int>();
        
        public IEnumerable<(int x, int y, int id)> Tiles => _tiles.Select(r => (r.Key.x, r.Key.y, r.Value));

        public int BlockTilesCount => _tiles.Values.Count(v => v == 2);
        public int Score { get; private set; }

        public Vector2 BallPosition => _tiles.First(r => r.Value == 4).Key;
        public Vector2 PaddlePosition => _tiles.First(r => r.Value == 3).Key;

        public void Draw(int x, int y, int tileId)
        {
            if (x == -1 && y == 0)
            {
                Score = tileId;
                return;
            }
            _tiles[new Vector2(x, y)] = tileId;
        }

        public void Clear()
        {
            Score = 0;
            _tiles.Clear();
        }
    }
}