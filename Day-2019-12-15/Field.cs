using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_15
{
    public class Field
    {
        private readonly Dictionary<Vector2, int> _cells = new Dictionary<Vector2, int>();

        public IEnumerable<(Vector2, int)> Cells => _cells.Select(cell => (cell.Key, cell.Value));
        
        public void SetCellState(Vector2 position, int state)
        {
            _cells[position] = state;
        }

        public bool HaveCell(Vector2 pos)
        {
            return _cells.ContainsKey(pos);
        }

        public bool IsNotWall(Vector2 pos)
        {
            if (!_cells.TryGetValue(pos, out var cellState))
                return false;
            return cellState != 0;
        }
        
        public bool IsFloor(Vector2 pos)
        {
            if (!_cells.TryGetValue(pos, out var cellState))
                return false;
            return cellState == 1;
        }


        public Vector2 OxygenPosition => _cells.First(cell => cell.Value == 2).Key;

        public (Vector2, Vector2) GetBounds()
        {
            return (
                new Vector2(
                    _cells.Select(cell => cell.Key.x).Min(),
                    _cells.Select(cell => cell.Key.y).Min()),
                new Vector2(
                    _cells.Select(cell => cell.Key.x).Max(),
                    _cells.Select(cell => cell.Key.y).Max()));
        }
    }
}
